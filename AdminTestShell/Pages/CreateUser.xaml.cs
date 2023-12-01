using AdminTestShell.Core;
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
using System.Windows.Shapes;

namespace AdminTestShell.Pages
{
    /// <summary>
    /// Interaction logic for CreateUser.xaml
    /// </summary>
    public partial class CreateUser : Window
    {
        private readonly Database.TestMasterdDBEntities database;
        private Database.user user;
        public CreateUser(Database.TestMasterdDBEntities entities)
        {
            InitializeComponent();
            this.database = entities;

        }

        private void OnCloseClick(object sender, RoutedEventArgs e)
        {
             this.Close();
        }

        private void OnCreateUserClick(object sender, RoutedEventArgs e)
        {
            var fullName = tbFullname.Text.Trim();
            var username = GenerateUsername.GetUsername(fullName, database);
            var password = GeneratePassword.GetPassword(10);

            user = new Database.user();
            user.username = username;
            user.fullName = fullName;
            user.password = password;
            user.role = 4;

            database.users.Add(user);
            database.SaveChanges();
            OnCloseClick(sender, e);

        }

        private void OnInputChange(object sender, TextChangedEventArgs e)
        {
            var words = tbFullname.Text.Trim().Split(' ');
            bCreateUser.IsEnabled = words.Length == 3 && words.All(word => word.Length >= 2);
        }
    }
}
