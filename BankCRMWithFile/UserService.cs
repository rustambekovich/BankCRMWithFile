using BankCRMWithFile.databases;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCRMWithFile
{
    public class UserService
    {
        /// <summary>
        /// Location in path
        /// </summary>
        private string path = Data.USER_INPUT;
        #region 
        public User add(User user)
        {
            string text = $"{user.Id}|{user.Name}|{user.LastName}|{user.Appeal}|{user.RegisteredData}\n";
            File.AppendAllText(path, text);
            return user;
        }
        #endregion 
        public string[] GetByID(int id)
        {
            if(File.Exists(path))
            {
                string[] lines = File.ReadAllText(path).Split("\n");
                foreach (var l in lines)
                {
                    if (l != "" && l != null)
                    {
                        string[] propty = l.Split('|');
                        if (int.Parse(propty[0]) == id)
                        {
                            return propty;
                        }
                    }
                }
            }
            return null;
        }

        public string[] GetAll()
        {
            if(File.Exists(path))
            {
                string[] lines = File.ReadAllText(path).Split("\n");
                return lines;
            }
            return null;
        }

        public bool Delete(int id)
        {
            User person = new User();
            string[] lines = File.ReadAllText(path).Split("\n");
            foreach (var l in lines)
            {
                if (l != "" && l != null)
                {
                    string[] propty = l.Split('|');
                    if (int.Parse(propty[0]) == id)
                    {
                        File.Delete(path);
                    }
                }
            }
            foreach (var p in lines)
            {
                if (p != "" && p != null)
                {
                    string[] soltuser = p.Split('|');
                    if (int.Parse(soltuser[0]) != id)
                    {
                        person.Id = int.Parse(soltuser[0]);
                        person.Name = soltuser[1];
                        person.LastName = soltuser[2];
                        person.Appeal = soltuser[3];
                        person.RegisteredData = DateTime.Now;
                        add(person);
                    }

                }
            }
            return true;
        }

        public User Uppdating(User user)
        {
            User person = new User();
            string[] lines = File.ReadAllText(path).Split("\n");
            foreach (var l in lines)
            {
                if (l != "" && l != null)
                {
                    string[] propty = l.Split('|');
                    if (int.Parse(propty[0]) == user.Id)
                    {
                        File.Delete(path);
                    }
                }
            }
            foreach (var p in lines)
            {
                if (p != "" && p != null)
                {
                    string[] soltuser = p.Split('|');
                    if (int.Parse(soltuser[0]) != user.Id)
                    {
                        person.Id = int.Parse(soltuser[0]);
                        person.Name = soltuser[1];
                        person.LastName = soltuser[2];
                        person.Appeal = soltuser[3];
                        person.RegisteredData = DateTime.Now;
                        add(person);
                    }
                    else if (int.Parse(soltuser[0]) == user.Id)
                    {
                        person.Id = user.Id;
                        person.Name = user.Name;
                        person.LastName = user.LastName;
                        person.Appeal = user.Appeal;
                        person.RegisteredData = DateTime.Now;
                        Console.WriteLine("Yangilandi");
                        add(person);
                    }

                }
            }
            return person;
        }
    }
}
