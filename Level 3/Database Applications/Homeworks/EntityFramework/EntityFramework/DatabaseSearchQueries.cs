using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public static class DatabaseSearchQueries
    {
        public static void firstQuery()
        {
            var context = new SoftUniEntities();
            var employees = context.Employees
                .Where(e => e.Projects.Any(
                    p => p.StartDate.Year >= 2001 && p.EndDate.Value.Year <= 2003))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerName = e.Employee1.FirstName,
                    Projects = e.Projects.Select(p => new
                    {
                        p.Name,
                        p.StartDate,
                        p.EndDate
                    })
                });

            foreach (var employee in employees)
            {
                Console.WriteLine("--{0} {1} ManId: {2}",
                    employee.FirstName,
                    employee.LastName,
                    employee.ManagerName);
                foreach (var project in employee.Projects)
                {
                    Console.WriteLine("{0} {1} {2}",
                        project.Name,
                        project.StartDate.Date,
                        project.EndDate.HasValue ? project.EndDate.Value.Date.ToString() : "not finished");
                }
            }
        }

        public static void secondQuery()
        {
            var context = new SoftUniEntities();
            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count())
                .ThenBy(a => a.Town.Name)
                .Select(a => new
                {
                    a.AddressText,
                    Town = a.Town.Name,
                    a.Employees.Count
                })
                .Take(10);

            foreach (var address in addresses)
            {
                Console.WriteLine("{0}, {1} - {2} employees",
                    address.AddressText,
                    address.Town,
                    address.Count);
            }
        }

        public static void thirdQuery()
        {
            var context = new SoftUniEntities();
            var employee = context.Employees
                .Where(e => e.EmployeeID == 147)
                .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                Projects = e.Projects
                    .Select(p => p.Name)
                    .OrderBy(p => p)
            }).ToList();

            foreach (var emp in employee)
            {
                Console.WriteLine("{0} {1} {2}",
                emp.FirstName,
                emp.LastName,
                emp.JobTitle);

                foreach (var project in emp.Projects)
                {
                    Console.WriteLine(project);
                }
            }            
        }

        public static void forthQuery()
        {
            var context = new SoftUniEntities();
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .Select(d => new
                {
                    d.Name,
                    Manager = d.Employee.LastName,
                    Employees = d.Employees
                        .Select(e => new
                        {
                            e.FirstName,
                            e.LastName,
                            e.HireDate,
                            e.JobTitle
                        })
                }).ToList();

            Console.WriteLine(departments.Count());

            foreach (var department in departments)
            {
                Console.WriteLine("--{0} - Manager: {1}, Employees: {2}",
                    department.Name,
                    department.Manager,
                    department.Employees.Count());
            }
        }

        public static void linqQuery()
        {
            var context = new SoftUniEntities();
            var emps =
                context.Employees.Where(e => e.Projects.Any(p => p.StartDate.Year == 2002)).Select(e => e.FirstName).ToList();
        }

        public static void nativeQuery()
        {
            DbContext haha = new SoftUniEntities();
            var emps2 = haha.Database.SqlQuery<string>(@"SELECT e.FirstName FROM Employees e
                                        JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
                                        JOIN Projects p ON p.ProjectID = ep.ProjectID
                                        WHERE YEAR(p.StartDate) = 2002").ToList();
        }
           
    }
}
