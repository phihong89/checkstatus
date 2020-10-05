using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KerryStatus.Models
{
    public class kem_gateway_response_log
    {
        public int id { get; set; }
        public string so_van_don { get; set; }
        public decimal khoi_luong { get; set; }
        public decimal cuoc { get; set; }
        public decimal phi { get; set; }
        public string ma_trang_thai { get; set; }
        public string response_code { get; set; }
        public DateTime time_status { get; set; }
        public string response_log { get; set; }
        public string data { get; set; }
        public string message { get; set; }
        public DateTime sys_createdate { get; set; }

    }
}