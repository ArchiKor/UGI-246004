using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    
    public class ScientificTechnicalLiterature:Edition
    {
        
        public string ScienceField { get; set; }  
        public string Annotation { get; set; }   

        
        public ScientificTechnicalLiterature(
            string title,
            List<string> authors,
            int year,
            string publisher,
            EditionStatus status,
            decimal price,
            string scienceField,
            string annotation)
            :base(title, authors, year, publisher, status, price)
        {
            ScienceField = scienceField;
            Annotation = annotation;
        }

        
        public override string[]GetInfo()
        {
           
            var baseInfo = base.GetInfo();

            var info = new string[baseInfo.Length + 2];
            Array.Copy(baseInfo, info, baseInfo.Length);

            info[baseInfo.Length] = $"Область науки: {ScienceField}";
            info[baseInfo.Length + 1] = $"Аннотация: {Annotation}";

            return info;
        }

       
    }
}
