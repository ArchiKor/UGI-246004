using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalog.UnitTests
{
    [TestFixture]
    public class FictionLiteratureTests
    {
        private FictionLiterature GetTestNovel()
        {
            var authors = new List<string> {"Лев Толстой"};
            return new FictionLiterature(
                title: "Война и мир",
                authors: authors,
                year: 1869,
                publisher: "Русский вестник",
                status: EditionStatus.InHome,
                price: 1500.00m,
                genre: "Роман-эпопея",
                language: "Русский",
                workType: "Проза"
            );
        }

        [Test]
        public void Constructor_AssignsProperties()
        {
            var novel = GetTestNovel();
            Assert.That(novel.Genre, Is.EqualTo("Роман-эпопея"));
            Assert.That(novel.Language, Is.EqualTo("Русский"));
            Assert.That(novel.WorkType, Is.EqualTo("Проза"));
        }

        [Test]
        public void GetInfo_ReturnsFiveLines()
        {
            var novel = GetTestNovel();
            var info = novel.GetInfo();
            Assert.That(info.Length, Is.EqualTo(5)); 
        }

        [Test]
        public void GetInfo_ContentCheck()
        {
            var novel = GetTestNovel();
            var info = novel.GetInfo();

            Assert.That(info[2], Is.EqualTo("Жанр: Роман-эпопея"));
            Assert.That(info[3], Is.EqualTo("Язык произведения: Русский"));
            Assert.That(info[4], Is.EqualTo("Вид: Проза"));
        }
    }
}
