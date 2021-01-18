using Lab6.App_Start;
using System.Data.Entity;


namespace Lab6.App_Start
{
    public class CustomDbInitializer : DropCreateDatabaseAlways<Context>
    {

        protected override void Seed(Context context)
        {
            context.School.Add(new Lab6.Models.School { name = "Number 1", year = 1999 });
            context.School.Add(new Lab6.Models.School { name = "Number 2", year = 2000 });
            context.School.Add(new Lab6.Models.School { name = "Number 3", year = 2001 });
            context.School.Add(new Lab6.Models.School { name = "Number 4", year = 2002 });
            context.School.Add(new Lab6.Models.School { name = "Number 5", year = 2003 });


            context.Teacher.Add(new Lab6.Models.Teacher { first_name = "Anna", last_name = "Maria", age = 30, gender = "female", school_id = 1 });
            context.Teacher.Add(new Lab6.Models.Teacher { first_name = "Inna", last_name = "Fabrykina", age = 50, gender = "female", school_id = 4 });
            context.Teacher.Add(new Lab6.Models.Teacher { first_name = "Sergii", last_name = "Vapnichnii", age = 30, gender = "male", school_id = 2 });
            context.Teacher.Add(new Lab6.Models.Teacher { first_name = "Anna", last_name = "Petrova", age = 35, gender = "female", school_id = 3 });
            context.Teacher.Add(new Lab6.Models.Teacher { first_name = "Maria", last_name = "Maria", age = 24, gender = "female", school_id = 5 });

            context.Subject.Add(new Lab6.Models.Subject { name = "Math", coefficient = 5, duration = 90 });
            context.Subject.Add(new Lab6.Models.Subject { name = "Native Language", coefficient = 5, duration = 90 });
            context.Subject.Add(new Lab6.Models.Subject { name = "Foreign Language", coefficient = 4, duration = 90 });
            context.Subject.Add(new Lab6.Models.Subject { name = "Draw", coefficient = 3, duration = 45 });
            context.Subject.Add(new Lab6.Models.Subject { name = "Chemistry", coefficient = 4, duration = 45 });
        }

    }
}