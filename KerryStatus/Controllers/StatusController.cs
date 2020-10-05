using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using KerryStatus.Models.KEM;
using KerryStatus.Repositorys.KEM;
using KEVENINTERNAL.repository.SQL;

namespace KerryStatus.Controllers
{
    public class StatusController : Controller
    {
        // GET: Status

        public ActionResult billStatus()
        {
            return View();
        }
        public ActionResult listStatus()
        {
            return View();
        }
        public ActionResult SearchStatus()
        {
            return View();
        }
        public ActionResult _PartialListStatus(string so_van_don)
        {
            var model = kem_gateway_bill_statusRepository.GetListStatus(so_van_don);
            return PartialView("_PartialListStatus", model);
        }
        public ActionResult ResultSearchStatus(string so_van_don)
        {
            string search = so_van_don.Trim().ToUpper();
            var lstStatus = kem_gateway_bill_statusRepository.GetListStatus(search);
            //var lstStatus = kem_gateway_bill_statusRepository.GetListStatus(so_van_don.Replace(" ",string.Empty).ToUpper());
            return View(lstStatus);
        }
        //[HttpGet]
        public ActionResult UpdateStatus(string id, string so_bill)
        {
            nc_billRepository nbr = new nc_billRepository();
            //kem_gateway_bill_status kgbs = new kem_gateway_bill_status();
            nc_bill nb = new nc_bill();
            nb = nbr.GetByWaybill(so_bill);
            // do something here
            ////string ma_nv_nhan = id.Trim();
            recordStaffBill rec = new recordStaffBill()
            {
                ma_nv_nhan = id.Trim(),
                so_bill = so_bill.Trim(),
                sender_address = nb.sender_address,
                sender_contact = nb.sender_contact,
                sender_phone = nb.sender_phone,
            };

            ViewBag.Message = rec;
            return View(rec);
        }
        public class Record
        {
            public string ma_nv_nhan { get; set; }
            public string so_bill { get; set; }

        }
        [HttpPost]
        public ActionResult updateBillStatus(string onPUP, string onPUX)
        {
            string status = string.Empty;
            if (onPUP != null)
            {
                status = "PUP";
            }
            if (onPUX != null)
            {
                status = "PUX";
            }
            string so_van_don = Request["txtSoVanDon"].ToString();
            string ma_nv_nhan = Request["txtMaNV"].ToString();
            string ly_do = Request["txtLyDo"].ToString() == "" ? null : Request["txtLyDo"].ToString();
            nc_billRepository nbr = new nc_billRepository();
            kem_gateway_bill_status kgbs = new kem_gateway_bill_status();
            nc_bill nb = new nc_bill();
            nb = nbr.GetByWaybill(so_van_don);
            kgbs.so_van_don = so_van_don;
            if (nb == null)
            {
                return Content("Waybill not found!!");
            }
            kgbs.ma_trang_thai = status;
            if (onPUP != null)
                kgbs.ma_nv_nhan = ma_nv_nhan;
            kgbs.ma_kh = nb.customer_code_api;
            kgbs.ghi_chu = onPUP != null ? "Nhan hang thanh cong" : ly_do;
            kgbs.sys_createby = int.Parse(ma_nv_nhan);
            kgbs.sync = 0;
            kgbs.so_lan = 0;
            kgbs.sys_createdate = DateTime.Now;
            kgbs.time_status = kgbs.time_status == DateTime.MinValue ? DateTime.Now : kgbs.time_status;
            kgbs.sys_active = true;
            kgbs.sys_delete = false;
            kgbs.type = 8;
            bool i = kem_gateway_bill_statusRepository.Insert(kgbs);
            if (i)
            {
                return Content("Succes!!");
            }
            else
            {
                return Content("Unsucces!!");
            }
        }


    }
}