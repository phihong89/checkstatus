using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KerryStatus.Models.KEM
{
    public class recordStaffBill
    {
        public string ma_nv_nhan { get; set; }
        public string so_bill { get; set; }
        public string sender_address { get; set; }
        public string sender_contact { get; set; }
        public string sender_phone { get; set; }

        [Required]
        public string ly_do { get; set; }
    }
}