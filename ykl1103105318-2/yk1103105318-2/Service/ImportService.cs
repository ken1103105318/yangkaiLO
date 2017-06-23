using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ykl1103105318.Models;

namespace ykl1103105318.Service
{
    public class ImportService
    {
        public List<Location> FindStationData()
        {
            List<Location> location = new List<Location>();
            var xml = XElement.Load(@"C:\Users\user\Desktop\county_h_10603.xml");
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
                    Data.欄位2 = 欄位2;
                    Data.欄位3 = 欄位3;
                    location.Add(Data);
                });
            return location;
        }
    }
}
