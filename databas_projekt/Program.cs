using System;
using System.Collections.Generic;
using System.Linq;
using databas_projekt.Models;
using Microsoft.EntityFrameworkCore;

namespace databsprojekt
{
    class Program
    {
        static void Main(string[] args)
        {
            menu();
        }

        static void menu()
        {
            using SampleContext Context = new SampleContext();


            //Hur många lärare jobbar på de olika avdelningarna?(EF VS)
            //Visa information om alla elever (EF VS)
            // Visa en lista på alla aktiva kurser (EF VS)

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Välkommen till gymnasieskolan!");
            Console.WriteLine("Välj funktion:");
            Console.WriteLine("1. Visa hur många lärare som jobbar på de olika avdelningarna");
            Console.WriteLine("2. Visa information om alla elever");
            Console.WriteLine("3. Visa en lista på alla aktiva kurser");
            int menuChoice = Int32.Parse(Console.ReadLine());
            switch (menuChoice)
            {
                case 1:
                    displayTeachers(Context);
                    Console.ReadKey();
                    break;
                case 2:
                    displayStudents(Context);
                    Console.ReadKey();
                    break;
                case 3:
                    displayCourses(Context);
                    Console.ReadKey();
                    break;

            }
        }
        static void displayTeachers(SampleContext Context)
        {

            var dep = (from c in Context.Departments where c.DepartmentName == "admin"
                       select c).Count();

            Console.WriteLine("Admin : " + dep);

            var dep1 = (from c in Context.Departments
                       where c.DepartmentName == "Lärare"
                       select c).Count();

            Console.WriteLine("Lärare : " + dep1);

            var dep2 = (from c in Context.Departments
                       where c.DepartmentName == "Övrigt"
                       select c).Count();

            Console.WriteLine("Övrigt : " + dep2);


            Console.WriteLine("Tryck på valfri tangent för att återvända till menyn. . .");
            Console.ReadKey();
            menu();

        }
        static void displayStudents(SampleContext Context)
        {
            var student = from Students in Context.Students
                          orderby Students.StudentId ascending
                          select Students;
            foreach (var item in student)
            {
                Console.WriteLine("Student id: " + item.StudentId);
                Console.WriteLine("Förnamn: " + item.Fname);
                Console.WriteLine("Efternamn: " + item.Lname);
                Console.WriteLine("---------");
            }

            Console.WriteLine("Tryck på valfri tangent för att återvända till menyn. . .");
            Console.ReadKey();
            menu();
        }
        static void displayCourses(SampleContext Context)
        {
            var courses = from kurs in Context.Kurs
                          where (kurs.EndDate >= DateTime.Parse("2022-02-07"))
                          select kurs;

            foreach (var item in courses)
            {
                Console.WriteLine("Kursnamn: " + item.CourseName);
                Console.WriteLine("Startdatum: " + item.StartDate);
                Console.WriteLine("Slutdatum " + item.EndDate);
                Console.WriteLine("--------");
            }
            
            Console.WriteLine("Tryck på valfri tangent för att återvända till menyn. . .");
            Console.ReadKey();
            menu();


        }
    }
}
