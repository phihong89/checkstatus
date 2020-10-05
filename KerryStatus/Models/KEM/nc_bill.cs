using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KerryStatus.Models.KEM
{
    public class nc_bill
    {
        public int Id { get; set; }
        public string waybill_number { get; set; }
        public string ref_number { get; set; }
        public string order_number_supper { get; set; }
        public string customer_code { get; set; }
        /* sender address*/
        public string sender_province { get; set; }
        public string sender_district { get; set; }
        public string sender_ward { get; set; }
        public string sender_address { get; set; }
        public string sender_contact { get; set; }
        public string sender_phone { get; set; }
        /* receiver address*/
        public string receiver_province { get; set; }
        public string receiver_district { get; set; }
        public string receiver_ward { get; set; }
        public string receiver_address { get; set; }
        public string receiver_contact { get; set; }
        public string receiver_phone { get; set; }
        public string receiver_name { get; set; }
        public Nullable<decimal> cod { get; set; }
        public Nullable<decimal> height { get; set; }
        public Nullable<decimal> length { get; set; }
        public Nullable<decimal> width { get; set; }
        public Nullable<int> no_parcels { get; set; }
        public Nullable<int> no_parcels_doc { get; set; }
        public Nullable<decimal> weight { get; set; }
        public Nullable<decimal> weight_conversion { get; set; }
        public Nullable<decimal> cost { get; set; }
        public string remark { get; set; }
        public Nullable<decimal> remote_cost { get; set; }
        public Nullable<decimal> woodbaler_cost { get; set; }
        public Nullable<decimal> double_check_cost { get; set; }
        public Nullable<decimal> insurance_cost { get; set; }
        public Nullable<decimal> other_cost { get; set; }
        public string service { get; set; }
        public string payment_type { get; set; }
        public string nv_nhan { get; set; }
        public string shop_code { get; set; }
        public Nullable<int> table { get; set; }
        public string sender_customer_code { get; set; }
        public string receiver_customer_code { get; set; }
        public string customer_code_api { get; set; }
        public Nullable<int> order_type { get; set; }
        public Nullable<int> special_cost { get; set; }
        public Nullable<DateTime> sys_createdate { get; set; }
        public Nullable<DateTime> sys_updatedate { get; set; }
        // public Nullable<Boolean> is_wood_baler { get; set; }
        public Nullable<int> sync { get; set; }
        public Nullable<int> receiver_pay_code { get; set; }
        public decimal? promotion_cost { get; set; }
    }
}