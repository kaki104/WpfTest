using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Controls;

namespace BasicControlSample
{
    public class Next1ViewModel : ObservableObject
    {
        private IList<Person> _persons = new ObservableCollection<Person>
            {
                new Person{ Name = "kaki0104", Sex = true, Age = 11, Address = "Seoul1" },
                new Person{ Name = "kaki0105", Sex = false, Age = 12, Address = "Seoul2" },
                new Person{ Name = "kaki0106", Sex = true, Age = 13, Address = "Seoul3" },
                new Person{ Name = "kaki0107", Sex = false, Age = 14, Address = "Seoul4" },
                new Person{ Name = "kaki0108", Sex = true, Age = 15, Address = "Seoul5" },
                new Person{ Name = "kaki0109", Sex = false, Age = 16, Address = "Seoul6" },
                new Person{ Name = "kaki0110", Sex = true, Age = 17, Address = "Seoul7" },
                new Person{ Name = "kaki0111", Sex = false, Age = 18, Address = "Seoul8" },
                new Person{ Name = "kaki0112", Sex = true, Age = 19, Address = "Seoul9" },
                new Person{ Name = "kaki0113", Sex = false, Age = 20, Address = "Seoul10" },
                new Person{ Name = "kaki0114", Sex = true, Age = 21, Address = "Seoul11" },
                new Person{ Name = "kaki0115", Sex = false, Age = 22, Address = "Seoul12" },
                new Person{ Name = "kaki0116", Sex = true, Age = 23, Address = "Seoul13" },
                new Person{ Name = "kaki0117", Sex = false, Age = 24, Address = "Seoul14" },
                new Person{ Name = "kaki0118", Sex = true, Age = 25, Address = "Seoul15" },
                new Person{ Name = "kaki0119", Sex = false, Age = 26, Address = "Seoul16" },
                new Person{ Name = "kaki0120", Sex = true, Age = 27, Address = "Seoul17" },
                new Person{ Name = "kaki0121", Sex = false, Age = 28, Address = "Seoul18" },
                new Person{ Name = "kaki0122", Sex = true, Age = 29, Address = "Seoul19" },
                new Person{ Name = "kaki0123", Sex = false, Age = 30, Address = "Seoul20" },
                new Person{ Name = "kaki0124", Sex = true, Age = 31, Address = "Seoul21" },
                new Person{ Name = "kaki0125", Sex = false, Age = 32, Address = "Seoul22" },
                new Person{ Name = "kaki0126", Sex = true, Age = 33, Address = "Seoul23" },
                new Person{ Name = "kaki0127", Sex = false, Age = 34, Address = "Seoul24" },
                new Person{ Name = "kaki0128", Sex = true, Age = 35, Address = "Seoul25" },
                new Person{ Name = "kaki0129", Sex = false, Age = 36, Address = "Seoul26" },
                new Person{ Name = "kaki0130", Sex = true, Age = 37, Address = "Seoul27" },
                new Person{ Name = "kaki0131", Sex = false, Age = 38, Address = "Seoul28" },
                new Person{ Name = "kaki0132", Sex = true, Age = 39, Address = "Seoul29" },
                new Person{ Name = "kaki0133", Sex = false, Age = 40, Address = "Seoul30" },
                new Person{ Name = "kaki0134", Sex = true, Age = 41, Address = "Seoul31" },
                new Person{ Name = "kaki0135", Sex = false, Age = 42, Address = "Seoul32" },
                new Person{ Name = "kaki0136", Sex = true, Age = 43, Address = "Seoul33" },
                new Person{ Name = "kaki0137", Sex = false, Age = 44, Address = "Seoul34" },
                new Person{ Name = "kaki0138", Sex = true, Age = 45, Address = "Seoul35" },
                new Person{ Name = "kaki0139", Sex = false, Age = 46, Address = "Seoul36" },
                new Person{ Name = "kaki0140", Sex = true, Age = 47, Address = "Seoul37" },
                new Person{ Name = "kaki0141", Sex = false, Age = 48, Address = "Seoul38" },
                new Person{ Name = "kaki0142", Sex = true, Age = 49, Address = "Seoul39" },
                new Person{ Name = "kaki0143", Sex = false, Age = 50, Address = "Seoul40" },
                new Person{ Name = "kaki0104", Sex = true, Age = 111, Address = "Seoul11" },
                new Person{ Name = "kaki0105", Sex = false, Age = 112, Address = "Seoul12" },
                new Person{ Name = "kaki0106", Sex = true, Age = 113, Address = "Seoul13" },
                new Person{ Name = "kaki0107", Sex = false, Age = 114, Address = "Seoul14" },
                new Person{ Name = "kaki0108", Sex = true, Age = 115, Address = "Seoul15" },
                new Person{ Name = "kaki0109", Sex = false, Age = 116, Address = "Seoul16" },
                new Person{ Name = "kaki0110", Sex = true, Age = 117, Address = "Seoul17" },
                new Person{ Name = "kaki0111", Sex = false, Age = 118, Address = "Seoul18" },
                new Person{ Name = "kaki0112", Sex = true, Age = 119, Address = "Seoul19" },
                new Person{ Name = "kaki0113", Sex = false, Age = 120, Address = "Seoul110" },
                new Person{ Name = "kaki0114", Sex = true, Age = 121, Address = "Seoul111" },
                new Person{ Name = "kaki0115", Sex = false, Age = 122, Address = "Seoul112" },
                new Person{ Name = "kaki0116", Sex = true, Age = 123, Address = "Seoul113" },
                new Person{ Name = "kaki0117", Sex = false, Age = 124, Address = "Seoul114" },
                new Person{ Name = "kaki0118", Sex = true, Age = 125, Address = "Seoul115" },
                new Person{ Name = "kaki0119", Sex = false, Age = 126, Address = "Seoul116" },
                new Person{ Name = "kaki0120", Sex = true, Age = 127, Address = "Seoul117" },
                new Person{ Name = "kaki0121", Sex = false, Age = 128, Address = "Seoul118" },
                new Person{ Name = "kaki0122", Sex = true, Age = 129, Address = "Seoul119" },
                new Person{ Name = "kaki0123", Sex = false, Age = 130, Address = "Seoul120" },
                new Person{ Name = "kaki0124", Sex = true, Age = 131, Address = "Seoul121" },
                new Person{ Name = "kaki0125", Sex = false, Age = 132, Address = "Seoul122" },
                new Person{ Name = "kaki0126", Sex = true, Age = 133, Address = "Seoul123" },
                new Person{ Name = "kaki0127", Sex = false, Age = 134, Address = "Seoul124" },
                new Person{ Name = "kaki0128", Sex = true, Age = 135, Address = "Seoul125" },
                new Person{ Name = "kaki0129", Sex = false, Age = 136, Address = "Seoul126" },
                new Person{ Name = "kaki0130", Sex = true, Age = 137, Address = "Seoul127" },
                new Person{ Name = "kaki0131", Sex = false, Age = 138, Address = "Seoul128" },
                new Person{ Name = "kaki0132", Sex = true, Age = 139, Address = "Seoul129" },
                new Person{ Name = "kaki0133", Sex = false, Age = 140, Address = "Seoul130" },
                new Person{ Name = "kaki0134", Sex = true, Age = 141, Address = "Seoul131" },
                new Person{ Name = "kaki0135", Sex = false, Age = 142, Address = "Seoul132" },
                new Person{ Name = "kaki0136", Sex = true, Age = 143, Address = "Seoul133" },
                new Person{ Name = "kaki0137", Sex = false, Age = 144, Address = "Seoul134" },
                new Person{ Name = "kaki0138", Sex = true, Age = 145, Address = "Seoul135" },
                new Person{ Name = "kaki0139", Sex = false, Age = 146, Address = "Seoul136" },
                new Person{ Name = "kaki0140", Sex = true, Age = 147, Address = "Seoul137" },
                new Person{ Name = "kaki0141", Sex = false, Age = 148, Address = "Seoul138" },
                new Person{ Name = "kaki0142", Sex = true, Age = 149, Address = "Seoul139" },
                new Person{ Name = "kaki0143", Sex = false, Age = 150, Address = "Seoul140" },
            };
        public IList<Person> Persons { get { return _persons; } }

