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
        //возвращает новый отсортированный лист
        public static List<ModelFilm> SortFilms(List<ModelFilm> oldList, int parametrSort)
        {
            List<ModelFilm> sortedList = new List<ModelFilm>();

            if (parametrSort == 1) //сортировка по рейтингу фильма
            {
                sortedList = oldList.OrderByDescending(it => it.rating).ToList();  //сортирует элементы списка от большего к меньшему по rating
                foreach (var film in sortedList)
                {
                    Console.WriteLine(film.ToString());
                }
            }
            if (parametrSort == 2)  //сортировка по году выпуска фильма
            {
                sortedList = oldList.OrderByDescending(it => it.year).ToList();  //сортирует элементы списка от большего к меньшему по year
                foreach (var film in sortedList)
                {
                    Console.WriteLine(film.ToString());
                }
            }
            if (parametrSort != 1 && parametrSort != 2)
            {
                Console.WriteLine("введено неверное число");
            }

            return sortedList;
        }

        //метод поиска фильмов по введенной строке
        //принимает список объектов и строку для поиска
        //возвращает новый отфильтрованный лист
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

            while (true)
            {

                //текстовое меню для пользователя
                Console.WriteLine("\nМЕНЮ:");
                Console.WriteLine("1. Считывание данных из файла\n2. Запись данных в файл\n3. Вывод данных на экран\n4. Сортировка данных по выбранному параметру\n5. Поиск данных по подстроке\n6. Добавление данных в структуру\n7. Удаление данных из структуры\n8. Изменение данных структуры");
                Console.Write("\nвведите номер действия: ");
                int deistvie = int.Parse(Console.ReadLine());  //действие, выбранное пользователем

                //выполнение команды, выбранной пользователем
                switch (deistvie)
                {
                    case 1: //Считывание данных из файла
                        {
                            Console.WriteLine("\nвыберите тип файла для считывания данных:");
                            Console.WriteLine("1. CSV\n2. JSON\n3. XML\n4. YAML");
                            Console.Write("введите номер типа файла: ");
                            int tip = int.Parse(Console.ReadLine());
                            switch (tip)
                            {
                                case 1:
                                    {
                                        // Чтение из CSV
                                        List<ModelFilm> readFilmsCsv = WorkingWithFiles.ReadFile<ModelFilm>("filmsCSV.csv");

                                        foreach (var film in readFilmsCsv)
                                        {
                                            Console.WriteLine(film.ToString());
                                        }
                                        Console.WriteLine("\n");
                                        break;
                                    }
                                case 2:
                                    {
                                        // Чтение из JSON
                                        List<ModelFilm> readFilmsJson = WorkingWithFiles.ReadFile<ModelFilm>("filmsJSON.json");

                                        foreach (var film in readFilmsJson)
                                        {
                                            Console.WriteLine(film.ToString());
                                        }
                                        Console.WriteLine("\n");
                                        break;
                                    }
                                case 3:
                                    {
                                        // Чтение из XML
                                        List<ModelFilm> readFilmsXml = WorkingWithFiles.ReadFile<ModelFilm>("filmsXML.xml");

                                        foreach (var film in readFilmsXml)
                                        {
                                            Console.WriteLine(film.ToString());
                                        }
                                        Console.WriteLine("\n");
                                        break;
                                    }
                                case 4:
                                    {
                                        // Чтение из YAML
                                        List<ModelFilm> readFilmsYaml = WorkingWithFiles.ReadFile<ModelFilm>("filmsYAML.yaml");

                                        foreach (var film in readFilmsYaml)
                                        {
                                            Console.WriteLine(film.ToString());
                                        }
                                        break;
                                    }
                                default:
                                    Console.WriteLine("введено неверное число");
                                    break;
                            }
                            break;
                        }
                    case 2:  //Запись данных в файл
                        {
                            Console.WriteLine("\nвыберите тип файла для записи данных:");
                            Console.WriteLine("1. CSV\n2. JSON\n3. XML\n4. YAML");
                            Console.Write("введите номер типа файла: ");
                            int tip = int.Parse(Console.ReadLine());

                            switch (tip)
                            {
                                case 1:
                                    {
                                        // Запись в CSV
                                        WorkingWithFiles.WriteFile(filmList, "filmsCSV.csv");
                                        Console.WriteLine("\n");
                                        break;
                                    }
                                case 2:
                                    {
                                        // Запись в JSON
                                        WorkingWithFiles.WriteFile(filmList, "filmsJSON.json");
                                        Console.WriteLine("\n");
                                        break;
                                    }
                                case 3:
                                    {
                                        // Запись в XML
                                        WorkingWithFiles.WriteFile(filmList, "filmsXML.xml");
                                        Console.WriteLine("\n");
                                        break;
                                    }
                                case 4:
                                    {
                                        // Запись в YAML
                                        WorkingWithFiles.WriteFile(filmList, "filmsYAML.yaml");
                                        break;
                                    }
                                default:
                                    Console.WriteLine("введено неверное число");
                                    break;
                            }
                            break;
                        }
                    case 3:  // Вывод данных на экран
                        {
                            Console.WriteLine("Содержание листа фильмов:");
                            foreach (var film in filmList)
                            {
                                Console.WriteLine(film.ToString());
                            }
                            break;
                        }
                    case 4:  //Сортировка данных по выбранному параметру
                        {
                            Console.WriteLine("Выберите параметр для сортировки фильмов:\n1. По рейтингу\n2. По году выпуска");
                            Console.Write("введите номер параметра сортировки: ");
                            int parametr = int.Parse(Console.ReadLine());
                            List<ModelFilm> sortedList = SortFilms(filmList, parametr);
                            break;
                        }
                    case 5:  //Поиск данных по подстроке
                        {
                            Console.WriteLine("введите строку для поиска информации о фильмах:");
                            string search = Console.ReadLine();

                            if (string.IsNullOrEmpty(search) || filmList == null || filmList.Count == 0)  //проверка что строка не пустая, что лист не пустой и содержит хотя бы 1 запись
                            {
                                Console.WriteLine("некорректная строка или лист фильмов");
                            }
                            else
                            {
                                List<ModelFilm> searchList = SearchFilm(filmList, search);
                                foreach (var film in searchList)   // вывод отфильтрованного листа фильмов
                                {
                                    Console.WriteLine(film.ToString());
                                }
                            }
                            break;
                        }
                    case 6:  //Добавление данных в структуру
                        {
                            Console.Write("\nвведите название нового фильма: ");
                            string nameFilm = Console.ReadLine();
                            Console.Write("введите жанр нового фильма: ");
                            string genreFilm = Console.ReadLine();
                            Console.Write("введите год выпуска нового фильма: ");
                            int yaerFilm = int.Parse(Console.ReadLine());
                            Console.Write("введите рейтинг нового фильма (вещественное число через запятую): ");
                            double reitingFilm = double.Parse(Console.ReadLine());

                            ModelFilm newFilm = new ModelFilm((filmList.Count) + 1, nameFilm, genreFilm, yaerFilm, reitingFilm);  //новый фильм
                            filmList.Add(newFilm);  //добавление нового фильма в лист фильмов
                            break;
                        }
                    case 7:  //Удаление данных из структуры
                        {
                            Console.Write("введите название фильма, который нужно удалить: ");
                            string deleteFilm = Console.ReadLine();

                            ModelFilm searchDelete = filmList.FirstOrDefault(it => it.name.ToLower() == deleteFilm.ToLower());  //поиск фильма в листе для удаления
                            if (searchDelete != null)
                            {
                                filmList.Remove(searchDelete);  //если указанный фильм есть в листе, он удаляется
                                Console.WriteLine($"фильм {searchDelete.name} успешно удален");
                            }
                            else
                            {
                                Console.WriteLine("фильм не найден");
                            }
                            break;
                        }
                    case 8:
                        {
                            Console.Write("введите название фильма, информацию о котором нужно изменить: ");
                            string changeFilm = Console.ReadLine();

                            ModelFilm searchChange = filmList.FirstOrDefault(it => it.name.ToLower() == changeFilm.ToLower());  //поиск фильма в листе для изменения информации
                            if (searchChange != null)  //если фильм найден изменяем информацию
                            {
                                Console.Write("\nвведите название фильма: ");
                                string nameFilm = Console.ReadLine();
                                filmList[searchChange.id - 1].name = nameFilm;    //изменение имени фильма

                                Console.Write("введите жанр фильма: ");
                                string genreFilm = Console.ReadLine();
                                filmList[searchChange.id - 1].genre = genreFilm;    //изменение жанра фильма

                                Console.Write("введите год выпуска фильма: ");
                                int yaerFilm = int.Parse(Console.ReadLine());
                                filmList[searchChange.id - 1].year = yaerFilm;    //изменение года выпуска фильма

                                Console.Write("введите рейтинг фильма (вещественное число через запятую): ");
                                double reitingFilm = double.Parse(Console.ReadLine());
                                filmList[searchChange.id - 1].rating = reitingFilm;    //изменение рейтинга фильма

                                Console.WriteLine($"фильм {searchChange.name} {searchChange.genre} {searchChange.year} {searchChange.rating} успешно изменен");
                            }
                            else
                            {
                                Console.WriteLine("фильм не найден");
                            }
                            break;
                        }
                    default:
                        Console.WriteLine("введено неверное число");
                        break;
                }

            }
            Console.ReadKey();
        }
    }
}
