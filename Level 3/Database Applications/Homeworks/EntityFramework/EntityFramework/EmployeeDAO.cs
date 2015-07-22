using EntityFramework;

namespace SoftuniModel
{
    public static class EmployeeDAO   
    {
        public static SoftUniEntities ContextEntities = new SoftUniEntities();

        public static void Add(Employee employee)
        {
            
            var softuniContext = new SoftUniEntities();
            ContextEntities.Employees.Add(employee);
            ContextEntities.SaveChanges();
        }

        public static Employee FindByKey(object key)
        {
            return ContextEntities.Employees.Find(key);
        }

        public static void Modify(Employee employee)
        {
            var employeeToChange = FindByKey(employee.EmployeeID);

            employeeToChange.FirstName = employee.FirstName;
            
            employeeToChange.LastName = employee.LastName;
            employeeToChange.MiddleName = employee.MiddleName;
            employeeToChange.JobTitle = employee.JobTitle;
            employeeToChange.Salary = employee.Salary;
            employeeToChange.ManagerID = employee.ManagerID;
            employeeToChange.AddressID = employee.AddressID;
            employeeToChange.DepartmentID = employee.DepartmentID;
            employeeToChange.HireDate = employee.HireDate;

            ContextEntities.SaveChanges();
        }

        public static void Delete(Employee employee)
        {
            ContextEntities.Employees.Remove(employee);
            ContextEntities.SaveChanges();
        }
    }
}
