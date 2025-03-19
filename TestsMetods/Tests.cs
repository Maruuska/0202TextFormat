using System.IO;
using System.Threading.Tasks;

namespace TextFormat.Tests
{
    // класс Tests содержит unit-тесты для тестирования методов работы с файлами различных форматов
    [TestClass]
    public class Tests
    {
        // Тест для проверки, что метод ReadFile возвращает 0 записей при неверном формате файла
        [TestMethod]
        public void TestReadFile()
        {
            string testPath = "абракадабра";  //имя несуществующего файла для считывания данных

            List<ModelFilm> testReadFilmsCsv = WorkingWithFiles.ReadFile<ModelFilm>(testPath);   // обращение к обобщенному методу для чтения данных из файла

            // Сравниваем ожидаемое количество фильмов с полученным в списке
            Assert.AreEqual(0, testReadFilmsCsv.Count);
        }

        // тест для проверки, что метод WriteFile возвращает правильную строку при неверном формате файла
        [TestMethod]
        public void TestWriteFile()
        {
            // лист фильмов для тестирования метода
            List<ModelFilm> filmList = new List<ModelFilm> {
                new ModelFilm (1,"Звездные войны","Фантастика",1980,8.7),
                new ModelFilm (2,"Побег из Шоушенка","Драма",1994,9.3),
            };

            string testPath = "абракадабра";  //имя несуществующего файла для записи данных

            string testWriteFilmsCsv = WorkingWithFiles.WriteFile<ModelFilm>(filmList, testPath);   // обращение к обобщенному методу для записи данных в файл

            // Сравниваем возвращенную строку с ожидаемой
            Assert.AreEqual("неверный формат файла", testWriteFilmsCsv);
        }

        //тест для проверки, что метод WriteCsv возвращает правильную строку
        [TestMethod]
        public void TestWriteCsv() 
        {
            // лист фильмов для тестирования метода
            List<ModelFilm> filmList = new List<ModelFilm> {
                new ModelFilm (1,"Звездные войны","Фантастика",1980,8.7),
                new ModelFilm (2,"Побег из Шоушенка","Драма",1994,9.3),
            };

            string testPath = "test.csv";  //имя файла для записи данных

            string testWriteCsv = WorkingWithFiles.WriteCsv<ModelFilm>(filmList, testPath);   // обращение к методу для записи данных в файл csv

            // Сравниваем возвращенную строку с ожидаемой
            Assert.AreEqual("запись в файл test.csv прошла успешно", testWriteCsv);
        }

        //тест для проверки, что метод WriteJson возвращает правильную строку
        [TestMethod]
        public void TestWriteJson()
        {
            // лист фильмов для тестирования метода
            List<ModelFilm> filmList = new List<ModelFilm> {
                new ModelFilm (1,"Звездные войны","Фантастика",1980,8.7),
                new ModelFilm (2,"Побег из Шоушенка","Драма",1994,9.3),
            };

            string testPath = "test.json";  //имя файла для записи данных

            string testWriteCsv = WorkingWithFiles.WriteJson<ModelFilm>(filmList, testPath);   // обращение к методу для записи данных в файл json

            // Сравниваем возвращенную строку с ожидаемой
            Assert.AreEqual("запись в файл test.json прошла успешно", testWriteCsv);
        }

        //тест для проверки, что метод WriteXml возвращает правильную строку
        [TestMethod]
        public void TestWriteXml()
        {
            // лист фильмов для тестирования метода
            List<ModelFilm> filmList = new List<ModelFilm> {
                new ModelFilm (1,"Звездные войны","Фантастика",1980,8.7),
                new ModelFilm (2,"Побег из Шоушенка","Драма",1994,9.3),
            };

            string testPath = "test.xml";  //имя файла для записи данных

            string testWriteCsv = WorkingWithFiles.WriteXml<ModelFilm>(filmList, testPath);   // обращение к методу для записи данных в файл xml

            // Сравниваем возвращенную строку с ожидаемой
            Assert.AreEqual("запись в файл test.xml прошла успешно", testWriteCsv);
        }

