# 기본컨트롤(BasicControls)

## BasicControlSample
- Post : https://kaki104.tistory.com/749
- 요약 : 이 글은 WPF의 ComboBox와 ListBox를 MVVM 패턴으로 사용할 때 필요한 핵심 프로퍼티와 바인딩 동작을 단계별 예제로 설명합니다. 대상 독자는 두 컨트롤이나 MVVM 데이터 바인딩에 익숙하지 않은 초급 개발자입니다

## ListViewSample
- https://kaki104.tistory.com/804
- WPF의 ListBox, DataGrid, ListView를 동일한 데이터로 비교해 각 컨트롤의 특징과 적합한 사용 사례를 설명한 글입니다.
- https://kaki104.tistory.com/805
- WPF ListView에 ViewBase 기반의 PlainView를 구현해, WrapPanel을 사용하는 타일·아이콘 형태의 사용자 정의 View를 적용하는 방법을 설명한 글입니다.
- https://kaki104.tistory.com/810
- WPF의 CollectionViewSource와 GroupStyle을 활용해 ListView와 DataGrid 데이터를 MVVM 방식으로 그룹화하고, 접기·펼치기가 가능한 그룹 UI를 구현하는 방법을 설명한 글입니다.

## ListVsObservableCollection
- https://kaki104.tistory.com/813
- WPF에서 List<T>와 ObservableCollection<T>의 차이, 사용 기준, 성능 및 UI 갱신 특성을 비교한 글입니다.
- https://kaki104.tistory.com/815
- List<T>와 ObservableCollection<T>에 항목을 추가·삭제할 때 WPF UI가 갱신되는 방식과 주의점을 실제 예제로 설명한 글입니다.

## ReorderingListBoxSample
- WPF ListBox의 항목을 Drag & Drop으로 이동해 ObservableCollection의 순서를 변경하는 사용자 정의 컨트롤 예제입니다.

## WpfCombo
- https://kaki104.tistory.com/748
- WPF ComboBox의 SelectionChanged 이벤트를 Behavior와 RelayCommand로 연결해 선택된 항목을 ViewModel에서 처리하는 방법을 설명한 글입니다.

# Behavior

## BehaviorSample
- https://kaki104.tistory.com/841
- WPF MVVM에서 Behavior를 사용해 컨트롤을 직접 수정하지 않고 포커스 시 전체 선택, Enter 키 Command 실행 등의 기능을 재사용 가능하게 구현하는 방법을 설명한 글입니다.

## KeywordSample
- https://kaki104.tistory.com/874
- WPF TextBlock에서 AttachedProperty와 Run을 활용해 입력한 검색 키워드의 첫 번째 일치 부분을 빨간색으로 강조하는 방법을 설명한 글입니다.

# Binding

## BindingSample
- https://kaki104.tistory.com/837
- WPF MVVM의 Data Binding 구성 요소와 Binding Mode, UpdateSourceTrigger, Binding Source, DataContext 상속 동작을 예제로 설명한 글입니다.

## ElementNameSample
- https://kaki104.tistory.com/838
- WPF Data Binding에서 ElementName, Source, RelativeSource, AttachedProperty를 활용해 다양한 바인딩 원본과 경로를 지정하는 방법을 설명한 글입니다.

## SourceSample
- https://kaki104.tistory.com/838
- WPF Data Binding에서 ElementName, Source, RelativeSource, AttachedProperty를 활용해 다양한 바인딩 원본과 경로를 지정하는 방법을 설명한 글입니다.

# Command

## CommandSample
- https://kaki104.tistory.com/840
- WPF MVVM에서 RelayCommand와 AsyncRelayCommand를 사용해 사용자 입력, 이벤트, 매개변수 및 실행 가능 상태를 ViewModel에서 처리하는 방법을 설명한 글입니다.

# Converter

## ConverterSample
- https://kaki104.tistory.com/839
- WPF MVVM에서 IValueConverter와 IMultiValueConverter의 개념, 등록·사용 방법, ConverterParameter 활용을 다양한 변환 예제로 설명한 글입니다.

# CrudSample

