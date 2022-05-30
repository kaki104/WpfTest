using CrudSample.Core.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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

        public IRelayCommand SelectionChangedCommand { get; set; }

        public IRelayCommand EditCommand { get; set; }

        public IRelayCommand DeleteCommand { get; set; }

        private bool _isEditing;
        public bool IsEditing
        {
            get { return _isEditing; }
            set { SetProperty(ref _isEditing, value); }
        }

        private Member _editMember;
        public Member EditMember
        {
            get { return _editMember; }
            set { SetProperty(ref _editMember, value); }
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

            NewCommand = new RelayCommand(OnNew);
            CancelCommand = new RelayCommand(() => IsEditing = false);
            SelectionChangedCommand = new RelayCommand<object>(OnSelectionChanged);

            //EditCommand = new RelayCommand(() => IsEditing = true, () => EditMember != null);
        }

        private void OnNew()
        {
            IsEditing = true;
            EditMember = new Member
            {
                Id = Members.Max(m => m.Id) + 1,
                RegDate = DateTime.Now
            };
        }

        private void OnSelectionChanged(object para)
        {
            var args = para as SelectionChangedEventArgs;
            if(args == null)
            {
                return;
            }
            
            if(args.AddedItems.Count == 0)
            {
                EditMember = null;
                return;
            }
            else
            {
                var member = args.AddedItems[0] as Member;
                EditMember = (Member)member.Clone();
            }

        }
    }
}
