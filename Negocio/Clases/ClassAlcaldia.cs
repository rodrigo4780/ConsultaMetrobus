using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Negocio.Clases
{
    public class ClassAlcaldia
    {
        [JsonPropertyName("records")]
        public IList<RecordsAlcaldia> Records { get; set; }
    }

    public class RecordsAlcaldia
    {
        [JsonPropertyName("fields")]
        public FieldsAlcaldia Fields { get; set; }

    }

    public class FieldsAlcaldia
    {
        [JsonPropertyName("cve_mun")]
        public string Cve_mun { get; set; }
    }
}
