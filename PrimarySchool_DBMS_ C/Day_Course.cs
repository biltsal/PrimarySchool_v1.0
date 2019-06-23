using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchool_DBMS__C
{
    class Day_Course
    {
        public Day Day { get; set; }
        public Course Course { get; set; }


        public Day_Course(Day day, Course course)
        {
            Day = day;
            Course = course;
        }


    }
}
