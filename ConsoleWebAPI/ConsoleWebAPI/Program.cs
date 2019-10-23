using ConsoleWebAPI.Model;
using ConsoleWebAPI.WebAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWebAPI
{
    class Program
    {
        static string uri = "https://localhost:44382/api/";

        static void Main(string[] args)
        {

            ConsoleKeyInfo UserInput;
            string result;

            do
            {
                Console.WriteLine("1. Принимает интервал дат (две даты с-по) и сохраняет их в базе данных");
                Console.WriteLine("2. Принимает интервал дат (две даты с-по) и " +
                    "возвращает список интервалов, которые были сохранены с помощью первого веб-метода и пересекаются с ним.");
                Console.WriteLine("3. Выход\n");
                Console.Write("Выберите действие: ");

                UserInput = Console.ReadKey();
                result = UserInput.KeyChar.ToString();
                Console.Clear();


                if (result == "1")
                {
                    Console.Write("Введите дату \"с\" (ГГГГ-ММ-ДД): ");
                    string start = Console.ReadLine();
                    Console.Write("Введите дату \"по\" (ГГГГ-ММ-ДД): ");
                    string end = Console.ReadLine();


                    WebApi wa = new WebApi(start, end);
                    var x = wa.WriteToDBAsync(uri);


                    Console.Write("\nИнтервал дат успешно добавлен в базу данных. Нажмите любую кнопку, чтобы вернуться в меню");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (result == "2")
                {
                    Console.Write("Введите дату \"с\" (ГГГ.ММ.ДД): ");
                    string start = Console.ReadLine();
                    Console.Write("Введите дату \"по\" (ГГГ.ММ.ДД): ");
                    string end = Console.ReadLine();

                    Console.Write("\nСписок интервалов, с которыми были найдены пересечения:\n");
                    ShowMatches(start, end);

                    Console.ReadKey();
                    Console.Clear();
                }


            } while (result != "3");

        }
        public static async void ShowMatches(string start, string end)
        {
            WebApi wa = new WebApi(start, end);
            Dictionary<string, string> returnedResult = await wa.GetMatchesAsync(uri);

            if (returnedResult.Count == 0)
                Console.WriteLine("Нет совпадений");

            foreach (var i in returnedResult)
            {
                Console.WriteLine($"{i.Key} / {i.Value}");
            }
        }



    }
}

