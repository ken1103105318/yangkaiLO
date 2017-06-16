using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ykl1103105318_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var location = FindLocationData();
            ShowLocationData(location);
            Console.ReadLine();
        }

        public static List<Location> FindLocationData()
        {
            List<Location> location = new List<Location>();
            var xml = XElement.Load(@"C:\Users\ASUS\Desktop\1103105318\county_h_10603.xml");
            var StationsData = xml.Descendants("county_h_10508").ToList();
            StationsData
                .Where(x => !x.IsEmpty).ToList()
                .ForEach(stationData =>
                {
                    var 欄位1 = stationData.Element("欄位1").Value.Trim();
                    var 欄位2 = stationData.Element("欄位2").Value.Trim();
                    var 欄位3 = stationData.Element("欄位3").Value.Trim();

                    Location Data = new Location();
                    Data.欄位1 = 欄位1;
                    Data.欄位2=  欄位2;
                    Data.欄位3 = 欄位3;
                    location.Add(Data);
                });
            return location;
        }
        public static void ShowLocationData(List<Location> location)
        {
            Console.WriteLine(string.Format("共收到{0}筆的資料", location.Count));
            location.ForEach(x =>
            {
                Console.WriteLine(string.Format("{0}，郵遞區號:{1}", x.欄位2, x.欄位1));
            });
        }
    }
}
