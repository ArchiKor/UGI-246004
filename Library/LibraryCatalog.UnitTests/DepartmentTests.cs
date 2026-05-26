using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalog.UnitTests
{
    [TestFixture]
    public class DepartmentTests
    {
        private List<Edition> testEditions;

        [SetUp]
        public void Setup()
        {
            testEditions = new List<Edition>
            {
                new Edition("Книга1", new List<string>{"Автор1"}, 2000, "Изд", EditionStatus.InStorage, 100),
                new Edition("Книга2", new List<string>{"Автор2"}, 2001, "Изд", EditionStatus.InStorage, 200),
                new Edition("Книга3", new List<string>{"Автор3"}, 2002, "Изд", EditionStatus.InStorage, 300)
            };
        }

        [Test]
        public void Constructor_SetsNameAndCount()
        {
            var dept = new Department("Отдел А", testEditions);
            Assert.That(dept.Name, Is.EqualTo("Отдел А"));
            Assert.That(dept.EditionCount, Is.EqualTo(3));
        }

        [Test]
        public void Constructor_IgnoresDuplicateEditions()
        {
            var duplicate = testEditions[0];
            var listWithDuplicates = new List<Edition>(testEditions) { duplicate, duplicate };
            var dept = new Department("Отдел", listWithDuplicates);

            Assert.That(dept.EditionCount, Is.EqualTo(3));
        }

        [Test]
        public void IEnumerable_ForeachIteratesOverEditionsInOrder()
        {
            var dept = new Department("Отдел", testEditions);
            int index = 0;
            foreach (var edition in dept)
            {
                Assert.That(edition, Is.SameAs(testEditions[index]));
                index++;
            }
            Assert.That(index, Is.EqualTo(3));
        }

        [Test]
        public void EditionCount_IsReadOnly()
        {
            var dept = new Department("Отдел", testEditions);
            var property = typeof(Department).GetProperty("EditionCount");
            Assert.That(property.CanWrite, Is.False);
        }
    }
}
