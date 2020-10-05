using Dapper;
using KerryStatus.Models.KEM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KerryStatus.Repositorys.KEM
{
    public class kem_gateway_k_waybillRepository
    {
        public kem_gateway_k_waybill GetInfoShipmentKemWaybill(string _waybill_number)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.ConnectionStringSQL))
            {
                string _sql = "select top 1 * from kem_gateway_k_waybill where waybill_number = @waybill_number order by sys_createdate";
                DynamicParameters p = new DynamicParameters();
                p.Add("@waybill_number", _waybill_number);
                return connection.QueryFirstOrDefault<kem_gateway_k_waybill>(_sql, p, commandType: CommandType.Text);
            }
        }

        public List<kem_gateway_k_waybill> GetShipmentsEton(string OrderNumber)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.ConnectionStringSQL))
            {
                string _sql = "select * from kem_gateway_k_waybill where customer_code = '5018821' and order_number = @OrderNumber;";

                DynamicParameters p = new DynamicParameters();
                p.Add("@OrderNumber", OrderNumber);

                return connection.Query<kem_gateway_k_waybill>(_sql, p, commandType: CommandType.Text).ToList();
            }
        }

        /// <summary>
        /// Get list shipment have status SIP, sync to Oracle
        /// </summary>
        /// <returns></returns>
        public List<kem_gateway_k_waybill> GetInfoShipmentSyncToOracle()
        {
            DateTime _now = DateTime.Now;
            string _dt = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.ConnectionStringSQL))
            {
                string _sql = "SELECT " +
                                "TOP 10 " +
                                  "k.* " +
                                "FROM kem_gateway_k_waybill k " +
                                "INNER JOIN kem_gateway_customer_key k1 " +
                                  "ON k.customer_code = k1.customer_code " +
                                "INNER JOIN kem_gateway_bill_status s " +
                                  "ON k.waybill_number = s.so_van_don " +
                                "WHERE k.sys_createdate >= '" + _dt + " 00:00:00' " +
                                "AND s.sys_createdate <= DATEADD(mi, -5, GETDATE()) " +
                                "AND (status_sync = 0 " +
                                "OR status_sync IS NULL) " +
                                "AND k1.is_test = 0 " +
                                "AND (s.ma_trang_thai = 'SIP' OR (s.ma_trang_thai = 'PUP' AND s.type = 3)) " +
                                "AND k.customer_code != '6666666' " +
                                "AND k.customer_code != '8888888' " +
                                "AND k.customer_code != 'C01TEST' " +
                                "AND k.waybill_number = 'FTGSFDCHN0099957KR'" +
                                "ORDER BY k.sys_createdate ASC";

                return connection.Query<kem_gateway_k_waybill>(_sql, commandType: CommandType.Text).ToList();
            }
        }

        /// <summary>
        /// Update status_sync, sync Oracle
        /// </summary>
        /// <param name="waybill_number"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool UpdateSync(string waybill_number, int value)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.ConnectionStringSQL))
            {
                string _sql = $"UPDATE kem_gateway_k_waybill SET status_sync = {value} WHERE waybill_number = @waybill_number";
                DynamicParameters p = new DynamicParameters();
                p.Add("@waybill_number", waybill_number);
                return connection.Execute(_sql, p, commandType: CommandType.Text) > 0;
            }
        }

        public bool CheckStatusExsist(string waybill_number, string status)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.ConnectionStringSQL))
            {
                string _sql = "select count(1) from kem_gateway_bill_status where so_van_don = @waybill_number and ma_trang_thai = @status";

                DynamicParameters p = new DynamicParameters();
                p.Add("@waybill_number", waybill_number);
                p.Add("@status", status);

                return connection.ExecuteScalar<int>(_sql, p, commandType: CommandType.Text) > 0;
            }
        }

        //public new_ems GetEmployeePickup(string waybill_number)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConfigurationSettings.ConnectionStringSQL))
        //    {
        //        string _sql = "select nv_nhan as employee_pickup, no_parcels from nc_bill where waybill_number  = @waybill_number;";

        //        DynamicParameters p = new DynamicParameters();
        //        p.Add("@waybill_number", waybill_number);

        //        return connection.QueryFirstOrDefault<new_ems>(_sql, p, commandType: CommandType.Text);
        //    }
        //}
        public bool InsertWaybill(kem_gateway_k_waybill _item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationSettings.ConnectionStringSQL))
                {
                    DynamicParameters p = new DynamicParameters();
                    p.Add("@waybill_number", _item.waybill_number);
                    p.Add("@order_number", _item.order_number);
                    p.Add("@order_number_super", _item.order_number_super);
                    p.Add("@customer_code", _item.customer_code);
                    p.Add("@sender_province", _item.sender_province);
                    p.Add("@sender_district", _item.sender_district);
                    p.Add("@sender_ward", _item.sender_ward);
                    p.Add("@sender_address", _item.sender_address);
                    p.Add("@sender_contact", _item.sender_contact);
                    p.Add("@sender_phone", _item.sender_phone);
                    p.Add("@receiver_province", _item.receiver_province);
                    p.Add("@receiver_district", _item.receiver_district);
                    p.Add("@receiver_ward", _item.receiver_ward);
                    p.Add("@receiver_address", _item.receiver_address);
                    p.Add("@receiver_contact", _item.receiver_contact);
                    p.Add("@receiver_phone", _item.receiver_phone);
                    p.Add("@receiver_name", _item.receiver_name);
                    p.Add("@status", _item.status);
                    p.Add("@cod", _item.cod);
                    p.Add("@height", _item.height);
                    p.Add("@length", _item.length);
                    p.Add("@width", _item.width);
                    p.Add("@no_parcels", _item.no_parcels);
                    p.Add("@weight", _item.weight);
                    p.Add("@weight_conversion", _item.weight_conversion);
                    p.Add("@cost", _item.cost);
                    p.Add("@remark", _item.remark);
                    p.Add("@remote_cost", _item.remote_cost);
                    p.Add("@woodbaler_cost", _item.woodbaler_cost);
                    p.Add("@is_wood_baler", _item.is_wood_baler);
                    p.Add("@service", _item.service);
                    p.Add("@payment_type", _item.payment_type);
                    p.Add("@items", _item.items);
                    p.Add("@data", _item.data);
                    p.Add("@status_sync", _item.status_sync);
                    p.Add("@sys_active", _item.sys_active);
                    p.Add("@sys_delete", _item.sys_delete);
                    p.Add("@sys_createdate", _item.sys_createdate);
                    p.Add("@sys_updatedate", _item.sys_updatedate);
                    p.Add("@sys_createby", _item.sys_createby);
                    p.Add("@sys_updateby", _item.sys_updateby);
                    p.Add("@tra_ngay", _item.tra_ngay);
                    p.Add("@lead_time", _item.lead_time);
                    p.Add("@status_sync_ems", _item.status_sync_ems);
                    p.Add("@nv_nhan", _item.nv_nhan);
                    p.Add("@sync_kes", _item.sync_kes);
                    p.Add("@zipcode", _item.zipcode);
                    p.Add("@double_check_fee", _item.double_check_fee);
                    p.Add("@shop_code", _item.shop_code);
                    p.Add("@acct_customer_code", _item.acct_customer_code);
                    p.Add("@no_parcels_doc", _item.no_parcels_doc);
                    p.Add("@goods_value", _item.goods_value);
                    p.Add("@insurance_fee", _item.insurance_fee);
                    var a = connection.Execute("kem_gateway_k_waybill_insert", p, commandType: System.Data.CommandType.StoredProcedure);

                    return connection.Execute("kem_gateway_k_waybill_insert", p, commandType: System.Data.CommandType.StoredProcedure) > 0;
                }
            }
            catch (Exception ex)
            {

                return false;
            }

        }
    }
}