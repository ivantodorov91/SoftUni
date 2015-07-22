using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public static class DatabaseChanges
    {
        public static void ChangeRecord()
        {
            var context1 = new SoftUniEntities();
            var context2 = new SoftUniEntities();

            context1.Employees.Find(1).FirstName = "context1";
            context2.Employees.Find(1).FirstName = "context2";
            
            context1.SaveChanges();
            context2.SaveChanges();
        }
    }
}
