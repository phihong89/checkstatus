using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KerryStatus.Models.KEM
{
    public class kem_gateway_bill_status
    {
        public long id { get; set; } = -1;
        public string so_van_don { get; set; }
        public string ma_trang_thai { get; set; }
        public string ma_kh { get; set; }
        public DateTime? created { get; set; } = null;
        public string ghi_chu { get; set; }
        public int so_lan { get; set; }
        public int sync { get; set; }
        public int sync_ems { get; set; }
        public int sync_orc { get; set; }
        public DateTime time_status { get; set; }
        public bool sys_active { get; set; }
        public bool sys_delete { get; set; }
        public DateTime sys_createdate { get; set; } = DateTime.Now;
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime ? sys_updatedate { get; set; } = null;
        public int sys_createby { get; set; }
        public int sys_updateby  { get; set; }
        public int type { get; set; }
        public int sync_kes { get; set; }
        public string ma_nv_nhan { get; set; }
        public string ma_nv_giao { get; set; }
    }
}