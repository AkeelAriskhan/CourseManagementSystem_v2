﻿using System;
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
            try
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
            catch (Exception ex) 
            {
               Console.WriteLine(ex.Message);
            }

        }
        public void ReadCourses()
        {


            try
            {
                using (var connection = new SqlConnection(connectionstring))
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
            catch (Exception ex) {
             Console.WriteLine(ex.Message);
            }
           
        }
        public void getcoursebyid(int id)
        {
            try
            {
                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"select* from Courses where courseId=@courseId";
                    command.Parameters.AddWithValue("@courseId", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine($"courseId{reader.GetString(0)} title{reader.GetString(1)}Duration{reader.GetString(2)} price {reader.GetDecimal(3)}");
                        }

                    }


                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
           
        }

        public void UpdateCourse(string courseId, string title, string Duration, decimal Price)
        {


            try
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
                    var rowafect = command.ExecuteNonQuery();
                    if (rowafect > 0)
                    {
                        Console.WriteLine("Course Updated succsesfuly");
                    }
                    else
                    {
                        Console.WriteLine("coures not found");

                    }

                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
          
        }
        public void DeleteCourse(string courseId) 
        {



            try
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
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                    }

        }
        //public string CapitalizeTitle(string title) 
        
        //{
        // var words=title.Split(' ');
        //    for(var i=0; i<words.Length; i++)
        //    {
        //        var  word[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
        //    }
        // return string.Join(" ", words);
        //}
    }
}
