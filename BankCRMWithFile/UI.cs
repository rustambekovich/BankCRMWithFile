using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCRMWithFile
{
    public class UI
    {
        public void print()
        {

            UserService service = new UserService();

            bool only = true;
            int back = 1, exit = 0, i;
            Console.WriteLine("Welcome To Bank CRM system!\n");
            while (only)
            {
            Key:
                Console.WriteLine("Choose your number ?");
                Console.WriteLine("1.Create user.\n2.Find user by ID.\n3.Show all user.\n4.Update user.\n5.Delete user.\n6.Stop.");
                Console.Write("Enter steap: ");
                int steap = int.Parse(Console.ReadLine());
                switch (steap)
                {
                    case 1:
                        User user = new User();

                        Console.Write("Write Id:");
                        user.Id= int.Parse(Console.ReadLine());

                        Console.Write("Write name:");
                        user.Name = Console.ReadLine();

                        Console.Write("Write surname:");
                        user.LastName = Console.ReadLine();


                        Console.Write("Write your problem:");
                        user.Appeal = Console.ReadLine();

                        Console.WriteLine($"Created user:{user.RegisteredData}");

                        service.add(user);
                        Console.WriteLine("Back --> 1\tExit --> 0");
                        i = int.Parse(Console.ReadLine());
                        Console.Clear();
                        if (back == i)
                        {
                            goto Key;
                        }
                        else if (exit == i)
                        {
                            break;
                        }
                        break;
                    case 2:
                        Console.Write("Enter ID:");
                        var item = int.Parse(Console.ReadLine());
                        var person = service.GetByID(item);
                        if(person != null)
                        {
                            Console.WriteLine($"\nID: {person[0]}\nName: {person[1]}\nLasrName: {person[2]}\nAppeal{person[3]}\nRegisteredDate: {person[4]}\n");
                        }
                        else
                        {
                            Console.WriteLine("User is ot found !");
                        }
                        Console.WriteLine("Back --> 1\tExit --> 0");
                        i = int.Parse(Console.ReadLine());
                        Console.Clear();
                        if (back == i)
                        {
                            goto Key;
                        }
                        else if (exit == i)
                        {
                            only = false;
                            break;
                        }
                        break;

                    case 3:
                        var arr = service.GetAll();

                        foreach (var l in arr)
                        {
                            if (l != "" && l != null)
                            {
                                string[] propty = l.Split('|');
                                Console.WriteLine($"ID: {propty[0]}\nName: {propty[1]}\nLasrName: {propty[2]}\nAppeal{propty[3]}\nRegisteredDate: {propty[4]}\n");

                            }
                            /*                            Console.WriteLine($"ID:\t{ls.id}\nName:\t{ls.name}\nSurname:{ls.surName}\nAge:\t{ls.age}\nAppeal:\t{ls.appeal}");
                            */
                        }
                        Console.WriteLine("\n");
                        Console.WriteLine("Back --> 1\tExit --> 0");
                        i = int.Parse(Console.ReadLine());
                        Console.Clear();
                        if (back == i)
                        {
                            goto Key;
                        }
                        else if (exit == i)
                        {
                            break;
                        }
                        break;

                    case 4:
                        User NewPerson = new User();
                        Console.Write("Write Id:");
                        NewPerson.Id = int.Parse(Console.ReadLine());

                        Console.Write("Write name:");
                        NewPerson.Name = Console.ReadLine();

                        Console.Write("Write surname:");
                        NewPerson.LastName = Console.ReadLine();

                        Console.Write("Write new your problem:");
                        NewPerson.Appeal = Console.ReadLine();

                        service.Uppdating(NewPerson);
                        Console.WriteLine("\n");
                        Console.WriteLine("Back --> 1\tExit --> 0");
                        i = int.Parse(Console.ReadLine());
                        Console.Clear();
                        if (back == i)
                        {
                            goto Key;
                        }
                        else if (exit == i)
                        {
                            break;
                        }
                        break;
                    case 5:
                        Console.Write("Enter ID:");
                        int idi = int.Parse(Console.ReadLine());
                        var check = service.Delete(idi);
                        if (check == true)
                        {
                            Console.WriteLine("Deleted");
                        }
                        else
                        {
                            Console.WriteLine("Not found Id!!!");
                        }
                        Console.WriteLine("Back --> 1\tExit --> 0");
                        i = int.Parse(Console.ReadLine());
                        Console.Clear();
                        if (back == i)
                        {
                            goto Key;
                        }
                        else if (exit == i)
                        {
                            break;
                        }
                        break;

                    case 6:
                        only = false;
                        break;
                }
            }
        }
    }
}
