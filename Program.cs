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

                encrypt - Зашифровать сообщение, сокращенный вид команды - en
                decrypt - Расшифровать сообщение, сокращенный вид команды - de
                back - вернуться назад, сокращенный вид команды - bk
                help - список команд)
                
                """);

            while (true)
            {
                System.Console.Write("Ввод: ");

                string vybor = Console.ReadLine().ToUpper();

                if (vybor == "ENCRYPT" || vybor == "EN")
                {
                    System.Console.WriteLine("Чтобы отменить команду введите - back или bk");
                    System.Console.Write("Введите сообщение: ");
                    string word = Console.ReadLine().ToUpper();
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
                    break;
                }
                else if (vybor == "VERSION")
                {
                    System.Console.WriteLine(v);
                }
                else if (vybor == "CONFIG")
                {
                    var envPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".env");
                    Process.Start("notepad.exe", envPath);
                }
                else if (vybor == "HELP")
                {
                    System.Console.WriteLine("""
                Список команд:

                encrypt - Зашифровать сообщение, сокращенный вид команды - en
                decrypt - Расшифровать сообщение, сокращенный вид команды - de
                back - вернуться назад, сокращенный вид команды - bk
                help - помощь (список команд)
                
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

                if (vybor == "ENCRYPT" || vybor == "EN")
                {
                    System.Console.WriteLine("To cancel the command, type - back or bk");
                    System.Console.Write("Enter message: ");
                    string word = Console.ReadLine().ToUpper();
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
                    break;
                }
                else if (vybor == "VERSION")
                {
                    System.Console.WriteLine(v);
                }
                else if (vybor == "CONFIG")
                {
                    // Путь к %AppData%
                    string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    // Путь к %LocalAppData%
                    string localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

                    // Например, сделаем подпапку для твоего приложения
                    string myAppFolder = Path.Combine(localAppDataPath, "EncryptionApp");
                    Directory.CreateDirectory(myAppFolder);

                    // Теперь путь к .env
                    string envPath = Path.Combine(myAppFolder, ".env");

                    Process.Start("notepad.exe", envPath);
                }
                else if (vybor == "HELP")
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