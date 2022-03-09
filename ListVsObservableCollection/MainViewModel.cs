using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ListVsObservableCollection
{
    
    public class MainViewModel : ObservableObject
    {
        private IList<Person> _persons = new List<Person>
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

        /// <summary>
        /// 왼쪽 버튼 커맨드
        /// </summary>
        public ICommand LeftButtonCommand { get; set; }
        /// <summary>
        /// 왼쪽 삭제 커맨드
        /// </summary>
        public IRelayCommand LeftRemoveCommand { get; set; }
        /// <summary>
        /// 오른쪽 버튼 커맨드
        /// </summary>
        public ICommand RightButtonCommand { get; set; }
        /// <summary>
        /// 오른쪽 삭제 커맨드
        /// </summary>
        public IRelayCommand RightRemoveCommand { get; set; }

        private Person _selectedLeftPerson;
        /// <summary>
        /// 왼쪽에서 선택된 사람
        /// </summary>
        public Person SelectedLeftPerson
        {
            get { return _selectedLeftPerson; }
            set { SetProperty(ref _selectedLeftPerson, value); }
        }

        private Person _selectedRightPerson;
        /// <summary>
        /// 오른쪽에서 선택된 사람
        /// </summary>
        public Person SelectedRightPerson
        {
            get { return _selectedRightPerson; }
            set { SetProperty(ref _selectedRightPerson, value); }
        }

        private IList<Person> _leftPeople;
        /// <summary>
        /// 왼쪽 사람들
        /// </summary>
        public IList<Person> LeftPeople
        {
            get { return _leftPeople; }
            set { SetProperty(ref _leftPeople, value); }
        }
        /// <summary>
        /// 왼쪽 타입 네임
        /// </summary>
        public string LeftPeopleTypeName
        {
            get { return LeftPeople.GetType().Name; }
        }

        private IList<Person> _rightPeople = new ObservableCollection<Person>();
        /// <summary>
        /// 오른쪽 사람들
        /// </summary>
        public IList<Person> RightPeople
        {
            get { return _rightPeople; }
            set { SetProperty(ref _rightPeople, value); }
        }

        /// <summary>
        /// 오른쪽 타입 네임
        /// </summary>
        public string RightPeopleTypeName
        {
            get { return RightPeople.GetType().Name; }
        }

        /// <summary>
        /// 생성자
        /// </summary>
        public MainViewModel()
        {
            Init();
        }

        /// <summary>
        /// 초기화
        /// </summary>
        private void Init()
        {
            LeftPeople = _persons;
            ((List<Person>)_persons).ForEach(p => RightPeople.Add(p));

            LeftButtonCommand = new RelayCommand<string>(OnLeftButton);
            LeftRemoveCommand = new RelayCommand(() => OnLeftButton("Remove"), () => SelectedLeftPerson != null);
            RightButtonCommand = new RelayCommand<string>(OnRightButton);
            RightRemoveCommand = new RelayCommand(() => OnRightButton("Remove"), () => SelectedRightPerson != null);
            PropertyChanged += MainViewModel_PropertyChanged;
        }

        private void MainViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case nameof(SelectedLeftPerson):
                    LeftRemoveCommand.NotifyCanExecuteChanged();
                    break;
                case nameof(SelectedRightPerson):
                    RightRemoveCommand.NotifyCanExecuteChanged();
                    break;
            }
        }

        private void OnRightButton(string parameter)
        {
            switch (parameter)
            {
                case "Refresh":
                    {
                        RightPeople.Clear();
                        foreach (var p in _persons)
                        {
                            RightPeople.Add(p);
                        }
                    }
                    break;
                case "Add":
                    RightPeople.Insert(0, CreateRandomPerson());
                    break;
                case "Remove":
                    {
                        if(SelectedRightPerson == null)
                        {
                            return;
                        }
                        RightPeople.Remove(SelectedRightPerson);
                    }
                    break;
            }
        }

        private void OnLeftButton(string parameter)
        {
            switch (parameter)
            {
                case "Refresh":
                    LeftPeople = _persons;
                    break;
                case "Add":
                    {
                        var list = LeftPeople.ToList();
                        list.Insert(0, CreateRandomPerson());
                        LeftPeople = list;
                    }
                    break;
                case "Remove":
                    {
                        if(SelectedLeftPerson == null)
                        {
                            return;
                        }
                        var list = LeftPeople.ToList();
                        list.Remove(SelectedLeftPerson);
                        LeftPeople = list;
                    }
                    break;
            }
        }

        private Person CreateRandomPerson()
        {
            var random = new Random();
            var randomInt = random.Next(200, 1000);
            return new Person 
            { 
                Name = $"kaki0{randomInt}",
                Sex = randomInt % 2 == 0,
                Age = randomInt,
                Address = $"Seoul{randomInt}"
            };
        }
    }
}
