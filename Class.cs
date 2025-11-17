using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Text;
using DotNetEnv;
using System.Runtime.InteropServices;
using System.IO;

namespace EasyEncryption
{
    class Encryption
    {
        static string lang = Environment.GetEnvironmentVariable("LANGUAGE");
        public static void Encrypt(string word)
        {
            Dictionary<char, int> letters = new Dictionary<char, int>
        {
            { ' ', 0 },

            // Русский алфавит
            { 'а', 1 }, { 'б', 2 }, { 'в', 3 }, { 'г', 4 }, { 'д', 5 },
            { 'е', 6 }, { 'ё', 7 }, { 'ж', 8 }, { 'з', 9 }, { 'и', 10 },
            { 'й', 11 }, { 'к', 12 }, { 'л', 13 }, { 'м', 14 }, { 'н', 15 },
            { 'о', 16 }, { 'п', 17 }, { 'р', 18 }, { 'с', 19 }, { 'т', 20 },
            { 'у', 21 }, { 'ф', 22 }, { 'х', 23 }, { 'ц', 24 }, { 'ч', 25 },
            { 'ш', 26 }, { 'щ', 27 }, { 'ъ', 28 }, { 'ы', 29 }, { 'ь', 30 },
            { 'э', 31 }, { 'ю', 32 }, { 'я', 33 },

            // Английский алфавит
            { 'a', 35 }, { 'b', 36 }, { 'c', 37 }, { 'd', 38 }, { 'e', 39 },
            { 'f', 40 }, { 'g', 41 }, { 'h', 42 }, { 'i', 43 }, { 'j', 44 },
            { 'k', 45 }, { 'l', 46 }, { 'm', 47 }, { 'n', 48 }, { 'o', 49 },
            { 'p', 50 }, { 'q', 51 }, { 'r', 52 }, { 's', 53 }, { 't', 54 },
            { 'u', 55 }, { 'v', 56 }, { 'w', 57 }, { 'x', 58 }, { 'y', 59 },
            { 'z', 60 },

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
                    if (lang == "RU")
                        Console.WriteLine("Ошибка: переменная KEY не является числом");
                    else if (lang == "EN")
                        Console.WriteLine("Error: The KEY variable is not a number");
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
                    byte[] bytes = Encoding.UTF8.GetBytes(output);
                    string base64 = Convert.ToBase64String(bytes);
                    //System.Console.WriteLine(output);
                    Console.WriteLine(base64);
                    //System.Console.Write($"KEY: {key}");
                    if (lang == "RU")
                        System.Console.WriteLine($"Кол-во символов в сообщении: {res.Count}");
                    else if (lang == "EN")
                        System.Console.WriteLine($"Number of characters in a message: {res.Count}");
                    System.Console.WriteLine(" ");
                }
            }
        }

