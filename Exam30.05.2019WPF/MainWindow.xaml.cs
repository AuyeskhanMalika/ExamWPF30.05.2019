using Newtonsoft.Json;
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

namespace Exam30._05._2019WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.textBox.PreviewTextInput += new TextCompositionEventHandler(textBoxPreviewTextInput);
        }



        private void textBoxPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text,0)) e.Handled = true;
        }



        private void SearchButtonClick(object sender, RoutedEventArgs e)
        {
            ILogger logger = new FileLogger();
            IDownloader downloader = new Downloader(logger);
            string json = downloader.DownloadRawJsonData($"https://earthquake.usgs.gov/fdsnws/event/1/query?format=geojson&limit={textBox.Text}");
            var data = JsonConvert.DeserializeObject<FeatureCollection>(json);
            List<Property> features = new List<Property>();
            foreach (var feature in data.Features)
            {
                features.Add(feature.Properties);
            }
            earthquakesDataGrid.ItemsSource = features;
        }



        private void TextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";
        }
    }
}
