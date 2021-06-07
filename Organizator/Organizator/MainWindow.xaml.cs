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
            Stream stream = new FileStream("C://Users/jovan/Desktop/hci_projekat/Organizator/Organizator/Files/users.txt", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, users);
            stream.Close();
            stream = new FileStream("C://Users/jovan/Desktop/hci_projekat/Organizator/Organizator/Files/users.txt", FileMode.Open, FileAccess.Read);
            Users users2 = (Users)formatter.Deserialize(stream);
            stream.Close();
            foreach (var u in users2.users)
            {
             Console.WriteLine(u.username);
             Console.WriteLine(u.password);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var s = new Layouts.LogIn();
            s.Show();
        }

    }
}
