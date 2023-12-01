using System;
using System.Collections.Generic;
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
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        private static Database.TestMasterdDBEntities database;
        public Authorization(Database.TestMasterdDBEntities entities)
        {
            InitializeComponent();
            database = entities;
        }

        private void OnInputChange(object sender, TextChangedEventArgs e)
        {
            bAuth.IsEnabled = tbLogin.Text.Trim().Length > 0 && tbPassword.Text.Trim().Length > 0;
        }

        private void OnAuthorizationClick(object sender, RoutedEventArgs e)
        {
            var username = tbLogin.Text.Trim();
            var password = tbPassword.Text.Trim();
            var user = database.users.Where(u => u.username == username && u.password == password).FirstOrDefault();
            tbLogin.Clear();
            tbPassword.Clear();
            if (user != null)
            {
                switch (user.role)
                {
                    case 4:
                        {
                            NavigationService.Navigate(Pages.ViewManager.Administration);
                        }
                        break;

                    default: break;
                }
            }
        }
    }
}
