//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


namespace TextFormat
{
    //класс ModelFilm для управление фильмами: Считывание и обработка данных о фильмах (идентификатор, название, жанр, год выпуска, рейтинг)
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
        //для записи в .xml
        public ModelFilm() { }

        //переопределение функции ToString 
        //метод, который будет выводить данные на экран в удобочитаемом формате
        public override string ToString()
        {
            return $"id: {this.id} name: {this.name} genre: {this.genre} year: {this.year} rating: {this.rating}";
        }
    }
}
