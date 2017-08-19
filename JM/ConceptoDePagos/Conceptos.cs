using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using JM.DB;
using System.Globalization;

namespace JM.ConceptoDePagos
{
    class Conceptos
    {
        public string ID { get; set; }
        public string Concepto { get; set; }
        public String Valor { get; set; }

       

           // var pre = Convert.ToInt32(prec).ToString("C", nfi);

        public void LlenarListadoConcepto(DataGridView data,List<Pago_Concepto> lista) 
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.CurrencyDecimalDigits = 2;

            using (var db = new PresupuestoEntities5()) 
            
            {
                foreach (var item in db.Pago_Concepto)
                {
                lista.Add(new Pago_Concepto { 
                valor=item.valor,
                idConceptoPago=item.idConceptoPago,
                Concepto=item.Concepto
                
                });
                }

                foreach (var item in lista)
                {
                    data.Rows.Add
                  (
                  Convert.ToString(item.idConceptoPago),
                  item.Concepto,
                    Convert.ToDouble(item.valor).ToString("C", nfi)

                  );
                    
                }
            }
        }

        public void FiltrarListadoConcepto(DataGridView data, string id,List<Pago_Concepto> lista) 
        {
            data.Rows.Clear();
            lista.Clear();

            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.CurrencyDecimalDigits = 2;

            using (var db = new PresupuestoEntities5())
            {
                foreach (var item in  db.Filtrar_pago_concepto(id))
                {
                    lista.Add(new Pago_Concepto
                    {
                    Concepto=item.Concepto,
                    idConceptoPago=item.idConceptoPago,
                    valor=Convert.ToInt32(item.valor)
                    });
                }



                foreach (var item in lista)
                {

                    data.Rows.Add
                        (
                            item.idConceptoPago.ToString(),
                            item.Concepto,
                           Convert.ToInt32(item.valor).ToString("C",nfi)
                        );


                }
            }
        }
    }
}
