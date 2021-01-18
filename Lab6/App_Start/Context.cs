using Lab6.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.App_Start
{
    public partial class Context : DbContext
    {
        public Context() : 
            base("name=schoolEntities")
        {
        }
        public DbSet<School> School { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<TeacherSubject> TeacherSubject { get; set; }
    }
}