        //тест для проверки, что метод WriteXml возвращает правильную строку
        [TestMethod]
        public void TestWriteYaml()
        {
            // лист фильмов для тестирования метода
            List<ModelFilm> filmList = new List<ModelFilm> {
                new ModelFilm (1,"Звездные войны","Фантастика",1980,8.7),
                new ModelFilm (2,"Побег из Шоушенка","Драма",1994,9.3),
            };

            string testPath = "test.yaml";  //имя файла для записи данных

            string testWriteCsv = WorkingWithFiles.WriteXml<ModelFilm>(filmList, testPath);   // обращение к методу для записи данных в файл yaml

            // Сравниваем возвращенную строку с ожидаемой
            Assert.AreEqual("запись в файл test.yaml прошла успешно", testWriteCsv);
        }

        //тест для проверки, что метод ReadCsv возвращает правильный лист фильмов
        [TestMethod]
        public void TestReadCsv()
        {
            // лист фильмов для тестирования метода
            List<ModelFilm> filmList = new List<ModelFilm> {
                new ModelFilm (1,"Звездные войны","Фантастика",1980,8.7),
                new ModelFilm (2,"Побег из Шоушенка","Драма",1994,9.3),
            };

            string testPath = "test1.csv";  //имя файла для чтения данных

            List<ModelFilm> testReadCsv = WorkingWithFiles.ReadCsv<ModelFilm>(testPath);   // обращение к методу для чтения данных из файла csv

            //проверка что метод возвращает правильные значения
            for (int i = 0; i < filmList.Count; i++)
            {
                Assert.AreEqual(filmList[i].id, testReadCsv[i].id);
                Assert.AreEqual(filmList[i].name, testReadCsv[i].name);
                Assert.AreEqual(filmList[i].genre, testReadCsv[i].genre);
                Assert.AreEqual(filmList[i].year, testReadCsv[i].year);
                Assert.AreEqual(filmList[i].rating, testReadCsv[i].rating);
            }
        }

        //тест для проверки, что метод ReadJson возвращает правильный лист фильмов
        [TestMethod]
        public void TestReadJson()
        {
            // лист фильмов для тестирования метода
            List<ModelFilm> filmList = new List<ModelFilm> {
                new ModelFilm (1,"Звездные войны","Фантастика",1980,8.7),
                new ModelFilm (2,"Побег из Шоушенка","Драма",1994,9.3),
            };

            string testPath = "test.json";  //имя файла для чтения данных

            List<ModelFilm> testReadJson = WorkingWithFiles.ReadJson<ModelFilm>(testPath);   // обращение к методу для чтения данных из файла json

            //проверка что метод возвращает правильные значения
            for (int i = 0; i < filmList.Count; i++)
            {
                Assert.AreEqual(filmList[i].id, testReadJson[i].id);
                Assert.AreEqual(filmList[i].name, testReadJson[i].name);
                Assert.AreEqual(filmList[i].genre, testReadJson[i].genre);
                Assert.AreEqual(filmList[i].year, testReadJson[i].year);
                Assert.AreEqual(filmList[i].rating, testReadJson[i].rating);
            }
        }

        //тест для проверки, что метод ReadXml возвращает правильный лист фильмов
        [TestMethod]
        public void TestReadXml()
        {
            // лист фильмов для тестирования метода
            List<ModelFilm> filmList = new List<ModelFilm> {
                new ModelFilm (1,"Звездные войны","Фантастика",1980,8.7),
                new ModelFilm (2,"Побег из Шоушенка","Драма",1994,9.3),
            };

            string testPath = "test1.xml";  //имя файла для чтения данных

            List<ModelFilm> testReadXml = WorkingWithFiles.ReadXml<ModelFilm>(testPath);   // обращение к методу для чтения данных из файла xml

            //проверка что метод возвращает правильные значения
            for (int i = 0; i < filmList.Count; i++)
            {
                Assert.AreEqual(filmList[i].id, testReadXml[i].id);
                Assert.AreEqual(filmList[i].name, testReadXml[i].name);
                Assert.AreEqual(filmList[i].genre, testReadXml[i].genre);
                Assert.AreEqual(filmList[i].year, testReadXml[i].year);
                Assert.AreEqual(filmList[i].rating, testReadXml[i].rating);
            }
        }
    }
}