## CrudSample.Core, CrudSample.Event, CrudSample.Mvvm
- https://kaki104.tistory.com/834
- WPF CRUD 예제를 통해 Event Driven 방식과 MVVM 방식의 데이터 출력, Command, 편집 상태 및 화면 제어 차이를 비교한 글입니다.
- https://kaki104.tistory.com/835
- electionChanged, Behavior, Binding, RelayCommand를 활용해 선택 항목의 상세 표시와 Edit·Delete Command 활성화를 MVVM으로 구현한 글입니다.
- https://kaki104.tistory.com/836
- WPF CRUD의 삭제·추가·수정·저장 기능을 Command와 ObservableObject 기반 MVVM 구조로 완성하는 방법을 설명한 글입니다.

# CustomControl

## CustomControlSample
- https://kaki104.tistory.com/849
- WPF에서 UserControl과 CustomControl의 차이를 비교하고, MVVM·Dependency Injection을 적용한 사용자 동의 팝업을 UserControl로 구현하는 방법을 설명한 글입니다.
- https://kaki104.tistory.com/851
- WPF CustomControl의 ControlTemplate, DependencyProperty, TemplatePart, OnApplyTemplate을 활용해 사용자 동의 컨트롤을 재사용 가능하게 구현하는 방법을 설명한 글입니다.

## DataGridNumberColumn
- https://kaki104.tistory.com/808
- WPF DataGrid에 Behavior를 적용해 정렬이나 행 추가·삭제 후에도 RowHeader의 행 번호가 자동으로 유지되도록 구현하는 방법을 설명한 글입니다.

# DependencyInversion

## DependencyInversionSample, DependencyInversionSample.Common
- https://kaki104.tistory.com/833
- WPF 애플리케이션에서 리소스 처리 기능을 IDynamicResource 인터페이스로 추상화하고, Dependency Injection을 적용해 상위 모듈이 구체 구현에 직접 의존하지 않도록 만드는 방법을 설명한 글입니다.

## ViewModelReuseSample
- MainWindowViewModel을 싱글톤으로 등록하고, 두번째 윈도우에서 뷰모델을 가져다가 사용하는 방법 - 권장하지 않음

# Etcs

## BackgroundServiceSample
- 백그라운드에서 주기적으로 데이터베이스를 조회해 WPF DataGrid 내용을 자동 갱신하는 샘플 코드입니다.

## CheckUrlSample
- https://kaki104.tistory.com/881
- WPF에서 HttpClient의 HEAD 요청과 Task.WhenAll을 사용해 여러 이미지 URL의 유효성을 비동기로 검사하는 방법을 설명한 글입니다.

## CoreWpf
- https://kaki104.tistory.com/714
- .NET Core WPF 프로젝트에서 .csproj의 UseWindowsForms를 활성화해 System.Windows.Forms.Screen으로 현재 화면의 작업 영역(Working Area)을 가져오는 방법을 설명한 글입니다.

## CoreWpfContextMenu
- https://kaki104.tistory.com/716
- WPF에서 Microsoft.Xaml.Behaviors.Wpf의 EventTrigger와 ChangePropertyAction을 사용해 버튼을 왼쪽 클릭했을 때 ContextMenu가 열리도록 구현하는 방법을 설명한 글입니다.

## CoreWpfMemory
- https://kaki104.tistory.com/715
- Visual Studio의 Memory Usage 도구로 WPF 이벤트 핸들러로 인한 메모리 누수를 진단하고 timer.Tick -= UpdateTime과 timer.Stop()으로 해결하는 방법을 설명한 글입니다.

## CreateBuildDate
- https://kaki104.tistory.com/818
- .NET 5 WPF 프로젝트에서 빌드 시점을 코드로 자동 생성해 애플리케이션의 버전 정보처럼 표시하는 방법을 설명한 글입니다.

## EventAsyncSample
- https://kaki104.tistory.com/821
- WPF 이벤트 처리에서 동기 작업으로 멈추는 UI를 async/await 기반 비동기 처리로 전환해 응답성을 유지하는 방법을 설명한 글입니다.

