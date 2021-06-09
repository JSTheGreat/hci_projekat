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
    /// Interaction logic for Suggestions.xaml
    /// </summary>
    public partial class Suggestions : Window
    {

        Point startPoint = new Point();

        public ObservableCollection<Offer> Offfers
        {
            get;
            set;
        }

        public ObservableCollection<Offer> Offfers2
        {
            get;
            set;
        }

        public Suggestions()
        {
            InitializeComponent();
            this.DataContext = this;
            string user = (string)App.Current.Properties["current_user"];
            string client = (string) App.Current.Properties["Client"];
            int budget = (int)App.Current.Properties["MaxBudget"];
            string type = (string)App.Current.Properties["PartyType"];
            string place = (string)App.Current.Properties["Place"];
            DateTime time = (DateTime)App.Current.Properties["Time"];
            Offfers = new ObservableCollection<Offer>();
            Offfers2 = new ObservableCollection<Offer>();
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("../../Files/associates.txt", FileMode.Open, FileAccess.Read);
            Associates associates = (Associates)formatter.Deserialize(stream);
            stream.Close();
            foreach(var a in associates.toList())
            {
                if (a.Place == place && a.Name == user)
                    Offfers.Add(new Offer(place, a.Name, time, 2500));
            }
        }

        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                ListView listView = sender as ListView;
                ListViewItem listViewItem =
                    FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

                // Find the data behind the ListViewItem
                Offer offer = (Offer)listView.ItemContainerGenerator.
                    ItemFromContainer(listViewItem);

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("myFormat", offer);
                DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void ListView_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void ListView_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Offer offer = e.Data.GetData("myFormat") as Offer;
                Offfers.Remove(offer);
                Offfers2.Add(offer);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            App.Current.Resources["requestsOpened"] = true;
        }
    }
}
