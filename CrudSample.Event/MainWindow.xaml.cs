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
            _members.Add(new Member 
            {
                Id = 1,
                Name = "kaki104",
                Phone = "010-1111-2222",
                RegDate = DateTime.Now,
                IsUse = true,
            });
            MemberDataGrid.ItemsSource = _members;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ChangeButtonVisibility();
            ChangeButtonIsEnable();
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
                DetailGrid.IsEnabled = true;
            }
            else
            {
                NewButton.Visibility = Visibility.Visible;
                EditButton.Visibility = Visibility.Visible;
                DeleteButton.Visibility = Visibility.Visible;
                SaveButton.Visibility = Visibility.Collapsed;
                CancelButton.Visibility = Visibility.Collapsed;
                DetailGrid.IsEnabled = false;
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
            }
            ClearDetail();
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
            MemberDataGrid.ItemsSource = null;
            MemberDataGrid.ItemsSource = _members;
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
            IsUse.Content = source.IsUse ? "사용" : "미사용";
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _isEditing = false;
            ChangeButtonVisibility();
        }

        private void MemberGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisplayMember(MemberDataGrid.SelectedItem as Member);
            ChangeButtonIsEnable();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            _isEditing = true;
            ChangeButtonVisibility();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(MemberDataGrid.SelectedItem == null)
            {
                return;
            }
            var result = MessageBox.Show("선택된 아이템을 삭제하시겠습니까?", "삭제 확인", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.No)
            {
                return;
            }
            var removeItem = MemberDataGrid.SelectedItem as Member;
            _members.Remove(removeItem);
        }

        private void IsUse_Checked(object sender, RoutedEventArgs e)
        {
            IsUse.Content = IsUse.IsChecked == true ? "사용" : "미사용";
        }

        private void IsUse_Unchecked(object sender, RoutedEventArgs e)
        {
            IsUse.Content = IsUse.IsChecked == true ? "사용" : "미사용";
        }

        private void ChangeButtonIsEnable()
        {
            if(MemberDataGrid.SelectedItem == null)
            {
                EditButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
            else
            {
                EditButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;
            }
        }
    }
}
