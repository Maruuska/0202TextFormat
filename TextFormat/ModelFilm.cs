
namespace TextFormat
{
    //класс ModelFilm содержит данные о фильме (идентификатор, название, жанр, год выпуска, рейтинг)
    public class ModelFilm
    {
        public int id { get; set; }  //идентификатор фильма
        public string name { get; set; } //название фильма
        public string genre { get; set; }  //жанр фильма
        public int year { get; set; }  //год выпуска фильма
        public double rating { get; set; } //рейтинг фильма

        //конструктор класса
        public ModelFilm(int id, string name, string genre, int year, double rating)
        {
            this.id = id;
            this.name = name;
            this.genre = genre;
            this.year = year;
            this.rating = rating;
        }
        //конструктор без аргументов для записи в .xml
        public ModelFilm() { }

        //переопределение функции ToString 
        //метод, который будет выводить данные на экран в удобочитаемом формате
        public override string ToString()
        {
            return $"id: {this.id} название: {this.name} жанр: {this.genre} год выпуска: {this.year} рейтинг: {this.rating}";
        }
    }
}
