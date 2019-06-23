using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchool_DBMS__C
{
    class Trainer
    {
        public int Trainer_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SubjectName { get; set; }
        public User UserId { get; set; }


        public Trainer(int id, string firstName, string lastName, string subjectName, User user)
        {
            Trainer_ID = id;
            FirstName = firstName;
            LastName = lastName;
            SubjectName = subjectName;
            UserId = user;
        }







        public static void PrintStudentsForSingleCourse(PrimarySchoolClassesDataContext dbContext, int courseID)
        {

            
                var StudentsPerCourse = (from s in dbContext.STUDENTs
                                         from e in s.STUDENT_COURSEs
                                         where e.COURSE.CourseID == courseID
                                         select s).ToList();



            int count = 0;
            foreach (var element in StudentsPerCourse)
            {
                count++;
                Console.Write($"{count} )" + "\t" + "First Name " + element.FirstName + "\t");
                Console.WriteLine("Last Name " + element.LastName + "\t");
                
            }
        }

        public static void PrintStudentsForAllCourses()
        {

            Console.Write("Please provide Trainer ID : ");
            string trainerId = Console.ReadLine();


            while (string.IsNullOrEmpty(trainerId))
            {
                Console.Clear();
                Console.WriteLine("Student ID is obligatory! Input Student ID once more");
                trainerId = Console.ReadLine();
            }

            int trainerID = int.Parse(trainerId);



            using (PrimarySchoolClassesDataContext dbContext = new PrimarySchoolClassesDataContext())
            {
                var CourseIdPerTrainer = (from s in dbContext.COURSEs
                                          where s.TrainerID == trainerID
                                          select s.CourseID).ToList();

                var CourseNamePerTrainer = (from s in dbContext.COURSEs
                                            where s.TrainerID == trainerID
                                            select s.Title).ToList();


                for (int i = 0; i < CourseNamePerTrainer.Count; i++)
                {
                    Console.WriteLine(CourseNamePerTrainer[i]);


                    PrintStudentsForSingleCourse(dbContext, CourseIdPerTrainer[i]);



                }
            }

            //int trainerID = 2; //εδω πρεπει να βαζω το trainerID γιατι το ζηταει η print
            //Trainer.PrintStudentsForAllCourses(dbContext, trainer_ID);





            

       
        }

        public static void PrintAssignmentsForSingleStudent()
        {
            using (PrimarySchoolClassesDataContext dbContext = new PrimarySchoolClassesDataContext())
            {
                Console.Clear();
                Console.Write("Please provide the Student ID for which you want to find Assignments per course :");
                string studentid = Console.ReadLine();

                while (string.IsNullOrEmpty(studentid))
                {
                    Console.Clear();
                    Console.WriteLine("Course ID can't be empty! Input Course ID once more");
                    studentid = Console.ReadLine();
                }

                int studentID = int.Parse(studentid);


                //check that student id exists
                var StudentIdExists = (from s in dbContext.STUDENTs
                                       where s.StudentID == studentID
                                       select s).SingleOrDefault();

                if (StudentIdExists != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Student has been found.. Please wait to print available assignments per course per student");



                    var assignmentPerStudent = from c in dbContext.COURSEs
                                               join a in dbContext.ASSIGNMENTs
                                               on c.CourseID equals a.CourseID
                                               join s in dbContext.ASSIGNMENT_STUDENTs
                                               on a.AssignmentID equals s.AssignmentID
                                               where s.StudentID == studentID
                                               select new
                                               {
                                                   CourseTitle = c.Title,
                                                   Assignment = a.Title


                                               };

                    assignmentPerStudent.ToList().ForEach(x => Console.WriteLine(x));





                }











                



            }




        }


        
        public static void GetCoursesData()
        {


            Console.Write("Please provide Trainer ID in order to see his/her Courses : ");
            string trainerId = Console.ReadLine();


            while (string.IsNullOrEmpty(trainerId))
            {
                Console.Clear();
                Console.WriteLine("Course ID can't be empty! Input Course ID once more");
                trainerId = Console.ReadLine();
            }

            int trainerID = int.Parse(trainerId);


            using (PrimarySchoolClassesDataContext dbContext = new PrimarySchoolClassesDataContext())
            {
                var courseDetails = from course in dbContext.COURSEs
                                    join trainer in dbContext.TRAINERs
                                    on course.TrainerID equals trainer.TrainerID
                                    where trainer.TrainerID == trainerID
                                    orderby course.Title, course.IsFullTime, course.StartDate
                                    select new
                                    {
                                        CourseTitle = course.Title,
                                        Subject = course.MainSubject,
                                        Start = course.StartDate,
                                        trainer = trainer.LastName

                                    };

                Console.Clear();
                Console.WriteLine($"Trainer ID {trainerID}");
                courseDetails.ToList().ForEach(s => Console.WriteLine("Course Title {0}  \t Subject {1}  \t Start Date {2} \t Trainer LastName {3}", s.CourseTitle, s.Subject, s.Start, s.trainer));
            }


            Console.ReadKey();



        }

        //edo stamatisa.....
        //public static void CreateCourse ()
        //{
        //    Console.Clear();
        //    Console.Write("Please provide the Course Title :");
        //    string courseTitle = Console.ReadLine();
        //    Console.Write("Please provide the Course Subject :");
        //    string courseSubject = Console.ReadLine();
        //    Console.Write("Please provide the Course's Period (Full / Part Time) :");
        //    bool isFullPeriod = bool.Parse(Console.ReadLine());
        //    Console.Write("Please provide the Course's Start Date :");
        //    DateTime courseStartDate = Convert.ToDateTime(Console.ReadLine());
        //    Console.Write("Please provide the Course's End Date :");
        //    DateTime courseEndDate = Convert.ToDateTime(Console.ReadLine());
        //    Console.Write("Please provide the Trainer's ID :");
        //    int trainersID = Convert.ToInt16(Console.ReadLine());



        //    using (PrimarySchoolClassesDataContext dbContext = new PrimarySchoolClassesDataContext())
        //    {
        //        Course newCourse = new Course()
        //        {
        //            Title = courseTitle,
        //            MainSubject = courseSubject,
        //            IsFullTime = isFullPeriod,
        //            StartDate = courseStartDate,
        //            EndDate = courseEndDate,
        //            TrainerID = trainersID
        //        };

        //        dbContext.COURSEs.InsertOnSubmit(newCourse);
        //        dbContext.SubmitChanges();

        //    }
        //}




        






    }
     
         
}
