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

        private Associates associates1;

        public AddAssociate()
        {
            App.Current.Resources["windowOpened"] = false;
            InitializeComponent();
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("../../Files/associates.txt", FileMode.Open, FileAccess.Read);
            associates1 = (Associates)formatter.Deserialize(stream);
            stream.Close();
            this.type = "restaurant";
            this.place = "pl1";
            this.name = "";
            this.number = "";
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine($"{this.number} {this.name} {this.place} {this.type}");
            if (this.name.Equals("") || this.number.Equals("") || this.place.Equals("") || this.type.Equals(""))
                MessageBox.Show("No field can remain empty. Please fill them in", "Warning");
            else if (!associates1.isUnique(name, number))
                MessageBox.Show("Name or number given is not unique. Please try entering different values for given fields", "Warning");
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

        private void Place_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.place = Place.Text;
        }

    }
}
