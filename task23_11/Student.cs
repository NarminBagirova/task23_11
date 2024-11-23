using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task23_11
{
    public class Student
    {
        private static int _idCounter = 1;
        public int Id { get; private set; }
        public string Fullname { get; set; }
        public int Point { get; set; }

        public Student(string fullname, int point)
        {
            if (string.IsNullOrEmpty(fullname))
                throw new ArgumentException("Fullname cannot be empty.");

            if (point < 0 || point > 100)
                throw new ArgumentException("Point must be between 0 and 100.");

            Id = _idCounter++;
            Fullname = fullname;
            Point = point;
        }

        public void StudentInfo()
        {
            Console.WriteLine($"ID: {Id}, Fullname: {Fullname}, Point: {Point}");
        }
    }
}