        public IList<CodeModel> Sexs { get; set; } = new List<CodeModel>
        {
            new CodeModel { Name = "Male", Value = true, Code = "male" },
            new CodeModel { Name = "Female", Value = false, Code = "female"}
        };

        public IList<CodeModel> Addressies { get; set; } = new List<CodeModel>
        {
            new CodeModel { Name = "서울 강남구", Code = "06090" },
            new CodeModel { Name = "서울 강동구", Code = "05397" },
            new CodeModel { Name = "서울 강북구", Code = "01071" },
            new CodeModel { Name = "서울 강서구", Code = "07658" },
            new CodeModel { Name = "서울 관악구", Code = "08832" },
            new CodeModel { Name = "서울 광진구", Code = "05026" },
            new CodeModel { Name = "서울 구로구", Code = "08284" },
            new CodeModel { Name = "서울 금천구", Code = "08611" },
            new CodeModel { Name = "서울 노원구", Code = "01689" },
            new CodeModel { Name = "서울 도봉구", Code = "01331" },
            new CodeModel { Name = "서울 동대문구", Code = "02565" },
            new CodeModel { Name = "서울 동작구", Code = "06928" },
            new CodeModel { Name = "서울 마포구", Code = "03937" },
            new CodeModel { Name = "서울 서대문구", Code = "03718" },
            new CodeModel { Name = "서울 서초구", Code = "06750" },
            new CodeModel { Name = "서울 성동구", Code = "04750" },
            new CodeModel { Name = "서울 성북구", Code = "02848" },
            new CodeModel { Name = "서울 송파구", Code = "05552" },
            new CodeModel { Name = "서울 양천구", Code = "08095" },
            new CodeModel { Name = "서울 영등포구", Code = "07260" },
            new CodeModel { Name = "서울 용산구", Code = "04390" },
            new CodeModel { Name = "서울 은평구", Code = "03384" },
            new CodeModel { Name = "서울 종로구", Code = "03153" },
            new CodeModel { Name = "서울 중구", Code = "04558" },
            new CodeModel { Name = "서울 중량구", Code = "02043" },
        };

