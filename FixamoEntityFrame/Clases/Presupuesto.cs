using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
//
using System.util;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
//
using System.Globalization;

namespace FixamoEntityFrame.Clases
{
    public class Presupuesto
    {
        //ip fixamo 192.168.1.74
        private readonly FixamoEntityFrame.ObservableListSource<LineaPresupuesto> _lineasPresupuesto =
                    new ObservableListSource<LineaPresupuesto>();

        public int PresupuestoId { get; set; }
        public int NroPresupuesto { get; set; }
        public DateTime FechaPresupuesto { get; set; }
        public string NroFactura { get; set; }
        public DateTime FechaCirugia { get; set; }
        public string Prestador { get; set; }
        public string MantenimientoDeOferta { get; set; }
        public bool Habilitado { get; set; } = true;

        public int? PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }

        public int? DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        public int? CondicionPagoId { get; set; }
        public virtual CondicionPago CondicionPago { get; set; }

        public int? PlazoEntregaId { get; set; }
        public virtual PlazoEntrega PlazoEntrega { get; set; }

        public int SolicitanteId { get; set; }
        public virtual Solicitante Solicitante { get; set; }

        public int? LugarCirugiaId { get; set; }
        public virtual LugarCirugia LugarCirugia{ get; set; }

        public virtual ObservableListSource<LineaPresupuesto> LineasPresupuesto { get { return _lineasPresupuesto; } }

        public int? UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        private string MonthName(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }

        public void imprimir()
        {
            string carpeta = @"c:\Presupuesto";
            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);
            string nombreArchivo = "presupuesto";
            Document doc = new Document(iTextSharp.text.PageSize.A4);
            doc.AddKeywords("pdf, PdfWriter; Documento; iTextSharp");
            string rut = carpeta + "\\" + nombreArchivo + ".pdf";
            //
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream
                    (rut, FileMode.Create));
                //
                iTextSharp.text.Font tipoFecha = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN
                    , 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                iTextSharp.text.Font tipoTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA
                    , 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                iTextSharp.text.Font tipoTitulo2 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA
                    , 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                iTextSharp.text.Font tipoTituloLista = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA
                    , 8, iTextSharp.text.Font.BOLD, BaseColor.BLUE);
                iTextSharp.text.Font tipoDetalleLista = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA
                    , 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                iTextSharp.text.Font tipoTotal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA
                    , 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                iTextSharp.text.Font tipoFooterTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA
                    , 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                //
                doc.AddTitle("Presupuesto");
                doc.AddCreator("Fixamo");
                doc.Open();
                //
                iTextSharp.text.Image logo;
                logo = iTextSharp.text.Image.GetInstance("logofixamo.png");
                logo.ScalePercent(50f);
                PdfPTable tblLogo = new PdfPTable(1);
                tblLogo.WidthPercentage = 100;
                tblLogo.WidthPercentage = 100;
                PdfPCell img = new PdfPCell(logo);
                img.BorderWidth = 0;
                tblLogo.AddCell(img);
                doc.Add(tblLogo);
                //
                PdfPTable tblfechaLugar = new PdfPTable(2);
                tblfechaLugar.WidthPercentage = 100;
                PdfPCell cell1 = new PdfPCell(new Paragraph("Giribone 1259 Cap. Fed\nC.P. 1427"));
                cell1.BorderWidth = 0;
                PdfPCell cell2 = new PdfPCell(new Paragraph("Buenos Aires, " +this.FechaPresupuesto.Day.ToString()+" de "+this.MonthName(this.FechaPresupuesto.Month)+" "+this.FechaPresupuesto.Year.ToString(),tipoFecha));
                cell2.BorderWidth = 0;
                cell2.HorizontalAlignment = Element.ALIGN_RIGHT;
                tblfechaLugar.AddCell(cell1);
                tblfechaLugar.AddCell(cell2);
                doc.Add(tblfechaLugar);
                //
                doc.Add(new Paragraph("\n"));
                //
                PdfPTable tblTitulo = new PdfPTable(3);
                tblLogo.WidthPercentage = 100;
                tblLogo.WidthPercentage = 100;
                float[] medidastblTitulo = { 33f,34f, 33f };
                tblTitulo.SetWidths(medidastblTitulo);
                PdfPCell cellTitulo1 = new PdfPCell(new Paragraph(""));
                cellTitulo1.BorderWidth = 0;
                tblTitulo.AddCell(cellTitulo1);
                PdfPCell cellTitulo2 = new PdfPCell(new Paragraph("PRESUPUESTO N° "+this.NroPresupuesto.ToString(), tipoTitulo));
                cellTitulo2.BorderWidth = 0;
                cellTitulo2.BorderWidthBottom = 1;
                cellTitulo2.HorizontalAlignment = Element.ALIGN_CENTER;
                tblTitulo.AddCell(cellTitulo2);
                PdfPCell cellTitulo3 = new PdfPCell(new Paragraph(""));
                cellTitulo3.BorderWidth = 0;
                tblTitulo.AddCell(cellTitulo3);
                doc.Add(tblTitulo);
                //
                doc.Add(new Paragraph("\n"));
                //
                PdfPTable tabla = new PdfPTable(2);
                tabla.WidthPercentage = 100;
                tabla.DefaultCell.BorderWidth = 0;

                cell1 = new PdfPCell(new Paragraph("SOLICITANTE: " + this.Solicitante.Nombre.ToUpper(), tipoTitulo2));
                cell1.BorderWidth = 0;
                tabla.AddCell(cell1);

                cell1 = new PdfPCell(new Paragraph(String.Format("DR: {0}", (this.Doctor != null) ? this.Doctor.Nombre.ToUpper() : String.Empty), tipoTitulo2));
                cell1.BorderWidth = 0;
                tabla.AddCell(cell1);

                cell1 = new PdfPCell(new Paragraph("ATTE: " + this.Solicitante.NombreOficina.ToUpper(), tipoTitulo2));
                cell1.BorderWidth = 0;
                tabla.AddCell(cell1);

                cell1 = new PdfPCell(new Paragraph(String.Format("PACIENTE: {0}", (this.Paciente != null) ? this.Paciente.Nombre.ToUpper() : String.Empty), tipoTitulo2));
                cell1.BorderWidth = 0;
                tabla.AddCell(cell1);

                cell1 = new PdfPCell(new Paragraph(String.Format("EMAIL: {0}", String.IsNullOrEmpty( this.Solicitante.Email) ? String.Empty : this.Solicitante.Email.ToUpper()), tipoTitulo2));
                cell1.BorderWidth = 0;
                tabla.AddCell(cell1);

                cell1 = new PdfPCell(new Paragraph(String.Format("NUMERO DE AFILIADO: {0}", (this.Paciente != null && !String.IsNullOrEmpty(this.Paciente.NroAfiliado)) ? this.Paciente.NroAfiliado : String.Empty), tipoTitulo2));
                cell1.BorderWidth = 0;
                tabla.AddCell(cell1);

                cell1 = new PdfPCell(new Paragraph(String.Format("TEL/FAX: {0}", String.IsNullOrEmpty(this.Solicitante.Telefono) ? String.Empty : this.Solicitante.Telefono.ToUpper()), tipoTitulo2));
                cell1.BorderWidth = 0;
                tabla.AddCell(cell1);

                cell1 = new PdfPCell(new Paragraph(String.Format("LUGAR: {0}", (this.LugarCirugia != null) ? this.LugarCirugia.Nombre.ToUpper() : String.Empty), tipoTitulo2));
                cell1.BorderWidth = 0;
                tabla.AddCell(cell1);

                cell1 = new PdfPCell(new Paragraph(String.Format("CUIT: {0}", String.IsNullOrEmpty(this.Solicitante.Cuit) ? String.Empty : this.Solicitante.Cuit), tipoTitulo2));
                cell1.BorderWidth = 0;
                tabla.AddCell(cell1);

                cell1 = new PdfPCell(new Paragraph(String.Format("FECHA CX: {0}", (this.FechaCirugia != default(DateTime)) ? this.FechaCirugia.Date.ToString().Substring(0, 9) : String.Empty), tipoTitulo2));
                cell1.BorderWidth = 0;
                tabla.AddCell(cell1);

                cell1 = new PdfPCell(new Paragraph(String.Format("RAZON SOCIAL: {0}", String.IsNullOrEmpty(this.Solicitante.RazonSoc) ? String.Empty : this.Solicitante.RazonSoc.ToUpper()), tipoTitulo2));
                cell1.BorderWidth = 0;
                tabla.AddCell(cell1);
                tabla.CompleteRow();
                doc.Add(tabla);
                /*doc.Add(new Paragraph("SOLICITANTE: "+this.Solicitante.Nombre.ToUpper(), tipoTitulo2));
                //doc.Add(new Paragraph("ATTE: " + this.Solicitante.NombreOficina.ToUpper(), tipoTitulo2));
                if(!(string.IsNullOrEmpty(this.Solicitante.Email)))
                    doc.Add(new Paragraph(this.Solicitante.Email.ToUpper(), tipoTitulo2));
                if (!(string.IsNullOrEmpty(this.Solicitante.Telefono)))
                    doc.Add(new Paragraph("TEL/FAX: "+this.Solicitante.Telefono.ToUpper(), tipoTitulo2));
                if (!(string.IsNullOrEmpty(this.Solicitante.Cuit)))
                    doc.Add(new Paragraph("CUIT: " + this.Solicitante.Cuit, tipoTitulo2));
                if (!(string.IsNullOrEmpty(this.Solicitante.RazonSoc)))
                    doc.Add(new Paragraph("RAZON SOCIAL: " + this.Solicitante.RazonSoc, tipoTitulo2));
                if (this.Doctor != null)
                {
                    doc.Add(new Paragraph("DR: " + this.Doctor.Nombre.ToUpper(), tipoTitulo2));
                }
                if (this.Paciente != null)
                {
                    doc.Add(new Paragraph("PACIENTE: " + this.Paciente.Nombre.ToUpper(), tipoTitulo2));
                    if (!(string.IsNullOrEmpty(this.Paciente.NroAfiliado)))
                        doc.Add(new Paragraph("AFILIADO: " + this.Paciente.NroAfiliado.ToUpper(), tipoTitulo2));
                    /*else
                        doc.Add(new Paragraph("\n", tipoTitulo2));
                }
                if (this.LugarCirugia != null)   
                    doc.Add(new Paragraph("LUGAR: " + this.LugarCirugia.Nombre.ToUpper(), tipoTitulo2));
                if (this.FechaCirugia != default(DateTime))
                    doc.Add(new Paragraph("FECHA CX: " + this.FechaCirugia.Date.ToString().Substring(0,9), tipoTitulo2));
                */
                doc.Add(new Paragraph("\n"));
                //
                double totalPresupuesto = 0;
                int i = 1;
                PdfPTable tblLista = new PdfPTable(5);
                tblLista.WidthPercentage = 100;
                float[] medidastblLista = { 6f, 8f, 56f,15f,15f };
                tblLista.SetWidths(medidastblLista);
                cell1 = new PdfPCell(new Paragraph("REN", tipoTituloLista));
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                cell1.BackgroundColor = BaseColor.LIGHT_GRAY;
                tblLista.AddCell(cell1);
                cell1 = new PdfPCell(new Paragraph("CANT", tipoTituloLista));
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                cell1.BackgroundColor = BaseColor.LIGHT_GRAY;
                tblLista.AddCell(cell1);
                cell1 = new PdfPCell(new Paragraph("DESCRIPCIÓN", tipoTituloLista));
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                cell1.BackgroundColor = BaseColor.LIGHT_GRAY;
                tblLista.AddCell(cell1);
                cell1 = new PdfPCell(new Paragraph("UNITARIO", tipoTituloLista));
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                cell1.BackgroundColor = BaseColor.LIGHT_GRAY;
                tblLista.AddCell(cell1);
                cell1 = new PdfPCell(new Paragraph("TOTAL", tipoTituloLista));
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                cell1.BackgroundColor = BaseColor.LIGHT_GRAY;
                tblLista.AddCell(cell1);
                foreach (Clases.LineaPresupuesto lineaPresupuesto in this.LineasPresupuesto)
                {
                    double valor;
                    double iva;
                    if (this.Solicitante.Exento)
                        valor = lineaPresupuesto.Precio;
                    else
                    {
                        iva = (21 * lineaPresupuesto.Precio) / 100;
                        valor = lineaPresupuesto.Precio + iva;
                    }
                    cell1 = new PdfPCell(new Paragraph(i.ToString(), tipoDetalleLista));
                    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                    tblLista.AddCell(cell1);
                    cell1 = new PdfPCell(new Paragraph(lineaPresupuesto.Cantidad.ToString(), tipoDetalleLista));
                    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                    tblLista.AddCell(cell1);
                    cell1 = new PdfPCell(new Paragraph(lineaPresupuesto.Descripcion.ToUpper(), tipoDetalleLista));
                    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell1.FixedHeight = (320/this.LineasPresupuesto.Count);
                    //cell1.PaddingBottom = 35;
                    tblLista.AddCell(cell1);
                    cell1 = new PdfPCell(new Paragraph("$ "+Math.Round(valor/lineaPresupuesto.Cantidad,2).ToString(), tipoDetalleLista));
                    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                    tblLista.AddCell(cell1);
                    cell1 = new PdfPCell(new Paragraph("$ "+valor.ToString(), tipoDetalleLista));
                    cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                    tblLista.AddCell(cell1);
                    //
                    totalPresupuesto = totalPresupuesto + valor;
                    i = i + 1;
                }
                cell1 = new PdfPCell(new Paragraph("", tipoTituloLista));
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                cell1.BackgroundColor = BaseColor.LIGHT_GRAY;
                tblLista.AddCell(cell1);
                cell1 = new PdfPCell(new Paragraph("", tipoTituloLista));
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                cell1.BackgroundColor = BaseColor.LIGHT_GRAY;
                tblLista.AddCell(cell1);
                string leyenda;
                if (this.Solicitante.Exento)
                    leyenda = "(IVA EXENTO)";
                else
                    leyenda = "(IVA 21%)";
                cell1 = new PdfPCell(new Paragraph("TOTAL PRESUPUESTO "+leyenda, tipoTituloLista));
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                cell1.BackgroundColor = BaseColor.LIGHT_GRAY;
                tblLista.AddCell(cell1);
                cell1 = new PdfPCell(new Paragraph("", tipoTituloLista));
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                cell1.BackgroundColor = BaseColor.LIGHT_GRAY;
                tblLista.AddCell(cell1);
                cell1 = new PdfPCell(new Paragraph("$ "+Math.Round(totalPresupuesto,2).ToString(), tipoTituloLista));
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                cell1.BackgroundColor = BaseColor.LIGHT_GRAY;
                tblLista.AddCell(cell1);
                doc.Add(tblLista);
                //
                doc.Add(new Paragraph("SON PESOS: "+Convertidor.convertir_numero_a_letras(totalPresupuesto), tipoTotal));
                //
                doc.Add(new Paragraph("\n"));
                //
                PdfPTable tblFooterGral = new PdfPTable(2);
                tblFooterGral.WidthPercentage = 100;
                float[] medidastblFooterGral = { 50f, 50f };
                tblFooterGral.SetWidths(medidastblFooterGral);
                //
                PdfPTable tblFooter = new PdfPTable(2);
                tblFooter.WidthPercentage = 100;
                float[] medidastblFooter = { 40f , 60f };
                tblFooter.SetWidths(medidastblFooter);
                if(this.CondicionPago != null)
                {
                    cell1 = new PdfPCell(new Paragraph("Condicion de Pago: ", tipoFooterTitulo));
                    cell1.BorderWidth = 0;
                    tblFooter.AddCell(cell1);
                    cell1 = new PdfPCell(new Paragraph(this.CondicionPago.Nombre, tipoDetalleLista));
                    cell1.BorderWidth = 0;
                    tblFooter.AddCell(cell1);
                }
                if(this.PlazoEntrega != null)
                {
                    cell1 = new PdfPCell(new Paragraph("Plazo de Entrega: ", tipoFooterTitulo));
                    cell1.BorderWidth = 0;
                    tblFooter.AddCell(cell1);
                    cell1 = new PdfPCell(new Paragraph(this.PlazoEntrega.Nombre, tipoDetalleLista));
                    cell1.BorderWidth = 0;
                    tblFooter.AddCell(cell1);
                    //doc.Add(tblFooter);
                }
                if (!(string.IsNullOrEmpty(this.MantenimientoDeOferta)))
                {
                    cell1 = new PdfPCell(new Paragraph("Mantenimiento de Oferta: ", tipoFooterTitulo));
                    cell1.BorderWidth = 0;
                    tblFooter.AddCell(cell1);
                    cell1 = new PdfPCell(new Paragraph(this.MantenimientoDeOferta, tipoFooterTitulo));
                    cell1.BorderWidth = 0;
                    tblFooter.AddCell(cell1);
                }
                if (!(string.IsNullOrEmpty(this.Prestador)))
                {
                    cell1 = new PdfPCell(new Paragraph("Prestador N°: " + this.Prestador, tipoFooterTitulo));
                    cell1.BorderWidth = 0;
                    tblFooter.AddCell(cell1);
                    cell1 = new PdfPCell(new Paragraph(this.Prestador, tipoFooterTitulo));
                    cell1.BorderWidth = 0;
                    tblFooter.AddCell(cell1);
                }
                //
                cell1 = new PdfPCell(tblFooter);
                cell1.BorderWidth = 0;
                tblFooterGral.AddCell(cell1);
                //
                tblFooter = new PdfPTable(1);
                tblFooter.WidthPercentage = 100;
                cell1 = new PdfPCell(new Paragraph("Contacto: " + this.Usuario.Nombre, tipoFooterTitulo));
                cell1.BorderWidth = 0;
                tblFooter.AddCell(cell1);
                if (!(string.IsNullOrEmpty(this.Usuario.Email)))
                {
                    cell1 = new PdfPCell(new Paragraph("Mail: " + this.Usuario.Email, tipoFooterTitulo));
                    cell1.BorderWidth = 0;
                    tblFooter.AddCell(cell1);
                }
                if (!(string.IsNullOrEmpty(this.Usuario.Telefono)))
                {
                    cell1 = new PdfPCell(new Paragraph("Celular: " + this.Usuario.Telefono, tipoFooterTitulo));
                    cell1.BorderWidth = 0;
                    tblFooter.AddCell(cell1);
                }
                cell1 = new PdfPCell(new Paragraph("Oficina: 3528-1518 / 4554-7281", tipoFooterTitulo));
                cell1.BorderWidth = 0;
                tblFooter.AddCell(cell1);
                //
                cell1 = new PdfPCell(tblFooter);
                cell1.BorderWidth = 0;
                tblFooterGral.AddCell(cell1);
                //
                doc.Add(tblFooterGral);
                //
                doc.Add(new Paragraph("\n"));
                PdfPTable tblFooter2 = new PdfPTable(1);
                tblFooter2.WidthPercentage = 100;
                cell1 = new PdfPCell(new Paragraph("info@fixamo.com.ar", tipoFooterTitulo));
                cell1.BorderWidth = 0;
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                tblFooter2.AddCell(cell1);
                doc.Add(tblFooter2);
                //
                doc.Close();
                writer.Close();
                Process prc = new System.Diagnostics.Process();
                prc.StartInfo.FileName = rut;
                prc.Start();
            }
            catch (Exception e)
            {
                if (MessageBox.Show("Debe cerrar el PDF abierto que contiene el ultimo presupuesto. ¿Reintentar?", "Cerrar PDF", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.imprimir();
                }
            }
        }
    }
}

