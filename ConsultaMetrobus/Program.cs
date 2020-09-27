using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using ConsultaMetrobus.Clases;
using System.Text.Json;
using Npgsql;
using Negocio;
using Negocio.Clases;


namespace ConsultaMetrobus
{
    class Program
    {
        //Variables donde se declaran las ligas tanto del servicio de consulta de posicion de metrobus como el de consulta de alcaldia en base a las coordenadas.
        private static string APIUrl = "https://datos.cdmx.gob.mx/api/records/1.0/search/?dataset=prueba_fetchdata_metrobus&rows=50";
        private static string AlcaldiaAPIUrl = "https://datos.cdmx.gob.mx/api/records/1.0/search/?dataset=alcaldias&q=&facet=geo_shape&geofilter.distance=";

        //Se instancia la clase de Metrobus, donde se llenara de la consulta de las ubicaciones de los metrobuses.
        public static ClassMetrobus records = new ClassMetrobus();

        static void Main(string[] args)
        {
            //Programa principal, se llama a la consulta de los datos del servicio.
            ObtenDatosMetrobus();

            //En base a la consulta de la ubicacion de las unidades, se llama el metodo que consulta el API de Alcaldias para obtener 
            //la alcaldia en base a las coordenadas obtenidas.
            LlenaAlcaldias();

            //Insertamos los registros en la Base de datos.
            PostgresUtility.InsertaRegistrosMetrobus(records);
        }

        //Metodo para la llamada del servicio de ubicacion de las unidades del metrobus.
        public static async void ObtenDatosMetrobus()
        {
            try
            {
                //se inicializa el hhtpclient
                using (var client = new HttpClient())
                {
                    // Se ad¿signan los valores al Cliente http
                    client.BaseAddress = new Uri(APIUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Se hace la llamada al API de ubicaciones de unidades
                    var response = client.GetAsync(APIUrl).Result;

                    //Si la respuesta es exitosa entra
                    if (response.IsSuccessStatusCode)
                    {
                        var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var rawResponse = readTask.GetAwaiter().GetResult();
                        Console.WriteLine(rawResponse);

                        //Deserializamos el Json que regresa el API a nuestra clase creada. (ClassMetrobus)
                        records = JsonSerializer.Deserialize<ClassMetrobus>(rawResponse);
                    }
                    Console.WriteLine("Complete");


                }
            }
            catch(Exception ex)
            {
                var Error = ex.Message;
            }
        }


        public static async void LlenaAlcaldias()
        {
            try
            {

                foreach (Records item in records.records)
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(AlcaldiaAPIUrl + item.fields.position_latitude + "," + item.fields.position_longitude);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var response = client.GetAsync(AlcaldiaAPIUrl + item.fields.position_latitude + "," + item.fields.position_longitude).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var rawResponse = readTask.GetAwaiter().GetResult();

                            //records = JsonSerializer.Deserialize<ClassMetrobus>(rawResponse);
                            ClassAlcaldia alcaldia = new ClassAlcaldia();

                            alcaldia = JsonSerializer.Deserialize<ClassAlcaldia>(rawResponse);

                            item.fields.AlcalciaId = alcaldia.Records[0].Fields.Cve_mun;
                        }
                    }


                }
            }
            catch(Exception ex)
            {
                var Error = ex.Message;
            }
        }



    }


}
