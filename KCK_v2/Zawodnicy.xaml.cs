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
    /// Interaction logic for Zawodnicy.xaml
    /// </summary>
    public partial class Zawodnicy : Window
    {
        kck db = new kck();
        

        public Zawodnicy()
        {
            InitializeComponent();
            InitBinding();
        }
        private void InitBinding()
        {
            klubyListBox.ItemsSource = db.zawodnicy.ToList();
        }

        private void addButtonClick(object sender, RoutedEventArgs e)
        {
            AddZawodnik add = new AddZawodnik();
            int index = klubyListBox.Items.Count;
            if (index == 0)
            {
                add.In = 0;
            }
            else
            {
                add.In = index;
            }
            add.Show();
            this.Hide();
        }

        private void editButtonClick(object sender, RoutedEventArgs e)
        {
            
            var index = klubyListBox.SelectedIndex;
            EditZawodnik edit = new EditZawodnik(index);
            edit.Index = index;
            edit.Show();
        }

        private void deleteButtonClick(object sender, RoutedEventArgs e)
        {
            error.Text = klubyListBox.SelectedIndex.ToString();
            var query = db.zawodnicy.Where(x => x.id_zawodnik == klubyListBox.SelectedIndex);
            foreach (var k in query.ToList())
            {
                db.zawodnicy.Remove(k);
            }
            db.SaveChanges();
            this.UpdateDefaultStyle();
        }

        private void logoutButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
            menuPage mp = new menuPage();
            mp.Show();
        }
    }
}
