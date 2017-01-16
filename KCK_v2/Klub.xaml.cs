using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KCK_v2
{
    /// <summary>
    /// Interaction logic for Klub.xaml
    /// </summary>
    public partial class Klub : Window
    {
        kck db = new kck();
        

        public Klub()
        {
            InitializeComponent();

            InitBinding();
        }
        private void InitBinding()
        {

            klubyListBox.ItemsSource = db.klub.ToList();
        }

        private void logoutButtonClick(object sender, RoutedEventArgs e)
        {
            menuPage mp = new menuPage();
            this.Hide();
            mp.Show();
        }

        private void addButtonClick(object sender, RoutedEventArgs e)
        {
            AddWindow add = new AddWindow();
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

        }

        private void editButtonClick(object sender, RoutedEventArgs e)
        {

            
            var index = klubyListBox.SelectedIndex;
            EditWindow edit = new EditWindow(index);
            edit.Index = index;
            edit.Show();
        }

        private void deleteButtonClick(object sender, RoutedEventArgs e)
        {
            var list = db.klub.ToList();
            error.Text = klubyListBox.SelectedIndex.ToString();
            var query = db.klub.Where(x => x.id_klub == klubyListBox.SelectedIndex);
            foreach (var k in query.ToList())
            {
                db.klub.Remove(k);
            }
            db.SaveChanges();
            this.UpdateDefaultStyle();
        }
        

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            
            //add.In = ((klubyListBox.SelectedItem as klub).id_klub);

            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                KlubInfo add = new KlubInfo(((klubyListBox.SelectedItem as klub).id_klub));
                error.Text = ((klubyListBox.SelectedItem as klub).id_klub).ToString();
                
                add.Show();
            }
        }

        private void klubyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}

