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
        SqlCommand command;
        SqlDataAdapter da;


        Magic newMagic = new Magic();
        public MainWindow()
        {
            InitializeComponent();
            newMagic.ReadingFromSql();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Yolo();
         //   string strings = newMagic.ReturnsHappy();
         //   Console.WriteLine(strings);
         //   connection.Open();
         ////   String selectQuery = "SELECT * FROM db_images.myimages WHERE ID = '" + textBoxID.Text + "'";
         //   String selectQuery = "SELECT * FROM db_images.myimages WHERE ID = "+ "bulbasaur" + "";

         //   command = new SqlCommand(selectQuery, connection);

         //   da = new SqlDataAdapter(command);

         //   DataTable table = new DataTable();

         //   da.Fill(table);



         //   byte[] img = (byte[])table.Rows[0][1];

         //   MemoryStream ms = new MemoryStream(img);

         //   //Image pokemon = Image.FromStream(ms);
         //   //Image.SourcePropert
            
         //   da.Dispose();
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
                object ext;
        void Yolo()
        {
            string SQL = "use PokemonSearch; SELECT image FROM AllPokemon WHERE imageName =" + "'bulbasaur'" +  "";
            string tempFile = @"C:\";

            
            using (SqlCommand cmd = new SqlCommand(SQL, connection))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = 14;
                connection.Open();
                
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        ext = rdr[0];
                        //File.WriteAllBytes(tempFile + ext, (byte[])rdr["image"]);

                        File.WriteAllBytes(tempFile + "Bulbasasur" + ".png",(byte[])rdr["image"]);

                    }
                }

                // OS run test
                // Opens the image
                Process prc = new Process();
                prc.StartInfo.FileName = tempFile + "Bulbasasur.png";
                prc.Start();
                connection.Close();
            }
        }

    }

}

