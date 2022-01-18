using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Models;

namespace WpfApp1.ViewModel
{
    public class SqliteViewModel : ViewModelBase
    {
        private string _dbPath;
        private SQLiteAsyncConnection _dbConn;

        private IList<Person> _people;
        /// <summary>
        /// 피플
        /// </summary>
        public IList<Person> People
        {
            get { return _people; }
            set { Set(ref _people ,value); }
        }

        public SqliteViewModel()
        {
            if(IsInDesignMode)
            {
            }
            else
            {
            }

            People = new List<Person>
            {
                new Person{Id=1, Name="지수", Age=23, Address="주소1", HasMarried=false},
                new Person{Id=2, Name="제니", Age=23, Address="주소2", HasMarried=true},
                new Person{Id=3, Name="로제", Age=21, Address="주소3", HasMarried=false},
                new Person{Id=4, Name="리사", Age=22, Address="주소4", HasMarried=true},
            };

            Init();
        }

        private async void Init()
        {
            if (IsInDesignMode) return;

            GetCommand = new RelayCommand(OnGetCommand);
            AddCommand = new RelayCommand(OnAddCommand);
            SaveCommand = new RelayCommand(OnSaveCommand);
            DeleteCommand = new RelayCommand(OnDeleteCommand);

            _dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Storage.sqlite");
            _dbConn = new SQLiteAsyncConnection(_dbPath);
            var result = await _dbConn.CreateTableAsync<Person>();
        }

        private Person _currentPerson;
        /// <summary>
        /// 선택한 사람
        /// </summary>
        public Person CurrentPerson
        {
            get { return _currentPerson; }
            set { Set(ref _currentPerson ,value); }
        }

        private async void OnDeleteCommand()
        {
            if (CurrentPerson == null) return;
            var result = MessageBox.Show(
                "선택한 아이템을 삭제하시겠습니까?", "삭제확인", 
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.No) return;

            await _dbConn.DeleteAsync(CurrentPerson);
            CurrentPerson = null;
            GetPerson();
        }

        private async void GetPerson()
        {
            var people = await _dbConn.Table<Person>().ToListAsync();
            People = people;
        }

        private async void OnSaveCommand()
        {
            if (CurrentPerson == null) return;

            var exist = await _dbConn.Table<Person>()
                .Where(p => p.Id == CurrentPerson.Id)
                .FirstOrDefaultAsync();
            if(exist == null)
            {
                await _dbConn.InsertAsync(CurrentPerson);
            }
            else
            {
                await _dbConn.UpdateAsync(CurrentPerson);
            }
            CurrentPerson = null;
            GetPerson();
        }

        private void OnAddCommand()
        {
            CurrentPerson = new Person();
        }

        private void OnGetCommand()
        {
            GetPerson();
        }

        public ICommand GetCommand { get; set; }

        public ICommand AddCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

    }
}
