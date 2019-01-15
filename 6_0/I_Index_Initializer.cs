using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _6_0
{
    class SCC9_Index_Initializer
    {

        public Dictionary<int, string> GetErrors()
        {
            Dictionary<int, string> webErrors = new Dictionary<int, string>
            {
                [404] = "Page not Found",
                [302] = "Page moved, but left a forwarding address.",
                [500] = "The web server can't come out to play today."
            };

            return webErrors;
        }

        static void Main()
        {
            var classList = new Enrollment()
            {
                new Student("Lessie", "Crosby"),
                new Student("Vicki", "Petty"),
                new Student("Ofelia", "Hobbs"),
                new Student("Leah", "Kinney"),
                new Student("Alton", "Stoker"),
                new Student("Luella", "Ferrell"),
                new Student("Marcy", "Riggs"),
                new Student("Ida", "Bean"),
                new Student("Ollie", "Cottle"),
                new Student("Tommy", "Broadnax"),
                new Student("Jody", "Yates"),
                new Student("Marguerite", "Dawson"),
                new Student("Francisca", "Barnett"),
                new Student("Arlene", "Velasquez")
              
            };
        }        
    }

    public class Enrollment : IEnumerable<Student>
    {
        private List<Student> allStudents = new List<Student>();

        public void Enroll(Student s)
        {
            allStudents.Add(s);
        }

        public IEnumerator<Student> GetEnumerator() => ((IEnumerable<Student>)allStudents).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<Student>)allStudents).GetEnumerator();
    }

    public static class StudentExtensions
    {
        //Map whatever method adds items to a collection to a method named 'Add' with an extension.
        public static void Add(this Enrollment e, Student s) => e.Enroll(s);
    }

    public class Student
    {
        private string v1;
        private string v2;

        public Student(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public int Id { get; set; }
        public int Name { get; set; }
    }
}
