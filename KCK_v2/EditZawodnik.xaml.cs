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
    /// Interaction logic for EditZawodnik.xaml
    /// </summary>
    public partial class EditZawodnik : Window
    {
        private int ind;
        private int id_edit;
        kck db = new kck();
        private String n;

        public String nKlubname
        {
            get { return n; }
            set { n = value; }
        }

        public int Index
        {
            get { return ind; }
            set { ind = value; }
        }
        public EditZawodnik(int id)
        {
            Index = id;
            InitializeComponent();
            var query = db.zawodnicy.Where(x => x.id_zawodnik == Index);
            foreach (var k in query)
            {
                imieField.Text = k.imie;
                nazwiskoField.Text = k.nazwisko;
                pozycjaField.Text = k.pozycja;
                wartoscField.Text = k.wartosc.ToString();
            }
            InitBinding();
        }

        private void InitBinding()
        {
            var list = db.klub.ToList();
            selectKlub.ItemsSource = list;
        }
    

        private void onSave(object sender, RoutedEventArgs e)
        {
            var query = db.zawodnicy.Where(x => x.id_zawodnik == Index);
            foreach (var k in query)
            {
                
                k.imie= imieField.Text;
                k.nazwisko = nazwiskoField.Text;
                k.pozycja = pozycjaField.Text;
                k.wartosc = int.Parse(wartoscField.Text);
                k.id_klub = id_edit;
                
            }

        
            db.SaveChanges();
            this.Hide();

        }
        private void selectKlub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = sender as ComboBoxItem;
            var item2 = ((selectKlub.SelectedValue as klub));
            if (item2 != null)
            {

                nKlubname = item2.nazwa;
                foreach (klub z in db.klub.ToList())
                {
                    if (nKlubname == z.nazwa)
                    {
                        id_edit = z.id_klub;
                    }
                }

            }
        }

        private void onCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
