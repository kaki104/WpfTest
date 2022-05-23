using CrudSample.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CrudSample.Event
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IList<Member> _members = new ObservableCollection<Member>();
        private bool _isEditing;

        public MainWindow()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            MemberGrid.ItemsSource = _members;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            _isEditing = true;
            ClearDetail();
            ChangeButtonVisibility();
        }

        private void ClearDetail()
        {
            Id.Text = "";
            Name.Text = "";
            Phone.Text = "";
            RegDate.Text = "";
            IsUse.IsChecked = false;
        }

        private void ChangeButtonVisibility()
        {
            if(_isEditing)
            {
                NewButton.Visibility = Visibility.Collapsed;
                EditButton.Visibility = Visibility.Collapsed;
                DeleteButton.Visibility = Visibility.Collapsed;
                SaveButton.Visibility = Visibility.Visible;
                CancelButton.Visibility = Visibility.Visible;
            }
            else
            {
                NewButton.Visibility = Visibility.Visible;
                EditButton.Visibility = Visibility.Visible;
                DeleteButton.Visibility = Visibility.Visible;
                SaveButton.Visibility = Visibility.Collapsed;
                CancelButton.Visibility = Visibility.Collapsed;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _isEditing = false;
            if(string.IsNullOrEmpty(Id.Text) == false)
            {
                //edit
                UpdateMember();
            }
            else
            {
                var id = _members.Any() ? _members.Select(m => m.Id).Max() + 1 : 1;
                //add
                var newMember = new Member
                {
                    Id = id,
                    Name = Name.Text,
                    Phone = Phone.Text,
                    RegDate = DateTime.Now,
                    IsUse = true
                };
                _members.Add(newMember);
                ClearDetail();
            }
            ChangeButtonVisibility();
        }

        private void UpdateMember()
        {
            var member = _members.FirstOrDefault(m => m.Id.ToString() == Id.Text);
            if(member == null)
            {
                return;
            }
            member.Name = Name.Text;
            member.Phone = Phone.Text;
            member.IsUse = IsUse.IsChecked == true ? true : false;
        }

        private void DisplayMember(Member source)
        {
            if(source == null)
            {
                ClearDetail();
                return;
            }
            Id.Text = source.Id.ToString();
            Name.Text = source.Name.ToString();
            Phone.Text = source.Phone.ToString();
            RegDate.Text = source.RegDate.ToString();
            IsUse.IsChecked = source.IsUse;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _isEditing = false;
            ChangeButtonVisibility();
        }

        private void MemberGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisplayMember(MemberGrid.SelectedItem as Member);
        }
    }
}
