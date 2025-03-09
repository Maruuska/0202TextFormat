//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Newtonsoft.Json;
using CsvHelper;
using System.Text.Json;
//using System.Xml.Serialization;
//using YamlDotNet.Serialization;
//using static System.Net.WebRequestMethods;
//using System.IO;
using System.Globalization;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Serialization;
using YamlDotNet.Serialization;
//using System.Formats.Asn1;
//using YamlDotNet.Serialization.NamingConventions;


namespace TextFormat
{
    public class WorkingWithFiles
    {
        //обобщенный метод для чтения данных из файлов
        //принимает имя файла
        //возвращает объект типа List<ModelFilm> (лист фильмов)
        public static List<ModelFilm> ReadFile<ModelFilm>(string pathFile)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));   //логирование ошибок
            switch (Path.GetExtension(pathFile).ToLower())   //расширение файла в нижнем регистре
            {
                case ".csv":
                    return ReadCsv<ModelFilm>(pathFile);
                case ".json":
                    return ReadJson<ModelFilm>(pathFile);
                case ".xml":
                    return ReadXml<ModelFilm>(pathFile);
                case ".yaml":
                    return ReadYaml<ModelFilm>(pathFile);
                default:
                    Trace.WriteLine("неверный формат файла");
                    Trace.Flush();
                    throw new Exception("неверный формат файла");   //Обработка ошибок формата
            }
        }

        //обобщенный метод для записи данных в файлы
        //принимает объект типа List<ModelFilm> (лист фильмов) и имя файла
        public static void WriteFile<ModelFilm>(List<ModelFilm> listFilms, string pathFile)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));   //логирование ошибок
            switch (Path.GetExtension(pathFile).ToLower())
            {
                case ".csv":
                    WriteCsv(listFilms, pathFile);
                    break;
                case ".json":
                    WriteJson(listFilms, pathFile);
                    break;
                case ".xml":
                    WriteXml(listFilms, pathFile);
                    break;
                case ".yaml":
                    WriteYaml(listFilms, pathFile);
                    break;
                default:
                    Trace.WriteLine("неверный формат файла");
                    Trace.Flush();
                    throw new Exception("неверный формат файла");   //Обработка ошибок формата
            }
        }

        //метод, реализующий логику записи данных в файл .csv
        private static void WriteCsv<ModelFilm>(List<ModelFilm> listFilms, string pathFile)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));    //логирование ошибок
            try
            {
                //Проверка на существование файла
                //if (System.IO.File.Exists(pathFile))  
                //{
                //using освобождает поток после записи
                using var writer = new StreamWriter(pathFile);     //StreamWriter предназначен для вывода символов в определенной кодировке в файл
                using var csv = new CsvWriter(writer, CultureInfo.CurrentCulture);
                csv.WriteRecords(listFilms);
                //}
                //else
                //{
                //    Trace.WriteLine("метод WriteCsv ошибка: файл не найден");
                //    Trace.Flush();
                //    throw new Exception("файл не найден");
                //}
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"метод WriteCsv ошибка: {ex.Message}");
                Trace.Flush();
            }
        }

        //метод, реализующий логику чтения данных из файла .csv
        private static List<ModelFilm> ReadCsv<ModelFilm>(string pathFile)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));   //логирование ошибок
            try
            {
                //Проверка на существование файла
                if (System.IO.File.Exists(pathFile))  
                {
                    //using освобождает поток после чтения
                    using var reader = new StreamReader(pathFile);    //StreamReader предназначен для ввода символов в определенной кодировке
                    using var csv = new CsvReader(reader, CultureInfo.CurrentCulture);
                    return csv.GetRecords<ModelFilm>().ToList();
                }
                else
                {
                    Trace.WriteLine("метод ReadCsv ошибка: файл не найден");
                    Trace.Flush();
                    throw new Exception("файл не найден");                    
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"метод ReadCsv ошибка: {ex.Message}");
                Trace.Flush();
                return new List<ModelFilm>();  //в случае ошибки возврат пустого листа
            }
        }



        //метод, реализующий логику записи данных в файл .json
        private static void WriteJson<ModelFilm>(List<ModelFilm> listFilms, string pathFile)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));    //логирование ошибок
            try
            {
                string json = JsonSerializer.Serialize(listFilms);
                File.WriteAllText(pathFile, json);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"метод WriteJson ошибка: {ex.Message}");
                Trace.Flush();
            }
        }

        //метод, реализующий логику чтения данных из файла .json
        private static List<ModelFilm> ReadJson<ModelFilm>(string pathFile)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));   //логирование ошибок
            try
            {
                //Проверка на существование файла
                if (System.IO.File.Exists(pathFile))
                {
                    string json = File.ReadAllText(pathFile);
                    return JsonSerializer.Deserialize<List<ModelFilm>>(json).ToList();
                }
                else
                {
                    Trace.WriteLine("метод ReadJson ошибка: файл не найден");
                    Trace.Flush();
                    throw new Exception("файл не найден");
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"метод ReadJson ошибка: {ex.Message}");
                Trace.Flush();
                return new List<ModelFilm>();   //в случае ошибки возврат пустого листа
            }
        }



        //метод, реализующий логику записи данных в файл .xml
        private static void WriteXml<ModelFilm>(List<ModelFilm> listFilms, string pathFile)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));    //логирование ошибок
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<ModelFilm>));  // передаем в конструктор тип класса ModelFilm
                using var stream = new FileStream(pathFile, FileMode.Create);  //поток
                serializer.Serialize(stream, listFilms);  //запись в файл
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"метод WriteXml ошибка: {ex.Message}");
                Trace.Flush();
            }
        }

        //метод, реализующий логику чтения данных из файла .xml
        private static List<ModelFilm> ReadXml<ModelFilm>(string pathFile)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));   //логирование ошибок
            try
            {
                //Проверка на существование файла
                if (System.IO.File.Exists(pathFile))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<ModelFilm>));   // передаем в конструктор тип класса ModelFilm
                    using var stream = new FileStream(pathFile, FileMode.Open);  //поток
                    return (List<ModelFilm>)serializer.Deserialize(stream);  //чтение из файла
                }
                else
                {
                    Trace.WriteLine("метод ReadXml ошибка: файл не найден");
                    Trace.Flush();
                    throw new Exception("файл не найден");
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"метод ReadXml ошибка: {ex.Message}");
                Trace.Flush();
                return new List<ModelFilm>();   //в случае ошибки возврат пустого листа
            }
        }




        //метод, реализующий логику записи данных в файл .yaml
        private static void WriteYaml<ModelFilm>(List<ModelFilm> listFilms, string pathFile)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));    //логирование ошибок
            try
            {
                var serializer = new SerializerBuilder().Build();
                string yaml = serializer.Serialize(listFilms);   //данные сериализуются в строку YAML
                System.IO.File.WriteAllText(pathFile, yaml);  //строка записывается в файл
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"метод WriteYaml ошибка: {ex.Message}");
                Trace.Flush();
            }
        }

        //метод, реализующий логику чтения данных из файла .yaml
        private static List<ModelFilm> ReadYaml<ModelFilm>(string pathFile)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));   //логирование ошибок
            try
            {
                //Проверка на существование файла
                if (System.IO.File.Exists(pathFile))
                {
                    string yaml = System.IO.File.ReadAllText(pathFile);  // содержимое файла читается в строку
                    var deserializer = new DeserializerBuilder().Build();
                    return deserializer.Deserialize<List<ModelFilm>>(yaml);  //строка YAML десериализуется обратно в объект
                }
                else
                {
                    Trace.WriteLine("метод ReadYaml ошибка: файл не найден");
                    Trace.Flush();
                    throw new Exception("файл не найден");
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"метод ReadYaml ошибка: {ex.Message}");
                Trace.Flush();
                return new List<ModelFilm>();   //в случае ошибки возврат пустого листа
            }
        }

    }
}
