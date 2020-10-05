using Dapper;
using KerryStatus.Models.KEM;
using KerryStatus.Repositorys;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEVENINTERNAL.repository.SQL
{
    class nc_billRepository
    {
        public nc_bill GetByWaybill(string waybill_number)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationSettings.ConnectionStringSQL))
            {
                string _sql = "SELECT * FROM nc_bill WHERE waybill_number = @waybill_number";
                DynamicParameters p = new DynamicParameters();
                p.Add("waybill_number", waybill_number);
                return connection.QueryFirstOrDefault<nc_bill>(_sql, p, commandType: System.Data.CommandType.Text);
            }
        }
    }
}
