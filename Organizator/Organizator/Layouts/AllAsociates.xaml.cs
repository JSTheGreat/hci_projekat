using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Organizator.Model;
using System.Collections.ObjectModel;

namespace Organizator.Layouts
{
    /// <summary>
    /// Interaction logic for AllAsociates.xaml
    /// </summary>
    public partial class AllAsociates : Window
    {
        private ObservableCollection<Associate> associates = new ObservableCollection<Associate>();

        public AllAsociates()
        {
            this.DataContext = this;
            App.Current.Resources["windowOpened"] = false;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("../../Files/associates.txt", FileMode.Open, FileAccess.Read);
            Associates a = (Associates)formatter.Deserialize(stream);
            List<Associate> list = a.toList();
            foreach (var l in list)
            {
                Console.WriteLine($"{l.place} {l.name}");
                this.associates.Add(l);
            }
            stream.Close();
            InitializeComponent();
        }
    }
}
