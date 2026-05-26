using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalog.UnitTests
{
    internal class PeriodLiteratureTests
    {
        [TestFixture]
        public class PeriodicalLiteratureTests
        {
            private PeriodLiterature GetTestMagazine()
            {
                var authors = new List<string> {"Редакция"};
                return new PeriodLiterature(
                    title: "Эстрадные звезды в обычной жизни",
                    authors: authors,
                    year: 2023,
                    publisher: "Пресса",
                    status: EditionStatus.InStorage,
                    price: 250.00m,
                    period: "Ежемесячно",
                    periodicalType: "Журнал"
                );
            }

            [Test]
            public void Constructor_SetsProperties()
            {
                var mag = GetTestMagazine();
                Assert.That(mag.Period, Is.EqualTo("Ежемесячно"));
                Assert.That(mag.PeriodicalType, Is.EqualTo("Журнал"));
            }

            [Test]
            public void GetInfo_ReturnsFourLines()
            {
                var mag = GetTestMagazine();
                var info = mag.GetInfo();
                Assert.That(info.Length, Is.EqualTo(4));
            }

            [Test]
            public void GetInfo_AdditionalLinesCorrect()
            {
                var mag = GetTestMagazine();
                var info = mag.GetInfo();

                Assert.That(info[2], Is.EqualTo("Периодичность: Ежемесячно"));
                Assert.That(info[3], Is.EqualTo("Тип периодики: Журнал"));
            }
        }
    }
}
