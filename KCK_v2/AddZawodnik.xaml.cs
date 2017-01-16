using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AddZawodnik.xaml
    /// </summary>
    public partial class AddZawodnik : Window
    {
        private int index;
        kck db = new kck();
        zawodnicy nowy = new zawodnicy();
        private String n;

        public  String nKlubname
        {
            get { return n; }
            set { n = value; }
        }

        public int In
        {
            get { return index; }
            set { index = value; }
        }
        public AddZawodnik()
        {
            InitializeComponent();
            InitBinding();
        }
        
        private void InitBinding()
        {
            var list = db.klub.ToList();
            selectKlub.ItemsSource = list;
        }
        private void onSave(object sender, RoutedEventArgs e)
        {
            //var klubylist = db.klub.ToList().Find(x => x.nazwa == nameBox.Text);
            nowy.id_zawodnik = In;
            nowy.imie = imieField.Text;
            nowy.nazwisko = nazwiskoField.Text;
            nowy.wartosc = int.Parse(wartoscField.Text);
            nowy.pozycja = pozycjaField.Text;
            
                

            
            db.zawodnicy.Add(nowy);
            db.SaveChanges();
            this.Hide();
        }

        private void onCancel(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void selectKlub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = sender as ComboBoxItem;
            var item2 = ((selectKlub.SelectedValue as klub));
            if (item2!=null)
            {

                nKlubname = item2.nazwa;
                foreach (klub k in db.klub.ToList())
                {
                    if (nKlubname == k.nazwa)
                    {
                        nowy.id_klub = k.id_klub;
                    }
                }
            }

        }
    }
}
