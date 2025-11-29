using System;
using System.Collections.Generic;
using DotNetEnv;
using System.Diagnostics;
using EasyEncryption;
using System.Runtime.InteropServices;
internal class Program
{
    
    private static void Main()
    {
        bool zapusk = true;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;

        EasyEncryption.Config.CreateEnv();

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            string homePath = Environment.GetEnvironmentVariable("HOME");
            string confpath = $"{homePath}/.config/EasyEncryption";
            EasyEncryption.Config.pathEnv1 = Path.Combine(confpath, ".env");
        }else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var confpath = Path.Combine(appDataPath, "EasyEncryption");
            EasyEncryption.Config.pathEnv1 = Path.Combine(confpath, ".env");
        }
        Env.Load(EasyEncryption.Config.pathEnv1);
        string v = "1.4.0-release";
        string lang = Environment.GetEnvironmentVariable("LANGUAGE");
        if (lang == "RU")
        {   
            System.Console.WriteLine("""
                Список команд:
                en - Зашифровать сообщение
                de - Расшифровать сообщение
                bk - вернуться назад
                help - помощь (список команд)
                config - настройки
                version - текущуя версия программы
                
                """);

            while (true)
            {
                System.Console.Write("Ввод: ");

                string vybor = Console.ReadLine().ToUpper();

                if (vybor == "ENCRYPT" || vybor == "EN")
                {
                    System.Console.WriteLine("Чтобы отменить команду введите - back или bk");
                    System.Console.Write("Введите сообщение: ");
                    string word = Console.ReadLine().ToLower();
                    Encryption.Encrypt(word);
                }
                else if (vybor == "DECRYPT" || vybor == "DE")
                {
                    System.Console.WriteLine("Чтобы отменить команду введите - back или bk");
                    System.Console.Write("Введите сообщение: ");
                    string word = Console.ReadLine();
                    Encryption.Decrypt(word);
                }
                else if (vybor == "0")
                {
                    zapusk = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("The program is completed!");
                    Console.ResetColor();
                    break;
                }
                else if (vybor == "VERSION")
                {
                    System.Console.WriteLine(v);
                }
                else if (vybor == "CONFIG")
                {
                    string keyyStr = Environment.GetEnvironmentVariable("KEY");

                    if (int.TryParse(keyyStr, out int keyy))
                    { }
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine($"""
                     _________________________
                     Config EasyEncryption App

                     key={keyy}
                     language={lang}
                     _________________________
                     """);
                    Console.ResetColor();
                    //System.Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    System.Console.Write("Config: ");
                    Console.ResetColor();
                    string comm = Console.ReadLine();
                    string[] com = comm.Split('=');
                    if (com[0] == "key")
                    {
                    
                        EasyEncryption.Config.UpdKey(EasyEncryption.Config.pathEnv1, com[1]);
                        zapusk = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("Ready!");
                        Console.ResetColor();
                        break;

                    }
                    else if (com[0] == "language")
                    {
                        
                        EasyEncryption.Config.UpdLang(EasyEncryption.Config.pathEnv1, com[1]);
                        zapusk = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("Ready!");
                        Console.ResetColor();
                        break;

                    }


                }
                else if (vybor == "HELP")
                {
                    System.Console.WriteLine("""

                Список команд:
                en - Зашифровать сообщение
                de - Расшифровать сообщение
                bk - вернуться назад
                help - помощь (список команд)
                config - настройки
                version - текущуя версия программы

                """);
                }

            }
            if (zapusk == true)
                Main();

        }
        else if (lang == "EN")
        {
            System.Console.WriteLine("""
                List of commands:
                en - Encrypt the message
                de - Decrypt the message
                bk - go back
                help - help (list of commands)
                config - settings
                version - the current version of the program
                
                """);

            while (true)
            {
                System.Console.Write("Input: ");

                string vybor = Console.ReadLine().ToUpper();

                if (vybor == "ENCRYPT" || vybor == "EN")
                {
                    System.Console.WriteLine("To cancel the command, type - back or bk");
                    System.Console.Write("Enter message: ");
                    string word = Console.ReadLine().ToLower();
                    Encryption.Encrypt(word);
                }
                else if (vybor == "DECRYPT" || vybor == "DE")
                {
                    System.Console.WriteLine("To cancel the command, type - back or bk");
                    System.Console.Write("Enter message: ");
                    string word = Console.ReadLine();
                    Encryption.Decrypt(word);
                }
                else if (vybor == "0")
                {
                    zapusk = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("The program is completed!");
                    Console.ResetColor();
                    break;
                }
                else if (vybor == "VERSION")
                {
                    System.Console.WriteLine(v);
                }
                else if (vybor == "CONFIG")
                {
                    string keyyStr = Environment.GetEnvironmentVariable("KEY");

                    if (int.TryParse(keyyStr, out int keyy))
                    { }
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine($"""
                     _________________________                    
                     Config EasyEncryption App

                     KEY={keyy}
                     LANGUAGE={lang}
                     _________________________
                     """);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    System.Console.Write("Config: ");
                    Console.ResetColor();
                    string comm = Console.ReadLine();
                    string[] com = comm.Split('=');
                    if (com[0] == "key")
                    {
                        EasyEncryption.Config.UpdKey(EasyEncryption.Config.pathEnv1, com[1]);
                        zapusk = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("Ready!");
                        Console.ResetColor(); 
                        break;
                    }
                    else if (com[0] == "language")
                    {
                        EasyEncryption.Config.UpdLang(EasyEncryption.Config.pathEnv1, com[1]);
                        zapusk = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("Ready!");
                        Console.ResetColor();
                        break;
                    }


                }
                else if (vybor == "HELP")
                {
                    System.Console.WriteLine("""

                            List of commands:
                            en - Encrypt the message
                            de - Decrypt the message
                            bk - go back
                            help - help (list of commands)
                            config - settings
                            version - the current version of the program
                    
                            """);
                }

            }
            if (zapusk == true)
                Main();
        }
 
    }
}