        public static void Decrypt(string w)
        {
            Dictionary<int, char> letters = new Dictionary<int, char>
        {
            { 0, ' ' },

            // Русский алфавит
            { 1, 'а' }, { 2, 'б' }, { 3, 'в' }, { 4, 'г' }, { 5, 'д' },
            { 6, 'е' }, { 7, 'ё' }, { 8, 'ж' }, { 9, 'з' }, { 10, 'и' },
            { 11, 'й' }, { 12, 'к' }, { 13, 'л' }, { 14, 'м' }, { 15, 'н' },
            { 16, 'о' }, { 17, 'п' }, { 18, 'р' }, { 19, 'с' }, { 20, 'т' },
            { 21, 'у' }, { 22, 'ф' }, { 23, 'х' }, { 24, 'ц' }, { 25, 'ч' },
            { 26, 'ш' }, { 27, 'щ' }, { 28, 'ъ' }, { 29, 'ы' }, { 30, 'ь' },
            { 31, 'э' }, { 32, 'ю' }, { 33, 'я' },

            // Английский алфавит
            { 35, 'a' }, { 36, 'b' }, { 37, 'c' }, { 38, 'd' }, { 39, 'e' },
            { 40, 'f' }, { 41, 'g' }, { 42, 'h' }, { 43, 'i' }, { 44, 'j' },
            { 45, 'k' }, { 46, 'l' }, { 47, 'm' }, { 48, 'n' }, { 49, 'o' },
            { 50, 'p' }, { 51, 'q' }, { 52, 'r' }, { 53, 's' }, { 54, 't' },
            { 55, 'u' }, { 56, 'v' }, { 57, 'w' }, { 58, 'x' }, { 59, 'y' },
            { 60, 'z' },

            //цифры
            {71,'0'},{72,'1'},{73,'2'},{74,'3'},{75,'4'},{76,'5'},{77,'6'},{78,'7'},{79,'8'},{80,'9'},

            { 34, '⍰' },{61,','},{62,'!'},{63,'?'},{64,'/'},{65,'|'},{66,'.'},{67,'-'},{68,'_'},{69,'='},{70,'+'},{81,':'},{82,';'}
        };

            try
            {


                if (w == "back" || w == "bk")
                {
                    return;
                }
                else
                {
                    byte[] bytess = Convert.FromBase64String(w);
                    string word = Encoding.UTF8.GetString(bytess);
                    string keyStr = Environment.GetEnvironmentVariable("KEY");

                    if (int.TryParse(keyStr, out int key))
                    { }
                    else
                    {
                        if (lang == "RU")
                            Console.WriteLine("Ошибка: переменная KEY не является числом");
                        else if (lang == "EN")
                            Console.WriteLine("Error: The KEY variable is not a number");
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

                        if (lang == "RU")
                            System.Console.WriteLine($"Кол-во символов в сообщении: {res.Count}");
                        else if (lang == "EN")
                            System.Console.WriteLine($"Number of characters in a message: {res.Count}");
                        System.Console.WriteLine(" ");
                    }


                }
            }
            catch (System.FormatException)
            {
                if (lang == "RU")
                    System.Console.WriteLine("ОШИБКА");
                else if (lang == "EN")
                    System.Console.WriteLine("ERROR");
            }
        }
    }
    
    class Config
    {
        public static async void UpdKey(string envPath, string key)
        {
            string zamena = $"KEY={key}";

                var line = File.ReadAllLines(envPath).ToList();

                line.RemoveAll(line => line.StartsWith("KEY"));

                File.WriteAllLines(envPath, line);

                using (StreamWriter writer = new StreamWriter(envPath, true))
                {
                    await writer.WriteLineAsync(zamena);
                }

        }

        public static async void UpdLang(string envPath, string lang)
        {
            string zamena = $"LANGUAGE={lang}";

            var line = File.ReadAllLines(envPath).ToList();

            line.RemoveAll(line => line.StartsWith("LANGUAGE"));

            File.WriteAllLines(envPath, line);

            using (StreamWriter writer = new StreamWriter(envPath, true))
            {
                await writer.WriteLineAsync(zamena);
            }

        }
        

        public static void CreateEnv()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                string homePath = Environment.GetEnvironmentVariable("HOME");
                string confpath = $"{homePath}/.config/EasyEncryption";
                string confpath2 = $"{homePath}/.config/EasyEncryption/.env";
                string conf = """ 
                LANGUAGE=EN 
                KEY=131 
                """;
                if (!File.Exists(confpath2))
                {
                    Directory.CreateDirectory(confpath);
                    using (FileStream fs = File.Create(confpath2))
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(conf);
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
                else
                {
                    return;
                }

            }else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                string confpath = $"{appDataPath}/EasyEncryption";
                string confpath2 = $"{appDataPath}/EasyEncryption/.env";
                string conf = """ 
                LANGUAGE=EN 
                KEY=131 
                """;
                if (!File.Exists(confpath2))
                {
                    Directory.CreateDirectory(confpath);
                    using (FileStream fs = File.Create(confpath2))
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(conf);
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
                else
                {
                    return;
                }
            }
        }


    }
}