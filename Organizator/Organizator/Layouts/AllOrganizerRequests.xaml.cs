using Organizator.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace Organizator.Layouts
{
    /// <summary>
    /// Interaction logic for AllOrganizerRequests.xaml
    /// </summary>
    public partial class AllOrganizerRequests : Window
    {
        public ObservableCollection<Request> Reqquests
        {
            get;
            set;
        }

        public AllOrganizerRequests()
        {
            InitializeComponent();
            this.DataContext = this;
            App.Current.Resources["windowOpened"] = false;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("../../Files/requests.txt", FileMode.Open, FileAccess.Read);
            Requests a = (Requests)formatter.Deserialize(stream);
            Reqquests = new ObservableCollection<Request>();
            string user = (string)App.Current.Properties["current_user"];
            foreach (var l in a.byUser(user))
            {
                Console.WriteLine($"{l.Place} {l.Organizer} {l.MaxBudget}");
                Reqquests.Add(l);
            }
            stream.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("../../Files/requests.txt", FileMode.Create, FileAccess.Write);
            Requests associates = new Requests(Reqquests);
            formatter.Serialize(stream, associates);
            stream.Close();
            App.Current.Resources["windowOpened"] = true;
        }
    }
}
