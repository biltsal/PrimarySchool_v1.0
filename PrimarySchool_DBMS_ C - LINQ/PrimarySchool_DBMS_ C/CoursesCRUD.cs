using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchool_DBMS__C
{
    class CoursesCRUD
    {
        public static void CreateCourse()
        {
            Console.WriteLine("Provide the title of the Course :");
            string title = Console.ReadLine();
            Console.WriteLine("Provide the MainSubject :");
            string courseMainSubject = Console.ReadLine();
            Console.WriteLine("Is the Course Full Time ? (True/False) : ");
            bool courseFullTime = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Provide the Start Date :");
            DateTime courseStartDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Provide the End Date :");
            DateTime courseEndDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Provide the Trainer's ID :");
            int courseTrainerID = int.Parse(Console.ReadLine());

            //Data maping object to our database  
            PrimarySchoolClassesDataContext dbContext = new PrimarySchoolClassesDataContext();
            
                Course objCourse = new Course();
                {
                    objCourse.Title = title;
                    objCourse.MainSubject = courseMainSubject;
                    objCourse.IsFullTime = courseFullTime;
                    objCourse.StartDate = courseStartDate;
                    objCourse.EndDate = courseEndDate;
                    objCourse.TrainerID = courseTrainerID;
                }

                
                //dbContext.COURSEs.InsertOnSubmit(objCourse);
                 
                //dbContext.SubmitChanges();
            
            


            


        }

        
        public static void RetrieveDataOnCourses()
        {
            using (PrimarySchoolClassesDataContext dbContext = new PrimarySchoolClassesDataContext())
            {

                var coursesData = (from s in dbContext.COURSEs
                                   select s).ToList();



                foreach (var item in coursesData)
                {
                    Console.WriteLine("Course Title : {0} \t\n" +
                                        "MainSubject : {1} \t\n" +
                                        "Full Time : {2} \t\n" +
                                        "Start Date : {3} \t\n" +
                                        "End Date : {4} \t\n" +
                                        "Trainer ID : {5} \t\n", item.Title, item.MainSubject, item.IsFullTime, item.StartDate, item.EndDate, item.TrainerID);
                }
                                  

            }




        }









        public static void UpdateCourse()
        {
            Console.Write("Please provide Course ID to be Updated : ");
            int courseID = int.Parse(Console.ReadLine());
            Console.WriteLine("You are ONLY permitted to change Trainer, Start Date & End Date Fields! Otherwise create a new COURSE..");

            using (PrimarySchoolClassesDataContext dbContext = new PrimarySchoolClassesDataContext())
            {
                int minAvailableTrainerID = dbContext.TRAINERs.Min(s => s.TrainerID);
                int maxAvailableTrainerID = dbContext.TRAINERs.Max(s => s.TrainerID);

                try
                {
                    var checkRights = (from s in dbContext.COURSEs
                                       where s.CourseID == courseID
                                       select s).SingleOrDefault();

                    if (checkRights != null)
                    {
                        Console.Clear();
                        Console.WriteLine(" Course Found..");
                        Console.Write("Updated Start Date ");
                        DateTime startDate = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine();
                        Console.Write("Updated End Date ");
                        DateTime endDate = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine();

                        bool flag = true;
                        Console.Write("Update Trainer ID ");
                        int trainerID = int.Parse(Console.ReadLine());

                        while (flag)
                        {

                            bool condition = trainerID >= minAvailableTrainerID && trainerID <= maxAvailableTrainerID;

                            if (condition)
                            {
                                flag = false;
                            }
                            else
                            {
                                Console.WriteLine("Trainer ID does not exist.. Please try again!");
                                Console.Write("Update Trainer ID ");
                                trainerID = int.Parse(Console.ReadLine());

                            }

                        }


                        COURSE courseUpdate = dbContext.COURSEs.SingleOrDefault(s => s.CourseID == courseID);
                        courseUpdate.StartDate = startDate;
                        courseUpdate.EndDate = endDate;
                        courseUpdate.TrainerID = trainerID;

                        try
                        {
                            dbContext.SubmitChanges();
                            Console.WriteLine("Update Action Succeeded..");


                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Update Action in Database Failed {e.Message}");

                        }
                    }

                    else
                        Console.WriteLine("Course NOT Found.. Please try again...");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Caught Exception {ex.Message}"); ;
                }
                finally
                {
                    Console.WriteLine("Problem ? ..contact the Administrator.");
                }





            }



        }




        public static void DeleteCourse()
        {
            Console.WriteLine("Provide the Course ID you want to delete :");
            int courseID = int.Parse(Console.ReadLine());

            using (PrimarySchoolClassesDataContext dbContext = new PrimarySchoolClassesDataContext())
            {

                var checkCourseID = (from s in dbContext.COURSEs
                                     where s.CourseID == courseID
                                     select s).SingleOrDefault();


                try
                {
                    

                    if (checkCourseID != null)
                    {
                        Console.WriteLine("Course Found..");
                        COURSE course = dbContext.COURSEs.SingleOrDefault(s => s.CourseID == courseID);
                        dbContext.COURSEs.DeleteOnSubmit(course);
                        dbContext.SubmitChanges();
                    }

                    else
                        Console.WriteLine("Course NOT Found.. Please try again...");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Caught Exception {ex.Message}"); ;
                }
                finally
                {
                    Console.WriteLine("If COURSE WITH ID {0} is NOT found, contact the Administrator.. ", courseID);
                }



            }



            


        }










        public static void PrintCreateRetrieveUpdateDeleteOnCourses()
        {
            PrimarySchoolClassesDataContext dbContext = new PrimarySchoolClassesDataContext();

            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("1. Create New Course");
                Console.WriteLine("2. Retrieve Data Regarding Course");
                Console.WriteLine("3. Update Course Details");
                Console.WriteLine("4. Delete Course from Database");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Make a choice : ");
                string option = Console.ReadLine();
                int choice;
                int.TryParse(option, out choice);


                bool choiceFlag = true;
                while (choiceFlag)
                {
                    if (choice > 0 && choice < 6)
                        choiceFlag = false;
                    else
                    {
                        Console.WriteLine("Please try again ....");

                        choice = int.Parse(Console.ReadLine());
                    }


                }



                Console.Clear();
                switch (choice)
                {
                    case 1:
                        CreateCourse();
                        break;
                    case 2:
                        RetrieveDataOnCourses();
                        Console.ReadKey();
                        break;
                    case 3:
                        UpdateCourse();
                        break;
                    case 4:
                        DeleteCourse();
                        break;
                    case 5:
                        Console.WriteLine("You are leaving Head Master Menu");
                        flag = false;

                        break;
                    default:
                        Console.WriteLine("Something went wrong");
                        break;
                }

            }
        }









    }
}
