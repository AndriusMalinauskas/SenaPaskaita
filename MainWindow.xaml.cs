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

namespace Paskaita_19_Zaidimas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int MyProperty { get; set; }
        public int MonetosReiksmes { get; set; }
        public int KauliukoReiksmes { get; set; }
        public int Visitaskai { get; set; }
        public int SuZaistiZaidimai { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MestiMonetaButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> moneta = new List<string>() { "Herbas", "Skaicius" };
            Random rand = new Random();
                MonetosReiksmes = rand.Next(0, moneta.Count);
                MonetosReiksme.Text = moneta[MonetosReiksmes];
                MestiMonetaButton.IsEnabled = false;
                MestiKauliukaButton.IsEnabled = true;
        }

        private void MestiKauliukaButton_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            KauliukoReiksmes = rand.Next(1, 7);
            KauliukoReiksme.Text = $"{KauliukoReiksmes}";
            MestiKauliukaButton.IsEnabled = false;
            SkaiciuotiTaskusButton.IsEnabled = true;
        }

        private void SkaiciuotiTaskusButton_Click(object sender, RoutedEventArgs e)
        { 
                switch (MonetosReiksme.Text)
                {
                    case "Herbas":
                        Visitaskai += KauliukoReiksmes;
                        break;
                    case "Skaicius":
                        Visitaskai += (KauliukoReiksmes * 2);
                        break;
                    default:
                        break;
                }
                SurinkitTaskai.Text = $"{Visitaskai}";
                MestiMonetaButton.IsEnabled = true;
                MonetosReiksme.Text = "";
                KauliukoReiksme.Text = "";
                SuZaistiZaidimai += 1;
                SkaiciuotiTaskusButton.IsEnabled = false;
            if (SuZaistiZaidimai >= int.Parse(ZaidimuSk.Text))
            {
                MestiKauliukaButton.IsEnabled = false;
                MestiMonetaButton.IsEnabled = false;
                if (int.Parse(SpetiTaskai.Text) == Visitaskai)
                {
                    MessageBox.Show($"Jus spejot, kad surinksit: {SpetiTaskai.Text} ir atspejot");
                }
                else
                {
                    MessageBox.Show($"Jus spejot, kad surinksit: {SpetiTaskai.Text}, is tikro surinkti taskai: {Visitaskai} ");
                }
            }

        }

        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            int zaidimuSk; int spetiTaskai;
            if (int.TryParse(ZaidimuSk.Text, out zaidimuSk) && int.TryParse(SpetiTaskai.Text, out spetiTaskai))
            {
               
                if (spetiTaskai >= zaidimuSk && spetiTaskai <=zaidimuSk*12)
                {
                    ZaistiButton.IsEnabled = true;
                }
                else
                {
                    ZaistiButton.IsEnabled = false;
                }
            }

        }

        private void ZaistiButton_Click(object sender, RoutedEventArgs e)
        {
            ZaidimuSk.IsReadOnly = true; SpetiTaskai.IsReadOnly = true; MestiMonetaButton.IsEnabled = true; ZaistiButton.IsEnabled = false;
        }

        private void ZaistiIsNaujoButton_Click(object sender, RoutedEventArgs e)
        {
            ZaidimuSk.Text = "";
            SpetiTaskai.Text = "";
            SuZaistiZaidimai = 0;
            Visitaskai = 0;
            SurinkitTaskai.Text = "";
            ZaidimuSk.IsReadOnly = false;
            SpetiTaskai.IsReadOnly = false;
            ZaistiButton.IsEnabled = false;         
        }
    }
}
