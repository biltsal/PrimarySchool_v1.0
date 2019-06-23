using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchool_DBMS__C
{
    




    class Day
    {
        public int DayID { get; set; }
        public string DayOfWeek { get; set; }
        public List<Day_Course> List_Day_Course { get; set; }


        public Day(int dayId, string dayOfWeek, List<Day_Course> list_Day_Course)
        {
            DayID = dayId;
            DayOfWeek = dayOfWeek;
            //List_Day_Course = list_Day_Course;
        }





    }
}
