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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ppedv.TransportVisu.UI.WPF.Views
{
    /// <summary>
    /// Interaction logic for AnlagenView.xaml
    /// </summary>
    public partial class AnlagenView : UserControl
    {
        public AnlagenView()
        {
            InitializeComponent();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ran = new Random();
            var data = new List<DpMitPos>();
            data.Add(new DpMitPos() { txtt = "lalallalalalal", Left = ran.Next(0, 500), Top = ran.Next(0, 200) });
            data.Add(new DpMitPos() { txtt = "234324324", Left = ran.Next(0, 500), Top = ran.Next(0, 200) });
            data.Add(new DpMitPos() { txtt = "ewrwer", Left = ran.Next(0, 500), Top = ran.Next(0, 200) });
            data.Add(new DpMitPos() { txtt = "xvcvxvc", Left = ran.Next(0, 500), Top = ran.Next(0, 200) });
            iccccc.ItemsSource = data;
        }
    }

    public class DpMitPos
    {
        public string txtt { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
    }

}
