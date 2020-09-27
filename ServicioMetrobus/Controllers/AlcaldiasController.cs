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
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AlcaldiasController : ControllerBase
    {
        // GET: api/Alcaldias/get
        [HttpGet]
        public string Get()
        {
            DataTable dt = new DataTable();

            dt = PostgresUtility.ConsultaAlcaldias();

            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dt);

            return JSONString;

        }


        // GET: api/Alcaldias/get/17
        [HttpGet("{id}")]
        public string Get(string id)
        {
            DataTable dt = new DataTable();

            dt = PostgresUtility.ConsultaAlcaldias(id);

            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dt);

            return JSONString;
        }

    }

    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UnidadesController : ControllerBase
    {
        // GET: api/Unidades/get
        [HttpGet]
        public string Get()
        {
            DataTable dt = new DataTable();

            dt = PostgresUtility.ConsultaUnidades();

            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dt);

            return JSONString;
        }

        // GET: api/Unidades/get/497
        [HttpGet("{id}")]
        public string Get(int id)
        {
            DataTable dt = new DataTable();

            dt = PostgresUtility.ConsultaUnidades(id);

            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dt);

            return JSONString;
        }


    }
}
