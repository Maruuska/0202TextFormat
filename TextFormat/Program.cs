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

namespace TextFormat
{
    public class Program
    {
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

            // Запись в CSV
            WorkingWithFiles.WriteFile(filmList, "filmsCSV.csv");

            // Чтение из CSV
            List<ModelFilm> readFilmsCsv = WorkingWithFiles.ReadFile<ModelFilm>("filmsCSV.csv");

            foreach (var film in readFilmsCsv)
            {
                Console.WriteLine(film.ToString());
            }
            Console.WriteLine("\n");


            // Запись в JSON
            WorkingWithFiles.WriteFile(filmList, "filmsJSON.json");

            // Чтение из JSON
            List<ModelFilm> readFilmsJson = WorkingWithFiles.ReadFile<ModelFilm>("filmsJSON.json");

            foreach (var film in readFilmsJson)
            {
                Console.WriteLine(film.ToString());
            }
            Console.WriteLine("\n");


            // Запись в XML
            WorkingWithFiles.WriteFile(filmList, "filmsXML.xml");

            // Чтение из XML
            List<ModelFilm> readFilmsXml = WorkingWithFiles.ReadFile<ModelFilm>("filmsXML.xml");

            foreach (var film in readFilmsXml)
            {
                Console.WriteLine(film.ToString());
            }
            Console.WriteLine("\n");


            // Запись в YAML
            WorkingWithFiles.WriteFile(filmList, "filmsYAML.yaml");

            // Чтение из YAML
            List<ModelFilm> readFilmsYaml = WorkingWithFiles.ReadFile<ModelFilm>("filmsYAML.yaml");

            foreach (var film in readFilmsYaml)
            {
                Console.WriteLine(film.ToString());
            }



            Console.ReadKey();
        }
    }
}
