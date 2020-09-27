using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace ConsultaMetrobus.Clases
{
    public class ClassMetrobus
    {

        [JsonPropertyName("nhits")]
        public int nhits { get; set; }


        [JsonPropertyName("records")]
        public IList<Records> records { get; set; }
    }

    public class Records
    {
        [JsonPropertyName("datasetid")]
        public string datasetid { get; set; }

        [JsonPropertyName("recordid")]
        public string recordid { get; set; }

        [JsonPropertyName("fields")]
        public Fields fields { get; set; }

        [JsonPropertyName("geometry")]
        public Geometry geometry { get; set; }

        [JsonPropertyName("record_timestamp")]
        public DateTimeOffset record_timestamp { get; set; }

    }

    public class Geometry
    {
        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonPropertyName("coordinates")]
        public IList<double> coordinates { get; set; }
    }

    public class Fields
    {
        [JsonPropertyName("vehicle_id")]
        public string vehicle_id { get; set; }

        [JsonPropertyName("trip_start_date")]
        public string trip_start_date { get; set; }

        [JsonPropertyName("date_updated")]
        public string date_updated { get; set; }

        [JsonPropertyName("position_longitude")]
        public double position_longitude { get; set; }

        [JsonPropertyName("trip_schedule_relationship")]
        public int trip_schedule_relationship { get; set; }

        [JsonPropertyName("position_speed")]
        public int position_speed { get; set; }

        [JsonPropertyName("position_latitude")]
        public double position_latitude { get; set; }

        [JsonPropertyName("trip_route_id")]
        public string trip_route_id { get; set; }

        [JsonPropertyName("vehicle_label")]
        public string vehicle_label { get; set; }

        [JsonPropertyName("position_odometer")]
        public int position_odometer { get; set; }

        [JsonPropertyName("trip_id")]
        public string trip_id { get; set; }

        [JsonPropertyName("vehicle_current_status")]
        public int vehicle_current_status { get; set; }

        [JsonPropertyName("geographic_point")]
        public IList<double> geographic_point { get; set; }

        public string AlcalciaId { get; set; }
    }
}
