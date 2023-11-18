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
        private ObservableCollection<Database.user> users;
        public Admins(Database.TestMasterdDBEntities entities)
        {
            InitializeComponent();
            database = entities;

            users = new ObservableCollection<Database.user>(database.users);

            var admins = new Binding();
            admins.Source = users;
            lbUsers.SetBinding(ItemsControl.ItemsSourceProperty, admins);
        }
    }
}
