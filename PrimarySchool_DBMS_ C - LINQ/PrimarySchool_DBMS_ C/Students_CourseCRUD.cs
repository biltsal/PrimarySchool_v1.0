using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchool_DBMS__C
{
    class Students_CourseCRUD : ICrudable
    {

        public void CreateData()
        {

            Console.Write("Please provide Student ID for which new record has to be created : ");
            string studentId = Console.ReadLine();


            while (string.IsNullOrEmpty(studentId))
            {
                Console.Clear();
                Console.WriteLine("Student ID can't be empty! Input Student ID once more");
                studentId = Console.ReadLine();
            }

            int studentID = int.Parse(studentId);


            Console.Write($"Please provide Course ID for Student ID {studentID} for which new record has to be created : ");
            string currentCourse = Console.ReadLine();
            //int oldCourseID = int.Parse(Console.ReadLine());

            while (string.IsNullOrEmpty(currentCourse))
            {
                Console.Clear();
                Console.WriteLine("Course ID can't be empty! Input Course ID once more");
                currentCourse = Console.ReadLine();
            }

            int newCourseID = int.Parse(currentCourse);

                        

            Console.WriteLine("A check has to be implemented, to ensure that current record exists! Please wait..");

            using (PrimarySchoolClassesDataContext dbContext = new PrimarySchoolClassesDataContext())
            {


                try
                {
                    //check that student id exists
                    var deleteStudentCourseDetails = (from s in dbContext.STUDENT_COURSEs
                                                      where s.StudentID == studentID && s.CourseID == newCourseID
                                                      select s).SingleOrDefault();

                    if (deleteStudentCourseDetails != null)
                    {
                        Console.Clear();
                        Console.WriteLine($" There is an existing record of Student ID {studentID} that follows a given course. " +
                            "You are not allowed to create a new record. Process terminated.. ");

                        Console.ReadKey();


                        // Query the database for the row to be deleted.First you have to delete the record and then 
                        // create a new one with the updated details. Linq does not support insert function
                        // in junction tables.
                    }
                    else
                    {
                        STUDENT_COURSE newInsert = new STUDENT_COURSE();
                        {
                            newInsert.CourseID = newCourseID;
                            newInsert.StudentID = studentID;
                            newInsert.Grade = 0;

                        }

                        dbContext.STUDENT_COURSEs.InsertOnSubmit(newInsert);
                        try
                        {
                            dbContext.SubmitChanges();
                            Console.WriteLine("Create the Course that a Student Follows Succeeded..");
                            //Console.ReadKey();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Create Action in Database Failed {ex.Message}");

                        }


                    }


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





        public void UpdateData()
        {

                Console.Write("Please provide Student ID for which change has to be made : ");
                string studentId = Console.ReadLine();


                while (string.IsNullOrEmpty(studentId))
                {
                    Console.Clear();
                    Console.WriteLine("Course ID can't be empty! Input Course ID once more");
                    studentId = Console.ReadLine();
                }

                int studentID = int.Parse(studentId);


            Console.Write("Please provide Course ID that is currently followed by the Student : ");
                string currentCourse = Console.ReadLine();
                //int oldCourseID = int.Parse(Console.ReadLine());

                while (string.IsNullOrEmpty(currentCourse))
                {
                    Console.Clear();
                    Console.WriteLine("Course ID can't be empty! Input Course ID once more");
                    currentCourse = Console.ReadLine();
                }

                int oldCourseID = int.Parse(currentCourse);

                Console.WriteLine("You are ONLY permitted to change the Course that a Student follows! Otherwise create a new COURSE..");


                Console.Write("Please provide new Course ID : ");
                string newCourse = Console.ReadLine();
            

                while (string.IsNullOrEmpty(newCourse))
                {
                    Console.Clear();
                    Console.WriteLine("Course ID can't be empty! Input Course ID once more");
                    newCourse = Console.ReadLine();
                }

                int newCourseID = int.Parse(newCourse);

                Console.Write("Please provide Course Grade if there is any : ");
                decimal grade = Convert.ToDecimal(Console.ReadLine());


            using (PrimarySchoolClassesDataContext dbContext = new PrimarySchoolClassesDataContext())
            {
                

                try
                {
                    //check that student id exists
                    var deleteStudentCourseDetails = (from s in dbContext.STUDENT_COURSEs
                                                        where s.StudentID == studentID && s.CourseID == oldCourseID
                                                        select s).SingleOrDefault();

                    if (deleteStudentCourseDetails != null)
                    {
                        Console.Clear();
                        Console.WriteLine(" Student that has a given course Found..");

                        Console.ReadKey();
                        

                        // Query the database for the row to be deleted.First you have to delete the record and then 
                        // create a new one with the updated details. Linq does not support insert function
                        // in junction tables.
                        

                        
                        dbContext.STUDENT_COURSEs.DeleteOnSubmit(deleteStudentCourseDetails);
                        

                        try
                        {
                            dbContext.SubmitChanges();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            
                        }



                        

                        STUDENT_COURSE newInsert = new STUDENT_COURSE();
                        {
                            newInsert.CourseID = newCourseID;
                            newInsert.StudentID = studentID;
                            newInsert.Grade = grade;
                            
                        }

                        dbContext.STUDENT_COURSEs.InsertOnSubmit(newInsert);


                        try
                        {
                            dbContext.SubmitChanges();
                            Console.WriteLine("Change the Course that a Student Follows Succeeded..");
                            //Console.ReadKey();

                        }
                        catch (Exception ex)
                        {
                             Console.WriteLine($"Update Action in Database Failed {ex.Message}");

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











        public void RetrieveData()
        {
            using (PrimarySchoolClassesDataContext dbContext = new PrimarySchoolClassesDataContext())
            {

                               
                    var studentsPerCourse = (from a in dbContext.COURSEs
                                                    join s in dbContext.STUDENT_COURSEs on a.CourseID equals s.CourseID
                                                    join e in dbContext.STUDENTs on s.StudentID equals e.StudentID
                                                    orderby s.CourseID, a.IsFullTime, e.LastName ascending
                                                    select new
                                                        {
                                                            a.Title,
                                                            a.IsFullTime,
                                                            e.FirstName,
                                                            e.LastName,  
                                                            s.CourseID,
                                                            s.StudentID
                                                        }).ToList();


                
                 
                foreach (var element in studentsPerCourse)
                    {
                        Console.WriteLine("Course Title : {0}  Full Time :{1}  First Name {2} Last Name : {3} Course ID {4} Student ID {5}", element.Title, element.IsFullTime, 
                                            element.FirstName, element.LastName, element.CourseID, element.StudentID );
                    }


                //foreach (var item in coursesData)
                //{
                //    Console.WriteLine("Course Title : {0} \t\n" +
                //                        "MainSubject : {1} \t\n" +
                //                        "Full Time : {2} \t\n" +
                //                        "Start Date : {3} \t\n" +
                //                        "End Date : {4} \t\n" +
                //                        "Trainer ID : {5} \t\n", item.Title, item.MainSubject, item.IsFullTime, item.StartDate, item.EndDate, item.TrainerID);
                //}


            }
        }

        public void DeleteData()
        {

            Console.Write("Please provide Student ID for which deletion has to be made : ");
            string studentId = Console.ReadLine();


            while (string.IsNullOrEmpty(studentId))
            {
                Console.Clear();
                Console.WriteLine("Student ID is obligatory! Input Student ID once more");
                studentId = Console.ReadLine();
            }

            int studentID = int.Parse(studentId);


            Console.Write("Please provide Course ID that is currently followed by the Student : ");
            string currentCourse = Console.ReadLine();
           

            while (string.IsNullOrEmpty(currentCourse))
            {
                Console.Clear();
                Console.WriteLine("Course ID is obligatory and it cannot be empty! Input Course ID once more");
                currentCourse = Console.ReadLine();
            }

            int oldCourseID = int.Parse(currentCourse);

            Console.WriteLine("You are ABOUT to permanently delete the Course that a Student follows! ");


            

            using (PrimarySchoolClassesDataContext dbContext = new PrimarySchoolClassesDataContext())
            {


                try
                {
                    //check that student id exists
                    var deleteStudentCourseDetails = (from s in dbContext.STUDENT_COURSEs
                                                      where s.StudentID == studentID && s.CourseID == oldCourseID
                                                      select s).SingleOrDefault();

                    if (deleteStudentCourseDetails != null)
                    {
                        Console.Clear();
                        Console.WriteLine(" Student that has a given course Found..");

                        Console.ReadKey();


                        // Query the database for the row to be deleted.First you have to delete the record and then 
                        // create a new one with the updated details. Linq does not support insert function
                        // in junction tables.



                        dbContext.STUDENT_COURSEs.DeleteOnSubmit(deleteStudentCourseDetails);


                        try
                        {
                            dbContext.SubmitChanges();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);

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





        public static void PrintCreateRetrieveUpdateDeleteOnStudents_Courses()
        {
            Students_CourseCRUD newStudentsPerCourse = new Students_CourseCRUD();
            


            PrimarySchoolClassesDataContext dbContext = new PrimarySchoolClassesDataContext();

            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("CRUD ON STUDENTS PER COURSES");
                Console.WriteLine("-----------------------------");
                Console.WriteLine();
                Console.WriteLine("1. Create New Course");
                Console.WriteLine("2. Retrieve Data Regarding Course");
                Console.WriteLine("3. Update Course Details");
                Console.WriteLine("4. Delete Course from Database");
                Console.WriteLine("5. Exit");
                Console.Write("Make a choice : ");
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
                        newStudentsPerCourse.CreateData();
                        break;
                    case 2:
                        newStudentsPerCourse.RetrieveData();
                        Console.ReadKey();
                        break;
                    case 3:
                        newStudentsPerCourse.UpdateData();
                        break;
                    case 4:
                        newStudentsPerCourse.DeleteData();
                        break;
                    case 5:
                        Console.WriteLine("You are leaving Head Master Sub-Menu");
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
