using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            UserContext context = new UserContext();
            context.Users.Add(UserData.testUsers[0]);
            context.Users.Add(UserData.testUsers[1]);
            context.Users.Add(UserData.testUsers[2]);
            context.SaveChanges();
            return;
            string username;
            string password;

            Console.WriteLine("username: ");
            username = Console.ReadLine();
            Console.WriteLine("password: ");
            password = Console.ReadLine();
            Console.WriteLine("\n");

            User user = null;
            LoginValidation loginValidation = new LoginValidation(username, password, actionOnError);

            if (loginValidation.ValidateUserInput(ref user))
            {
                Console.WriteLine(user.toString());
                switch (LoginValidation.currentUserRole) 
                {
                    case UserRoles.ANONYMOUS:
                        Console.WriteLine("Потребителят не е намерен.");
                        break;
                    case UserRoles.ADMIN:
                        Console.WriteLine("Системен администратор е логнат.");
                        break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine("Инспектор е логнат.");
                        break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine("Професор е логнат.");
                        break;
                    case UserRoles.STUDENT:
                        Console.WriteLine("Студент е логнат.");
                        break;
                }
                AdministratorActivity();
            }
        }

        static void actionOnError(string error) {
            Console.WriteLine("!!! " + error + " !!!");
        }

        static void AdministratorActivity()
        {
            for (;;)
            {
                Console.WriteLine("\n");
                Console.WriteLine("Choose option:");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: Change user role");
                Console.WriteLine("2: Change user active until");
                Console.WriteLine("3: List of active users: ");
                Console.WriteLine("4: View log activity: ");
                Console.WriteLine("5: View current activity: ");

                String option = Console.ReadLine();
                if (option.Equals("0"))
                {
                    break;
                }

                string userName = "";
                if(option.Equals("1") || option.Equals("2"))
                {
                    Console.WriteLine("Въведи потребителско име: ");
                    userName = Console.ReadLine();

                }

                IEnumerable<string> currentActs;
                StringBuilder sb = new StringBuilder();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("Въведи нова роля:");
                        int newRole = Convert.ToInt32(Console.ReadLine());
                        UserData.AssignUserRole(userName, (UserRoles)newRole);
                        break;
                    case "2":
                        Console.WriteLine("Въведи нова активна дата:");
                        DateTime newDate = DateTime.Parse(Console.ReadLine());
                        UserData.SetUserActiveUntil(userName, newDate);
                        break;
                    case "3":
                        UserData.testUsers.ForEach(u => Console.WriteLine(u.username));
                        break;
                    case "4":
                        currentActs =
                        Logger.OuputlogFile();
/*                        foreach (string line in currentActs)
                        {
                            sb.Append(line);
                        }
                        Console.WriteLine(sb.ToString());*/
                        Console.WriteLine(string.Join("", currentActs));
                        break;
                    case "5":
                        Console.WriteLine("Въведи филтър: ");
                        string filter = Console.ReadLine();
                        currentActs =
                        Logger.GetCurrentSessionActivities(filter);
     /*                   foreach (string line in currentActs)
                        {
                            sb.Append(line);
                        }
                        Console.WriteLine(sb.ToString());*/
                        Console.WriteLine(string.Join("", currentActs));
                        break;
                    default:
                        Console.WriteLine("Грешна опция!");
                        break;
                }
            }
        }
    }
}
