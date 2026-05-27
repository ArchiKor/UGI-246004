using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace FoodStruct
{
    public struct Food
    {
        private const double Precision = 1e-13;
        private const int DecimalPlaces = 1;

        private int weight;
        private double calorie;

        public int Weight
        {
            get => weight;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Вес должен быть положительным целым числом.");
                weight = value;
            }
        }

        public double Calorie
        {
            get => calorie;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Калорийность должна быть положительным числом.");
                calorie = Math.Round(value, 1);
            }
        }

        //количество килокалорий во всём продукте
        public double Value => Weight * Calorie / 100.0;

        public Food(int weight, double calorie) : this()
        {
            Weight = weight;       
            Calorie = calorie;     
        }

        //Строковое представление
        public override string ToString()
        {
            string calorieStr = Calorie.ToString("F1", CultureInfo.InvariantCulture)
                                       .Replace('.', ',');
            return $"{Weight} г калорийности {calorieStr} Ккал/100 г";
        }

        //Сравнение
        public override bool Equals(object obj)
        {
            if (obj is Food other)
            {
                return Weight == other.Weight &&
                       Math.Abs(Calorie - other.Calorie) < Precision;
            }
            throw new ArgumentException("Объект для сравнения не является продуктом (Food).");
        }

        //Хэш: чтобы равные по Equals объекты дали одинаковый хэш
        public override int GetHashCode()
        {
            int hash = 17;
            const int p = 23;
            hash = hash * p + Weight.GetHashCode();
            hash = hash * p + Math.Round(Calorie, DecimalPlaces,
                                         MidpointRounding.AwayFromZero).GetHashCode();
            return hash;
        }

        //сравнения
        public static bool operator ==(Food left, Food right) => left.Equals(right);
        public static bool operator !=(Food left, Food right) => !left.Equals(right);

        //калорийности должны быть одинаковы
        public static Food operator +(Food a, Food b)
        {
            if (Math.Abs(a.Calorie - b.Calorie) >= Precision)
                throw new ArgumentException(
                    "Складывать можно только продукты с одинаковой калорийностью.");
            return new Food(a.Weight + b.Weight, a.Calorie);
        }

        //калорийности одинаковы, результат не должен быть отрицательным/нулевым
        public static Food operator -(Food a, Food b)
        {
            if (Math.Abs(a.Calorie - b.Calorie) >= Precision)
                throw new ArgumentException(
                    "Вычитать можно только продукты с одинаковой калорийностью.");
            if (b.Weight > a.Weight)
                throw new ArgumentException(
                    "Нельзя вычесть продукт с большим весом.");
            return new Food(a.Weight - b.Weight, a.Calorie);
        }
    }
}
