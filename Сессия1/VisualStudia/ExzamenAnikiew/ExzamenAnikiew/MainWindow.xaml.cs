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

namespace ExzamenAnikiew
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Voiti_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = BdAnikiewEntities.GetContext().User.FirstOrDefault(x => x.Login == txbLogin.Text && x.Parol == PbPassword.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Пользователь с таким логином и паролем найден!", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                { 
                    AppFrame.MainFrame.Navigate(new Perevoski());
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка:" + Ex.Message.ToString(), "Критическая работа приложения", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
