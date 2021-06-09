using System;
using System.Collections.Generic;
using System.Linq;
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
        public Suggestions()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            App.Current.Resources["requestsOpened"] = true;
        }
    }
}
