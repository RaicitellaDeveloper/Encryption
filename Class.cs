using System;
using System.Collections.Generic;
using DotNetEnv;

namespace EasyEncryption
{
    class Encryption
    {

        
        public static void Encrypt(string word)
        {
            Dictionary<char, int> letters = new Dictionary<char, int>
        {
            { ' ', 0 },

            // Русский алфавит
            { 'А', 1 }, { 'Б', 2 }, { 'В', 3 }, { 'Г', 4 }, { 'Д', 5 },
            { 'Е', 6 }, { 'Ё', 7 }, { 'Ж', 8 }, { 'З', 9 }, { 'И', 10 },
            { 'Й', 11 }, { 'К', 12 }, { 'Л', 13 }, { 'М', 14 }, { 'Н', 15 },
            { 'О', 16 }, { 'П', 17 }, { 'Р', 18 }, { 'С', 19 }, { 'Т', 20 },
            { 'У', 21 }, { 'Ф', 22 }, { 'Х', 23 }, { 'Ц', 24 }, { 'Ч', 25 },
            { 'Ш', 26 }, { 'Щ', 27 }, { 'Ъ', 28 }, { 'Ы', 29 }, { 'Ь', 30 },
            { 'Э', 31 }, { 'Ю', 32 }, { 'Я', 33 },

            // Английский алфавит
            { 'A', 35 }, { 'B', 36 }, { 'C', 37 }, { 'D', 38 }, { 'E', 39 },
            { 'F', 40 }, { 'G', 41 }, { 'H', 42 }, { 'I', 43 }, { 'J', 44 },
            { 'K', 45 }, { 'L', 46 }, { 'M', 47 }, { 'N', 48 }, { 'O', 49 },
            { 'P', 50 }, { 'Q', 51 }, { 'R', 52 }, { 'S', 53 }, { 'T', 54 },
            { 'U', 55 }, { 'V', 56 }, { 'W', 57 }, { 'X', 58 }, { 'Y', 59 },
            { 'Z', 60 },

            //цифры
            {'0',71},{'1',72},{'2',73},{'3',74},{'4',75},{'5',76},{'6',77},{'7',78},{'8',79},{'9',80},

            { '⍰', 34 }, {',',61},{'!',62},{'?',63},{'/',64},{'|',65},{'.',66},{'-',67},{'_',68},{'=',69},{'+',70},{':',81},{';',82}
        };

            if (word == "BACK" || word == "BK")
            {
                return;
            }
            else
            {
                List<string> res = new List<string>();

                string keyStr = Environment.GetEnvironmentVariable("KEY");

                if (int.TryParse(keyStr, out int key))
                { }
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

                        res.Add(Convert.ToString(encrypt));
                    }
                    else
                    {
                        res.Add("⍰⍰⍰");
                    }

                    i++;
                }

                {
                    string output = string.Join("-", res);
                    Console.WriteLine(output);
                    //System.Console.Write($"KEY: {key}");
                    System.Console.WriteLine($"Кол-во символов в сообщении: {res.Count}");
                    System.Console.WriteLine(" ");
                }
            }
        }


        public static void Decrypt(string word)
        {
            Dictionary<int, char> letters = new Dictionary<int, char>
        {
            { 0, ' ' },

            // Русский алфавит
            { 1, 'А' }, { 2, 'Б' }, { 3, 'В' }, { 4, 'Г' }, { 5, 'Д' },
            { 6, 'Е' }, { 7, 'Ё' }, { 8, 'Ж' }, { 9, 'З' }, { 10, 'И' },
            { 11, 'Й' }, { 12, 'К' }, { 13, 'Л' }, { 14, 'М' }, { 15, 'Н' },
            { 16, 'О' }, { 17, 'П' }, { 18, 'Р' }, { 19, 'С' }, { 20, 'Т' },
            { 21, 'У' }, { 22, 'Ф' }, { 23, 'Х' }, { 24, 'Ц' }, { 25, 'Ч' },
            { 26, 'Ш' }, { 27, 'Щ' }, { 28, 'Ъ' }, { 29, 'Ы' }, { 30, 'Ь' },
            { 31, 'Э' }, { 32, 'Ю' }, { 33, 'Я' },

            // Английский алфавит
            { 35, 'A' }, { 36, 'B' }, { 37, 'C' }, { 38, 'D' }, { 39, 'E' },
            { 40, 'F' }, { 41, 'G' }, { 42, 'H' }, { 43, 'I' }, { 44, 'J' },
            { 45, 'K' }, { 46, 'L' }, { 47, 'M' }, { 48, 'N' }, { 49, 'O' },
            { 50, 'P' }, { 51, 'Q' }, { 52, 'R' }, { 53, 'S' }, { 54, 'T' },
            { 55, 'U' }, { 56, 'V' }, { 57, 'W' }, { 58, 'X' }, { 59, 'Y' },
            { 60, 'Z' },

            //цифры
            {71,'0'},{72,'1'},{73,'2'},{74,'3'},{75,'4'},{76,'5'},{77,'6'},{78,'7'},{79,'8'},{80,'9'},

            { 34, '⍰' },{61,','},{62,'!'},{63,'?'},{64,'/'},{65,'|'},{66,'.'},{67,'-'},{68,'_'},{69,'='},{70,'+'},{81,':'},{82,';'}
        };

            try
            {
                if (word == "BACK" || word == "BK")
                {
                    return;
                }
                else
                {
                    string keyStr = Environment.GetEnvironmentVariable("KEY");

                    if (int.TryParse(keyStr, out int key))
                    { }
                    else
                    {
                        Console.WriteLine("Ошибка: переменная KEY не является числом");
                    }

                    string[] parts = word.Split('-');
                    
                    List<int> result = new List<int>();
                    List<char> res = new List<char>();

                    for (int i = 0; i < parts.Length; i++)
                    {
                        if (parts[i] != "⍰⍰⍰")
                        {
                            result.Add(Convert.ToInt32(parts[i]));
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
                        System.Console.WriteLine(" ");
                    }


                }
            }
            catch (System.FormatException)
            {
                System.Console.WriteLine("ОШИБКА");
            }
        }


    }
}