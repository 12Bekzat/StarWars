using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace StarWarsCards
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string url = "https://swapi.co/api/people/*";
        private const string CONNECTION_STRING = "Server=A-104-10;Database=StarWars;Trusted_Connection=True;";
        public MainWindow()
        {
            InitializeComponent();
        }



        private void Load(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(page.Text))
            {
                MessageBox.Show("Введите страницу!");
            }
            else
            {
                int pageNum = 0;
                if (!int.TryParse(page.Text, out pageNum))
                {
                    MessageBox.Show("Введите число для страницы!");
                    return;
                }
                if(pageNum == 0)
                {
                    MessageBox.Show("Ноль нельзя ввести!");
                }
                WebClient webClient = new WebClient();
                url = url.Replace("*", page.Text);
                string json = webClient.DownloadString(url);
                Result root = JsonConvert.DeserializeObject<Result>(json);
                cardsStarwars.Items.Add(root);
            }
        }
    }
}
