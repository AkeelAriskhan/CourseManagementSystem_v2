using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem_v2
{
    internal class CourseRepository
    {
        private readonly string connectionstring = "Server=(localdb)\\MSSQLLocalDB; database=CourseManagement; Trusted_Connection=true;TrustServerCertificate=true";

        public void CreateCourse(string courseId, string title, string Duration, decimal Price)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"insert into  Courses(CourseId,Title,Duration,Price) values(@courseId,@title,@Duration,@Price );";
                command.Parameters.AddWithValue("@courseId", courseId);
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@Duration", Duration);
                command.Parameters.AddWithValue("@Price", Price);
                command.ExecuteNonQuery();

            }

        }
        public void ReadCourses()
        {
            using(var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"select* from Courses";
                using (var reader = command.ExecuteReader()) 
                {
                    while (reader.Read()) 
                    {
                        Console.WriteLine($"courseId{reader.GetString(0)} title{reader.GetString(1)}Duration{reader.GetString(2)} price {reader.GetDecimal(3)}");
                    }
                
                }
            }
        }
        public void getcoursebyid(int id)
        {
          using( var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"select* from Courses where courseId=@courseId";
                command.Parameters.AddWithValue("@courseId", id);
                using (var reader = command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        Console.WriteLine($"courseId{reader.GetString(0)} title{reader.GetString(1)}Duration{reader.GetString(2)} price {reader.GetDecimal(3)}");
                    }

                }


            }
        }

        public void UpdateCourse(string courseId, string title, string Duration, decimal Price)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"UPDATE Courses SET title=@title, Duration=@Duration,Price=@Price where courseId=courseId ";
                command.Parameters.AddWithValue("@courseId", courseId);
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@Duration", Duration);
                command.Parameters.AddWithValue("@Price", Price);
                   var rowafect=command.ExecuteNonQuery();
                if (rowafect > 0)
                {
                    Console.WriteLine("Course Updated succsesfuly");
                }
                else {
                    Console.WriteLine("coures not found");

                }

            }
        }
        public void DeleteCourse(string courseId) 
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"DELETE* from Courses where courseId=@courseId";
                command.Parameters.AddWithValue("@courseId", courseId);
                var rowafect = command.ExecuteNonQuery();
                if (rowafect > 0)
                {
                    Console.WriteLine("Course Delete succsesfuly");
                }
                else
                {
                    Console.WriteLine("coures not found");

                }



            }

        }
    }
}
