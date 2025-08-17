using System;
using System.Collections.Generic;
using DotNetEnv;
using EasyEncryption;

internal class Program
{
    
    private static void Main(string[] args)
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;

        Env.Load();

        System.Console.WriteLine("""
                Список команд:

                encrypt - Зашифровать сообщение, сокращенный вид команды - en
                decrypt - Расшифровать сообщение, сокращенный вид команды - de
                back - вернуться назад, сокращенный вид команды - bk
                help - помощь (список команд)
                
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
                string word = Console.ReadLine().ToUpper();
                Encryption.Decrypt(word);
            }
            else if (vybor == "0")
            {
                break;
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
}