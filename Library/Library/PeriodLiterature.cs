using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class PeriodLiterature:Edition
    {
        public string Period { get; set; }
        public string PeriodicalType { get; set; }

        public PeriodLiterature(
            string title,
            List<string> authors,
            int year,
            string publisher,
            EditionStatus status,
            decimal price,
            string period,
            string periodicalType)
            : base(title, authors, year, publisher, status, price)
        {
            Period = period;
            PeriodicalType = periodicalType;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var info = new string[baseInfo.Length + 2];
            Array.Copy(baseInfo, info, baseInfo.Length);

            info[baseInfo.Length] = $"Периодичность: {Period}";
            info[baseInfo.Length + 1] = $"Тип периодики: {PeriodicalType}";

            return info;
        }
    }
}
