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
using System.Windows.Shapes;

namespace AdminTestShell.Pages
{
    /// <summary>
    /// Interaction logic for CreateUser.xaml
    /// </summary>
    public partial class CreateUser : Window
    {
        private readonly Database.TestMasterdDBEntities database;
        public CreateUser(Database.TestMasterdDBEntities entities)
        {
            InitializeComponent();
            this.database = entities;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
             this.Close();
        }
    }
}
