using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyParkingManagerDB
{
    public class ParkingCar
    {
        public int parkingSpot {  get; set; }
        public string carNumber { get; set; }
        public string driverName { get; set; }
        public string phoneNumber { get; set; }
        public DateTime parkingTime { get; set; }
    }
}
