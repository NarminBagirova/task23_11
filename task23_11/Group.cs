using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task23_11
{
    public class Group
    {
        public string GroupNo { get; set; }
        public int StudentLimit { get; set; }

        private Student[] Students;

        private int _studentCount = 0;
        public Group(string groupNo, int studentLimit)
        {
            if (studentLimit < 5 || studentLimit > 18)
            {
                Console.WriteLine("Student limit must be between 5 and 18.");
                return;
            }

            GroupNo = groupNo;
            StudentLimit = studentLimit;
            Students = new Student[studentLimit];
        }

        public bool CheckGroupNo(string groupNo)
        {
            if (groupNo.Length != 5)
                return false;

            if (!char.IsUpper(groupNo[0]) || !char.IsUpper(groupNo[1]))
                return false;

            for (int i = 2; i < 5; i++)
            {
                if (!char.IsDigit(groupNo[i]))
                    return false;
            }

            return true;
        }

        public void AddStudent(Student student)
        {
            if (_studentCount < StudentLimit)
            {
                Students[_studentCount] = student;
                _studentCount++;
                Console.WriteLine($"Student {student.Fullname} added to the group.");
            }
            else
            {
                Console.WriteLine("Cannot add more students. Group is full.");
            }
        }

        public Student GetStudent(int id)
        {
            if (Students == null || Students.Length == 0) return null;

            foreach (var student in Students)
                if (student != null && student.Id == id) return student;

            return null;
        }

        public Student[] GetAllStudents()
        {
            return Students;
        }
    }
}
