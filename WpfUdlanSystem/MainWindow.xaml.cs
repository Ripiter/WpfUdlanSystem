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
            //TO DO: change the @c:\ to projekt file
            newMagic.FirstImage();
            //pokemonImage.Source = new BitmapImage(new Uri(@"C:\pokemonNotFound.png"));

            pokemonImage.Source = new BitmapImage(new Uri(@"\imgNotFound\notFound.png", UriKind.Relative));

            //if file exists show image, else get image from database
            //pokemonImage.Source = new BitmapImage(new Uri(@"\Pokemon\ "+ "pokemonname" +" .png", UriKind.Relative));
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string poke = pokemonName.Text;
            newMagic.Happens(poke);
            newMagic.ChangeImage(pokemonImage);
            newMagic.RetriveImage();
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

        private void RedirectLoginPage(object sender, RoutedEventArgs e)
        {
            LoginPage windowTwo = new LoginPage();
            //this will open your child window
            windowTwo.Show();
            //this will close parent window. windowOne in this case
            this.Close();
        }
    }

}

