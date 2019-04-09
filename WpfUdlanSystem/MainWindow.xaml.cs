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

using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;



namespace WpfUdlanSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source=ZBC-EMA-23111;Initial Catalog=master; Integrated Security=True");

        Magic newMagic = new Magic();
        public MainWindow()
        {
            InitializeComponent();
            newMagic.ReadingFromSql();
            pokemonImage.Source = new BitmapImage(new Uri(@"C:\notFound.png"));
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string poke = pokemonName.Text;
            newMagic.Happens(poke);
            //Change the method to the logic class
            //Yolo();
            newMagic.RetriveImage(poke);
            //pokemonImage.Source = new BitmapImage(new Uri(@"C:\Users\pete168s\Desktop\bulbasaur.png", UriKind.Relative));
            //pokemonImage.Source = new BitmapImage(new Uri(@"C:\bulbasaur.png"));
           // pokemonImage.Source = new BitmapImage(new Uri(@"C:\" + poke + ".png"));
            newMagic.ChangeImage(pokemonImage);
        }
        
        //When user chooses coffe
        //We send coffe to happens
        private void ComboboxItem_Selected(object sender, RoutedEventArgs e)
        {
            string covfefe = coffie.Content.ToString();
            newMagic.Happens(covfefe);
        }
        private void ComboboxItem(object sender, RoutedEventArgs e)
        {
            string teafefe = tea.Content.ToString();
            newMagic.Happens(teafefe);
        }
    }

}

