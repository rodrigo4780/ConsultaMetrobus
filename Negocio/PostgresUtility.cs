using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using ConsultaMetrobus.Clases;
using Npgsql;

namespace Negocio
{
    public class PostgresUtility
    {
        public static NpgsqlConnection creaConexion()
        {
            try
            {

                // crea la conexión 
                string host = Environment.GetEnvironmentVariable("host");

                if (host == null || host.Length == 0)
                {
                    host = "localhost";
                }

                Console.WriteLine(host);
                NpgsqlConnection conn = new NpgsqlConnection("Server=" + host + ";Port=5432;User Id=postgres;" +
                                        "Password=rodrigo;Database=postgres;");

                return conn;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public static DataTable Consulta(string query)
        {
            // Se crea la conexion.
            NpgsqlConnection conn = creaConexion();

            try
            {
                conn.Open();

                // Se crea el comando con el query enviado
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

                // Se ejecuta el query y se llena el dataReader
                NpgsqlDataReader dr = cmd.ExecuteReader();

                // while (dr.Read())
                //   Console.Write("{0}\n", dr[0]);

                //Se crea el datatable a llenar con la respuesta
                DataTable dt = new DataTable();

                //Se llena el datatable con el contenido del datareader
                dt.Load(dr);

                return dt;
            }
            finally
            {

                // Close connection
                conn.Close();
            }

            
        }


        public static void InsertaRegistrosMetrobus(ClassMetrobus classMetrobus)
        {
            //Se crea la conexión a la base de datos
            NpgsqlConnection conn = creaConexion();
            //Abrimos la conexión
            conn.Open();
            try
            {
                //Se guardaran en la Base de Datos cada uno de los registros enviados de la ubicacion de las unidades.
                foreach (Records item in classMetrobus.records)
                {
                    try
                    {
                        //Se crea el insert en base a los datos del registro.
                        string query = @"insert into records (record_id, record_alcaldia_id, vehicle_id, trip_start_date, date_updated, position_longitude, trip_schedule_relationship,
                                                    position_speed, position_latitude, trip_route_id, vehicle_label, position_odometer, trip_id, vehicle_current_status, record_timestamp)
                                 values('" + item.recordid + "', '" + item.fields.AlcalciaId + "', '" + item.fields.vehicle_id + "', '" + item.fields.trip_start_date + "', '" + item.fields.date_updated + "', " + item.fields.position_longitude + ", " + item.fields.trip_schedule_relationship + ","
                                         + item.fields.position_speed + "," + item.fields.position_latitude + ",'" + item.fields.trip_route_id + "', '" + item.fields.vehicle_label + "', " + item.fields.position_odometer + ", '" + item.fields.trip_id + "'," + item.fields.vehicle_current_status + ", '" + item.record_timestamp.ToString() + "')";
                        
                        //instanciamos el comando y asiganmos la conexión
                        NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

                        //Ejecutamos el comando
                        cmd.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    { var error = ex.Message; }
                }
            }
            finally
            {
                conn.Close();
            }
        }

        public static DataTable ConsultaAlcaldias()
        {
            // Se crea la conexion.
            NpgsqlConnection conn = creaConexion();

            try
            {
                conn.Open();

                // Se crea el comando con el query enviado
                NpgsqlCommand cmd = new NpgsqlCommand("Select * from alcaldias where alcaldia_id in (select record_alcaldia_id from records)", conn);

                // Se ejecuta el query y se llena el dataReader
                NpgsqlDataReader dr = cmd.ExecuteReader();

                // while (dr.Read())
                //   Console.Write("{0}\n", dr[0]);

                //Se crea el datatable a llenar con la respuesta
                DataTable dt = new DataTable();

                //Se llena el datatable con el contenido del datareader
                dt.Load(dr);

                return dt;
            }
            finally
            {

                // Close connection
                conn.Close();
            }
        }

        public static DataTable ConsultaAlcaldias(string id)
        {
            // Se crea la conexion.
            NpgsqlConnection conn = creaConexion();

            try
            {
                conn.Open();

                // Se crea el comando con el query enviado
                NpgsqlCommand cmd = new NpgsqlCommand("select * from alcaldias, records  where alcaldia_id = record_alcaldia_id and record_alcaldia_id = lpad('"+id+"',3,'0')", conn);

                // Se ejecuta el query y se llena el dataReader
                NpgsqlDataReader dr = cmd.ExecuteReader();

                // while (dr.Read())
                //   Console.Write("{0}\n", dr[0]);

                //Se crea el datatable a llenar con la respuesta
                DataTable dt = new DataTable();

                //Se llena el datatable con el contenido del datareader
                dt.Load(dr);

                return dt;
            }
            finally
            {

                // Close connection
                conn.Close();
            }
        }

        public static DataTable ConsultaUnidades()
        {
            // Se crea la conexion.
            NpgsqlConnection conn = creaConexion();

            try
            {
                conn.Open();

                // Se crea el comando con el query enviado
                NpgsqlCommand cmd = new NpgsqlCommand("select vehicle_id from records group by vehicle_id", conn);

                // Se ejecuta el query y se llena el dataReader
                NpgsqlDataReader dr = cmd.ExecuteReader();

                //Se crea el datatable a llenar con la respuesta
                DataTable dt = new DataTable();

                //Se llena el datatable con el contenido del datareader
                dt.Load(dr);

                return dt;
            }
            finally
            {

                // Close connection
                conn.Close();
            }
        }

        public static DataTable ConsultaUnidades(int id)
        {
            // Se crea la conexion.
            NpgsqlConnection conn = creaConexion();

            try
            {
                conn.Open();

                // Se crea el comando con el query enviado
                NpgsqlCommand cmd = new NpgsqlCommand("select alcaldia_nombre, date_updated fecha from alcaldias, records where alcaldia_id = record_alcaldia_id and vehicle_id = '" + id+"'", conn);

                // Se ejecuta el query y se llena el dataReader
                NpgsqlDataReader dr = cmd.ExecuteReader();

                // while (dr.Read())
                //   Console.Write("{0}\n", dr[0]);

                //Se crea el datatable a llenar con la respuesta
                DataTable dt = new DataTable();

                //Se llena el datatable con el contenido del datareader
                dt.Load(dr);

                return dt;
            }
            finally
            {

                // Close connection
                conn.Close();
            }
        }

    }
}
