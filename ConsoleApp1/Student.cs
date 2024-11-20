using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Student:Person
    {
        protected int StudentID { get; set; }

        public int GetStudentID()
        {
        return StudentID;
        }
    }
}