## LargeFileReadSample
- https://kaki104.tistory.com/822
- 대용량 CSV 데이터를 WPF ListBox에 표시할 때 발생하는 UI Freeze와 메모리 문제를 확인하고, yield return을 적용해 데이터를 순차적으로 읽는 방법을 실험한 글입니다.
- https://kaki104.tistory.com/823
- yield return으로 읽은 데이터를 Items에 나누어 추가하고 주기적으로 Task.Delay를 호출해 UI 응답성을 유지하는 방법을 설명한 글입니다.
- https://kaki104.tistory.com/824
- 대용량 데이터를 조금씩 ItemsControl.Items에 추가하는 기능을 재사용 가능한 Behavior로 구현해 MVVM 구조에 적용하는 방법을 설명한 글입니다.

## MetroStudioSample
- https://kaki104.tistory.com/828
- Syncfusion Metro Studio 5에서 원하는 아이콘을 검색·편집하고 PNG, ICO, SVG, XAML 등으로 내보내 WPF 리소스로 사용하는 방법을 설명한 글입니다.

# Localization

## CoreWpfLocalization, WpfLocalization
- https://kaki104.tistory.com/718
- WPF에서 DynamicObject와 .resx 리소스를 활용해 XAML 및 코드에서 다국어 문자열을 사용하고, 실행 중 언어를 즉시 변경하는 방법을 설명한 글입니다.
- 하나는 .Net Core 프로젝트, 다른 하나는 .Net Framework 버전

# PrismLibrary

## PackUriSample, PackUriSample.Module
- https://kaki104.tistory.com/878
- WPF에서 이미지의 Build Action과 출력 디렉터리 복사 설정에 따라 Resource, Embedded Resource, siteoforigin Pack URI로 이미지를 불러오는 방법을 비교한 글입니다.
- https://kaki104.tistory.com/879
- WPF 클래스 라이브러리와 Prism Module에 포함된 이미지를 Pack URI와 어셈블리 리소스로 참조하는 방법과 권장 리소스 설정을 설명한 글입니다.

## PrismStep1
- https://kaki104.tistory.com/855
- WPF Prism 프로젝트의 PrismApplication, DI 컨테이너 등록, CreateShell, ViewModelLocator, Region 구성 방식을 일반 MVVM 프로젝트와 비교해 설명한 글입니다.

## PrismStep2
- https://kaki104.tistory.com/856
- WPF Prism의 DelegateCommand 사용법과 CommandParameter, CanExecute, ObservesProperty, ObservesCanExecute를 활용한 Command 활성화 제어 방법을 설명한 글입니다.

## PrismStep3
- https://kaki104.tistory.com/857
- WPF Prism에서 Register, RegisterSingleton, RegisterInstance를 이용한 DI 타입 등록 방식과 Dialog·Region Navigation용 화면 등록 방법을 설명한 글입니다.

## PrismStep4
- https://kaki104.tistory.com/858
- WPF Prism의 RegionManager와 ContentControl을 활용해 화면 전환·뒤로 가기(Back) 및 INavigationAware 기반 Navigation 생명주기를 처리하는 방법을 설명한 글입니다.

## PrismStep5
- https://kaki104.tistory.com/859
- WPF Prism에서 TabControl에 Region을 적용해 여러 View를 탭으로 탐색하고, IActiveAware로 각 탭의 활성화 상태를 감지하는 방법을 설명한 글입니다.

## PrismStep6
- https://kaki104.tistory.com/860
- WPF Prism에서 StackPanel을 Region으로 사용하기 위한 사용자 정의 RegionAdapter를 만들고, View 추가·삭제 및 닫기 기능까지 구현하는 방법을 설명한 글입니다.

## PrismStep7
- https://kaki104.tistory.com/887
- rism DI 컨테이너와 Behavior를 활용해 ViewModel이 View를 직접 생성하지 않고 ContentControl에 동적으로 View를 주입하는 방법을 설명한 글입니다.
- https://kaki104.tistory.com/876
- Prism의 Region Navigation과 싱글톤 AppContext를 사용해 로그인 정보를 유지하면서 Login 화면에서 Home 화면으로 이동하는 방법을 설명한 글입니다.

