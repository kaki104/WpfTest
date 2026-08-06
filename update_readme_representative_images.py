#!/usr/bin/env python3
"""README.md의 Tistory 링크마다 og:image 대표 이미지를 추가/갱신합니다.

사용 예:
    python update_readme_representative_images.py README.md
    python update_readme_representative_images.py README.md --output README.updated.md
    python update_readme_representative_images.py README.md --dry-run
"""

from __future__ import annotations

import argparse
import html
import re
import shutil
import sys
import time
from dataclasses import dataclass
from html.parser import HTMLParser
from pathlib import Path
from typing import Iterable
from urllib.error import HTTPError, URLError
from urllib.request import Request, urlopen

TISTORY_URL_RE = re.compile(r"https://kaki104\.tistory\.com/(\d+)")
IMAGE_LINE_RE = re.compile(r"^\s*-\s*대표이미지\s*:\s*!\[대표이미지\]\([^)]*\)\s*$")
USER_AGENT = (
    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) "
    "AppleWebKit/537.36 (KHTML, like Gecko) "
    "Chrome/131.0 Safari/537.36"
)


class OpenGraphParser(HTMLParser):
    def __init__(self) -> None:
        super().__init__(convert_charrefs=True)
        self.og_image: str | None = None

    def handle_starttag(self, tag: str, attrs: list[tuple[str, str | None]]) -> None:
        if tag.lower() != "meta" or self.og_image:
            return

        values = {key.lower(): value for key, value in attrs if value is not None}
        property_name = (values.get("property") or values.get("name") or "").lower()
        if property_name in {"og:image", "og:image:url", "twitter:image"}:
            content = values.get("content")
            if content:
                self.og_image = html.unescape(content.strip())


@dataclass(frozen=True)
class FetchResult:
    post_url: str
    image_url: str | None
    error: str | None = None


def fetch_representative_image(post_url: str, timeout: float, retries: int) -> FetchResult:
    last_error: str | None = None

    for attempt in range(1, retries + 1):
        try:
            request = Request(
                post_url,
                headers={
                    "User-Agent": USER_AGENT,
                    "Accept": "text/html,application/xhtml+xml",
                    "Accept-Language": "ko-KR,ko;q=0.9,en;q=0.8",
                },
            )
            with urlopen(request, timeout=timeout) as response:
                charset = response.headers.get_content_charset() or "utf-8"
                body = response.read().decode(charset, errors="replace")

            parser = OpenGraphParser()
            parser.feed(body)
            if parser.og_image:
                return FetchResult(post_url, parser.og_image)

            return FetchResult(post_url, None, "og:image 메타데이터를 찾지 못했습니다.")
        except (HTTPError, URLError, TimeoutError, OSError) as exc:
            last_error = f"{type(exc).__name__}: {exc}"
            if attempt < retries:
                time.sleep(min(2 ** (attempt - 1), 4))

    return FetchResult(post_url, None, last_error or "알 수 없는 오류")


def collect_post_urls(lines: Iterable[str]) -> list[str]:
    urls: list[str] = []
    seen: set[str] = set()
    for line in lines:
        for match in TISTORY_URL_RE.finditer(line):
            url = match.group(0)
            if url not in seen:
                seen.add(url)
                urls.append(url)
    return urls


def find_description_end(lines: list[str], url_index: int) -> int:
    """URL 다음의 설명 bullet 위치를 반환합니다.

    README 형식은 URL bullet 다음 줄에 설명 bullet이 오는 구조를 우선합니다.
    설명이 없으면 URL 줄 자체를 반환합니다.
    """
    index = url_index + 1
    while index < len(lines) and not lines[index].strip():
        index += 1

    if index >= len(lines):
        return url_index

    stripped = lines[index].lstrip()
    if stripped.startswith("#") or TISTORY_URL_RE.search(lines[index]):
        return url_index
    if IMAGE_LINE_RE.match(lines[index]):
        return url_index

    # 일반 설명 bullet 또는 '- 요약 :' 줄을 설명으로 간주합니다.
    if stripped.startswith("-"):
        return index

    return url_index


