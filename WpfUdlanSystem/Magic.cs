using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Controls;

using System.Diagnostics;
using System.Windows.Media.Imaging;

namespace WpfUdlanSystem
{
    class Magic
    {
        SqlConnection connection = new SqlConnection(@"Data Source=ZBC-EMA-23111;Initial Catalog=master; Integrated Security=True");
        /// <summary>
        /// Prints for testing, what user have inputed
        /// </summary>
        string userPokemonName;
        public void Happens(string a)
        {
            this.userPokemonName = a;
            Console.WriteLine(userPokemonName);
        }
        public void ChangeImage(Image image)
        {
            try
            {
                image.Source = new BitmapImage(new Uri(@"C:\" + userPokemonName + ".png"));
            }
            catch(Exception exe)
            {
                image.Source = new BitmapImage(new Uri(@"C:\notFound.png"));
                Console.WriteLine(exe.Message);
            }
        }

        /// <summary>
        /// Gets image and prints it to C drive
        /// </summary>
        object ext;
        string pokemonName;
        public void RetriveImage(string uPokemonName)
        {
            this.pokemonName = uPokemonName;
            string sql = "use PokemonSearch; SELECT image FROM AllPokemon WHERE imageName = '" + pokemonName + "'";
            string tempFile = @"C:\";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = 14;
                    connection.Open();

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            ext = rdr[0];
                            //File.WriteAllBytes(tempFile + ext, (byte[])rdr["image"]);
                            File.WriteAllBytes(tempFile + pokemonName + ".png", (byte[])rdr["image"]);

                        }
                    }
                    #region Opens the file 
                    // OS run test
                    // Opens the image
                    //try
                    //{
                    //    Process prc = new Process();
                    //    prc.StartInfo.FileName = tempFile + pokemonName + ".png";
                    //    prc.Start();
                    //}
                    //catch (Exception xe)
                    //{
                    //    Console.WriteLine(xe.Message.ToString());
                    //}
                    #endregion
                    connection.Close();
                }
            }
            catch (Exception exex)
            {
                Console.WriteLine(exex.Message);
            }
        }
    }
}
