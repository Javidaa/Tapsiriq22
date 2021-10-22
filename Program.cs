using System;
using System.Collections.Generic;

namespace Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Group> groupContext = new List<Group>
            {

            };
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("Menu: 1 - Add group  | 2 - Add student | 3 - Add student mark | 4 - View student list | 5 - Find student | 6 - Delete group | exit");
                Console.ResetColor();

                string userResponse = Console.ReadLine();

                if (userResponse.ToLower() == "exit")
                {
                    break;
                }

                int selection;
                bool selectionIsValid = int.TryParse(userResponse, out selection);

                if (selectionIsValid && selection >= 1 && selection <=6) 
                {
                    switch (selection)
                    {
                        case (int)AppMenuSelection.Addgroup:

                            Console.WriteLine("Enter student name: ");
                            string ctName = Console.ReadLine();
                            if (string.IsNullOrEmpty(ctName))
                            {
                                Console.WriteLine("Group name invalid.");
                                break;
                            }

                            Console.WriteLine("Enter group MaxStudentCount: ");
                            int groupMaxStudentCount;
                            bool groupMaxStudentCountIsValid = int.TryParse(Console.ReadLine(), out groupMaxStudentCount);
                            if (!groupMaxStudentCountIsValid)
                            {
                                Console.WriteLine("MaxStudentCount invalid.");
                                break;
                            }

                            Group newgroup = new Group(ctName, groupMaxStudentCount);
                            if (groupContext.Contains(newgroup))

                            {
                                Console.WriteLine("Group already exists");
                            }
                            groupContext.Add(newgroup);
                            Console.WriteLine("Group added successfully.");

                            break;
                        case (int)AppMenuSelection.Addstudent:
                            if (groupContext.Count<=0)
                            {
                                Console.WriteLine("Group name invaled.");
                                break;
                            }

                            Console.Write("Enter student name: ");
                            string studentName = Console.ReadLine();
                            if (string.IsNullOrEmpty(studentName))
                            {
                                Console.WriteLine("Student name invalid.");
                                break;
                            }

                            Console.Write("Enter student Surname: ");
                            string studentSurname = Console.ReadLine();
                            if (string.IsNullOrEmpty(studentSurname))
                            {
                                Console.WriteLine("Student Surname invalid.");
                                break;
                            }

                            Console.WriteLine("Enter student Point: ");
                            int studentPoint;
                            bool studentPointIsValid = int.TryParse(Console.ReadLine(), out studentPoint);
                            if (!studentPointIsValid)
                            {
                                Console.WriteLine("Point invalid.");
                                break;
                            }

                            Console.WriteLine("Enter student Average: ");
                            int studentAverage;
                            bool studentAverageIsValid = int.TryParse(Console.ReadLine(), out studentAverage);
                            if (!studentAverageIsValid)
                            {
                                Console.WriteLine("Average invalid.");
                                break;
                            }

                            foreach (Group item in groupContext)
                            {
                                Console.WriteLine(item);
                            }
                            Console.WriteLine("Enter the id of the group that you want to add  the group to");

                            int studentGroupId;
                            bool studentGroupIdIsValid = int.TryParse(Console.ReadLine(), out studentGroupId);
                            if (!studentGroupIdIsValid)
                            {
                                Console.WriteLine("Group id invalid.");
                            }

                            Group groupToAddStudentTo = null;

                            foreach  (Group item in groupContext)
                            {
                                if (item.Id==studentGroupId)
                                {
                                    groupToAddStudentTo = item;
                                }
                            }

                            if (groupToAddStudentTo == null)
                            {
                                Console.WriteLine("Group does not exist.");
                                break;
                            }

                            Student newStudent = new Student(studentName, studentSurname, studentPoint, studentAverage);
                            groupToAddStudentTo.AddStudent(newStudent);
                            Console.WriteLine("Student added successfully.");

                                break;
                        case (int)AppMenuSelection.Addstudentmark:
                            Console.WriteLine("3 cu funksiya secildi ");
                            break;
                        case (int)AppMenuSelection.Viewstudentlist:
                            foreach (Group item in groupContext)
                            {
                                item.PrintAllStudents();
                            }
                            


                            break;
                        case (int)AppMenuSelection.Findstudent:
                            Console.WriteLine("Enter query:");
                            string userQuery = Console.ReadLine();
                            if (string.IsNullOrEmpty(userQuery))
                            {
                                Console.WriteLine("Query invalid.");
                            }
                            foreach (Group item in groupContext)
                            {
                                item.SearchAndPrintStudents(userQuery);
                            }


                            break;
                        case (int)AppMenuSelection.Deletegroup:
                            foreach (Group item in groupContext)
                            {
                                Console.WriteLine(item);
                            }
                            Console.WriteLine("Enter the id of the group that you want to delete:");

                            int deleteGroupId;
                            bool deleteGroupIdIsValid = int.TryParse(Console.ReadLine(), out deleteGroupId);
                            if (!deleteGroupIdIsValid)
                            {
                                Console.WriteLine("Group id invalid.");
                            }

                            Group groupToDelete = null;

                            foreach (Group item in groupContext)
                            {
                                if (item.Id == deleteGroupId)
                                {
                                    groupToDelete = item;
                                }
                            }

                            if (groupToDelete == null)
                            {
                                Console.WriteLine("Group does not exist.");
                                break;
                            }
                            groupContext.Remove(groupToDelete);
                            Console.WriteLine("Group deleted successfully.");
                            break;


                          
                    }
                }
                else
                {
                    Console.WriteLine("Invalid menu selection.");
                }
            }
        }

    }
}
