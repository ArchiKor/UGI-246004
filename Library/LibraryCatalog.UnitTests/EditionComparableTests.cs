using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalog.UnitTests
{
    [TestFixture]
    public class EditionComparableTests
    {
        [Test]
        public void CompareTo_FirstAuthor_Different()
        {
            var authors1 = new List<string> {"Пушкин А.С.", "Толстой Л.Н."};
            var authors2 = new List<string> {"Блохинцев Д.И."};
            var edition1 = new Edition("Книга", authors1, 2019, "Изд", EditionStatus.InStorage, 100);
            var edition2 = new Edition("Журнал", authors2, 2021, "Изд", EditionStatus.InStorage, 200);

            Assert.That(edition1, Is.Not.Null);
            Assert.That(edition2, Is.Not.Null);

            Assert.That(edition1.CompareTo(edition2), Is.GreaterThan(0));
            Assert.That(edition2.CompareTo(edition1), Is.LessThan(0));
        }

        [Test]
        public void CompareTo_SameFirstAuthor_CompareTitle()
        {
            var authors = new List<string> {"Толстой Л.Н."};
            var edition1 = new Edition("Война и мир", authors, 2000, "Изд", EditionStatus.InStorage, 100);
            var edition2 = new Edition("Анна Каренина", authors, 2001, "Изд", EditionStatus.InStorage, 200);

            Assert.That(edition2.CompareTo(edition1), Is.LessThan(0));
            Assert.That(edition1.CompareTo(edition2), Is.GreaterThan(0));
        }

        [Test]
        public void CompareTo_SameAuthorAndTitle_CompareYearDescending()
        {
            var authors = new List<string> {"Пушкин"};
            var edition1 = new Edition("Сказки", authors, 2000, "Изд", EditionStatus.InStorage, 100);
            var edition2 = new Edition("Сказки", authors, 2020, "Изд", EditionStatus.InStorage, 200);

            Assert.That(edition2.CompareTo(edition1), Is.LessThan(0));
            Assert.That(edition1.CompareTo(edition2), Is.GreaterThan(0));
        }

        [Test]
        public void CompareTo_OneAuthorNull_ConsideredLess()
        {
            var authors1 = new List<string>();
            var authors2 = new List<string> {"Автор"};
            var edition1 = new Edition("Книга", authors1, 2000, "Изд", EditionStatus.InStorage, 100);
            var edition2 = new Edition("Книга", authors2, 2000, "Изд", EditionStatus.InStorage, 200);

            Assert.That(edition1.CompareTo(edition2), Is.LessThan(0));
            Assert.That(edition2.CompareTo(edition1), Is.GreaterThan(0));
        }

        [Test]
        public void CompareTo_BothAuthorsNull_CompareTitle()
        {
            var authors = new List<string>();
            var edition1 = new Edition("А", authors, 2000, "Изд", EditionStatus.InStorage, 100);
            var edition2 = new Edition("Б", authors, 2000, "Изд", EditionStatus.InStorage, 200);

            Assert.That(edition1.CompareTo(edition2), Is.LessThan(0));
        }
    }
}
