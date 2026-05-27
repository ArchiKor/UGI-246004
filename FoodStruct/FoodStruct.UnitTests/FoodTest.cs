using NUnit.Framework;
using System;
using FoodStruct;

namespace FoodStruct.UnitTests
{
    [TestFixture]
    public class FoodTests
    {
        [Test]
        public void Constructor_ValidParameters_PropertiesSetCorrectly()
        {
            var food = new Food(250, 280.5);
            Assert.That(food.Weight, Is.EqualTo(250));
            Assert.That(food.Calorie, Is.EqualTo(280.5).Within(1e-13));
        }

        //неположительный вес: исключение
        [TestCase(0)]
        [TestCase(-5)]
        public void Constructor_InvalidWeight_ThrowsException(int weight)
        {
            Assert.That(() => new Food(weight, 100.0), Throws.ArgumentException);
        }

        //неположительная калорийность: исключение
        [TestCase(0.0)]
        [TestCase(-1.0)]
        public void Constructor_InvalidCalorie_ThrowsException(double calorie)
        {
            Assert.That(() => new Food(100, calorie), Throws.ArgumentException);
        }

        //Weight: проверка исключения
        [TestCase(0)]
        [TestCase(-10)]
        public void Weight_SetInvalidValue_ThrowsException(int value)
        {
            var food = new Food();
            Assert.That(() => food.Weight = value, Throws.ArgumentException);
        }

        //Calorie: проверка исключения и округления
        [TestCase(0.0)]
        [TestCase(-5.0)]
        public void Calorie_SetInvalidValue_ThrowsException(double value)
        {
            var food = new Food();
            Assert.That(() => food.Calorie = value, Throws.ArgumentException);
        }

        [Test]
        public void Calorie_Set_RoundsToOneDecimal()
        {
            var food = new Food();
            food.Calorie = 280.55;
            Assert.That(food.Calorie, Is.EqualTo(280.6).Within(1e-13));

            food.Calorie = 123.454;
            Assert.That(food.Calorie, Is.EqualTo(123.5).Within(1e-13));
        }

        [TestCase(200, 300.0, 600.0)]
        [TestCase(150, 250.5, 375.75)]
        [TestCase(100, 100.0, 100.0)] 
        public void Value_ComputesCorrectly(int weight, double calorie, double expected)
        {
            var food = new Food { Weight = weight, Calorie = calorie };
            Assert.That(food.Value, Is.EqualTo(expected).Within(1e-13));
        }

        [TestCase(250, 280.5, "250 г калорийности 280,5 Ккал/100 г")]
        [TestCase(500, 123.4, "500 г калорийности 123,4 Ккал/100 г")]
        public void ToString_ReturnsFormattedString(int weight, double calorie, string expected)
        {
            var food = new Food { Weight = weight, Calorie = calorie };
            Assert.That(food.ToString(), Is.EqualTo(expected));
        }

        //Equals: два продукта равны, не равны
        [Test]
        public void Equals_SameWeightAndCalorie_ReturnsTrue()
        {
            var a = new Food(100, 250.5);
            var b = new Food(100, 250.5);
            Assert.That(a.Equals(b), Is.True);
        }

        [Test]
        public void Equals_DifferentWeight_ReturnsFalse()
        {
            var a = new Food(100, 250.5);
            var b = new Food(200, 250.5);
            Assert.That(a.Equals(b), Is.False);
        }

        [Test]
        public void Equals_DifferentCalorie_ReturnsFalse()
        {
            var a = new Food(100, 250.5);
            var b = new Food(100, 300.0);
            Assert.That(a.Equals(b), Is.False);
        }

        [Test]
        public void Equals_VeryCloseCalorie_ConsideredEqual()
        {
            var a = new Food(100, 250.5);
            var b = new Food(100, 250.5 + 1e-14);
            Assert.That(a.Equals(b), Is.True);
        }

        [Test]
        public void Equals_NotFoodObject_ThrowsException()
        {
            var food = new Food(100, 250.5);
            Assert.That(() => food.Equals("не продукт"), Throws.ArgumentException);
        }

        //Хэш: равные объекты – одинаковый хэш
        [Test]
        public void GetHashCode_EqualObjects_ReturnSameHash()
        {
            var a = new Food(200, 320.7);
            var b = new Food(200, 320.7 + 1e-14);
            Assert.That(a.Equals(b), Is.True);
            Assert.That(a.GetHashCode(), Is.EqualTo(b.GetHashCode()));
        }

        //Сравнение
        [Test]
        public void EqualityOperators_WorkCorrectly()
        {
            var x = new Food(150, 200.5);
            var y = new Food(150, 200.5);
            var z = new Food(150, 201.0);
            Assert.That(x == y, Is.True);
            Assert.That(x != y, Is.False);
            Assert.That(x == z, Is.False);
            Assert.That(x != z, Is.True);
        }

        //Сложение
        [Test]
        public void Add_SameCalorie_ReturnsSumWeight()
        {
            var a = new Food(100, 250.5);
            var b = new Food(50, 250.5);
            var result = a + b;
            Assert.That(result.Weight, Is.EqualTo(150));
            Assert.That(result.Calorie, Is.EqualTo(250.5).Within(1e-13));
        }

        [Test]
        public void Add_DifferentCalorie_ThrowsException()
        {
            var a = new Food(100, 250.5);
            var b = new Food(50, 300.0);
            Assert.That(() => a + b, Throws.ArgumentException);
        }

        //Вычитание
        [Test]
        public void Subtract_SameCalorie_ReturnsDifferenceWeight()
        {
            var a = new Food(100, 250.5);
            var b = new Food(30, 250.5);
            var result = a - b;
            Assert.That(result.Weight, Is.EqualTo(70));
            Assert.That(result.Calorie, Is.EqualTo(250.5).Within(1e-13));
        }

        [Test]
        public void Subtract_LargerWeight_ThrowsException()
        {
            var a = new Food(50, 250.5);
            var b = new Food(100, 250.5);
            Assert.That(() => a - b, Throws.ArgumentException);
        }

        [Test]
        public void Subtract_DifferentCalorie_ThrowsException()
        {
            var a = new Food(100, 250.5);
            var b = new Food(50, 300.0);
            Assert.That(() => a - b, Throws.ArgumentException);
        }
    }
}