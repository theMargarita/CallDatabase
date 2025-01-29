using Labb_3.Models;
using Microsoft.EntityFrameworkCore;
using Labb_3.Data;
using Labb_3;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Labb_3Test
{
    internal static class UserInterface
    {
        public static void UserInteraction()
        {
            
            using (var context = new FictiveSchoolContext())
            {

                while (true)
                {
                    Console.WriteLine("Here is the menu from the database\n");
                    Console.WriteLine("1: Students\n2: Classes\n3: Add staff\n4: Exit");
                    string userInput = Console.ReadLine();
                    Console.Clear();
                    switch (userInput)
                    {
                        case "1":
                            ShowStudents();
                            Console.Clear();
                            break;

                        case "2":
                            ShowClasses();
                            Console.Clear();
                            break;

                        case "3":
                            DataManager.AddStaff();
                            Console.Clear();
                            break;

                        case "4":
                            Console.WriteLine("Exiting");
                            Console.Clear();
                            return;

                        default:
                            Console.WriteLine("Something went wrong.\nPress enter to return ");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
            }
        }

        public static void ShowClasses()
        {
            var allClasses = DataManager.GetClasses();

            Console.WriteLine("Classes: ");
            foreach (var c in allClasses)
            {
                Console.WriteLine($"{c.ClassName}");
            }
            Console.WriteLine();

            Console.WriteLine("Enter class name: ");
            string userInput = Console.ReadLine();
            Console.Clear();

            var studentInClass = DataManager.GetStudentsByClass(userInput);

            Console.WriteLine($"Class: {userInput} - {studentInClass.Count} students\n");
            foreach (var s in studentInClass)
            {
                Console.WriteLine($"{s.Firstname} {s.Lastname}");
            }

            Console.ReadKey();
        }
        public static void ShowStudents()
        {
            Console.WriteLine("How do you want to sort the students´by firstname or lastname?" +
                  "\n1: Firstname\n2: Lastname");
            int sortChoice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Do you want it in ascending or descending order?" +
                "\n1: Ascending\n2: Descending");
            int orderChoice = Convert.ToInt32(Console.ReadLine());

           //have to have these parameters because the exsists in the method 
           List<Student>sortedStudents =  DataManager.SortStudents(sortChoice, orderChoice);

            // execute the query
            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"Name: \t{student.Firstname} {student.Lastname}");
            }
            Console.ReadKey();
            Console.Clear();

        }
    }
}

