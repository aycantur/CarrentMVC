using CarRental.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json.Serialization;

namespace CarRental.Controllers
{
    public class PopupController : Controller
    {
        public JsonResult Index(Popupmessage popupmessage)
        {
            Popup popup = new Popup();
            JsonResult json = new JsonResult(popup);
            
            if (popupmessage.success)
            {
                popup.IsSuccess = true;
                popup.JsonMessage = "Kayıt başarılı.";
            }
            else
            {
                popup.IsSuccess = false;
                popup.JsonMessage = "Kayıt başarısız.";
            }

            return Json(popup, json.Value); ;
        }
    }
}
