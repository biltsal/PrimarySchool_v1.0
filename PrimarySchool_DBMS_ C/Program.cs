using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PrimarySchool_DBMS__C
{

    
    class Program
    {

        
        static void Main(string[] args)
        {
            bool flag = true;
            while(flag)
            {
                
                int choice = User.UserLogin();

                if (choice != 0)
                {
                    GMenu.Menu();
                    flag = false;
                }
                else
                    flag = true;
            }
            
            //need to create encryption for user
            
            
           


            







        }
    }
}
