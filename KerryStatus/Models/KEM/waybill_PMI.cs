using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KerryStatus.Models.KEM
{
    public class waybill_PMI
    {
        public int id { get; set; }
        public string waybill_number { get; set; }
        public string order_number { get; set; }
        public string order_number_super { get; set; }
        public string customer_code { get; set; }
        public string sender_province { get; set; }
        public string sender_district { get; set; }
        public string sender_ward { get; set; }
        public string sender_address { get; set; }
        public string sender_contact { get; set; }
        public string sender_phone { get; set; }
        public string receiver_province { get; set; }
        public string receiver_district { get; set; }
        public string receiver_ward { get; set; }
        public string receiver_address { get; set; }
        public string receiver_contact { get; set; }
        public string receiver_phone { get; set; }
        public string receiver_name { get; set; }
        public string status { get; set; }
        public decimal cod { get; set; }
        public decimal height { get; set; }
        public decimal length { get; set; }
        public decimal width { get; set; }
        public int no_parcels { get; set; }
        public decimal weight { get; set; }
        public decimal weight_conversion { get; set; }
        public decimal cost { get; set; }
        public string remark { get; set; }
        public decimal remote_cost { get; set; }
        public decimal woodbaler_cost { get; set; }
        public bool is_wood_baler { get; set; }
        public string service { get; set; }
        public string payment_type { get; set; }
        public string items { get; set; }
        //public List<item> items { get; set; }
        public string data { get; set; }
        public int status_sync { get; set; }
        public bool sys_active { get; set; }
        public bool sys_delete { get; set; }
        public DateTime sys_createdate { get; set; }
        public DateTime? sys_updatedate { get; set; } = null;
        public int sys_createby { get; set; }
        public int sys_updateby { get; set; }
        public bool tra_ngay { get; set; }
        public string lead_time { get; set; }
        public int status_sync_ems { get; set; }
        public string nv_nhan { get; set; }
        public int sync_kes { get; set; }
        public string zipcode { get; set; }
        public decimal double_check_fee { get; set; }
        public string shop_code { get; set; }
        public string acct_customer_code { get; set; }
        public int no_parcels_doc { get; set; }
        public decimal goods_value { get; set; }
        public decimal insurance_fee { get; set; }
    }
}