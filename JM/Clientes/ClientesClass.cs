using JM.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JM.Clientes
{
    class ClientesClass
    {
        public void FiltrarClientesActivos(string query, DataGridView grilla) 
        {
            grilla.Rows.Clear();
            using (var db = new PresupuestoEntities5()) 
            {
                var w="%"+query+"%";
                foreach (var item in db.SP_FiltrarClienteActivo(w).OrderByDescending(c=>c.id))
	            {
                    grilla.Rows.Add
                        (
                            "00"+item.id,
                            item.Nombre,
                            item.Telefono,
                            item.TipoCliente
                        );
	            }
            
            }
        
        }
        public void LlenarGridClientesActivos(DataGridView grilla)
        {
            using (var db = new PresupuestoEntities5())

            {
                foreach (var item in db.Clientes.Where(c=>c.Estado==1).OrderByDescending(c=>c.id))
                {
                    grilla.Rows.Add(
                        "00"+item.id,
                        item.Nombre,
                        item.Telefono,
                        item.TipoCliente
                        );
                }
            }

        }
    }
}
