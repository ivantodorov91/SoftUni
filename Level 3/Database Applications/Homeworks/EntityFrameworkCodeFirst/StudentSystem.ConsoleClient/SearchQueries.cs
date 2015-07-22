using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystem.Data;

namespace StudentSystem.ConsoleClient
{
    public static class SearchQueries
    {
        public static void firstQuery()
        {
            var context = new StudentSystemContext();
            var students = context.Students.Select(s => new
            {
                s.Name,
                Homeworks = s.Homeworks.Select(h => new
                {
                    h.Content,
                    h.HomeworkContentType
                })
            });
        }

        public static void secondQuery()
        {
            var context = new StudentSystemContext();
            var courses = context.Courses
                .OrderBy(c => c.StartDate)
                .ThenByDescending(c => c.EndDate)
                .Select(c => new
                {
                    c.Name,
                    c.Description,
                    c.Resources
                });
        }

        public static void thirdQuery()
        {
            var context = new StudentSystemContext();
            var courses = context.Courses
                .Where(c => c.Resources.Count > 6)
                .OrderByDescending(c => c.Resources.Count)
                .ThenByDescending(c => c.StartDate)
                .Select(c => new
                {
                    c.Name,
                    c.Resources.Count
                });
        }

        public static void fourthQuery()
        {
            var context = new StudentSystemContext();
            var courseDate = new DateTime(2011, 06, 12);
            var courses = context.Courses
                .Where(c => c.StartDate <= courseDate &&
                            c.EndDate >= courseDate)
                .OrderByDescending(c => c.Students.Count)
                .ThenByDescending(c => (c.EndDate - c.StartDate).Days)
                .Select(c => new
                {
                    c.Name,
                    c.StartDate,
                    c.EndDate,
                    CourseDuration = (c.EndDate - c.StartDate).Days,
                    c.Students.Count
                });
        }

        public static void fifthQuery()
        {
            var context = new StudentSystemContext();
            var students = context.Students
                .OrderByDescending(s => s.Courseses.Sum(c => c.Price))
                .ThenByDescending(s => s.Courseses.Count)
                .ThenBy(s => s.Name)
                .Select(s => new
                {
                    s.Name,
                    s.Courseses.Count,
                    Price = s.Courseses.Sum(c => c.Price),
                    AveragePrice = s.Courseses.Average(c => c.Price)
                });

        }
    }
}
