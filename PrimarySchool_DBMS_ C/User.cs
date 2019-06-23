using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchool_DBMS__C
{
    class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }


        public User(int id, string userName, string password, string role)
        {
            ID = id;
            UserName = userName;
            Password = password;
            Role = role;
        }







        public override string ToString()
        {
            string result = "User ID" + " " + ID + "\n" +
                            "Username" + " " + UserName + "\n" +
                            "Password" + " " + Password + "\n";
                        

            return result;
        }

        public static int UserLogin()
        {
            //find dates of Submission per student per course

            using (PrimarySchoolClassesDataContext dbContext = new PrimarySchoolClassesDataContext())
            {
                Console.Write("Please give the Username :");
                string userName = Console.ReadLine();


                while (string.IsNullOrEmpty(userName))
                {
                    Console.Clear();
                    Console.WriteLine("Username can't be empty! Input Username once more");
                    userName = Console.ReadLine();
                }

                Console.Write("Please give the Password :");
                string password = Console.ReadLine();

                while (string.IsNullOrEmpty(password))
                {
                    Console.Clear();
                    Console.WriteLine("Password can't be empty! Input password once more");
                    password = Console.ReadLine();
                }

                int userID;

                //check whether User exists
                var checkID = (from s in dbContext.UsersDetails
                               where s.Username == userName && s.Password == password
                               select s).SingleOrDefault();



                if (checkID != null)
                {
                    Console.WriteLine($"Record exists. You are a {checkID.Role}");

                    return userID = checkID.UserID;

                }
                else
                {
                    Console.WriteLine("User does not exist.Please try again..");
                    userID = 0;

                }




                return userID;





            }



        }




    }
}
