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

namespace KCK_v2
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private int index;

        public int In
        {
            get { return index; }
            set { index = value; }
        }

        public AddWindow()
        {
            InitializeComponent();
        }

        private void onSave(object sender, RoutedEventArgs e)
        {
            kck db = new kck();
            klub nowy = new klub();
            nowy.id_klub = In;
            nowy.majatek = int.Parse(majatekField.Text);
            nowy.nazwa = nazwaField.Text;
            nowy.path = "barca.png";
            db.klub.Add(nowy);
            db.SaveChanges();
            
        }

        private void onCancel(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