## TrayIconSample
- WPF Prism 애플리케이션에서 NotifyIcon을 생성하고, 창 닫기 시 트레이로 숨기며, 트레이 메뉴를 통해 창 복원과 프로그램 종료를 처리하는 예제입니다.

# ResourceDictionary

## ResourceDictionarySample
- https://kaki104.tistory.com/802
- WPF에서 ResourceDictionary에 공통 스타일을 정의하고 MergedDictionaries를 통해 개별 Window 또는 App.xaml에 등록해 재사용하는 기본 방법을 설명한 글입니다.

## ResourceDictionarySample2
- https://kaki104.tistory.com/803
- WPF ResourceDictionary에 SolidColorBrush, BitmapImage, 문자열, 객체 인스턴스, DataTemplate 등을 등록해 여러 화면에서 재사용하는 활용 방법을 설명한 글입니다.

# Selectors
- https://kaki104.tistory.com/847
- WPF DataTemplateSelector를 사용해 데이터의 MessageType에 따라 ListBox 항목에 서로 다른 DataTemplate을 적용하는 방법을 설명한 글입니다.
- https://kaki104.tistory.com/848
- WPF StyleSelector를 사용해 데이터의 MessageType에 따라 ListBoxItem의 정렬과 배경 등 서로 다른 스타일을 적용하는 방법을 설명한 글입니다.

# Sqlite

## SqliteSample
- https://kaki104.tistory.com/796
- WPF에서 sqlite-net-pcl과 SQLiteAsyncConnection을 사용해 SQLite 데이터베이스를 초기화하고 조회·추가·수정·삭제하는 CRUD 기능을 구현하는 방법을 설명한 글입니다.

## SQLiteSample2
- WPF에서 Prism MVVM과 sqlite-net-pcl을 활용해 Person 데이터를 SQLite에 저장하고 조회·추가·수정·삭제하는 CRUD 기능을 구현한 샘플 프로젝트입니다.

# Template

## TemplateSample
- https://kaki104.tistory.com/846
- WPF ContentControl의 구조와 ContentTemplate을 이해하고, DataTemplate과 Path 아이콘을 활용해 콘텐츠 표시 형태를 재사용 가능하게 구성하는 방법을 설명한 글입니다.

# Trigger

## TriggerSample1
- https://kaki104.tistory.com/861
- WPF의 PropertyTrigger, DataTrigger, EventTrigger 종류와 적용 위치를 소개하고, ListBoxItem의 선택 상태에 따라 UI 스타일을 변경하는 기본 방법을 설명한 글입니다.

## TriggerSample2
- https://kaki104.tistory.com/864
- Trigger와 MultiTrigger를 활용해 선택·활성화 상태에 따라 ListBoxItem의 배경, 테두리, 크기, 그림자 효과를 동적으로 변경하는 방법을 설명한 글입니다.

## TriggerSample3
- https://kaki104.tistory.com/866
- DataTrigger와 데이터 바인딩을 사용해 Model·ViewModel의 프로퍼티 값에 따라 WPF 컨트롤의 UI를 동적으로 변경하는 방법을 설명한 글입니다.

## TriggerSample4
- https://kaki104.tistory.com/868
- WPF EventTrigger와 Storyboard 애니메이션을 사용해 마우스 이벤트 발생 시 글자 크기와 텍스트 등의 속성을 변경하는 방법을 설명한 글입니다.

## TriggerSample5
- https://kaki104.tistory.com/870
- Microsoft.Xaml.Behaviors.Wpf의 Trigger와 Action을 사용해 기존 WPF EventTrigger보다 간결하고 재사용 가능한 이벤트 기반 동작을 구현하는 방법을 설명한 글입니다.

## TriggerSample6
- https://kaki104.tistory.com/873
- LaunchUriOrFileAction 등 Microsoft.Xaml.Behaviors.Wpf의 다양한 Action을 활용해 파일·웹페이지 열기와 같은 동작을 XAML에서 처리하는 방법을 설명한 글입니다.