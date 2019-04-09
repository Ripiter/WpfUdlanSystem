using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Controls;


namespace WpfUdlanSystem
{
    class Magic
    {
        string b;
        public void Happens(string a)
        {
            this.b = a;
        }


        public string ReturnsHappy()
        {
            return b;
        }

        public void SetImage(System.Windows.Controls.Image pokemonImg)
        {
            //byte[] bytes;
            //string fileName;
            //string myCon = "Data Source=PIZZASERVER;Initial Catalog=PokemonSearch; Integrated Security=True";
            //SqlConnection con = new SqlConnection(myCon);
            //con.Open();
            //string query = "select * fromn profiledetails where imageName="bulbasaur";
            //SqlCommand cmd = new SqlCommand(query);
            //cmd.Connection = con;
            //SqlDataReader sdr = cmd.ExecuteReader();
            //sdr.Read();
            //bytes = (byte[])sdr["AllPokemon"];
            //fileName = sdr["imageName"].ToString();
            //pokemonImg.Source = "data:image/jpg;base74," + Convert.ToBase64String(bytes);
        }

        string a;
        public void ReadingFromSql()
        {
            //catalog master
            SqlConnection con = new SqlConnection(@"Data Source=ZBC-EMA-23111;Initial Catalog=master; Integrated Security=True");


            string query = "use PokemonSearch; Select * from AllPokemon";
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows)

            while (reader.Read())
            {
                string name = reader[0].ToString();
                    var img = reader[1];
               
            a = string.Format(name,img);
            }
            Console.WriteLine(a);

        }
    }
}
