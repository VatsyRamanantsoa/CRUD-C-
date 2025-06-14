using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoostC__CRUD.Models;

namespace BoostC__CRUD.Controller
{
    internal class PersonneController
    {

        public static List<Personne> getAllPersonne()
        {
            SqlConnection conn = null;
            string query = "SELECT * FROM PERSONNE";

            List<Personne> personnes = new List<Personne>();

            try
            {
                conn = DbConnection.GetConnection();
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                
                while (reader.Read())
                {
                    personnes.Add(new Personne(
                        Convert.ToInt32(reader["Id"]),
                        reader["Nom"].ToString(),
                        reader["Prenom"].ToString(),
                        reader["Age"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Age"]),
                        reader["Adresse"].ToString()
                    ));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return personnes;
        }


        public static void addPersonne(Personne personne)
        {

            string query = "INSERT INTO PERSONNE(Nom,Prenom,Age,Adresse)VALUES(@nom, @prenom,@age, @adresse)";

            SqlConnection conn = null;
            try
            {
                conn = DbConnection.GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nom", personne.nom);
                cmd.Parameters.AddWithValue("@prenom", personne.prenom);
                cmd.Parameters.AddWithValue("@age", personne.age);
                cmd.Parameters.AddWithValue("@adresse", personne.adresse);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        public static void updatePersonne(Personne personne)
        {

            string query= "UPDATE PERSONNE SET Nom = @nom , Prenom = @prenom, Age = @age,Adresse= @adresse WHERE id = @id ";

            SqlConnection conn = null;
            try
            {
                conn = DbConnection.GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", personne.id);
                cmd.Parameters.AddWithValue("@nom", personne.nom);
                cmd.Parameters.AddWithValue("@prenom", personne.prenom);
                cmd.Parameters.AddWithValue("@age", personne.age);
                cmd.Parameters.AddWithValue("@adresse", personne.adresse);
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        public static void deletePersonne(int Id)
        {
            string query = "DELETE FROM PERSONNE WHERE id = @id";
            SqlConnection conn = null;
            try
            {
                conn = DbConnection.GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }
        }
    }
}
