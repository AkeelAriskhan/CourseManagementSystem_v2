using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem_v2
{
    internal class Course
    {
        public string courseId { get; set; }
        public string title { get; set; }
        public string Duration { get; set; }
        public decimal Price { get; set; }

        public Course(string courseId, string title, string duration, decimal price)
        {
            this.courseId = courseId;
            this.title = title;
            Duration = duration;
            Price = price;
        }
    }
}
