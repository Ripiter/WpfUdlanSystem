using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WpfUdlanSystem
{
    class Dal
    {
        string connectionString = @"Data Source=ZBC-EMA-23111;Initial Catalog=master; Integrated Security=True";
        static SqlConnection connection = new SqlConnection(@"Data Source=ZBC-EMA-23111;Initial Catalog=master; Integrated Security=True");

        public static SqlConnection Connection
        {
            get
            {
                return connection;
            }
            set
            {
                connection = value;
            }
        }

        public string ConnectionString
        {
            get
            {
                return this.connectionString;
            }
            set
            {
                this.connectionString = value;
            }
        }

        public void ConnectionOpen()
        {
            connection.Open();
        }
        public void ConnectionClose()
        {
            connection.Close();
        }
        public string Querty(string pokemonName)
        {
            string sql = "use PokemonSearch; SELECT image FROM AllPokemon WHERE imageName = '" + pokemonName + "'";
            return sql;
        }
       

    }
}
