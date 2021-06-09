using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Organizator.Model;

namespace Organizator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            User user1 = new User("user1", "pass1");
            User user2 = new User("user2", "pass2");
            List<User> list = new List<User>();
            list.Add(user1);
            list.Add(user2);
            Users users = new Users(list);
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("../../Files/users.txt", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, users);
            stream.Close();
            stream = new FileStream("../../Files/users.txt", FileMode.Open, FileAccess.Read);
            Users users2 = (Users)formatter.Deserialize(stream);
            stream.Close();
            foreach (var u in users2.users)
            {
             Console.WriteLine(u.username);
             Console.WriteLine(u.password);
            }
            stream = new FileStream("../../Files/associates.txt", FileMode.Create, FileAccess.Write);
            Associate as1 = new Associate("as1", "pl1", "restaurant", "555-111");
            Associate as2 = new Associate("as2", "pl1", "catering firm", "555-222");
            Associate as3 = new Associate("as3", "pl2", "catering firm", "555-333");
            Associate as4 = new Associate("as4", "pl2", "restaurant", "555-444");
            Associate as5 = new Associate("as5", "pl2", "restaurant", "555-555");
            Associate as6 = new Associate("as6", "pl2", "catering firm", "555-666");
            List<Associate> list2 = new List<Associate>();
            list2.Add(as6);
            list2.Add(as5);
            list2.Add(as4);
            list2.Add(as3);
            list2.Add(as2);
            list2.Add(as1);
            Associates associates = new Associates(list2);
            formatter.Serialize(stream, associates);
            stream.Close();
            Request re1 = new Request("client1", "birthday", new DateTime(2021, 6, 20, 12, 30, 0), "pl1", 1000, "user1");
            Request re2 = new Request("client2", "birthday party", new DateTime(2021, 6, 21, 12, 00, 0), "pl1", 2000, "user1");
            Request re3 = new Request("client3", "promotion", new DateTime(2021, 6, 22, 12, 30, 0), "pl2", 3000, "user1");
            Request re4 = new Request("client4", "promotion party", new DateTime(2021, 6, 20, 14, 30, 0), "pl2", 4000, "user1");
            Request re5 = new Request("client5", "retirement party", new DateTime(2021, 6, 20, 14, 30, 0), "pl2", 5000, "user1");
            Request re6 = new Request("client6", "birthday", new DateTime(2021, 6, 20, 12, 30, 0), "pl1", 1000, "user2");
            Request re7 = new Request("client7", "birthday party", new DateTime(2021, 6, 21, 12, 00, 0), "pl1", 2000, "user2");
            Request re8 = new Request("client8", "promotion", new DateTime(2021, 6, 22, 12, 30, 0), "pl1", 3000, "user2");
            Request re9 = new Request("client9", "promotion party", new DateTime(2021, 6, 20, 14, 30, 0), "pl2", 4000, "user2");
            Request re10 = new Request("client10", "retirement party", new DateTime(2021, 6, 20, 14, 30, 0), "pl2", 5000, "user2");
            List<Request> list3 = new List<Request>();
            list3.Add(re1);
            list3.Add(re2);
            list3.Add(re3);
            list3.Add(re4);
            list3.Add(re5);
            list3.Add(re6);
            list3.Add(re7);
            list3.Add(re8);
            list3.Add(re9);
            list3.Add(re10);
            Requests requests = new Requests(list3);
            stream = new FileStream("../../Files/requests.txt", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, requests);
            stream.Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var s = new Layouts.LogIn();
            s.Show();
        }

        private void logout_btn_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["current_user"] = null;
            App.Current.Resources["loggedIn"] = false;
            App.Current.Resources["loggedOut"] = true;
            MessageBox.Show("You have successfully logged out", "Info");
        }

        private void all_associates(object sender, RoutedEventArgs e)
        {
            var s = new Layouts.AllAsociates();
            s.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var s = new Layouts.AddAssociate();
            s.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            App.Current.Shutdown();
        }

        private void requests_Click(object sender, RoutedEventArgs e)
        {
            var s = new Layouts.AllOrganizerRequests();
            s.Show();
        }
    }
}
