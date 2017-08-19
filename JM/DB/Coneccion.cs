using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM.DB
{
    class Coneccion
    {

        public void Conectar()
        {
            var conexion = "Data Source=JONATHAN\\SQLEXPRESS;Initial Catalog=Presupuesto;Integrated Security=True";

            SqlConnection cn = new SqlConnection(conexion);

            try
            {
                cn.Open();
                Console.WriteLine("Connection Open ! ");
                cn.Close();
                Console.ReadLine();
                var cmd = cn.CreateCommand();
                var hola = "hola";
                var si = 25;
                cmd.CommandText = "Insert into Comida(Descripcion,Precio) values (@De,@Pre)";

                cmd.Parameters.AddWithValue("@Pre", si);
                cmd.Parameters.AddWithValue("@De", hola);
                cmd.ExecuteNonQuery();


                cn.Close();
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not connect");
                Console.ReadLine();
            }

        }
    }
}