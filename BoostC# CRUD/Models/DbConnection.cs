using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostC__CRUD.Models
{
    internal class DbConnection
    {

        private static readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\L2\C#\Boost\BoostC# CRUD\BoostC# CRUD\CrudPersonne.mdf;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            try
            {
                return new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool Teste_connection()
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connexion reussi");
                    return true;


                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur de connexion : " + ex.Message);
                    return false;

                }
            }
        }
    }
}
