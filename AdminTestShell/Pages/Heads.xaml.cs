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
    /// Логика взаимодействия для Heads.xaml
    /// </summary>
    public partial class Heads : Page
    {
        private readonly Database.user9Entities database;
        private ObservableCollection<Database.user> heads;

        public Heads(Database.user9Entities entities)
        {
            InitializeComponent();
            this.database = entities;

            heads = new ObservableCollection<Database.user>(database.users.Where(u => u.role == 3).ToList());
            var bheads = new Binding();
            bheads.Source = heads;
            lbUsers.SetBinding(ItemsControl.ItemsSourceProperty, bheads);
        }

        private void OnRemoveUserClick(object sender, RoutedEventArgs e)
        {
            var user = lbUsers.SelectedItem as Database.user;
            database.users.Remove(user);
            heads.Remove(user);
            database.SaveChanges();

        }

        private void OnChangeUser(object sender, SelectionChangedEventArgs e)
        {
            bRemoveUser.IsEnabled = lbUsers.SelectedItem != null;
        }
    }
}