def update_markdown(lines: list[str], images: dict[str, str]) -> tuple[list[str], int]:
    output: list[str] = []
    changed = 0
    index = 0

    while index < len(lines):
        line = lines[index]
        output.append(line)

        match = TISTORY_URL_RE.search(line)
        if not match:
            index += 1
            continue

        post_url = match.group(0)
        image_url = images.get(post_url)
        if not image_url:
            index += 1
            continue

        description_end = find_description_end(lines, index)

        # URL과 설명 사이의 줄까지 그대로 복사합니다.
        while index < description_end:
            index += 1
            output.append(lines[index])

        representative_line = f"- 대표이미지 : ![대표이미지]({image_url})\n"
        next_index = index + 1

        # 기존 대표이미지 줄이 있으면 교체합니다. 빈 줄 하나는 유지합니다.
        scan_index = next_index
        blank_lines: list[str] = []
        while scan_index < len(lines) and not lines[scan_index].strip():
            blank_lines.append(lines[scan_index])
            scan_index += 1

        if scan_index < len(lines) and IMAGE_LINE_RE.match(lines[scan_index]):
            output.extend(blank_lines)
            if lines[scan_index] != representative_line:
                output.append(representative_line)
                changed += 1
            else:
                output.append(lines[scan_index])
            index = scan_index + 1
            continue

        output.append(representative_line)
        changed += 1
        index += 1

    return output, changed


def parse_args() -> argparse.Namespace:
    parser = argparse.ArgumentParser(
        description="README.md의 Tistory 링크 아래에 og:image 대표이미지를 추가합니다."
    )
    parser.add_argument("readme", type=Path, help="수정할 README.md 경로")
    parser.add_argument("--output", type=Path, help="출력 파일 경로. 생략하면 원본을 수정합니다.")
    parser.add_argument("--timeout", type=float, default=20.0, help="요청 제한 시간(초)")
    parser.add_argument("--retries", type=int, default=3, help="포스트별 최대 요청 횟수")
    parser.add_argument("--delay", type=float, default=0.25, help="포스트 요청 사이 대기 시간(초)")
    parser.add_argument("--dry-run", action="store_true", help="파일을 쓰지 않고 결과만 확인합니다.")
    parser.add_argument("--no-backup", action="store_true", help="원본 수정 시 .bak 파일을 만들지 않습니다.")
    return parser.parse_args()


def main() -> int:
    args = parse_args()
    source: Path = args.readme

    if not source.is_file():
        print(f"오류: 파일을 찾을 수 없습니다: {source}", file=sys.stderr)
        return 2

    original_text = source.read_text(encoding="utf-8")
    lines = original_text.splitlines(keepends=True)
    post_urls = collect_post_urls(lines)

    if not post_urls:
        print("Tistory 링크를 찾지 못했습니다.")
        return 0

    print(f"대상 포스트: {len(post_urls)}개")
    images: dict[str, str] = {}
    failures: list[FetchResult] = []

    for position, post_url in enumerate(post_urls, start=1):
        result = fetch_representative_image(post_url, args.timeout, max(1, args.retries))
        if result.image_url:
            images[post_url] = result.image_url
            print(f"[{position:02d}/{len(post_urls):02d}] 확인: {post_url}")
        else:
            failures.append(result)
            print(f"[{position:02d}/{len(post_urls):02d}] 실패: {post_url} - {result.error}")
        if position < len(post_urls) and args.delay > 0:
            time.sleep(args.delay)

    updated_lines, changed = update_markdown(lines, images)
    updated_text = "".join(updated_lines)

    print(f"대표이미지 확인 성공: {len(images)}개")
    print(f"README 변경 항목: {changed}개")

    if failures:
        print("\n확인하지 못한 포스트:")
        for failure in failures:
            print(f"- {failure.post_url}: {failure.error}")

    if args.dry_run:
        return 1 if failures else 0

    destination: Path = args.output or source
    if destination == source and not args.no_backup:
        backup = source.with_suffix(source.suffix + ".bak")
        shutil.copy2(source, backup)
        print(f"백업 생성: {backup}")

    destination.write_text(updated_text, encoding="utf-8", newline="")
    print(f"저장 완료: {destination}")
    return 1 if failures else 0


if __name__ == "__main__":
    raise SystemExit(main())
