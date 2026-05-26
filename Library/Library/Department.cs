using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Department : IEnumerable<Edition>
    {
        public string Name { get; set; }
        public int EditionCount => editions.Count;

        private List<Edition> editions;

        public Department(string name, IEnumerable<Edition> editionsCollection)
        {
            Name = name;
            editions = new List<Edition>();
            if (editionsCollection != null)
            {
                foreach (var edition in editionsCollection)
                {
                    if (!editions.Contains(edition))
                    {
                        editions.Add(edition);
                    }
                }
            }
        }

        public IEnumerator<Edition> GetEnumerator()
        {
            return editions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
