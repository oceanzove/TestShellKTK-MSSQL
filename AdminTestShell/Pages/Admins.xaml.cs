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

namespace AdminTestShell.Pages
{
    /// <summary>
    /// Interaction logic for Admins.xaml
    /// </summary>
    public partial class Admins : Page
    {
        private readonly Database.TestMasterdDBEntities database;
        private ObservableCollection<Database.user> admins;

        public Admins(Database.TestMasterdDBEntities entities)
        {
            InitializeComponent();
            database = entities;

            admins = new ObservableCollection<Database.user>(database.users.Where(u => u.role == 4).ToList());
            var badmins = new Binding();
            badmins.Source = admins;
            lbUsers.SetBinding(ItemsControl.ItemsSourceProperty, badmins);
        }

        private void OnRemoveUserClick (object sender, RoutedEventArgs e)
        {
            var user = lbUsers.SelectedItem as Database.user;
            database.users.Remove(user);
            admins.Remove(user);
            database.SaveChanges();

        }

        private void OnSaveChangeClick (object sender, RoutedEventArgs e)
        {
            var login = tbLogin.Text.Trim();
            var fullname = tbFullname.Text.Trim();
            var password = tbPassword.Text.Trim();

            var user = lbUsers.SelectedItem as Database.user;
            
            if (login != user.username)
            {
                user.username = login;
            }
            if (fullname != user.fullName)
            {
                user.fullName = fullname;
            }
            if(password != user.password)
            {
                user.password = password;
            }
            database.SaveChanges ();
        }

        private void OnCreateUserClick (object sender, RoutedEventArgs e)
        {
            ViewManager.CreateUser.Show();
        }

        private void OnChangeUser(object sender, SelectionChangedEventArgs e)
        {
            bRemoveUser.IsEnabled = lbUsers.SelectedItem != null;
            bSaveEdit.IsEnabled = lbUsers.SelectedItem != null;
        }
    }
}
