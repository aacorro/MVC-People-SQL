using PeopleMVC.Models;
using System.Data.SqlClient;
using System.Reflection;

namespace PeopleMVC.Services
{
    public class PeopleDAO : IPeopleDataService
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public int Delete(PeopleModel person)
        {
            int newIdNumber = -1;

            string sqlStatement = "delete from People where Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@Id", person.Id);

                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return newIdNumber;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<PeopleModel> GetAllPeople()
        {
            List<PeopleModel> foundPeople= new List<PeopleModel>();
            string sqlStatement = "select * from People";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader= command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundPeople.Add(new PeopleModel { Id = (int)reader[0], FirstName = (string)reader[1], LastName = (string)reader[2], Age= (int)reader[3], Email = (string)reader[4] });
                    }
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return foundPeople;
        }

        public PeopleModel GetPeopleById(int id)
        {
            PeopleModel foundPerson = null;

            string sqlStatement = "select * from people where Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundPerson = new PeopleModel { Id = (int)reader[0], FirstName = (string)reader[1], LastName = (string)reader[2], Age = (int)reader[3], Email = (string)reader[4] };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return foundPerson;

        }

        public int Insert(PeopleModel personModel)
        {
            int newIdNumber = -1;

            string sqlStatement = "insert into people (FirstName, LastName, Age, Email) values (@FirstName, @LastName, @Age, @Email)";

            using (SqlConnection connection =new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@FirstName", personModel.FirstName);
                command.Parameters.AddWithValue("@LastName", personModel.LastName);
                command.Parameters.AddWithValue("@Age", personModel.Age);
                command.Parameters.AddWithValue("@Email", personModel.Email);

                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return newIdNumber;
        }

        public List<PeopleModel> SearchPeople(string searchTerm)
        {
            List<PeopleModel> foundpeople= new List<PeopleModel>();

            string sqlStatement = "select * from people where FirstName like @FirstName";

            using (SqlConnection connection= new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    sqlStatement, connection);
                command.Parameters.AddWithValue("@FirstName", '%' + searchTerm + '%');

                try
                {
                    connection.Open();
                    SqlDataReader reader= command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundpeople.Add(new PeopleModel { Id = (int)reader[0], FirstName = (string)reader[1], LastName = (string)reader[2], Age = (int)reader[3], Email = (string)reader[4] });
                    }
                }
                catch (Exception ex) 
                { 
                    Console.WriteLine(ex.Message);
                }
            }
            return foundpeople;
        }

        public int Update(PeopleModel person)
        {
            int newIdNumber = -1;

            string sqlStatement = "update people set FirstName = @FirstName, LastName = @LastName, Age = @Age, Email = @Email where Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@FirstName", person.FirstName);
                command.Parameters.AddWithValue("@LastName", person.LastName);
                command.Parameters.AddWithValue("@Age", person.Age);
                command.Parameters.AddWithValue("@Email", person.Email);
                command.Parameters.AddWithValue("@Id", person.Id);

                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return newIdNumber;
        }
        
    }
}
