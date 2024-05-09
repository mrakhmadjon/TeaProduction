using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaProduction.Business.DTOs
{
    internal class GreenTeaDto : TeaBaseDto
    {
        public double AntioxidantLevel { get; set; }
        public string LeafGrade { get; set; }
        public int BrewingTemperature { get; set; }
        public override string GetDescription()
        {
            return $"Name: {Name}," +
                $" Type: {Type}," +
                $" Price: {Price}, " +
                $"Antioxidant level : {AntioxidantLevel}," +
                $"Leaf grade: {LeafGrade}," +
                $"Brewing Temperature : {BrewingTemperature}";
        }
    }
}
