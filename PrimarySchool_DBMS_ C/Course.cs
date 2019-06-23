using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchool_DBMS__C
{
    enum Type
    {
        FullTime,
        PartTime
    }

    


    class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public string MainSubject { get; set; }
        public bool IsFullTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TrainerID { get; set; }
        //public List<Student> Students { get; set; }
        //public List<Trainer> Trainers { get; set; }
        //public List<Student_Course> StudentPerCourse { get; set; }
        //public List<Day_Course> List_Day_Course { get; set; }

        public Course(string title, string mainsubject, bool isFullTime, DateTime startDate, DateTime endDate, int trainerID)
        {
            Title = title;
            MainSubject = mainsubject;
            IsFullTime = isFullTime;
            StartDate = startDate;
            EndDate = endDate;
            TrainerID = trainerID;
            

        }

        public Course()
        {

        }




        //public List<Trainer> TrainersPerCourse(SqlDataReader readerTrainers)
        //{
        //    //List<Trainer> Trainers = new List<Trainer>();

        //    while (readerTrainers.Read())
        //    {

        //        Trainer Trainer = new Trainer()
        //        {
        //            Trainer_ID = readerTrainers.GetInt32(0),
        //            First_Name = readerTrainers.GetString(1),
        //            Last_Name = readerTrainers.GetString(2),
        //            SubjectName = readerTrainers.GetString(3)

        //        };
        //        Trainers.Add(Trainer);

        //    }

        //    return Trainers;

        //}

        public override string ToString()
        {
            string result = "Course ID" + " " + CourseID + "\n" +
                            "Title" + " " + Title + "\n" +
                            "MainSubject" + " " + MainSubject + "\n" +
                            "isFullTime" + " " + IsFullTime + "\n" +
                            "StartDate" + " " + StartDate + "\n" +
                            "EndDate" + " " + EndDate + "\n";
                            
                            


            return result;
        }

        public static void DailySchedulePerCourse()
        {
            //var query = from s in 



        }

    }


}
