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
        Dal dal = new Dal();
        string userPokemonName;
        string oldpokemon;


        /// <summary>
        /// Prints for testing, what user have inputed
        /// set's pokemons name to users input
        /// </summary>
        /// <param name="a"></param>
        public void Happens(string uPoke)
        {
            oldpokemon = userPokemonName;
            this.userPokemonName = uPoke;
            Console.WriteLine(userPokemonName);
        }

        /// <summary>
        /// We change the image in wpf app
        /// </summary>
        /// <param name="image"></param>
        Image img;
        public void ChangeImage(Image image)
        {
            this.img = image;
            string filePath = @"C:\" + userPokemonName + ".png";
            try
            {
                //Creates a copy of the file we got from sql
                //and we use a copy, and when we delete the file
                //copy is also deleted
                BitmapImage imagee = new BitmapImage();
                imagee.BeginInit();
                imagee.CacheOption = BitmapCacheOption.OnLoad;
                imagee.UriSource = new Uri(filePath);
                imagee.EndInit();
                image.Source = imagee;

                // image.Source = new BitmapImage(new Uri(@"C:\" + userPokemonName + ".png"));
            }
            catch (Exception exe)
            {
                image.Source = new BitmapImage(new Uri(@"C:\notFound.png"));
                Console.WriteLine(exe.Message);
            }
        }

        /// <summary>
        /// Remove the COPY of the image we get from the sql
        /// </summary>
        public void RemoveImage()
        {
            string filePath = @"C:\" + oldpokemon + ".png";

            if (oldpokemon != userPokemonName)
                try
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                            Console.WriteLine("removed " + oldpokemon);
                    }
                }
                catch (Exception exexexe)
                {
                    Console.WriteLine(exexexe.Message);
                }
        }

        /// <summary>
        /// Gets image and prints it to C drive
        /// </summary>
        //ext is incase i need the byte[]
        object ext;
        public void RetriveImage()
        {
            // string sql = "use PokemonSearch; SELECT image FROM AllPokemon WHERE imageName = '" + pokemonName + "'";
            string sql = dal.Querty(userPokemonName);
            string tempFile = @"C:\";
            //make a folder that stores all images
            //and check if its in the folder, if its not it takes from the server
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, Dal.Connection))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = 14;
                    dal.ConnectionOpen();

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            ext = rdr[0];
                            //File.WriteAllBytes(tempFile + ext, (byte[])rdr["image"]);
                            File.WriteAllBytes(tempFile + userPokemonName + ".png", (byte[])rdr["image"]);

                            AAA = ((byte[])rdr[0]);
                            ShowPhoto(AAA);
                        }
                        rdr.Close();
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
                }
            }
            catch (Exception exex)
            {
                Console.WriteLine(exex.Message);
            }
            finally
            {
                dal.ConnectionClose();
            }
        }
        /// <summary>
        /// Make it look pretty
        /// </summary>
        byte[] aaa;
        public byte[] AAA
        {
            get
            {
                return aaa;
            }
            set
            {
                aaa = value;
            }
        }
        void ShowPhoto(byte[] a)
        {

            // Get the raw bytes of the image
            byte[] photoSource = a;

            // Create the bitmap object
            // NOTE: This is not a GDI+ Bitmap object
            BitmapImage bitmap = new BitmapImage();
            MemoryStream strm = new MemoryStream();

            // Well-known work-around to make Northwind images work
            // Read the image into the bitmap object

            int offset = 0;
            strm.Write(photoSource, offset, photoSource.Length);
            bitmap.BeginInit();
            bitmap.StreamSource = strm;
            // Set the Image with the Bitmap
            bitmap.EndInit();
            img.Source = bitmap;
            Console.WriteLine("e");

        }
        public void FirstImage()
        {
            // string sql = "use PokemonSearch; SELECT image FROM AllPokemon WHERE imageName = '" + pokemonName + "'";
            string tripleA = "pokemonNotFound";
            string sql = dal.Querty(tripleA);
            string tempFile = @"C:\";
            //make a folder that stores all images
            //and check if its in the folder, if its not it takes from the server
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, Dal.Connection))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = 14;
                    dal.ConnectionOpen();

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            ext = rdr[0];
                            //File.WriteAllBytes(tempFile + ext, (byte[])rdr["image"]);
                            File.WriteAllBytes(tempFile + tripleA + ".png", (byte[])rdr["image"]);
                        }
                        rdr.Close();
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
                }
            }
            catch (Exception exex)
            {
                Console.WriteLine(exex.Message);
            }
            finally
            {
                dal.ConnectionClose();
            }
        }


    }
}

