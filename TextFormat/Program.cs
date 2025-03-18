//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Newtonsoft.Json;
//using CsvHelper;
//using System.Xml.Serialization;
//using YamlDotNet.Serialization;
//using static System.Net.WebRequestMethods;
//using System.Diagnostics;
//using System.Globalization;
//using YamlDotNet.Serialization.NamingConventions;

//Управление фильмами: Считывание и обработка данных о фильмах (идентификатор, название, жанр, год выпуска, рейтинг)

using System.Collections.Generic;

namespace TextFormat
{
    public class Program
    {
        //метод сортировки списка фильмов
        //принимает список объектов и параметр для сортировки
        public static List<ModelFilm> SortFilms(List<ModelFilm> oldList, int parametrSort)
        {
            List<ModelFilm> sortedList = new List<ModelFilm>();

            if (parametrSort == 1)
            {
                sortedList = oldList.OrderByDescending(it => it.rating).ToList();  //сортирует элементы списка от большего к меньшему по rating
                foreach (var film in sortedList)
                {
                    Console.WriteLine(film.ToString());
                }
            }
            if (parametrSort == 2)
            {
                sortedList = oldList.OrderByDescending(it => it.year).ToList();  //сортирует элементы списка от большего к меньшему по year
                foreach (var film in sortedList)
                {
                    Console.WriteLine(film.ToString());
                }
            }

            return sortedList;
        }

        //метод поиска фильмов по введенной строке
        public static List<ModelFilm> SearchFilm(List<ModelFilm> filmList, string search)
        {
            search = search.ToLower(); // преобразование строки в нижний регистр

            return filmList.Where(film =>
                film.name.ToLower().Contains(search) ||   //проверка на содержание строки в названии фильма
                film.genre.ToLower().Contains(search) ||  //проверка на содержание строки в жанре фильма
                film.year.ToString().Contains(search) ||  //проверка на содержание строки в годе выпуска фильма
                film.rating.ToString().Contains(search)   //проверка на содержание строки в рейтинге фильма
            ).ToList();
        }

        public static void Main(string[] args)
        {
            // лист фильмов
            List<ModelFilm> filmList = new List<ModelFilm> {
                new ModelFilm (1,"Звездные войны","Фантастика",1980,8.7),
                new ModelFilm (2,"Побег из Шоушенка","Драма",1994,9.3),
                new ModelFilm (3,"Титаник","Драма",1997,7.8),
                new ModelFilm (4,"Храброе сердце","Исторический",1995,8.3),
                new ModelFilm (5,"Леон","Боевик",1994,8.5),
                new ModelFilm (6,"Матрица","Фантастика",1999,8.7),
                new ModelFilm (7,"Интерстеллар","Фантастика",2014,8.6),
                new ModelFilm (8,"Гладиатор","Исторический",2000,8.5)
            };

            //// Запись в CSV
            //WorkingWithFiles.WriteFile(filmList, "filmsCSV.csv");

            //// Чтение из CSV
            //List<ModelFilm> readFilmsCsv = WorkingWithFiles.ReadFile<ModelFilm>("filmsCSV.csv");

            //foreach (var film in readFilmsCsv)
            //{
            //    Console.WriteLine(film.ToString());
            //}
            //Console.WriteLine("\n");


            //// Запись в JSON
            //WorkingWithFiles.WriteFile(filmList, "filmsJSON.json");

            //// Чтение из JSON
            //List<ModelFilm> readFilmsJson = WorkingWithFiles.ReadFile<ModelFilm>("filmsJSON.json");

            //foreach (var film in readFilmsJson)
            //{
            //    Console.WriteLine(film.ToString());
            //}
            //Console.WriteLine("\n");


            //// Запись в XML
            //WorkingWithFiles.WriteFile(filmList, "filmsXML.xml");

            //// Чтение из XML
            //List<ModelFilm> readFilmsXml = WorkingWithFiles.ReadFile<ModelFilm>("filmsXML.xml");

            //foreach (var film in readFilmsXml)
            //{
            //    Console.WriteLine(film.ToString());
            //}
            //Console.WriteLine("\n");


            //// Запись в YAML
            //WorkingWithFiles.WriteFile(filmList, "filmsYAML.yaml");

            //// Чтение из YAML
            //List<ModelFilm> readFilmsYaml = WorkingWithFiles.ReadFile<ModelFilm>("filmsYAML.yaml");

            //foreach (var film in readFilmsYaml)
            //{
            //    Console.WriteLine(film.ToString());
            //}


            //текстовое меню для пользователя
            Console.WriteLine("МЕНЮ:");
            Console.WriteLine("1. Считывание данных из файла");
            Console.WriteLine("2. Запись данных в файл");
            Console.WriteLine("3. Вывод данных на экран");
            Console.WriteLine("4. Сортировка данных по выбранному параметру");
            Console.WriteLine("5. Поиск данных по подстроке");
            Console.WriteLine("6. Добавление данных в структуру");
            Console.WriteLine("7. Удаление данных из структуры");
            Console.WriteLine("8. Изменение данных структуры");
            Console.Write("\nвведите номер действия: ");
            int deistvie = int.Parse(Console.ReadLine());


            //List<ModelFilm> sortedList = new List<ModelFilm>();
            //sortedList = SortFilms(filmList, 2);

            List<ModelFilm> searchList = new List<ModelFilm>();
            searchList = SearchFilm(filmList, "Драма");
            foreach (var film in searchList)
            {
                Console.WriteLine(film.ToString());
            }


            //if (string.IsNullOrEmpty(search) || filmList == null || filmList.Count == 0)
            //{
            //    Console.WriteLine("некорректная строка");
            //}

            Console.ReadKey();
        }
    }
}
