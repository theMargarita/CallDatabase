using Labb_3.Models;
using Microsoft.EntityFrameworkCore;
using Labb_3.Data;

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


        public static void AddStaff()
        {
            using (var context = new FictiveSchoolContext())
            {

                Console.WriteLine("Firstname: ");
                string fNameInput = Console.ReadLine();

                Console.WriteLine("Lastname: ");
                string lNameInput = Console.ReadLine();

                Console.WriteLine("SSN: ");
                string ssn = Console.ReadLine();

                Console.WriteLine("What role does this person have: " +
                    "\n1. Principal\n2. Teacher\n3. " +
                    "Counsler\n4. School Nurse\n5. Librarian\n6. Janitor" +
                    "\n7. Cafeteria Lady\n8. Administrator");
                int staffId = Convert.ToInt32(Console.ReadLine());

                var newStaff = new SchoolRole
                {
                    FirstName = fNameInput,
                    LastName = lNameInput,
                    Ssn = ssn,
                    StaffId = staffId
                };
                context.SchoolRoles.AddRange(newStaff);
                context.SaveChanges();

                Console.WriteLine("\nNew staff added.\n");

                var staff = context.StaffRoles
                    .Include(s => s.SchoolRoles).ToList();

                foreach (var s in staff)
                {
                    foreach (var sr in s.SchoolRoles)
                    {
                        Console.WriteLine($"{sr.FirstName} {sr.LastName} - {s.RoleType}");

                    }
                }
            }
        }
    }
}
