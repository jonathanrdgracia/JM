using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
namespace JM
{
    class PDF
    {
        public void prueba() 
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 34);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Text.pdf", FileMode.Create));
            doc.Open();// open document to write

            //Write something
            Paragraph paragraph = new Paragraph("Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años, sino que tambien ingresó como texto de relleno en documentos electrónicos, quedando esencialmente igual al original. Fue popularizado en los 60s con la creación de las hojas  las cuales contenian pasajes de Lorem Ipsum, y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum.");
            doc.Add(paragraph);// now add the above the usying diferent classs to our PDF document
            doc.Close();
        }
    }
}
