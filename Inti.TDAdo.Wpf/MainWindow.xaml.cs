using Inti.TDAdo.Metier;
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

namespace Inti.TDAdo.Wpf
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> ListArticle { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            BLArticle.Init();
            ListArticle = new List<string>();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var articles = BLArticle.GetArticles();
            for (int i = 0; i < articles.Count; i += 3)
            {
                list1.Items.Add((string)articles[i + 1]);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Suppression");
        }
    }
}
