using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Config_xml_reader
{
    class Game
    {

        public static Games Name { get; set; }
        public Genres Genre { get; set; }
        public string Manufacturer { get; set; }

        private double rating;
        public double Rating
        {
            get => rating;
            set
            {
                if (value > 0 && value <= 10) rating = value;
                else
                    throw new ArgumentException("Invalid game rating");
            }
        }

        public Game() { }

        public Game(Games name, Genres genre, string manufacturer, double rating)
        {
            Name = name;
            Genre = genre;
            Manufacturer = manufacturer;
            Rating = rating;
        }

        public override string ToString() => $" Игра: {Name} | Жанр: {Genre} | Производитель: {Manufacturer} | Рейтинг: {Rating} |\n" +
                                             $"РЕКОМЕНДУЕМЫЕ НАСТРОЙКИ ГРАФИКИ ДЛЯ ДАННОЙ ИГРЫ\n" +
                                             $"Разрешение: {Settings.Resolution}\n" +
                                             $"Гамма: {Settings.Gamma}\n" +
                                             $"FPS: {Settings.FPS}\n" +
                                             $"Вертикальная синхронизация: {Settings.Vsinch}";


    }
}
