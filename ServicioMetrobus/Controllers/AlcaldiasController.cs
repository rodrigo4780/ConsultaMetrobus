using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using Newtonsoft.Json;

namespace ServicioMetrobus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlcaldiasController : ControllerBase
    {
        // GET: api/Alcaldias
        [HttpGet]
        public string Get()
        {
            DataTable dt = new DataTable();

            dt = PostgresUtility.ConsultaAlcaldias();

            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dt);

            return JSONString;

        }


        // GET: api/Alcaldias/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(string id)
        {
            DataTable dt = new DataTable();

            dt = PostgresUtility.ConsultaAlcaldias(id);

            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dt);

            return JSONString;
        }

        //// POST: api/Alcaldias
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

    }
}
