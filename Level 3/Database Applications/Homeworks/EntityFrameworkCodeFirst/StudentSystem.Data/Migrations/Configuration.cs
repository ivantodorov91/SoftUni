using System.Collections.Generic;
using StudentSystem.Models.Models;
using StudentSystem.Models.Types;

namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "StudentSystem.Data.StudentSystemContext";
        }

        protected override void Seed(StudentSystemContext context)
        {
            context.Students.AddOrUpdate(
                s => s.Name,
                new Student
                {
                    Name = "Joro",
                    Birthday = new DateTime(1991, 10, 22),
                    Courseses = new List<Course>()
                    {
                        new Course
                        {
                            Name = "Math",
                            Description = "Skuchnata matematika brat",
                            Price = 500m,
                            EndDate = new DateTime(2012, 11, 11),
                            StartDate = new DateTime(2011, 11, 11),
                            Homeworks = new List<Homework>(),
                            Resources = new List<Resource>()
                        },
                        new Course
                        {
                            Name = "Turbologiq",
                            Description = "Skuchnata matematika brat",
                            Price = 500m,
                            EndDate = new DateTime(2012, 11, 11),
                            StartDate = new DateTime(2011, 11, 11),
                            Homeworks = new List<Homework>(),
                            Resources = new List<Resource>()
                        }
                    },
                    Homeworks = new List<Homework>(),
                    PhoneNumber = "094949494",
                    RegistrationDate = DateTime.Now
                }
                );
            context.Students.AddOrUpdate(
                s => s.Name,
                new Student
                {
                    Name = "Pancho",
                    Birthday = new DateTime(2000, 01, 13),
                    Courseses = new List<Course>()
                    {
                        new Course
                        {
                            Name = "Biology",
                            Description = "I tq e skuchna",
                            Price = 200m,
                            EndDate = new DateTime(2011, 02, 10),
                            StartDate = new DateTime(2011, 5, 5),
                            Homeworks = new List<Homework>(),
                            Resources = new List<Resource>()
                            {
                                new Resource
                                {
                                    Name = "Nqkakuv resurs :D",
                                    TypeOfResource = TypeOfResource.Document,
                                    URL = "www.gotinresurs.com"
                                }
                            }
                        }
                    },
                    Homeworks = new List<Homework>()
                    {
                        new Homework
                        {
                            HomeworkContentType = HomeworkContentType.PDFApplication,
                            Content = "Super zle",
                            SubmissionDate = new DateTime(2011, 03, 22)
                        }
                    },
                    PhoneNumber = "2929292922",
                    RegistrationDate = DateTime.Now
                }
                );


            context.SaveChanges();
        }
    }
}
