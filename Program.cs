using System;
using System.Collections.Generic;
using DotNetEnv;
using System.Diagnostics;
using EasyEncryption;

internal class Program
{
    
    private static void Main(string[] args)
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;

        Env.Load();
        string v = "1.4.0-dev";
        string lang = Environment.GetEnvironmentVariable("LANGUAGE");
        if (lang == "RU")
        {
            System.Console.WriteLine("""
                Список команд:

                !en - Зашифровать сообщение
                !de - Расшифровать сообщение
                !bk - вернуться назад
                !help - помощь (список команд)
                !config - настройки
                
                """);

            while (true)
            {
                System.Console.Write("Ввод: ");

                string vybor = Console.ReadLine().ToUpper();

                if (vybor == "!ENCRYPT" || vybor == "!EN")
                {
                    System.Console.WriteLine("Чтобы отменить команду введите - back или bk");
                    System.Console.Write("Введите сообщение: ");
                    string word = Console.ReadLine().ToUpper();
                    Encryption.Encrypt(word);
                }
                else if (vybor == "!DECRYPT" || vybor == "!DE")
                {
                    System.Console.WriteLine("Чтобы отменить команду введите - back или bk");
                    System.Console.Write("Введите сообщение: ");
                    string word = Console.ReadLine();
                    Encryption.Decrypt(word);
                }
                else if (vybor == "!0")
                {
                    break;
                }
                else if (vybor == "!VERSION")
                {
                    System.Console.WriteLine(v);
                }
                else if (vybor == "!CONFIG")
                {
                    string keyyStr = Environment.GetEnvironmentVariable("KEY");

                    if (int.TryParse(keyyStr, out int keyy))
                    { }
                    System.Console.WriteLine($"""
                        Config EasyEncryption App

                        KEY={keyy}
                        LANGUAGE={lang}
                     """);
                    //System.Console.WriteLine();
                    string comm = Console.ReadLine();
                    string[] com = comm.Split('=');
                    if(com[0] == "key")
                    {
                        string envPath = ".env";
                        EasyEncryption.Config.UpdKey(envPath,com[1]);

                    }else if(com[0] == "language")
                    {
                        string envPath = ".env";
                        EasyEncryption.Config.UpdLang(envPath,com[1]);
                        
                    }
                    
                    
                }
                else if (vybor == "!HELP")
                {
                    System.Console.WriteLine("""
                Список команд:

                !en - Зашифровать сообщение
                !de - Расшифровать сообщение
                !bk - вернуться назад
                !help - помощь (список команд)
                !config - настройки

                
                """);
                }

            }
        }
        else if (lang == "EN")
        {
            System.Console.WriteLine("""
                List of commands: 

                encrypt - Encrypt a message, abbreviated form of the command - en 
                decrypt - Decrypt the message, abbreviated form of the command - de 
                back - go back, abbreviated form of the command - bk 
                help - list of commands
                
                """);

            while (true)
            {
                System.Console.Write("Input: ");

                string vybor = Console.ReadLine().ToUpper();

                if (vybor == "!ENCRYPT" || vybor == "!EN")
                {
                    System.Console.WriteLine("To cancel the command, type - back or bk");
                    System.Console.Write("Enter message: ");
                    string word = Console.ReadLine().ToUpper();
                    Encryption.Encrypt(word);
                }
                else if (vybor == "!DECRYPT" || vybor == "!DE")
                {
                    System.Console.WriteLine("To cancel the command, type - back or bk");
                    System.Console.Write("Enter message: ");
                    string word = Console.ReadLine();
                    Encryption.Decrypt(word);
                }
                else if (vybor == "!0")
                {
                    break;
                }
                else if (vybor == "!VERSION")
                {
                    System.Console.WriteLine(v);
                }
                else if (vybor == "!CONFIG")
                {
                    string keyyStr = Environment.GetEnvironmentVariable("KEY");

                    if (int.TryParse(keyyStr, out int keyy))
                    { }
                    System.Console.WriteLine($"""
                        Config EasyEncryption App

                        KEY={keyy}
                        LANGUAGE={lang}
                     """);
                    string comm = Console.ReadLine();
                    string[] com = comm.Split('=');
                    if(com[0] == "key")
                    {
                        string envPath = ".env";
                        EasyEncryption.Config.UpdKey(envPath,com[1]);

                    }else if(com[0] == "language")
                    {
                        string envPath = ".env";
                        EasyEncryption.Config.UpdLang(envPath,com[1]);
                        
                    }
                    
                    
                }
                else if (vybor == "!HELP")
                {
                    System.Console.WriteLine("""
                            List of commands: 

                            encrypt - Encrypt a message, abbreviated form of the command - en 
                            decrypt - Decrypt the message, abbreviated form of the command - de 
                            back - go back, abbreviated form of the command - bk 
                            help - list of commands
                    
                            """);
                }

            }
        }
 
    }
}