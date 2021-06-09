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
            Associate as2 = new Associate("as2", "pl2", "catering firm", "555-222");
            Associate as3 = new Associate("as3", "pl3", "catering firm", "555-333");
            Associate as4 = new Associate("as4", "pl4", "restaurant", "555-444");
            Associate as5 = new Associate("as5", "pl5", "restaurant", "555-555");
            List<Associate> list2 = new List<Associate>();
            list2.Add(as5);
            list2.Add(as4);
            list2.Add(as3);
            list2.Add(as2);
            list2.Add(as1);
            Associates associates = new Associates(list2);
            formatter.Serialize(stream, associates);
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
    }
}
