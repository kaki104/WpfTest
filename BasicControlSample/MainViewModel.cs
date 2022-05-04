using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BasicControlSample
{
    public class MainViewModel : ObservableObject
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

        private Person _selectedListItem2;
        public Person SelectedListItem2
        {
            get { return _selectedListItem2; }
            set { SetProperty(ref _selectedListItem2, value); }
        }

        public IRelayCommand DeleteListItemCommand { get; set; }

        private Person _selectedComboItem2;
        public Person SelectedComboItem2
        {
            get { return _selectedComboItem2; }
            set { SetProperty(ref _selectedComboItem2, value); }
        }

        public IRelayCommand DeleteComboItemCommand { get; set; }

        public IRelayCommand ShowNextWindowCommand { get; set; }

        public MainViewModel()
        {
            Init();
        }

        private void Init()
        {
            SelectedListItem = Persons.FirstOrDefault();
            SelectedComboItem = Persons.FirstOrDefault();

            //커맨드 생성
            DeleteListItemCommand = new RelayCommand(OnDeleteListItem,
                () => SelectedListItem2 != null && SelectedListItem2.Age % 2 == 0);
            DeleteComboItemCommand = new RelayCommand(OnDeleteComboItem,
                () => SelectedComboItem2 != null && SelectedComboItem2.Age % 2 == 1);
            ShowNextWindowCommand = new RelayCommand(OnShowNextWindow);

            //뷰모델 내부에서 프로퍼티 체인지 이벤트 핸들러 추가
            PropertyChanged += MainViewModel_PropertyChanged;
        }

        private void OnShowNextWindow()
        {
            //Sample코드이기 때문에 뷰를 직접 생성해서 Show를 하는 것입니다.
            //실제 애플리케이션일 때 뷰모델에서 뷰를 생성하는 것은 하지 않습니다.
            var nextWindow = new Next1Window();
            nextWindow.Show();
        }

        private void MainViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //nameof를 이용하면, 프로퍼티의 이름이 변경되었을 때 에러가
            //발생하기 때문에, 에러가 발생하는 것을 방지 할 수 있음
            switch (e.PropertyName)
            {
                case nameof(SelectedListItem2):
                    //커맨드의 사용가능 여부 확인
                    DeleteListItemCommand.NotifyCanExecuteChanged();
                    break;
                case nameof(SelectedComboItem2):
                    DeleteComboItemCommand.NotifyCanExecuteChanged();
                    break;
            }
        }

        private void OnDeleteComboItem()
        {
            Persons.Remove(SelectedComboItem2);
        }

        private void OnDeleteListItem()
        {
            Persons.Remove(SelectedListItem2);
        }
    }
}
