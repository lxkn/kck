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
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private int id;
        
        public int Index
        {
            get { return id; }
            set { id = value; }
        }
        kck db = new kck();
        
        public EditWindow(int id)
        {
            Index = id;
            InitializeComponent();
            var query = db.klub.Where(x => x.id_klub == Index);
            foreach (var k in query)
            {
                nazwaField.Text = k.nazwa;
                majatekField.Text = k.majatek.ToString();
            }
        }
        
        private void onSave(object sender, RoutedEventArgs e)
        {
            var query = db.klub.Where(x => x.id_klub == Index);
            foreach(var k in query)
            {
                k.nazwa = nazwaField.Text;
                k.majatek = int.Parse(majatekField.Text);
            }
            db.SaveChanges();
            this.Hide();

        }

        private void onCancel(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
