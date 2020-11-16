using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//IMPORTAR LIBRERIAS
using System.Data;
using System.Data.SqlClient;
using yo.Models;

namespace yo.Controllers
{
    public class ClientesDAO
    {
        string CAD_CN = "server=.;database=northwind;user id=sa;password=sql;";


        public List<listar_clientes> ListarClientes()
        {
            List<listar_clientes> lista = new List<listar_clientes>();

            SqlConnection cn = new SqlConnection(CAD_CN);
            cn.Open();

            SqlCommand cmd = new SqlCommand("listar_clientes",cn);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader lector = cmd.ExecuteReader();

            while(lector.Read())
            {
                listar_clientes x = new listar_clientes();
                x.customerid = lector["customerid"].ToString();
                x.companyname = lector.GetString(1);

                lista.Add(x);
            }
            lector.Close();


            cn.Close();
            return lista;
        }
        
        
        public List<ordenes_por_cliente> OrdenesPorCliente(string cod)
        {
            List<ordenes_por_cliente> lista = new List<ordenes_por_cliente>();

            SqlConnection cn = new SqlConnection(CAD_CN);
            cn.Open();

            SqlCommand cmd = new SqlCommand("ordenes_por_cliente", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codigo", cod);
            

            SqlDataReader lector = cmd.ExecuteReader();

            while(lector.Read())
            {
                ordenes_por_cliente obj = new ordenes_por_cliente();
                obj.orderid = Convert.ToInt32(lector["orderid"]);
                obj.orderdate = Convert.ToDateTime(lector["orderdate"]);
                obj.employeeid = Convert.ToInt32(lector["employeeid"]);

                lista.Add(obj);
            }
            lector.Close();
            cn.Close();
            return lista;
            
        }


        public List<ordenes_por_fecha> OrdenesPorFecha(DateTime fecha)
        {
            List<ordenes_por_fecha> lista = new List<ordenes_por_fecha>();

            SqlDataAdapter adap = new SqlDataAdapter("ordenes_por_fecha", CAD_CN);
            //adap.SelectComand => Es uno de los 4 sqlcommand del dataadapter

            adap.SelectCommand.CommandType = CommandType.StoredProcedure;
            adap.SelectCommand.Parameters.AddWithValue("@fecha", fecha);

            DataTable tabla = new DataTable(); //POBLAR LAS FILAS DEL RESULTADO DEL PROC. ALMACENADO DEL DATAPDATER AL DATABLE
            adap.Fill(tabla);

            //UNA FILA DEL DATATABLE ES UN DATAROW
            foreach (DataRow fila in tabla.Rows)
            {
                ordenes_por_fecha x = new ordenes_por_fecha();
                x.orderid = Convert.ToInt32(fila["orderid"]);
                x.orderdate = Convert.ToDateTime(fila["orderdate"]);
                x.employeeid = Convert.ToInt32(fila["employeeid"]);

                lista.Add(x);
            }
            return lista;
        }


    }
}