using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Paszporty
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AktualizujZdjecia("000");
        }

        private void txtNumer_LostFocus(object sender, RoutedEventArgs e)
        {
            string numer = txtNumer.Text.Trim();
            if (!string.IsNullOrEmpty(numer))
            {
                AktualizujZdjecia(numer);
            }
            else
            {
                AktualizujZdjecia("000");
            }
        }

        private void AktualizujZdjecia(string numer)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            string zdjeciePath = System.IO.Path.Combine(baseDir, "zdjecia", $"{numer}-zdjecie.jpg");
            string odciskPath = System.IO.Path.Combine(baseDir, "zdjecia", $"{numer}-odcisk.jpg");

            if (File.Exists(zdjeciePath))
            {
                imgZdjecie.Source = new BitmapImage(new Uri(zdjeciePath, UriKind.Absolute));
            }
            else
            {
                imgZdjecie.Source = null;
            }

            if (File.Exists(odciskPath))
            {
                imgOdcisk.Source = new BitmapImage(new Uri(odciskPath, UriKind.Absolute));
            }
            else
            {
                imgOdcisk.Source = null;
            }
        }
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            string imie = txtImie.Text.Trim();
            string nazwisko = txtNazwisko.Text.Trim();

            if (string.IsNullOrEmpty(imie) || string.IsNullOrEmpty(nazwisko))
            {
                MessageBox.Show("Wprowadź dane", "", MessageBoxButton.OK);
                return;
            }

            string kolorOczu = "";
            if (rbNiebieskie.IsChecked == true)
            {
                kolorOczu = "niebieskie";
            }
            else if (rbZielone.IsChecked == true)
            {
                kolorOczu = "zielone";
            }
            else if (rbPiwne.IsChecked == true)
            {
                kolorOczu = "piwne";
            }

            MessageBox.Show($"{imie} {nazwisko} kolor oczu {kolorOczu}", "", MessageBoxButton.OK);
        }
    }
}