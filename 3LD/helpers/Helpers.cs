using System;
using System.Collections.Generic;
using System.Text;

namespace _3LD
{
    public class Helpers {

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

                            //if(grade.)

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

    }

}
