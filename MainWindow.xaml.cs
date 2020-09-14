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

namespace Paskaita_19
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string>  Lietuviskai { get; set; }
        public List<string> Angliskai { get; set; }
        public int ZodzioNr { get; set; }
        public int SpejimuSkaicius { get; set; }
        public int TeisingiSpeijimai { get; set; }
        public MainWindow()
        {
            Lietuviskai = new List<string>() { "suo", "kate", "namas", "saule", "medis", "arklys" };
            Angliskai = new List<string>() { "dog", "cat", "house", "sun", "tree", "horse" };
            InitializeComponent();
        }

        private void SpejamasZodis_TextChanged(object sender, TextChangedEventArgs e)
        {
            

        }

        private void ParinkitZodiButton_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            ZodzioNr = rand.Next(0, Lietuviskai.Count);
            DuotasZodis.Text = Lietuviskai[ZodzioNr];
            ParinkitZodiButton.IsEnabled = false;
            SpejamasZodis.Text = "";
            SpejamasZodis.Background = Brushes.White;
            TikrintiButton.IsEnabled = true;

        }

        private void TikrintiButton_Click(object sender, RoutedEventArgs e)
        {
            var teisingasSpejimas = Angliskai[ZodzioNr];
            if (teisingasSpejimas == SpejamasZodis.Text)
            {
                SpejamasZodis.Background = Brushes.Green;
                MessageBox.Show("Atspejote");
                ParinkitZodiButton.IsEnabled = true;
                TeisingiSpeijimai += 1;
            }
            else
            {
                SpejamasZodis.Background = Brushes.Red;
                MessageBox.Show("Neteisingai");
                ParinkitZodiButton.IsEnabled = true;
            }
            TikrintiButton.IsEnabled = false;
            SpejimuSkaicius += 1;
            SpejimuSk.Content = $"Speta kartu : {SpejimuSkaicius} is ju teisingi {TeisingiSpeijimai}";
        }
    }
}
