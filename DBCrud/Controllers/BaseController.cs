using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Entity.ServiceResp;
using Microsoft.AspNetCore.Mvc;

namespace DBCrud.Controllers
{
    public class BaseController : Controller
    {
        protected IActionResult Okay(ServiceResponse serviceResult)
        {

            return Ok(new
            {
                serviceResult.MessageType,
                serviceResult.Status,
                serviceResult.Data,
                serviceResult.Messages
            });
        }
    }
}