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

        private Requests all;

        public AllOrganizerRequests()
        {
            InitializeComponent();
            this.DataContext = this;
            App.Current.Resources["windowOpened"] = false;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("../../Files/requests.txt", FileMode.Open, FileAccess.Read);
            all = (Requests)formatter.Deserialize(stream);
            Reqquests = new ObservableCollection<Request>();
            string user = (string)App.Current.Properties["current_user"];
            Console.WriteLine($"username in requests: {user}");
            foreach (var l in all.byUser(user))
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
            formatter.Serialize(stream, all);
            stream.Close();
            App.Current.Resources["windowOpened"] = true;
        }

        private void suggest_btn_Click(object sender, RoutedEventArgs e)
        {
            Request r = all.byClient(suggest_btn.Content.ToString());
            App.Current.Properties["Client"] = r.Client;
            App.Current.Properties["MaxBudget"] = r.MaxBudget;
            App.Current.Properties["PartyType"] = r.PartyType;
            App.Current.Properties["Place"] = r.Place;
            App.Current.Properties["Time"] = r.Time;
            App.Current.Resources["requestsOpened"] = false;
            Console.WriteLine($"Client: {r.Client}, Time: {r.Time}, MaxBudget: {r.MaxBudget}");
            var s = new Suggestions();
            s.Show();
            Console.WriteLine(suggest_btn.Content.ToString());
        }
    }
}
