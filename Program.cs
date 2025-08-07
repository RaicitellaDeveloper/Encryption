using System;
using System.Collections.Generic;
using DotNetEnv;

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
            //System.Console.WriteLine("1. Зашифровать сообщение");
            //System.Console.WriteLine("2. Расшифровать сообщение");

            string vybor = Console.ReadLine();

            if (vybor == "encrypt" || vybor == "en")
            {
                Encrypt();
            }
            else if (vybor == "decrypt" || vybor == "de")
            {
                Decrypt();
            }
            else if (vybor == "0")
            {
                break;
            }
            else if (vybor == "help")
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

        { }
    }

    static void Encrypt()
    {
        Dictionary<char, int> letters = new Dictionary<char, int>
        {
            { ' ', 0 },
            { 'А', 1 }, { 'Б', 2 }, { 'В', 3 }, { 'Г', 4 }, { 'Д', 5 },
            { 'Е', 6 }, { 'Ё', 7 }, { 'Ж', 8 }, { 'З', 9 }, { 'И', 10 },
            { 'Й', 11 }, { 'К', 12 }, { 'Л', 13 }, { 'М', 14 }, { 'Н', 15 },
            { 'О', 16 }, { 'П', 17 }, { 'Р', 18 }, { 'С', 19 }, { 'Т', 20 },
            { 'У', 21 }, { 'Ф', 22 }, { 'Х', 23 }, { 'Ц', 24 }, { 'Ч', 25 },
            { 'Ш', 26 }, { 'Щ', 27 }, { 'Ъ', 28 }, { 'Ы', 29 }, { 'Ь', 30 },
            { 'Э', 31 }, { 'Ю', 32 }, { 'Я', 33 }
        };
        System.Console.WriteLine("Чтобы отменить команду введите - back или bk");
        System.Console.Write("Введите сообщение: ");
        string word = Console.ReadLine().ToUpper();

        if (word == "BACK" || word == "BK")
        {
            return;
        }
        else
        {


            List<int> result = new List<int>();

            List<string> res = new List<string>();

            string keyStr = Environment.GetEnvironmentVariable("KEY");

            if (int.TryParse(keyStr, out int key))
            {

            }
            else
            {
                Console.WriteLine("Ошибка: переменная KEY не является числом");
            }



            int i = 0;
            while (i < word.Length)
            {
                if (letters.ContainsKey(word[i]))
                {
                    int a = letters[word[i]];

                    int encrypt = a ^ key;

                    result.Add(encrypt);
                }
                else
                {
                    //Console.WriteLine($"Символ '{word[i]}' не поддерживается.");
                    result.Add(0);
                }

                i++;
            }

            foreach (int q in result)
            {
                if (q == 0)
                {
                    res.Add("⍰⍰⍰");
                }
                else
                {
                    res.Add(q.ToString());
                }
            }

            {
                string output = string.Join("-", res);
                Console.WriteLine(output);
                //System.Console.Write($"KEY: {key}");
                System.Console.WriteLine($"\nКол-во символов в сообщении: {result.Count}");
            }
        }
    }

    static void Decrypt()
    {
        Dictionary<int, char> letters = new Dictionary<int, char>
            {
                { 0, ' ' },
                { 1, 'А' },
                { 2, 'Б' },
                { 3, 'В' },
                { 4, 'Г' },
                { 5, 'Д' },
                { 6, 'Е' },
                { 7, 'Ё' },
                { 8, 'Ж' },
                { 9, 'З' },
                { 10, 'И' },
                { 11, 'Й' },
                { 12, 'К' },
                { 13, 'Л' },
                { 14, 'М' },
                { 15, 'Н' },
                { 16, 'О' },
                { 17, 'П' },
                { 18, 'Р' },
                { 19, 'С' },
                { 20, 'Т' },
                { 21, 'У' },
                { 22, 'Ф' },
                { 23, 'Х' },
                { 24, 'Ц' },
                { 25, 'Ч' },
                { 26, 'Ш' },
                { 27, 'Щ' },
                { 28, 'Ъ' },
                { 29, 'Ы' },
                { 30, 'Ь' },
                { 31, 'Э' },
                { 32, 'Ю' },
                { 33, 'Я' },
                { 34, '⍰' }
            };

        List<int> result = new List<int>();
        List<char> res = new List<char>();
        System.Console.WriteLine("Чтобы отменить команду введите - back или bk");
        System.Console.Write("Введите сообщение: ");
        try
        {
            string word = Console.ReadLine().ToUpper();

            if (word == "BACK" || word == "BK")
            {
                return;
            }
            else
            {
                string keyStr = Environment.GetEnvironmentVariable("KEY");

                if (int.TryParse(keyStr, out int key))
                {

                }
                else
                {
                    Console.WriteLine("Ошибка: переменная KEY не является числом");
                }
                string a = "";

                for (int i = 0; i < word.Length;)
                {
                    if (word[i] != '-')
                    {
                        if (a.Length == 3)
                        {
                            if (a != "⍰⍰⍰")
                            {
                                result.Add(Convert.ToInt32(a));
                            }
                            else
                            {
                                result.Add(34);
                            }

                            a = "";
                        }
                        else
                        {
                            a += word[i];
                            i++;
                        }

                    }
                    else
                    {
                        i++;
                    }

                }
                if (a.Length > 0)
                {
                    if (a != "⍰⍰⍰")
                    {
                        result.Add(Convert.ToInt32(a));
                    }
                    else
                    {
                        result.Add(34);
                    }
                }

                int x = 0;
                while (x < result.Count)
                {
                    int Decrypt = result[x] ^ key;


                    if (letters.ContainsKey(Decrypt))
                    {

                        res.Add(letters[Decrypt]);
                    }
                    else
                    {
                        //Console.WriteLine($"Символ '{word[i]}' не поддерживается.");
                        res.Add('⍰');
                    }
                    x++;
                }

                {
                    string output = string.Join("", res);
                    Console.WriteLine(output);

                    System.Console.WriteLine($"Кол-во символов в сообщении: {result.Count}");
                }


            }
        }
        catch (System.FormatException)
        {
                System.Console.WriteLine("ОШИБКА");
            }
    }
}