using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem_v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Course course1 = new Course("C_001", "phython", "3months", 10);
            Console.WriteLine(course1.ToString());
            var coursemanage = new CourseRepository();
            bool exit = true;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Course Management System:");
                Console.WriteLine("1. Add a Course");
                Console.WriteLine("2. View All Courses");
                Console.WriteLine("3. Update a Course");
                Console.WriteLine("4. Delete a Course");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option:");
                int num = Convert.ToInt32(Console.ReadLine());

                switch (num)
                {

                    case 1:
                        Console.Clear();
                        Console.Write(" Enter a courseId:");
                        var courseId = Console.ReadLine();
                        Console.Write(" Enter a title:");
                        var title = Console.ReadLine();
                        Console.Write(" Enter a Duration:");
                        var Duration = Console.ReadLine();
                        Console.Write("Enter a course price : ");
                        //var Price = coursemanage.ValidateCoursePrice();
                        var Price=decimal.Parse(Console.ReadLine());
                        coursemanage.CreateCourse(courseId, title, Duration, Price);
                        break;
                    case 2:
                        Console.Clear();
                        //coursemanage.ReadCourses();

                        break;
                    case 3:
                        Console.Clear();
                        Console.Clear();
                        Console.Write(" Enter a courseId:");
                        var courseId1 = Console.ReadLine();
                        Console.Write(" Enter a title:");
                        var title1 = Console.ReadLine();
                        Console.Write(" Enter a Duration:");
                        var Duration1 = Console.ReadLine();
                        //Console.Write("Enter a course price : ");
                        //var Price1 = coursemanage.ValidateCoursePrice();
                        var Price1 = decimal.Parse(Console.ReadLine());


                        //coursemanage.UpdateCourse(courseId1, title1, Duration1, Price1);
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write(" Enter a courseId:");
                        var courseId2 = Console.ReadLine();
                        //coursemanage.DeleteCourse(courseId2);
                        break;
                    case 5:
                        exit = false;
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("invalid input try again");

                        break;

                }
                Console.WriteLine("enter any key to exit");
                Console.ReadKey();
            }
        }
    }
}
