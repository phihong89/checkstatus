using Dapper;
using KerryStatus.Models.KEM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KerryStatus.Repositorys.KEM
{
    public class kem_gateway_bill_statusRepository
    {
        public static bool Insert(kem_gateway_bill_status _item)
        {
            bool result;
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.ConnectionStringSQL))
            {
                string _sql = "INSERT INTO [dbo].[kem_gateway_bill_status] ( [so_van_don], [ma_trang_thai], [ma_kh], [created], [ghi_chu], [so_lan], [sync], [sync_ems], [sync_orc], [time_status], [sys_active], [sys_delete], [sys_createdate], [sys_updatedate], [sys_createby], [sys_updateby], [type], [sync_kes], [ma_nv_nhan], [ma_nv_giao] )  VALUES ( @so_van_don, @ma_trang_thai, @ma_kh, @created, @ghi_chu, @so_lan, @sync, @sync_ems, @sync_orc, @time_status, @sys_active, @sys_delete, @sys_createdate, @sys_updatedate, @sys_createby, @sys_updateby, @type, @sync_kes, @ma_nv_nhan, @ma_nv_giao )";
                DynamicParameters p = new DynamicParameters();
                p.Add("@so_van_don", _item.so_van_don);
                p.Add("@ma_trang_thai", _item.ma_trang_thai);
                p.Add("@ma_kh", _item.ma_kh);
                p.Add("@created", _item.created);
                p.Add("@ghi_chu", _item.ghi_chu);
                p.Add("@so_lan", _item.so_lan);
                p.Add("@sync", _item.sync);
                p.Add("@sync_ems", _item.sync_ems);
                p.Add("@sync_orc", _item.sync_orc);
                p.Add("@time_status", _item.time_status);
                p.Add("@sys_active", _item.sys_active);
                p.Add("@sys_delete", _item.sys_delete);
                p.Add("@sys_createdate", _item.sys_createdate);
                p.Add("@sys_updatedate", _item.sys_updatedate);
                p.Add("@sys_createby", _item.sys_createby);
                p.Add("@sys_updateby", _item.sys_updateby);
                p.Add("@type", _item.type);
                p.Add("@sync_kes", _item.sync_kes);
                p.Add("@ma_nv_nhan", _item.ma_nv_nhan);
                p.Add("@ma_nv_giao", _item.ma_nv_giao);
                int rowsAffected = connection.Execute(_sql, p, commandType: CommandType.Text);
                result = (rowsAffected > 0);
            }
            return result;
        }

        public static List<kem_gateway_bill_status> GetListStatus(string so_van_don)
        {
            //DateTime _now = DateTime.Now;
            //string _dt = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.ConnectionStringSQL))
            {
                string _sql = "SELECT " +
                                "TOP 100 " +
                                  "so_van_don, ma_kh, ma_trang_thai,sys_createby, ghi_chu, so_lan, sync, FORMAT(time_status, 'dd/MM/yyyy HH:mm:ss') as time_status, sys_updatedate, FORMAT(sys_createdate, 'dd/MM/yyyy HH:mm:ss') as sys_createdate " +
                                "FROM kem_gateway_bill_status  " +
                                "WHERE so_van_don = @so_van_don ORDER BY ID ASC";
                DynamicParameters p = new DynamicParameters();
                p.Add("so_van_don", so_van_don);
                return connection.Query<kem_gateway_bill_status>(_sql,p, commandType: CommandType.Text).ToList();
            }
        }
    }
}