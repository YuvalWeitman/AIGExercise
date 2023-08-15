using CoreWebApplication1.Models;
using CoreWebApplication1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System;

namespace CoreWebApplication1.Controllers
{
    public class SnoozeController : Controller
    {
        private readonly SnoozeService snoozeService;

        public SnoozeController()
        {
            snoozeService = new SnoozeService();
        }

        [HttpPost]
        public IActionResult CreateSnooze(string message, int option, DateTime dateTime)
        {
            try
            {
                if(option < 0 || option > Enum.GetNames(typeof(SnoozeOption)).Length - 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(option));
                }

                snoozeService.HandleSnoozeRequest(message, (SnoozeOption)option, dateTime);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();

        }
    }
}
