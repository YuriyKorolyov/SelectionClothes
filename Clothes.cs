using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp5
{
    public class Clothes
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Tuple<int, int> TemperatureRange { get; set; }
        public List<string> Occasion { get; set; }
        public List<string> Precipitation;

        public Clothes(string name, string type, Tuple<int, int> temperatureRange, List<string> occasion, List<string> precipitation)
        {
            Name = name;
            Type = type;
            TemperatureRange = temperatureRange;
            Occasion = occasion;
            Precipitation = precipitation;
        }

        public override string ToString()
        {
            //return $"Название: {Name}, Тип: {Type}, Температура: {Temperature}, Повод: {Occasion}";
            return Name;
        }
    }
}
