<h1> Модуль управления фильмами </h1>
<h2>Описание</h2> 
Данный модуль предназначен для считывания и обработки данных о фильмах (идентификатор, название, жанр, год выпуска, рейтинг)

<h2>Структура</h2>
- Program.cs - класс, реализующий пользовательский интерфейс
- ModelFilm.cs - класс, содержащий модель фильма
- WorkingWithFiles.cs - класс, содержащий методы работы с файлами
- Tests.cs - класс, содержащий набор автоматизированных тестов, реализованных с использованием платформы MSTest

<h2>Класс WorkingWithFiles содержит следующие методы </h2>
1. public static List<ModelFilm> ReadFile<ModelFilm>(string pathFile) - обобщенный метод для чтения данных из файлов
2. public static string WriteFile<ModelFilm>(List<ModelFilm> listFilms, string pathFile) - обобщенный метод для записи данных в файлы
3. public static string WriteCsv<ModelFilm>(List<ModelFilm> listFilms, string pathFile) - метод, реализующий логику записи данных в файл .csv
4. public static List<ModelFilm> ReadCsv<ModelFilm>(string pathFile) - метод, реализующий логику чтения данных из файла .csv
5. public static string WriteJson<ModelFilm>(List<ModelFilm> listFilms, string pathFile) - метод, реализующий логику записи данных в файл .json
6. public static List<ModelFilm> ReadJson<ModelFilm>(string pathFile) - метод, реализующий логику чтения данных из файла .json
7. public static string WriteXml<ModelFilm>(List<ModelFilm> listFilms, string pathFile) - метод, реализующий логику записи данных в файл .xml
8. public static List<ModelFilm> ReadXml<ModelFilm>(string pathFile) - метод, реализующий логику чтения данных из файла .xml
9. public static string WriteYaml<ModelFilm>(List<ModelFilm> listFilms, string pathFile) - метод, реализующий логику записи данных в файл .yaml
10. public static List<ModelFilm> ReadYaml<ModelFilm>(string pathFile) - метод, реализующий логику чтения данных из файла .yaml


