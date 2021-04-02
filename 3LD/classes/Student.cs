using System;
using System.Linq;
using static System.String;
using System.IO;
using System.Collections.Generic;

namespace _3LD {

    public class Student
    {
        private const int MINIMUM = 1;
        private const int MAXIMUM = 10;

        private Random random = new Random();

        private string name;
        private string surname;
        private List<int> homeworks;
        private int exam;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public List<int> Homeworks { get => homeworks; set => homeworks = value; }
        public int Exam { get => exam; set => exam = value; }

        public Student() {
            this.name = "Name" + random.Next(10000);
            this.surname = "Surname" + random.Next(10000);
            this.homeworks = new List<int>();
            for (int i = 0; i < 5; i++) {
                this.homeworks.Add(random.Next(MINIMUM, MAXIMUM));
            };
            this.exam = random.Next(MINIMUM, MAXIMUM);
        }

        public Student(string name, string surname, List<int> homeworks, int exam) {
            this.name = name;
            this.surname = surname;
            this.homeworks = homeworks;
            this.exam = exam;
        }

        public static Boolean isInRange(int x) {

            if(Enumerable.Range(MINIMUM, MAXIMUM).Contains(x)) {
                return true;
            } else {
                return false;
            }

        }

        public static double GetMedian(IEnumerable<int> homeworks) {
            // Create a copy of the input, and sort the copy
            int[] temp = homeworks.ToArray();
            Array.Sort(temp);
            int count = temp.Length;
            if (count == 0) {
                throw new InvalidOperationException("Empty collection");
            } else if (count % 2 == 0) {
                // count is even, average two middle elements
                double a = temp[count / 2 - 1];
                double b = temp[count / 2];
                return a + b / 2;
            } else {
                // count is odd, return the middle element
                return temp[count / 2];
            }
        }

        public static Student createStudent() {

            Student student = new Student();

            Name:
                Console.Write("Input student name: ");
                string name = Console.ReadLine();
                if(!IsNullOrEmpty(name) && name.Length < 20) {
                    goto Surname;
                } else {
                    Console.Clear();
                    goto Name;
                }

            Surname:
                Console.Write("\nInput student surname: ");
                string surname = Console.ReadLine();
                if(!IsNullOrEmpty(surname) && surname.Length < 30) {
                    student.Surname = surname;
                    goto Homework;
                } else {
                    Console.Clear();
                    goto Surname;
                }

            Homework:
                student.Homeworks = Helpers.createHomeworkList(student.surname);
                goto Exam;

            Exam:
                try {
                    Console.Write("\nInput students exam grade: ");
                    int grade = Convert.ToInt32(Console.ReadLine());
                    if(isInRange(grade) == true) {
                        student.Exam = grade;
                        goto Finish;
                    } else {
                        Console.Clear();
                        goto Exam;
                    }
                } catch(Exception e) {
                    Console.WriteLine(e);
                    goto Exam;
                }

            Finish:
                return student;
        }

        public double FinalPoints() {
            return 0.3 * Homeworks.Average() + 0.7 * Exam;
        }

        public static void showInTable(List<Student> students, Boolean median) {

            students = students.OrderBy(student => student.Name).ToList();

            Console.Write('\n');
            if(median  == false) {
                Console.WriteLine("{0, -30} {1, -20} {2, -5}", "Surname", "Name", "Final points (Avg.)");

                for(int i = 0; i < 72; i++) {
                    Console.Write("-");
                }
                Console.Write('\n');

                foreach(var item in students) {
                    Console.WriteLine("{0, -30} {1, -20} {2, -5}", item.Surname, item.Name, item.FinalPoints());
                }

            } else {

                Console.WriteLine("{0, -30} {1, -20} {2, -5}", "Surname", "Name", "Final points (Avg.) / Final points (Med.)");

                for(int i = 0; i < 100; i++) {
                    Console.Write("-");
                }
                Console.Write('\n');

                foreach(var item in students) {
                    Console.WriteLine("{0, -30} {1, -20} {2, -21} {3, -20}", item.Surname, item.Name, item.FinalPoints(), GetMedian(item.Homeworks));
                }

            }
            
        }

        public static List<Student> ReadFromFile(string filename) {

            List<Student> students = new List<Student>();

            try {
                var reader = new StreamReader(@Environment.CurrentDirectory + filename);
                bool isFirst = true;
                while (!reader.EndOfStream) {

                    var line = reader.ReadLine();
                    var split = line.Split(',');
                    if(isFirst) {
                        isFirst=false;
                        continue;
                    }

                    List<int> grades = new List<int>();
                    for(int i = 2; i < 7; i++) {
                        grades.Add(int.Parse(split[i]));
                    }
                    Student stud = new Student(split[0], split[1], grades, int.Parse(split[7]));
                    students.Add(stud);
                }
            } catch(Exception e) {
                throw e;
            }

            students = students.OrderBy(student => student.Name).ToList();
            return students;

        }

        public string convertToCsvString() {
            var line = $"{Name},{Surname},";
            foreach (var item in Homeworks) {
                line += $"{item},";
            }
            line += $"{Exam}";
            return line;
        }
    }
}