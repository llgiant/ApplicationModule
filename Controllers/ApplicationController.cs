using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationModule.Model;


namespace ApplicationModule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase

    {
        private static readonly List<RegisterApp> Applications = new List<RegisterApp>
        {
            new RegisterApp{
                CreateDate = DateTime.Today,
                Email = "first@mail.com",
                Number = 1,
                OrganizationName = "Developers Inc.",
                Position = "Developer",
                UserFullName = "Виктор Николаевич Лагутин"
            },
            new RegisterApp{
                CreateDate = DateTime.Today.AddDays(-1),
                Email = "rabbits_DGF@mail.com",
                Number = 2,
                OrganizationName = "New Stone Arm LLC",
                Position = "Manager",
                UserFullName = "Семен Семенович Горбунков"
            },
              new RegisterApp{
                CreateDate = DateTime.Today.AddDays(-2),
                Email = "ASN@mail.com",
                Number = 3,
                OrganizationName = "Ever Best Company",
                Position = "Accountant",
                UserFullName = "Андрей Сергеевич Новиков"
            },
        };


        [HttpGet]
        public IEnumerable<RegisterApp> GetApplications()
        {
            return Applications;
        }


        [HttpPost("{number}")]
        public ActionResult CreateApplication(int number, RegisterApp app)
        {
            var existingItem = Applications.FirstOrDefault(a => a.Number == number || a.Number == app.Number);

            if (existingItem != null)
            {
                var message = string.Format("Заявака с номером = {0} уже создана", number);             
                System.Web.Http.HttpError err = new System.Web.Http.HttpError(message);
                return BadRequest(message);
            }

            Applications.Add(app);

            return Ok();
        }

        [HttpPut("{number}")]
        public ActionResult UpdateApplication(int number, RegisterApp app)
        {
            var existingItem = Applications.FirstOrDefault(a => a.Number == number);

            if (existingItem!=null)
            {
                //use automapper and DTOs instead
                existingItem.Number = app.Number;
                existingItem.Email = app.Email;
                existingItem.OrganizationName = existingItem.OrganizationName;
                existingItem.Position = app.Position;
                existingItem.UserFullName = app.UserFullName;
                return Ok();
            }

            return NotFound();

        }

        [HttpDelete("{number}")]
        public ActionResult DeleteApplication(int number, RegisterApp app)
        {
            var existingItem = Applications.FirstOrDefault(a => a.Number == number);

            if (existingItem != null)
            {
                Applications.Remove(existingItem);
                return Ok();
            }

            return NotFound();
        }
    }

}
