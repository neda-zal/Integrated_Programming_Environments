using System;
using System.Collections.Generic;

namespace _3LD
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>{};

            int pas;
            try {
                do {
                    Console.Write("\n");
                    Console.WriteLine(" 1 - Add new student.\n" +
                                    " 2 - Show students average final score.\n" +
                                    " 3 - Show students median final score.\n" +
                                    " 4 - Add random student.\n" +
                                    " 5 - Add students from file.\n" +
                                    " 6 - Generate files with 10000, 100000, 1000000, 10000000 students.\n" +
                                    " 7 - Test with different containers.\n" +
                                    " 0 - Exit.\n");
                    Console.Write("Your choice: ");
                    pas = int.Parse(Console.ReadLine());
                    switch(pas) {
                        case 0: {
                            break;
                        }
                        case 1: {
                            students.Add(Student.createStudent());
                            break;
                        }
                        case 2: {
                            Student.showInTable(students, false);
                            break;
                        }
                        case 3: {
                            Student.showInTable(students, true);
                            break;
                        }
                        case 4: {
                            Student student = new Student();
                            students.Add(student);
                            break;
                        }
                        case 5: {
                            List<Student> tmp = Student.ReadFromFile("//assets//students.csv");
                            students.AddRange(tmp);
                            break;
                        }
                        case 6: {
                            Helpers.Test();
                            break;
                        }
                        case 7: {
                            //Helpers.generateAmount(10000);
                            //Helpers.generateAmount(100000);
                            //Helpers.generateAmount(1000000);
                            //Helpers.generateAmount(10000000);
                            Helpers.testContainers();
                            break;
                        }
                        default: {
                            Console.WriteLine("Invalid choice.");
                            break;
                        }
                    }
                } while (pas != 0);
            } catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}
