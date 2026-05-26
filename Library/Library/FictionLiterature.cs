using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    
    public class FictionLiterature : Edition
    {
        public string Genre { get; set; }  

        public string Language { get; set; } 
        
        public string WorkType { get; set; }  
        

        public FictionLiterature(
            string title,
            List<string> authors,
            int year,
            string publisher,
            EditionStatus status,
            decimal price,
            string genre,
            string language,
            string workType)
            : base(title, authors, year, publisher, status, price)
        {
            Genre = genre;
            Language = language;
            WorkType = workType;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var info = new string[baseInfo.Length + 3];
            Array.Copy(baseInfo, info, baseInfo.Length);

            info[baseInfo.Length] = $"Жанр: {Genre}";
            info[baseInfo.Length + 1] = $"Язык произведения: {Language}";
            info[baseInfo.Length + 2] = $"Вид: {WorkType}";

            return info;
        }
    }
}
