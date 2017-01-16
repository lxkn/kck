using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    /// Interaction logic for KlubInfo.xaml
    /// </summary>
    public partial class KlubInfo : Window
    {
        int index;
        

        public KlubInfo(int index)
        {
            InitializeComponent();
            this.index = index;
            InitBinding();
            
        }
        
        
        private void InitBinding()
        {
            kck db = new kck();
            var query = db.klub.ToList().FindAll(x=>x.id_klub==index);
            foreach (klub k in query)
            {
                klubName.Text = k.nazwa;
                klubMajatek.Text = k.majatek.ToString();
                

                var source = new BitmapImage();
                using (var stream = new FileStream(k.path, FileMode.Open))
                {
                    source.BeginInit();
                    source.CacheOption = BitmapCacheOption.OnLoad;
                    source.StreamSource = stream;
                    source.EndInit();
                    source.Freeze();
                }
                klubAvatar.Source = source;
            }
             
        }

        private void team_Click(object sender, RoutedEventArgs e)
        {
            Team team = new Team(index);
            team.Show();
        }
    }
}
