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
        //Obtener una lista de las Alcaldias Disponibles
        // GET: api/Alcaldias/get
        [HttpGet]
        public string Get()
        {
            //Se instancia un DataTable donde guardaremos el resultado de la consulta
            DataTable dt = new DataTable();

            //Mandamos a llamar el metodo que consultara la base de datos.
            dt = PostgresUtility.ConsultaAlcaldias();

            //Se crea string para asignar el Json resultante
            string JSONString = string.Empty;

            //Serializamos el contenido del DataTable a Json
            JSONString = JsonConvert.SerializeObject(dt);

            return JSONString;

        }

        //Obtener una lista de unidades que hayan estado dentro de una alcaldia, como parametro mandamos la clave de alcaldia a consultar.
        // GET: api/Alcaldias/get/17
        [HttpGet("{id}")]
        public string Get(string id)
        {
            //Se instancia un DataTable donde guardaremos el resultado de la consulta
            DataTable dt = new DataTable();

            //Mandamos a llamar el metodo que consultara la base de datos.
            dt = PostgresUtility.ConsultaAlcaldias(id);

            //Se crea string para asignar el Json resultante
            string JSONString = string.Empty;

            //Serializamos el contenido del DataTable a Json
            JSONString = JsonConvert.SerializeObject(dt);

            return JSONString;
        }

    }

    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UnidadesController : ControllerBase
    {
        //Obtener una lista de las unidades disponibles
        // GET: api/Unidades/get
        [HttpGet]
        public string Get()
        {
            //Se instancia un DataTable donde guardaremos el resultado de la consulta
            DataTable dt = new DataTable();

            //Mandamos a llamar el metodo que consultara la base de datos.
            dt = PostgresUtility.ConsultaUnidades();

            //Se crea string para asignar el Json resultante
            string JSONString = string.Empty;

            //Serializamos el contenido del DataTable a Json
            JSONString = JsonConvert.SerializeObject(dt);

            return JSONString;
        }

        //Obtener el historial de ubicaciones/fechas de una unidad dado su Id
        // GET: api/Unidades/get/497
        [HttpGet("{id}")]
        public string Get(int id)
        {
            //Se instancia un DataTable donde guardaremos el resultado de la consulta
            DataTable dt = new DataTable();

            //Mandamos a llamar el metodo que consultara la base de datos.
            dt = PostgresUtility.ConsultaUnidades(id);

            //Se crea string para asignar el Json resultante
            string JSONString = string.Empty;

            //Serializamos el contenido del DataTable a Json
            JSONString = JsonConvert.SerializeObject(dt);

            return JSONString;
        }


    }
}
