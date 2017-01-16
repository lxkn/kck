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
    /// Interaction logic for Team.xaml
    /// </summary>
    public partial class Team : Window
    {
        kck db = new kck();
        private int id;

        public int Myid
        {
            get { return id; }
            set { id = value; }
        }

        public Team(int id)
        {
            Myid = id;
            InitializeComponent();
            InitBinding();
        }
        private void InitBinding()
        {
            var list = db.klub.ToList().FindAll(x => x.id_klub == Myid);
            foreach(klub k in list)
            {
                teamList.ItemsSource = k.zawodnicy;
            }
            
        }
    }
}
