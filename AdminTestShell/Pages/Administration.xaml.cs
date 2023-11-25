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
    /// Interaction logic for Administration.xaml
    /// </summary>
    public partial class Administration : Page
    {

        public Administration()
        {
            InitializeComponent();
            ListLoad.Navigate(ViewManager.Admins);
        }

        private void OnAdminsListClick(object sender, RoutedEventArgs e)
        {
            ListLoad.Navigate(ViewManager.Admins);
        }

        private void OnHeadsListClick(object sender, RoutedEventArgs e)
        {
            ListLoad.Navigate(ViewManager.Heads);
        }

        private void OnTeachersListClick(object sender, RoutedEventArgs e)
        {
            ListLoad.Navigate(ViewManager.Teachers);
        }

        private void OnLogOutClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(ViewManager.Authorization);
        }
    }
}
