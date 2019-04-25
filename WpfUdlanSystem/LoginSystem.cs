using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;

namespace WpfUdlanSystem
{
    class LoginSystem
    {
        Dal dal = new Dal();

        #region variables 
        string userUsername;
        string userPassword;

        string dbUsername;
        string dbPassword;
        #endregion

        #region Get, Set

        #endregion


        public void ReadingFromDb()
        {
            string commandText = "use PokemonSearch; select password from LoginTable WHERE Username = @Username";

            using (SqlConnection connection = new SqlConnection(dal.ConnectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.Add("@Username", SqlDbType.NVarChar);//.Value = userUsername;
                command.Parameters["@Username"].Value = userUsername;

                connection.Open();
                using(SqlDataReader rdr = command.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        string ext = rdr[0].ToString();
                        Console.WriteLine(ext);

                        DecryptPassword(ext);
                    }
                    rdr.Close();
                }
                connection.Close();
            }            
        }

        void DecryptPassword(string encryptedPass)
        {
            //Decrypt password from db
            byte[] hashBytes = Convert.FromBase64String(encryptedPass);

            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            string passQuestionMark = string.Format("{0}", userPassword);
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(passQuestionMark, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            Compare(hashBytes, hash);
        }

        void Compare(byte[] hashBytees, byte[] haash)
        {
            bool correctPass = true;
            //Compers uUsername with userUsername
            //and compers upassword with userPassword
            for (int i = 0; i < 20; i++)
            {
                if (hashBytees[i + 16] != haash[i])
                    correctPass = false;
            }
             
            //Show message go to next window,
            //if wrong message show "Wrong pass"
            if (correctPass == true)
            {
                Console.WriteLine("Correct pass");
            }
            else
            {
                Console.WriteLine("Wrong pas");
            }
        }


        public void UserLogin(string uUsername, string uPassword)
        {
            this.userUsername = uUsername;
            this.userPassword = uPassword;
        }
    }
}
