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

namespace AdminTestShell
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Database.TestMasterdDBEntities connection;
        public ObservableCollection<Database.user> Users {  get; set; }
        public MainWindow()
        {
            InitializeComponent();

            connection = new Database.TestMasterdDBEntities();
            if (!connection.Database.Exists())
            {
                MessageBox.Show("Подключение к базе данных не было выполнено. Приложение будет завершено.",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                Application.Current.Shutdown();
            }

            Users = new ObservableCollection<Database.user>(connection.users);

            DataContext = this;
        }
    }
}
