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
    /// Interaction logic for AddAssociate.xaml
    /// </summary>
    public partial class AddAssociate : Window
    {

        private string name;
        private string type;
        private string number;
        private string place;

        public AddAssociate()
        {
            App.Current.Resources["windowOpened"] = false;
            InitializeComponent();
        }

        private void ClosedEvent(object sender, EventArgs e)
        {
            App.Current.Resources["windowOpened"] = true;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.name = Name.Text; 
        }

        private void Number_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.number = Number.Text;
        }

        private void Place_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.place = Place.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (name == "" || number == "" || place == "" || type == "")
                MessageBox.Show("No field can remain empty", "Warning");
            else
            {
                Console.WriteLine("type: " + type);
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("../../Files/associates.txt", FileMode.Open, FileAccess.Read);
                Associates associates = (Associates)formatter.Deserialize(stream);
                stream.Close();
                associates.addAssociate(new Associate(name, place, type, number));
                stream = new FileStream("../../Files/associates.txt", FileMode.Create, FileAccess.Write);
                formatter.Serialize(stream, associates);
                stream.Close();
                Close();
            }
        }

        private void Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.type = Type.Text;
        }
    }
}
