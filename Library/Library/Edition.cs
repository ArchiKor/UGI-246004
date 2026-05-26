using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Edition
    {
        private static int _nextInventoryNumber = 1;

        public string Title { get; set; }
        public int Year { get; set; }
        public string Publisher { get; set; }
        public EditionStatus Status { get; set; }
        public decimal Price { get; set; }

        
        private readonly List<string> _authors; 
        public IReadOnlyList<string> Authors => _authors.AsReadOnly();


        public readonly int InventoryNumber;
        public Edition(string title, List<string> authors, int year, string publisher,
            EditionStatus status, decimal price)
        {
            Title = title;
            _authors = authors ?? new List<string>(); 
            Year = year;
            Publisher = publisher;
            Status = status;
            Price = price;

            InventoryNumber = _nextInventoryNumber++;
        }

        public int CompareTo(Edition other)
        {
            // Получаем первого автора или пустую строку, если список пуст
            string author1 = Authors.Count > 0 ? Authors[0] : "";
            string author2 = other.Authors.Count > 0 ? other.Authors[0] : "";

            if (author1 != author2)
                return author1.CompareTo(author2);
            else if (Title != other.Title)
                return Title.CompareTo(other.Title);
            else
                return other.Year.CompareTo(this.Year); // убывание года
        }


        public virtual string[] GetInfo() // Метод для получения информации об объекте
        {
            var info = new string[2];

            string authorsStr = string.Join(", ", _authors); 
            info[0] = $"{Title}. Авторы: {authorsStr}";

            string statusText; 
            switch (Status)
            {
                case EditionStatus.InStorage:
                    statusText = "в хранилище";
                    break;
                case EditionStatus.InReadingRoom:
                    statusText = "в читальном зале";
                    break;
                case EditionStatus.InHome:
                    statusText = "выдана на дом";
                    break;
                default:
                    statusText = "неизвестно";
                    break;
            }

            info[1] = $"Год: {Year}. Издательство: {Publisher}. Инв. номер: {InventoryNumber}. Статус: {statusText}. Цена: {Price:C}.";
            return info;
        }

    }
}
