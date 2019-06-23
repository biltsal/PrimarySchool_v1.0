using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchool_DBMS__C
{
    class Student
    {
        public int StudentID {get;set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Student_Course> StudentPerCourse { get; set; }
        public User UserId { get; set; }
        public List<Assignment_Student> AssignmentsPerStudent { get; set; }


        public Student(int studentId, string firstName, string lastName, DateTime dateOfBirth, User userId, List<Assignment_Student> list_Assignment_Student)
        {
            StudentID = studentId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            UserId = userId;
            //AssignmentsPerStudent = list_Assignment_Student;
        }







        public static void StudentDatesOfSubmission()
        {
            //find dates of Submission per student per course

            using (PrimarySchoolClassesDataContext dbContext = new PrimarySchoolClassesDataContext())
            {
                Console.Write("Please give the Course ID :");
                string option = Console.ReadLine();
                int choice;
                int.TryParse(option, out choice);

                //check whether Course ID exists
                var checkID = (from s in dbContext.COURSEs
                               where s.CourseID == choice
                               select s).SingleOrDefault();

                if (checkID != null)
                {
                    Console.WriteLine("Record exists");
                }
                else
                    Console.WriteLine("Record does not exist.Please try again..");




                //var studentCourses = from s in dbContext.STUDENT_COURSEs
            }



        }


        public static void PrintDailySchedulePerCourse(PrimarySchoolClassesDataContext dbContext, int courseID)
        {

            var dailySchedule = (from d in dbContext.DAYs
                                join dc in dbContext.DAY_COURSEs on d.DayID equals dc.DayID
                                join e in dbContext.COURSEs on dc.CourseID equals e.CourseID
                                where e.CourseID == courseID
                                select new
                                {
                                    CourseTitle = e.Title,
                                    d.WeekDay
                                }).ToList();
            foreach (var element in dailySchedule)
            {
                Console.WriteLine("Course Title : {0}  Day of Week :{1}", element.CourseTitle,  element.WeekDay);
            }
            
            
        }

        public static void PrintDailyScheluleForAllCoursePerStudent()
        {
            Console.Clear();

            using (PrimarySchoolClassesDataContext dbContext = new PrimarySchoolClassesDataContext())
            {
                Console.WriteLine("Please provide the Student ID : ");
                int result = int.Parse(Console.ReadLine());


                var searchCourses = (from sc in dbContext.STUDENT_COURSEs
                                     where sc.StudentID == result
                                     select sc.CourseID).ToList();

                foreach (var element in searchCourses)
                {
                    PrintDailySchedulePerCourse(dbContext, element);
                }
            }


               



        }

        public static void PrintAssignmentDatesOfSubmissionPerCourse(PrimarySchoolClassesDataContext dbContext, int studentID)
        {


            var assignmentSubmissionDate = (from a in dbContext.ASSIGNMENTs
                                             join s in dbContext.ASSIGNMENT_STUDENTs on a.AssignmentID equals s.AssignmentID
                                             join e in dbContext.STUDENTs on s.StudentID equals e.StudentID
                                             join c in dbContext.COURSEs on a.CourseID equals c.CourseID
                                             where s.StudentID == studentID
                                             select new
                                             {
                                                 CourseTitle = c.Title,
                                                 a.Title,
                                                 a.SubmissionDate
                                             }).ToList();

            foreach (var element in assignmentSubmissionDate)
            {
                Console.WriteLine("Course Title : {0}  Assignment Title :{1}  Submission Date : {2}", element.CourseTitle, element.Title, element.SubmissionDate);
            }

            
        }





        public static void PrintDatesOfSubmissionOfAssignmentPerCourse()
        {
            Console.Clear();
            using (PrimarySchoolClassesDataContext dbContext = new PrimarySchoolClassesDataContext())
            {
                Console.Write("Please provide the Student ID : ");
                int result = int.Parse(Console.ReadLine());

                PrintAssignmentDatesOfSubmissionPerCourse(dbContext, result);


                Console.ReadKey();
            }

               


        }

        public static void SubmitAnyAssignment(int studentID, int userID)
        {
            Console.Write("Please provide Assignment ID : ");
           
            int AssignmentID = int.Parse(Console.ReadLine());

            using (PrimarySchoolClassesDataContext dbContext = new PrimarySchoolClassesDataContext())
            {
                try
                {
                    var checkRights = (from s in dbContext.STUDENTs
                                       where s.UserID == userID
                                       && s.StudentID == studentID
                                       select s).SingleOrDefault();

                    if (checkRights != null)
                    {
                        Console.WriteLine("User Found..");
                        CheckIfAssignmentExistsAndUpdate(studentID, AssignmentID);
                    }

                    else
                        Console.WriteLine("User NOT Found.. Please try again...");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Caught Exception {ex.Message}"); ;
                }
                finally
                {
                    Console.WriteLine("If User is NOT found, contact the Administrator..");
                }


                Console.ReadKey();
            }

                

        }


        //edo stamatisa 22.05.2019
        public static void CheckIfAssignmentExistsAndUpdate(int studentID, int AssignmentID)
        {
            using (PrimarySchoolClassesDataContext dbContext = new PrimarySchoolClassesDataContext())
               

                try
            {
                var checkAssignment = (from s in dbContext.ASSIGNMENT_STUDENTs
                                   where s.StudentID == studentID
                                   && s.AssignmentID == AssignmentID
                                   select s).SingleOrDefault();

                if (checkAssignment != null)
                {
                    Console.WriteLine("Record exists..");
                    ASSIGNMENT_STUDENT studentUpdate = dbContext.ASSIGNMENT_STUDENTs.SingleOrDefault(s => s.StudentID == studentID && s.AssignmentID == AssignmentID);
                        studentUpdate.IsSubmitted = true;
                        studentUpdate.DateSubmitted = DateTime.Now;




                            try
                    {
                        dbContext.SubmitChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Update Action in Database Failed {e.Message}");
                        
                    }



                }
                    
                else
                    Console.WriteLine("Record DOES NOT Exist.. Submit Failed...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Caught Exception {ex.Message}"); ;
            }
            finally
            {
                Console.WriteLine("If Assignment DOES NOT Exist.. Please try again");
            }



            
        }


    }
}
