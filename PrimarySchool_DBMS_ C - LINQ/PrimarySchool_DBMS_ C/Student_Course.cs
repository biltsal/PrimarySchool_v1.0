using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchool_DBMS__C
{
    class Student_Course
    {
        public Student Pupil { get; set; }
        public Course Course { get; set; }
        public List<Student> StudentsPerCourse { get; set; }

        public Student_Course(Course course, Student pupil)
        {
            Course = course;
            Pupil = pupil;
        }

        



    }
}
