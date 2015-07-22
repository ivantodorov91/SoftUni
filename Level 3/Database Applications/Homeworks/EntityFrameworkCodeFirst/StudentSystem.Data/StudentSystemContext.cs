namespace StudentSystem.Data
{
    using Models.Models;

    using System.Data.Entity;


    public class StudentSystemContext : DbContext
    {
        
        public StudentSystemContext()
            : base("name=StudentSystemContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }
        public virtual IDbSet<Homework> Homeworks { get; set; }
        public virtual IDbSet<Resource> Resources { get; set; }
        public virtual IDbSet<Student> Students { get; set; }
    }
}