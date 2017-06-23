using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ykl1103105318.Models;

namespace ykl1103105318
{
    class Program
    {
        static void Main(string[] args)
        {
            var import = new ykl1103105318.Service.ImportService();
            var db = new ykl1103105318.Repository.LocationRepository();
            var locations = import.FindStationData(); //xml
            //locations
            //    .ToList().ForEach(station =>
            //{
            //    db.Create(locations);
            //});
            //var locations = db.FindAllStations();
            ShowLocationData(locations);
            Console.ReadLine();
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
