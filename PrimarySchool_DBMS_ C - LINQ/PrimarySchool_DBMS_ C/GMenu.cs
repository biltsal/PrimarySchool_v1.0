using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchool_DBMS__C
{
    class GMenu
    {

        public static void Menu()
        {
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("Main Menu");
                Console.WriteLine("----------");
                Console.WriteLine("1. Student");
                Console.WriteLine("2. Trainer");
                Console.WriteLine("3. Head Master");
                Console.WriteLine("4. Exit");
                Console.Write("Make a choice : ");
                string option = Console.ReadLine();
                int choice;
                int.TryParse(option, out choice);


                bool choiceFlag = true;
                while (choiceFlag)
                {
                    if (choice > 0 && choice < 5)
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
                        StudentMenu();
                        break;
                    case 2:
                        TrainerMenu();
                        Console.ReadKey();
                        break;
                    case 3:
                        HeadMasterMenu();
                        break;
                    case 4:
                        Console.WriteLine("You are leaving Head Master Menu");
                        flag = false;

                        break;
                    default:
                        Console.WriteLine("Something went wrong");
                        break;
                }

            }



        }

        public static void HeadMasterMenu()
        {
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("1. CRUD ON Courses");
                Console.WriteLine("2. CRUD ON Students Per Courses");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Make a choice : ");
                string option = Console.ReadLine();
                int choice;
                int.TryParse(option, out choice);


                bool choiceFlag = true;
                while (choiceFlag)
                {
                    if (choice > 0 && choice < 4)
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
                        CoursesCRUD.PrintCreateRetrieveUpdateDeleteOnCourses();
                        break;
                    case 2:
                        Students_CourseCRUD.PrintCreateRetrieveUpdateDeleteOnStudents_Courses();
                        Console.ReadKey();
                        break;
                                       
                    case 3:
                        Console.WriteLine("You are leaving Head Master Menu");
                        flag = false;

                        break;
                    default:
                        Console.WriteLine("Something went wrong");
                        break;
                }

            }



        }

        public static void StudentMenu()
        {
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("STUDENT MENU");
                Console.WriteLine("===============");
                Console.WriteLine("1. Daily Schedule Per Course");
                Console.WriteLine("2. Dates of Submission of the Assignments Per Course");
                Console.WriteLine("3. Submit any Assignment");
                Console.WriteLine("4. Exit");
                Console.Write("Make a choice : ");
                string option = Console.ReadLine();
                int choice;
                int.TryParse(option, out choice);


                bool choiceFlag = true;
                while (choiceFlag)
                {
                    if (choice > 0 && choice < 5)
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
                        Student.PrintDailyScheluleForAllCoursePerStudent();
                        break;
                    case 2:
                        Console.WriteLine("Dates of Submission of the Assignments Per Course");
                        Student.PrintDatesOfSubmissionOfAssignmentPerCourse();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Write("Please provide Student ID : ");
                        int studentID = int.Parse(Console.ReadLine());
                        Console.Write("Please provide Student ID : ");
                        int userID = int.Parse(Console.ReadLine());
                        Student.SubmitAnyAssignment(studentID, userID);
                        //NEEDS TO BE CHANGED AND BECOME MORE FUNCTIONAL & VALIDATED IN A LATER VERSION
                        break;
                    case 4:
                        Console.WriteLine("You are leaving student's Menu");
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Something went wrong");
                        break;
                }

            }



        }

        public static void TrainerMenu()
        {
            bool flag = true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("TRAINER MENU");
                Console.WriteLine("=============");
                Console.WriteLine("1. View All the Courses you are Enrolled");
                Console.WriteLine("2. View all the Students Per Course");
                Console.WriteLine("3. View all the Assignments Per Student Per Course");
                Console.WriteLine("4. Mark Assignment Per Student per Course");
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
                        Trainer.GetCoursesData();
                        break;
                    case 2:
                        Trainer.PrintStudentsForAllCourses();
                        Console.ReadKey();
                        break;
                    case 3:
                        Trainer.PrintAssignmentsForSingleStudent();
                        
                        break;
                    case 4:
                        Console.WriteLine("Mark Assignment Per Student per Course");
                        flag = false;
                        break;
                    case 5:
                        Console.WriteLine("Exit");
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




































































































































    

