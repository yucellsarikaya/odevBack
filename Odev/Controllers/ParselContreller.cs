using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Odev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev.Controllers
{
    [Route("/api/Parsel")]
    [ApiController]
    public class ParselContreller : ControllerBase
    {
        private TableContext tableContext;

        public ParselContreller(TableContext tableContext)
        {
            this.tableContext = tableContext;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var all = tableContext.Parsels.ToList();
            return Ok(all);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddParsel(Parsel parsel)
        {
            tableContext.Parsels.Add(parsel);
            tableContext.SaveChanges();
            return Ok(parsel.ParselId);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult UpdateParsel(Parsel parsel)
        {
            tableContext.Update(parsel);
            tableContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteGadget(int id)
        {
            var gadgetToDelete = tableContext.Parsels.Where(p => p.ParselId == id).FirstOrDefault(); //verilen id ye eşit varsa elemanı getirir
            if (gadgetToDelete == null) //gelen eleman yoksa 404 döner
            {
                return NotFound();
            }

            tableContext.Parsels.Remove(gadgetToDelete); //eleman varsa siler
            tableContext.SaveChanges(); // db yi kayıt eder
            return NoContent();
        }
    }
}
