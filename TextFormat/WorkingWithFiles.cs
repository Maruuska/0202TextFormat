using CsvHelper;
using System.Text.Json;
using System.Globalization;
using System.Diagnostics;
using System.Xml.Serialization;
using YamlDotNet.Serialization;

namespace TextFormat
{
    // класс WorkingWithFiles содержит методы работы с файлами
    public class WorkingWithFiles
    {
        //обобщенный метод для чтения данных из файлов
        //принимает строковое имя файла
        //возвращает объект типа List<ModelFilm> (лист фильмов)
        public static List<ModelFilm> ReadFile<ModelFilm>(string pathFile)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));   //логирование ошибок
            switch (Path.GetExtension(pathFile).ToLower())   //расширение файла в нижнем регистре
            {
                case ".csv":
                    return ReadCsv<ModelFilm>(pathFile);   //чтение данных из .csv
                case ".json":
                    return ReadJson<ModelFilm>(pathFile);  //чтение данных из .json
                case ".xml":
                    return ReadXml<ModelFilm>(pathFile);   //чтение данных из .xml
                case ".yaml":
                    return ReadYaml<ModelFilm>(pathFile);  //чтение данных из .yaml
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("неверный формат файла");    //обработка ошибок формата
                    Console.ResetColor();
                    Trace.WriteLine("неверный формат файла");    //логирование ошибки
                    Trace.Flush();
                    return new List<ModelFilm>();  //в случае ошибки возврат пустого листа
            }
        }

        //обобщенный метод для записи данных в файлы
        //принимает объект типа List<ModelFilm> (лист фильмов) и строковое имя файла
        public static void WriteFile<ModelFilm>(List<ModelFilm> listFilms, string pathFile)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));   //логирование ошибок
            switch (Path.GetExtension(pathFile).ToLower())   //расширение файла в нижнем регистре
            {
                case ".csv":
                    WriteCsv(listFilms, pathFile); //запись данных в .csv
                    break;
                case ".json":
                    WriteJson(listFilms, pathFile); //запись данных в .json
                    break;
                case ".xml":
                    WriteXml(listFilms, pathFile);  //запись данных в .xml
                    break;
                case ".yaml":
                    WriteYaml(listFilms, pathFile); //запись данных в .yaml
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("неверный формат файла");   //обработка ошибок формата
                    Console.ResetColor();
                    Trace.WriteLine("неверный формат файла");  //логирование ошибки
                    Trace.Flush();
                    break;
            }
        }

        //метод, реализующий логику записи данных в файл .csv
        //принимает лист фильмов типа List<ModelFilm> и строковый путь к файлу
        private static void WriteCsv<ModelFilm>(List<ModelFilm> listFilms, string pathFile)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));    //логирование ошибок
            try
            {
                //using освобождает поток после записи
                using StreamWriter writer = new StreamWriter(pathFile);     //StreamWriter предназначен для вывода символов в определенной кодировке в файл
                using CsvWriter csv = new CsvWriter(writer, CultureInfo.CurrentCulture);  //объект класса, который записывает данные в виде набора данных с разделителями
                csv.WriteRecords(listFilms);   //запись в файл всего листа сразу
                Console.WriteLine($"запись в файл {pathFile} прошла успешно");
            }
            catch (Exception ex)
            {
                Console.WriteLine("метод WriteCsv ошибка записи данных");
                Trace.WriteLine($"метод WriteCsv ошибка: {ex.Message}");
                Trace.Flush();
            }
        }

        //метод, реализующий логику чтения данных из файла .csv
        //принимает строковый путь к файлу
        //возвращает лист фильмов типа List<ModelFilm>
        private static List<ModelFilm> ReadCsv<ModelFilm>(string pathFile)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));   //логирование ошибок
            try
            {
                //Проверка на существование файла
                if (System.IO.File.Exists(pathFile))  
                {
                    //using освобождает поток после чтения
                    using StreamReader reader = new StreamReader(pathFile);    //StreamReader предназначен для ввода символов в определенной кодировке
                    using CsvReader csv = new CsvReader(reader, CultureInfo.CurrentCulture);  //объект класса, который считывает данные из набора данных с разделителями
                    return csv.GetRecords<ModelFilm>().ToList();  //получение всех записей в файле и преобразование в лист типа <ModelFilm>
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("файл не найден");
                    Console.ResetColor();
                    Trace.WriteLine("метод ReadCsv ошибка: файл не найден");
                    Trace.Flush();
                    return new List<ModelFilm>();  //в случае ошибки возврат пустого листа
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
        //принимает лист фильмов типа List<ModelFilm> и строковый путь к файлу
        private static void WriteJson<ModelFilm>(List<ModelFilm> listFilms, string pathFile)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));    //логирование ошибок
            try
            {
                string json = JsonSerializer.Serialize(listFilms);  //преобразования листа listFilms в строку JSON
                File.WriteAllText(pathFile, json);  // запись строки json в файл
                Console.WriteLine($"запись в файл {pathFile} прошла успешно");
            }
            catch (Exception ex)
            {
                Console.WriteLine("метод WriteJson ошибка записи данных");
                Trace.WriteLine($"метод WriteJson ошибка: {ex.Message}");
                Trace.Flush();
            }
        }

        //метод, реализующий логику чтения данных из файла .json
        //принимает строковый путь к файлу
        //возвращает лист фильмов типа List<ModelFilm>
        private static List<ModelFilm> ReadJson<ModelFilm>(string pathFile)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));   //логирование ошибок
            try
            {
                //Проверка на существование файла
                if (System.IO.File.Exists(pathFile))
                {
                    string json = File.ReadAllText(pathFile);   // чтение строки json из файл
                    return JsonSerializer.Deserialize<List<ModelFilm>>(json).ToList();  // преобразование строки json в List<ModelFilm>
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("файл не найден");
                    Console.ResetColor();
                    Trace.WriteLine("метод ReadJson ошибка: файл не найден");
                    Trace.Flush();
                    return new List<ModelFilm>();  //в случае ошибки возврат пустого листа
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
        //принимает лист фильмов типа List<ModelFilm> и строковый путь к файлу
        private static void WriteXml<ModelFilm>(List<ModelFilm> listFilms, string pathFile)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));    //логирование ошибок
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<ModelFilm>));  // передаем в конструктор тип List<ModelFilm>
                using FileStream stream = new FileStream(pathFile, FileMode.Create);  //поток для работы с файлом
                serializer.Serialize(stream, listFilms);  //запись в файл
                Console.WriteLine($"запись в файл {pathFile} прошла успешно");
            }
            catch (Exception ex)
            {
                Console.WriteLine("метод WriteXml ошибка записи данных");
                Trace.WriteLine($"метод WriteXml ошибка: {ex.Message}");
                Trace.Flush();
            }
        }

        //метод, реализующий логику чтения данных из файла .xml
        //принимает строковый путь к файлу
        //возвращает лист фильмов типа List<ModelFilm>
        private static List<ModelFilm> ReadXml<ModelFilm>(string pathFile)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));   //логирование ошибок
            try
            {
                //Проверка на существование файла
                if (System.IO.File.Exists(pathFile))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<ModelFilm>));   // передаем в конструктор тип List<ModelFilm>
                    using FileStream stream = new FileStream(pathFile, FileMode.Open);  //поток для работы с файлом
                    return (List<ModelFilm>)serializer.Deserialize(stream);  //преобразование считанных данных в лист типа <ModelFilm>
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("файл не найден");
                    Console.ResetColor();
                    Trace.WriteLine("метод ReadXml ошибка: файл не найден");
                    Trace.Flush();
                    return new List<ModelFilm>();  //в случае ошибки возврат пустого листа
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
        //принимает лист фильмов типа List<ModelFilm> и строковый путь к файлу
        private static void WriteYaml<ModelFilm>(List<ModelFilm> listFilms, string pathFile)
        {
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));    //логирование ошибок
            try
            {
                var serializer = new SerializerBuilder().Build();
                string yaml = serializer.Serialize(listFilms);   //данные сериализуются в строку YAML
                System.IO.File.WriteAllText(pathFile, yaml);  //строка записывается в файл
                Console.WriteLine($"запись в файл {pathFile} прошла успешно");
            }
            catch (Exception ex)
            {
                Console.WriteLine("метод WriteYaml ошибка записи данных");
                Trace.WriteLine($"метод WriteYaml ошибка: {ex.Message}");
                Trace.Flush();
            }
        }

        //метод, реализующий логику чтения данных из файла .yaml
        //принимает строковый путь к файлу
        //возвращает лист фильмов типа List<ModelFilm>
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
                    return deserializer.Deserialize<List<ModelFilm>>(yaml);  //строка YAML десериализуется обратно в List<ModelFilm>
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("файл не найден");
                    Console.ResetColor();
                    Trace.WriteLine("метод ReadYaml ошибка: файл не найден");
                    Trace.Flush();
                    return new List<ModelFilm>();  //в случае ошибки возврат пустого листа
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
