using Labb_3.Models;
using Microsoft.EntityFrameworkCore;
using Labb_3.Data;
using System.Runtime.Intrinsics.X86;

namespace Labb_3
{
    public static class DataManager
    {
        public static List<Student>SortStudents(int sortChoice, int orderChoice)
        {
            using (var context = new FictiveSchoolContext())
            {
                var studentsQuery = context.Students.AsQueryable();

                if (sortChoice == 1) 
                {
                    studentsQuery = orderChoice == 1
                        ? studentsQuery.OrderBy(s => s.Firstname)
                        : studentsQuery.OrderByDescending(s => s.Firstname);
                }
                else if (sortChoice == 2)
                {
                    studentsQuery = orderChoice == 1
                        ? studentsQuery.OrderBy(s => s.Lastname)
                        : studentsQuery.OrderByDescending(s => s.Lastname);
                }

                return studentsQuery.ToList();
            }
        }

        //returnerar listan av class tabellen/classen med enbart klassnamnen
        public static List<Class> GetClasses()
        {
            using (var context = new FictiveSchoolContext())
            {
                return context.Classes.ToList();
            }
        }

        //returnerar studenten som är kopplade till deras klasser och använder parametern för lambda funktionen 
        public static List<Student> GetStudentsByClass(string className)
        {
            using (var context = new FictiveSchoolContext())
            {
                return context.Students.Where(c => c.Class.ClassName == className).ToList();
            }
        }

        public static List<SchoolRole> NewStaff(string fName, string lName, string ssn, int staffId)
        {
            using(var context = new FictiveSchoolContext())
            {
                var newStaff = new SchoolRole
                {
                    FirstName = fName,
                    LastName = lName,
                    Ssn = ssn,
                    StaffId = staffId
                };
                context.SchoolRoles.AddRange(newStaff);
                context.SaveChanges();

                return context.SchoolRoles.ToList();

            }
        }
    }
}
