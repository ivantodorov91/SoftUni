using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftuniModel;

namespace EntityFramework
{
    class MainMethod
    {
        static void Main(string[] args)
        {
            //var context = new SoftUniEntities();
            //var totalCount = context.Employees.Count();

            //var sw = new Stopwatch();
            //sw.Start();
            //DatabaseSearchQueries.nativeQuery();
            //Console.WriteLine("Native: {0}", sw.Elapsed);

            //sw.Restart();

            //DatabaseSearchQueries.linqQuery();
            //Console.WriteLine("Linq: {0}", sw.Elapsed);

            //sw.Stop();

            DatabaseChanges.ChangeRecord();

        }
    }
}
