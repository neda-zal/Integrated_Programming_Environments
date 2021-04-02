using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Linq;

namespace _3LD
{
    public class Helpers {

        private const string HEADER = "Name,Surname,HW1,HW2,HW3,HW4,HW5,Exam";

        public static List<int> createHomeworkList(String surname) {

            List<int> homeworks = new List<int>{};
            int grade;

            while(true) {
                Console.WriteLine("0 - stop entering grades");
                Grade: 
                    try {
                        
                        Console.Write("Input students " + surname + " grade: ");
                        grade = Convert.ToInt32(Console.ReadLine());

                        if (grade == 0) {
                            break;
                        };

                        if(Student.isInRange(grade) == false) {
                            Console.WriteLine("The grade is out of bounds, try again.");
                            continue;
                        } else {
                            homeworks.Add(grade);
                        }
                    } catch(Exception e) {
                        Console.WriteLine(e);
                        goto Grade;
                    }            
            }
            return homeworks;
        }

        public static void generateStudents(int amount) {

            Stopwatch timer = new Stopwatch();
            timer.Restart();

            List<Student> students = new List<Student>();
            
            // generating random students
            for (int i = 0; i < amount; i++) {
                students.Add(new Student());
            }

            StreamWriter passedStudentList = new StreamWriter($"assets/passed_students_of_{amount}.csv");
            StreamWriter failedStudentList = new StreamWriter($"assets/failed_students_of_{amount}.csv");

            passedStudentList.WriteLine(HEADER);
            failedStudentList.WriteLine(HEADER);

            foreach(Student student in students) {
                if (student.FinalPoints() >= 5) {
                    passedStudentList.WriteLine(student.convertToCsvString());
                } else {
                    failedStudentList.WriteLine(student.convertToCsvString());
                }                
            }

            passedStudentList.Close();
            failedStudentList.Close();

            timer.Stop();

            Console.WriteLine("Time elapsed generating {0} random {1} students.", amount, timer.Elapsed);

        }

        public static void generateAmount(int amount) {
            StreamWriter students = new StreamWriter($"{amount}_students.csv");

            students.WriteLine(HEADER);

            for (int i = 0; i < amount; i++)
                students.WriteLine(new Student().convertToCsvString());

            students.Close();
        }

        public static void Test() {
            // testing with 10000, 100000, 1000000, 10000000
            generateStudents(10000);
            generateStudents(100000);
            generateStudents(1000000);
            generateStudents(10000000);
        }

        public static void testContainers() {

            // testing with 10000, 100000, 1000000, 10000000
            MeasureContainerPerformance(true, @"/10000_students.csv", 10000);
            MeasureContainerPerformance(false, @"/10000_students.csv", 10000);
            MeasureContainerPerformance(null, @"/10000_students.csv", 10000);
            Console.WriteLine();

            MeasureContainerPerformance(true, @"/100000_students.csv", 100000);
            MeasureContainerPerformance(false, @"/100000_students.csv", 100000);
            MeasureContainerPerformance(null, @"/100000_students.csv", 100000);
            Console.WriteLine();

            MeasureContainerPerformance(true, @"/1000000_students.csv", 1000000);
            MeasureContainerPerformance(false, @"/1000000_students.csv", 1000000);
            MeasureContainerPerformance(null, @"/1000000_students.csv", 1000000);
            Console.WriteLine();

            MeasureContainerPerformance(true, @"/10000000_students.csv", 10000000);
            MeasureContainerPerformance(false, @"/10000000_students.csv", 10000000);
            MeasureContainerPerformance(null, @"/10000000_students.csv", 10000000);
            Console.WriteLine();
        }

        public static IEnumerable<Student> chooseContainer(string filename, bool? choice) {
            switch(choice) {
                case true: {
                    return new List<Student>(Student.ReadFromFile(filename));
                }
                case false: {
                    return new LinkedList<Student>(Student.ReadFromFile(filename));
                }
                case null: {
                    return new Queue<Student>(Student.ReadFromFile(filename));
                }
            }
        }

        public static void MeasureContainerPerformance(bool? choice, string filename, int amount) {

            Stopwatch timer = new Stopwatch();
            timer.Restart();

            var students = Helpers.chooseContainer(filename, choice);

            var passedStudentList = (IEnumerable<Student>)Activator.CreateInstance(students.GetType());
            var failedStudentList = (IEnumerable<Student>)Activator.CreateInstance(students.GetType());

            foreach(Student student in students) {
                if (student.FinalPoints() >= 5) {
                    passedStudentList.Append(student);
                } else {
                    failedStudentList.Append(student);
                }                
            }

            timer.Stop();

            Console.WriteLine($"Time elapsed sorting {students.GetType().Name} with {amount} random students: {timer.Elapsed} ");

        }

    }

}
