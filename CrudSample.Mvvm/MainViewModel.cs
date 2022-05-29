using CrudSample.Core.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSample.Mvvm
{
    public class MainViewModel : ObservableObject
    {
        //public IList<Member> Members { get; set; }
        private IList<Member> _member;
        public IList<Member> Members
        {
            get { return _member; }
            set { SetProperty(ref _member, value); }
        }

        public IRelayCommand NewCommand { get; set; }

        public IRelayCommand CancelCommand { get; set; }

        private bool _isEditing;
        public bool IsEditing
        {
            get { return _isEditing; }
            set { SetProperty(ref _isEditing, value); }
        }

        public MainViewModel()
        {
            Init();
        }

        private void Init()
        {
            Members = new ObservableCollection<Member> 
            {
                new Member
                {
                    Id = 1,
                    Name = "kaki104",
                    Phone = "010-1111-2222",
                    RegDate = DateTime.Now,
                    IsUse = true,
                }
            };

            NewCommand = new RelayCommand(() => IsEditing = true);
            CancelCommand = new RelayCommand(() => IsEditing = false);
        }
    }
}
