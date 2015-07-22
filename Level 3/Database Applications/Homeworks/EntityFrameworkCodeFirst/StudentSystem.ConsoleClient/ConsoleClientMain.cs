using System;
using System.Data.Entity;
using System.Linq;
using StudentSystem.Data;
using StudentSystem.Data.Migrations;

namespace StudentSystem.ConsoleClient
{
    public class ConsoleClientMain
    {
        static void Main(string[] args)
        {
            var context = new StudentSystemContext();
            //var count = context.Courses.Count();
            //Console.WriteLine(count);
            
            //var migrationStrategy = new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>();
            //migrationStrategy.InitializeDatabase(context);

           

            
            


        }
    }
}
