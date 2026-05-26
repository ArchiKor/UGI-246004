using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalog.UnitTests
{
    [TestFixture]
    public class EditionComparerByInventoryNumberTests
    {
        [Test]
        public void Sort_UsingComparer_OrdersByInventoryNumberAscending()
        {
            var authors = new List<string> {"Автор"};
            var ed1 = new Edition("Первая", authors, 2000, "Изд", EditionStatus.InStorage, 100);
            var ed2 = new Edition("Вторая", authors, 2000, "Изд", EditionStatus.InStorage, 200);

            var list = new List<Edition> { ed2, ed1 }; 
            list.Sort(new InventoryNumber());

            Assert.That(list[0].InventoryNumber, Is.LessThan(list[1].InventoryNumber));
        }

        [Test]
        public void Compare_NullHandling()
        {
            var comparer = new InventoryNumber();
            var edition = new Edition("Книга", new List<string> {"Автор"}, 2000, "Изд", 
                EditionStatus.InStorage, 100);

            Assert.That(comparer.Compare(null, edition), Is.EqualTo(-1));
            Assert.That(comparer.Compare(edition, null), Is.EqualTo(1));
            Assert.That(comparer.Compare(null, null), Is.EqualTo(0));
        }
    }
}
