using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalog.UnitTests
{
    [TestFixture]
    public class ScientificTechnicalLiteratureTests
    {
        
        private ScientificTechnicalLiterature GetTestBook()
        {
            var authors = new List<string> {"Д.И.Блохинцев"};
            return new ScientificTechnicalLiterature(
                title: "Основы квантовой механики",
                authors: authors,
                year: 1976,
                publisher: "Наука",
                status: EditionStatus.InReadingRoom,
                price: 1200.00m,
                scienceField: "Физика",
                annotation: "Подходит для аспирантов, студентов физико-математических специальностей"
            );
        }

        [Test]
        public void Constructor_InitializesAllProperties()
        {
            var book = GetTestBook();

            Assert.That(book.Title, Is.EqualTo("Основы квантовой механики"));
            Assert.That(book.Authors, Is.EquivalentTo(new[] {"Д.И.Блохинцев"}));
            Assert.That(book.Year, Is.EqualTo(1976));
            Assert.That(book.Publisher, Is.EqualTo("Наука"));
            Assert.That(book.Status, Is.EqualTo(EditionStatus.InReadingRoom));
            Assert.That(book.Price, Is.EqualTo(1200.00m));
            Assert.That(book.InventoryNumber, Is.GreaterThan(0));

            Assert.That(book.ScienceField, Is.EqualTo("Физика"));
            Assert.That(book.Annotation, Is.EqualTo("Подходит для аспирантов, студентов физико-математических специальностей"));
        }

        [Test]
        public void GetInfo_ReturnsFourLines()
        {
            var book = GetTestBook();
            var info = book.GetInfo();
            Assert.That(info.Length, Is.EqualTo(4)); 
        }

        [Test]
        public void GetInfo_ContainsCorrectData()
        {
            var book = GetTestBook();
            var info = book.GetInfo();


            Assert.That(info[0], Does.StartWith("Основы квантовой механики. Авторы: Д.И.Блохинцев"));

            
            Assert.That(info[1], Does.Contain("1976"));
            Assert.That(info[1], Does.Contain("Наука"));
            Assert.That(info[1], Does.Contain("в читальном зале"));
            Assert.That(book.Price, Is.EqualTo(1200.00m));


            Assert.That(info[2], Is.EqualTo("Область науки: Физика"));
            Assert.That(info[3], Is.EqualTo("Аннотация: Подходит для аспирантов, студентов физико-математических специальностей"));
        }
    }
}
