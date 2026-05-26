using Library;
using NUnit.Framework;
using System.Collections.Generic;

namespace LibraryCatalog.UnitTests
{
    [TestFixture]
    public class EditionUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var authors = new List<string> {"Пушкин А.С.","Толстой Л.Н."};
            var edition = CreateTestEdition(authors);

            Assert.That(edition.Title, Is.EqualTo("Евгений Онегин"));
            Assert.That(edition.Authors, Is.EqualTo(authors));
            Assert.That(edition.Year, Is.EqualTo(2020));
            Assert.That(edition.Publisher, Is.EqualTo("Издательство"));
            Assert.That(edition.Status, Is.EqualTo(EditionStatus.InStorage));
            Assert.That(edition.Price, Is.EqualTo(500.00m));
            Assert.That(edition.InventoryNumber, Is.GreaterThan(0));
        }

        [Test]
        public void GetInfoTest()
        {
            var authors = new List<string> {"Пушкин А.С.", "Толстой Л.Н."};
            var edition = CreateTestEdition(authors);
            var info = edition.GetInfo();

            Assert.That(info.Length, Is.EqualTo(2));
            Assert.That(info[0], Is.EqualTo("Евгений Онегин. Авторы: Пушкин А.С., Толстой Л.Н."));

     
            string expectedSecond = $"Год: {edition.Year}. Издательство: {edition.Publisher}. " +
                $"Инв. номер: {edition.InventoryNumber}. Статус: в хранилище. Цена: {edition.Price:C}.";
            Assert.That(info[1], Is.EqualTo(expectedSecond));
        }

        [Test]
        public void InventoryNumberIncrementsTest()
        {
            var authors = new List<string> { "Автор" };
            var ed1 = new Edition("Книга1", authors, 2000, "Изд1", EditionStatus.InStorage, 100);
            var ed2 = new Edition("Книга2", authors, 2001, "Изд2", EditionStatus.InHome, 200);
            Assert.That(ed2.InventoryNumber, Is.EqualTo(ed1.InventoryNumber + 1));
        }

        private Edition CreateTestEdition(List<string> authors)
        {
            return new Edition("Евгений Онегин", authors, 2020, "Издательство",
                               EditionStatus.InStorage, 500.00m);
        }
    }
}