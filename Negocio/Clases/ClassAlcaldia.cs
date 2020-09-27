using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Negocio.Clases
{
    //Clase Alcaldia donde se guardara la respueta del Api de Alcaldia
    //Primer nivel del Json
    public class ClassAlcaldia
    {
        [JsonPropertyName("records")]
        public IList<RecordsAlcaldia> Records { get; set; }
    }

    //Se crea el segundo nivel de la estructura del Json
    public class RecordsAlcaldia
    {
        [JsonPropertyName("fields")]
        public FieldsAlcaldia Fields { get; set; }

    }

    //Tercer Nivel del Json, aqui obtendremos la clave de la Alcaldia
    public class FieldsAlcaldia
    {

        //Propiedad para asignar la clave de la Alcaldia
        [JsonPropertyName("cve_mun")]
        public string Cve_mun { get; set; }
    }
}
