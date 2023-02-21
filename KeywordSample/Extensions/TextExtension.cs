using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace KeywordSample.Extensions
{
    /// <summary>
    /// Text Extension
    /// </summary>
    public static class TextExtension
    {
        private static readonly SolidColorBrush _redColorBrush = new(Colors.Red);

        public static string GetKeyword(DependencyObject obj)
        {
            return (string)obj.GetValue(KeywordProperty);
        }

        public static void SetKeyword(DependencyObject obj, string value)
        {
            obj.SetValue(KeywordProperty, value);
        }

        /// <summary>
        /// Keyword
        /// </summary>
        public static readonly DependencyProperty KeywordProperty =
            DependencyProperty.RegisterAttached("Keyword", typeof(string), typeof(TextExtension), new PropertyMetadata(null, OnKeywordChanged));

        private static void OnKeywordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //TextBlock이 아니거나 문자열이 아니거나 빈문자열인 경우 나감
            if (d is not TextBlock textBlock || e.NewValue is not string keyword)
            {
                return;
            }
            string backupText = textBlock.Text;
            //첫번째 키워드 위치 저장 (1개의 키워드 위치만 찾아서 표시합니다)
            //이 내용 참고하면 전체 텍스트에서 검색해서 출력하는 것도 가능합니다.
            int index = backupText.IndexOf(keyword, StringComparison.OrdinalIgnoreCase);
            string preText = backupText[..index];
            string keywordText = backupText.Substring(index, keyword.Length);
            string postText = backupText[(index + keyword.Length)..];
            textBlock.Inlines.Clear();
            textBlock.Inlines.Add(preText);
            //빨간색 글씨 표시
            textBlock.Inlines.Add(new Run(keywordText)
                {
                    Foreground = _redColorBrush
                });
            textBlock.Inlines.Add(postText);
        }
    }
}
