using iTextSharp.text;
using iTextSharp.text.pdf;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloRelatorio;
using System;
using System.IO;

namespace LocadoraDeVeiculos.Infra.Pdf.ITextSharp.ModuloLocacao
{
    public class GeradorRelatorioLocacaoItextSharp : IGeradorRelatorio
    {

        public void GerarRelatorioPdf()
        {
            string nomeArquivo = Environment.CurrentDirectory + @"\contratos\";

            FileStream arquivoContrato = new FileStream(nomeArquivo, FileMode.Create, FileAccess.Read);

            Document doc = new Document(PageSize.A4);

            PdfWriter escritorPdf = PdfWriter.GetInstance(doc, arquivoContrato);

            Image logo = Image.GetInstance(Environment.CurrentDirectory + @"\iconeLocadora.png");
            logo.ScaleToFit(140f, 120f);
            logo.Alignment = Element.ALIGN_LEFT;

            string dados = "";

            Paragraph paragrafo1 = new (dados, new Font(Font.NORMAL, 14, (int)System.Drawing.FontStyle.Bold));

            paragrafo1.Alignment = Element.ALIGN_RIGHT;
            paragrafo1.Add("TESTE\n");
            paragrafo1.Add("Curso de C#");

            Paragraph paragrafo2 = new(dados, new Font(Font.NORMAL, 14, (int)System.Drawing.FontStyle.Italic));
            paragrafo1.Alignment = Element.ALIGN_LEFT;
            string texto = "Texto parágrafo 2.";
            paragrafo2.Add(texto);


            doc.Open();
            doc.Add(logo);
            doc.Add(paragrafo1);
            doc.Add(paragrafo2);
            doc.Close();

        }
    }
}
