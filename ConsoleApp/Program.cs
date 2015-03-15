using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using passstore;
using MongoDB.Bson;

namespace ConsoleApp
{
    class Program
    {
        static TestUser _user { get; set; }
        static void Main(string[] args)
        {
            args = new [] { "user", "add", "test", "test", "test" };
            try
            {
                if (args[0] == "user")
                {
                    // passstore user add {{username}} {{masterpass}} {{name}}
                    if (args[1] == "add")
                    {
                        _user = new TestUser();
                        _user.Username = args[2];
                        _user.MasterPassword = args[3];
                        _user.Name = args[4];

                        new TestUsers().Add(_user);
                    }
                }
                else if (args[0] == "pass")
                {
                    // passstore pass add {{name}} {{username}} {{password}} {{username}} {{masterpass}}
                    if (args[1] == "add")
                    {
                        _user = new TestUser() {Username = args[5], MasterPassword = args[6]};
                        _user.Auth();

                        if (_user.MasterPassword != null)
                        {
                            new Passstore().AddPass(_user, args[2], args[3], args[4]);
                        }
                        else
                        {
                            Console.WriteLine("Username or password not correct");
                        }
                    }
                    // passstore pass get {{username}} {{masterpass}}
                    else if (args[1] == "get")
                    {
                        _user = new TestUser {Username = args[3], MasterPassword = args[4]};
                        _user.Auth();

                        if (_user.MasterPassword != null)
                        {
                            var passwords = new Passstore().GetEncryptedPasswords(_user);
                            foreach (var pass in passwords)
                            {
                                Console.WriteLine(pass.Name + " - " + pass._id);
                            }
                        }
                    }
                    // passstore pass unlock {{passid}} {{username}} {{masterpass}}
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Arguments are wrong");
            }
        }
    }
}
