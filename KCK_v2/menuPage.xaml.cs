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
    /// Interaction logic for menuPage.xaml
    /// </summary>
    public partial class menuPage : Window
    {
        public int Flag { get; set; }
        public menuPage()
        {
            InitializeComponent();
            
        }
        
        private void onKlubyClick(object sender, RoutedEventArgs e)
        {
            Klub klub = new Klub();
            klub.Show();
        }

        private void onZawodnicyClick(object sender, RoutedEventArgs e)
        {
            Zawodnicy zw = new Zawodnicy();
            zw.Show();
        }
    }
}
