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

namespace KCK_v2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String log, pass;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            kck db = new kck();
            log = loginField.Text;
            pass = hasloField.Password;
            var list = db.users.ToList();
                foreach(users u in list)
            {
                if (log.Equals(u.login) && pass.Equals(u.haslo))
                {
                    
                    menuPage menu = new menuPage();
                    menu.Show();
                    this.Close();
                }
                else if ((log.Equals("") || pass.Equals("")))
                {
                    this.UpdateDefaultStyle();
                    error.Text = "Błąd: Wprowadz login lub haslo!!!! Nie możesz pozostawić pustych pól!";
                    
                }
                /*else if(!(log.Equals(u.login)&&pass.Equals(u.haslo)))
                {
                    this.UpdateDefaultStyle();
                    error.Text = "Błąd: Login lub haslo są niepoprawne!!";
                }*/
            }
        }
        
        
    }
}
