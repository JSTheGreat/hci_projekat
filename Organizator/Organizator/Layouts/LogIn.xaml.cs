using Organizator.Model;
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
using System.Windows.Shapes;

namespace Organizator.Layouts
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {

        private Users users;
        private string username;
        private string password;

        public LogIn()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("C://Users/jovan/Desktop/hci_projekat/Organizator/Organizator/Files/users.txt", FileMode.Open, FileAccess.Read);
            this.users = (Users)formatter.Deserialize(stream);
            stream.Close();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = new User(this.username, this.password);
            if (!this.users.userExists(user))
                MessageBox.Show("Check spelling on username or password");
            else
            {
                Console.WriteLine(App.Current.Properties["logged_in"]);
                App.Current.Properties["logged_in"] = user;
                Console.WriteLine(App.Current.Properties["logged_in"].ToString());
                Close();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.username = Username.Text;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            this.password = Password.Password;
        }
    }
}