        private Person _selectedListItem;
        public Person SelectedListItem
        {
            get { return _selectedListItem; }
            set { SetProperty(ref _selectedListItem, value); }
        }

        private Person _selectedComboItem;
        public Person SelectedComboItem
        {
            get { return _selectedComboItem; }
            set { SetProperty(ref _selectedComboItem, value); }
        }

        /// <summary>
        /// 리스트 셀렉션 체인지 이벤트 커맨드
        /// </summary>
        public IRelayCommand ListSelectionChangedCommand { get; set; }
        /// <summary>
        /// 리스트 아이템 삭제 커맨드
        /// </summary>
        public IRelayCommand DeleteListItemCommand { get; set; }
        /// <summary>
        /// 콤보 셀렉션 체인지 이벤트 커맨드
        /// </summary>
        public IRelayCommand ComboSelectionChangedCommand { get; set; }
        /// <summary>
        /// 콤보 아이템 삭제 커맨드
        /// </summary>
        public IRelayCommand DeleteComboItemCommand { get; set; }

        public Next1ViewModel()
        {
            Init();
        }

        private void Init()
        {
            ListSelectionChangedCommand = new RelayCommand<object>(OnListSelectionChanged);
            DeleteListItemCommand = new RelayCommand(OnDeleteListItem,
                                        () => SelectedListItem != null && SelectedListItem.Age % 2 == 0);
            ComboSelectionChangedCommand = new RelayCommand<object>(OnComboSelectionChanged);
            DeleteComboItemCommand = new RelayCommand(OnDeleteComboItem,
                                        () => SelectedComboItem != null && SelectedComboItem.Age % 2 == 1);
        }

        private void OnDeleteComboItem()
        {
            Persons.Remove(SelectedComboItem);
        }

        private void OnDeleteListItem()
        {
            Persons.Remove(SelectedListItem);
        }

        private void OnComboSelectionChanged(object arg)
        {
            var eventArgs = arg as SelectionChangedEventArgs;
            if (eventArgs == null)
            {
                return;
            }
            Debug.WriteLine($"Combo AddedItems.Count : {eventArgs.AddedItems.Count}");
            Debug.WriteLine($"Combo RemovedItems.Count : {eventArgs.RemovedItems.Count}");
            DeleteComboItemCommand.NotifyCanExecuteChanged();
        }

        private void OnListSelectionChanged(object arg)
        {
            var eventArgs = arg as SelectionChangedEventArgs;
            if(eventArgs == null)
            {
                return;
            }
            Debug.WriteLine($"List AddedItems.Count : {eventArgs.AddedItems.Count}");
            Debug.WriteLine($"List RemovedItems.Count : {eventArgs.RemovedItems.Count}");
            DeleteListItemCommand.NotifyCanExecuteChanged();
        }
    }
}
