using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchool_DBMS__C
{
    class Assignment_Student
    {
        public int AssignmentNumber { get; set; }
        public Student Pupil { get; set; }
        public double OralMark { get; set; }
        public double TotalMark { get; set; }
        public bool IsSubmitted {get;set;}
        public DateTime DateSubmitted { get; set; }

        public Assignment_Student(int assignmentNumber, Student student, double oralMark, double totalMark, bool isSubmitted, DateTime dateSubmitted)
        {
            AssignmentNumber = assignmentNumber;
            Pupil = student;
            OralMark = oralMark;
            TotalMark = totalMark;
            IsSubmitted = isSubmitted;
            DateSubmitted = dateSubmitted;
        }




    }
}
