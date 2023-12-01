using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
    /// Логика взаимодействия для Teachers.xaml
    /// </summary>
    public partial class Teachers : Page
    {
        private readonly Database.TestMasterdDBEntities database;
        private ObservableCollection<Database.user> teachers;
        public Teachers(Database.TestMasterdDBEntities entities)
        {
            InitializeComponent();
            this.database = entities;

            teachers = new ObservableCollection<Database.user>(database.users.Where(u => u.role == 2).ToList());
            var bteacher = new Binding();
            bteacher.Source = teachers;
            lbUsers.SetBinding(ItemsControl.ItemsSourceProperty, bteacher);
        }

        private void OnRemoveUserClick(object sender, RoutedEventArgs e)
        {
            var user = lbUsers.SelectedItem as Database.user;
            database.users.Remove(user);
            teachers.Remove(user);
            database.SaveChanges();

        }

        private void OnChangeUser(object sender, SelectionChangedEventArgs e)
        {
            bRemoveUser.IsEnabled = lbUsers.SelectedItem != null;
        }
    }
}
