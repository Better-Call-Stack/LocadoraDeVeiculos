using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloRelatorio.ModuloLocacao;
using System;
using System.IO;

namespace LocadoraDeVeiculos.Infra.Pdf.ITextSharp.ModuloLocacao
{
    public class GeradorRelatorioLocacaoItextSharp : IGeradorRelatorioLocacao
    {
        #region Escrita do pdf locação
        public void GerarRelatorioPdfLocacao(Locacao locacao)
        {
            string localDoArquivo = Environment.CurrentDirectory + @"\contratos\";

            if (Directory.Exists(localDoArquivo) == false)
                Directory.CreateDirectory(localDoArquivo);

            var nomeArquivo = localDoArquivo + GerarNomeArquivoPdfLocacao(locacao);

            FileStream arquivoContrato = new FileStream(nomeArquivo, FileMode.Create, FileAccess.ReadWrite);

            var doc = new Document(PageSize.A4);

            PdfWriter escritorPdf = PdfWriter.GetInstance(doc, arquivoContrato);

            Paragraph pulaLinha = new Paragraph("\n");
            Font fonteNormal = FontFactory.GetFont("Arial", 12, Font.NORMAL, new BaseColor(0, 0, 0));
            Font fonteNegrito = FontFactory.GetFont("Arial", 12, Font.BOLD, new BaseColor(0, 0, 0));
            Chunk linebreak = new Chunk(new LineSeparator(2f, 100f, new BaseColor(192, 192, 192), Element.ALIGN_CENTER, -1));


            Image logo = Image.GetInstance(Environment.CurrentDirectory + @"\iconeLocadora.png");
            logo.ScaleToFit(70f, 60f);
            logo.Alignment = Element.ALIGN_LEFT;
            logo.Alignment = Element.ALIGN_TOP;


            Paragraph titulo = new Paragraph("Informações de Locação\n\n\n", FontFactory.GetFont("Arial", 14, Font.BOLD, new BaseColor(0, 0, 0)));
            titulo.Alignment = Element.ALIGN_CENTER;
            
            Paragraph tituloSecaoCliente = new Paragraph("Informações do Cliente\n", fonteNegrito);
            Phrase cliente = null;

            if (locacao.Cliente.CPF != null)
                cliente = new Phrase($"Nome: {locacao.Condutor.Cliente.Nome}\nCPF: {locacao.Condutor.Cliente.CPF}\n", fonteNormal);
            
            else if(locacao.Cliente.CNPJ != null)
                cliente = new Phrase($"Nome: {locacao.Condutor.Cliente.Nome}\nCNPJ: {locacao.Cliente.CNPJ}\n", fonteNormal);
            
            Paragraph tituloSecaoCondutor = new Paragraph("Informações do Condutor\n", fonteNegrito);

            Phrase nomeCondutor = new Phrase($"Nome: {locacao.Condutor.Nome}\n", fonteNormal);

            Paragraph tituloDocumentosCondutor = new Paragraph("Documentos\n", fonteNegrito);
            Phrase textoDocumentosCondutor = new Phrase(
                $"CPF: {locacao.Condutor.CPF}\n" +
                $"CNH: {locacao.Condutor.CNH}\n" +
                $"Validade CNH: {locacao.Condutor.ValidadeCNH.ToShortDateString()}\n",
                fonteNormal);

            Paragraph tituloContatoCondutor = new Paragraph("Contato:\n", fonteNegrito);
            Phrase textoContatoCondutor = new Phrase(
                $"Email: {locacao.Condutor.Email}\n", fonteNormal);

            Paragraph tituloEnderecoCondutor = new Paragraph("Endereço:", fonteNegrito);
            Phrase textoEnderecoCondutor = new Phrase(
                $"{locacao.Condutor.Endereco}", fonteNormal);

            Paragraph tituloVeiculo = new Paragraph("Veículo contratado\n", fonteNegrito);

            Phrase textoVeiculo = new Phrase(
            $"Fabricante: {locacao.Veiculo.Fabricante}\n" +
            $"Modelo: {locacao.Veiculo.Modelo}\n" +
            $"Ano: {locacao.Veiculo.Ano}\n" +
            $"Cor: {locacao.Veiculo.Cor}\n" +
            $"Placa: {locacao.Veiculo.Placa}\n" +
            $"Combustível: {locacao.Veiculo.TipoCombustivel}\n" +
            $"Capacidade do Tanque: {locacao.Veiculo.CapacidadeTanque}\n" +
            $"Quilometragem: {locacao.Veiculo.KmPercorrido}\n" +
            $"Grupo: {locacao.Veiculo.Grupo.Nome}\n", fonteNormal);

            PdfPTable tabelaDatas = new PdfPTable(2);

            PdfPCell cell = new PdfPCell(new Phrase("Datas do contrato: ", fonteNegrito));
            cell.Colspan = 2;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            tabelaDatas.AddCell(cell);

            tabelaDatas.AddCell(new Phrase("Data da locação", fonteNegrito));
            tabelaDatas.AddCell(new Phrase("Data de devolução prevista", fonteNegrito));


            tabelaDatas.AddCell(new Phrase($"{locacao.DataLocacao.ToShortDateString()}\n", fonteNormal));
            tabelaDatas.AddCell(new Phrase($"{locacao.PrevisaoDevolucao.ToShortDateString()}\n", fonteNormal));

            PdfPTable tabelaPlanoCobrancaDiario = new PdfPTable(2);
            PdfPTable tabelaPlanoCobrancaKmControlado = new PdfPTable(3);
            PdfPTable tabelaPlanoCobrancaKmLivre = new PdfPTable(1);

            if (locacao.PlanoSelecionado == "Diário")
            {
                PdfPCell cellPlanoCobrancaDiario1 = new PdfPCell(new Phrase("Plano Diário", fonteNegrito));
                cellPlanoCobrancaDiario1.Colspan = 2;
                cellPlanoCobrancaDiario1.HorizontalAlignment = Element.ALIGN_CENTER;
                tabelaPlanoCobrancaDiario.AddCell(cellPlanoCobrancaDiario1);

                tabelaPlanoCobrancaDiario.AddCell(new Phrase($"Valor por dia: R$ {locacao.PlanoDeCobranca.ValorPorDia_PlanoDiario}", fonteNormal));
                tabelaPlanoCobrancaDiario.AddCell(new Phrase($"Valor por Km: R$ {locacao.PlanoDeCobranca.ValorKmRodado_PlanoDiario}", fonteNormal));

            }

            else if (locacao.PlanoSelecionado == "Km Controlado")
            {
                PdfPCell cellPlanoCobrancaKmControladoHeader = new PdfPCell(new Phrase("Plano Quilometragem Limitada", fonteNegrito));
                cellPlanoCobrancaKmControladoHeader.Colspan = 3;
                cellPlanoCobrancaKmControladoHeader.HorizontalAlignment = Element.ALIGN_CENTER;
                tabelaPlanoCobrancaKmControlado.AddCell(cellPlanoCobrancaKmControladoHeader);

                tabelaPlanoCobrancaKmControlado.AddCell(new Phrase($"Valor por dia: R$ {locacao.PlanoDeCobranca.ValorPorDia_PlanoKmControlado}", fonteNormal));
                tabelaPlanoCobrancaKmControlado.AddCell(new Phrase($"Quilometragem inclusa: {locacao.PlanoDeCobranca.KmLivreIncluso_PlanoKmControlado}", fonteNormal));
                tabelaPlanoCobrancaKmControlado.AddCell(new Phrase($"Valor por Km excedente: R$ {locacao.PlanoDeCobranca.ValorKmRodado_PlanoKmControlado}", fonteNormal));

            }

            else if (locacao.PlanoSelecionado == "Km Livre")
            {
                PdfPCell cellPlanoCobrancaKmLivreHeader = new PdfPCell(new Phrase("Plano Quilometragem Livre", fonteNegrito));
                cellPlanoCobrancaKmLivreHeader.HorizontalAlignment = Element.ALIGN_CENTER;
                tabelaPlanoCobrancaKmLivre.AddCell(cellPlanoCobrancaKmLivreHeader);

                tabelaPlanoCobrancaKmLivre.AddCell(new Phrase($"Valor por dia: R$ {locacao.PlanoDeCobranca.ValorPorDia_PlanoKmLivre}", fonteNormal));

            }

            PdfPTable tabelaTaxas = new PdfPTable(3);

            if (locacao.Taxas.Count > 0)
            {
                PdfPCell cell1 = new PdfPCell(new Phrase("Serviços adicionais", fonteNegrito));
                cell1.Colspan = 3;
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                tabelaTaxas.AddCell(cell1);

                tabelaTaxas.AddCell(new Phrase("Serviço", fonteNegrito));
                tabelaTaxas.AddCell(new Phrase("Valor", fonteNegrito));
                tabelaTaxas.AddCell(new Phrase("Tipo de Cálculo", fonteNegrito));

                foreach (var t in locacao.Taxas)
                {
                    tabelaTaxas.AddCell(new Phrase($"{t.Nome}", fonteNormal));
                    tabelaTaxas.AddCell(new Phrase($"{t.Valor}", fonteNormal));
                    tabelaTaxas.AddCell(new Phrase($"{t.Tipo}", fonteNormal));
                 
                }
            }

            Paragraph avisoSemTaxa = new Paragraph("Nenhum serviço adicional foi contratado.", fonteNegrito);

            Paragraph totalPorDia = new Paragraph($"Valor previsto por dia: R${locacao.ValorDiario}\n", fonteNegrito);
            totalPorDia.Alignment = Element.ALIGN_CENTER;
            Paragraph totalPrevisto = new Paragraph($"Valor total previsto: R${locacao.Subtotal}\n", fonteNegrito);
            totalPrevisto.Alignment = Element.ALIGN_CENTER;

            Paragraph aviso = new Paragraph("Os valores acima informados são uma previsão conforme o plano solicitado pelo cliente e podem sofrer" +
                                               " alteração com a contratação de novos serviços e/ou a necessidade de cobrança de taxas adicionais e multa.", fonteNormal);
            
            var dataEmissao = new Paragraph("Emitido em: " + DateTime.Now, fonteNormal);
            dataEmissao.Alignment = Element.ALIGN_BOTTOM;
            dataEmissao.Alignment = Element.ALIGN_RIGHT;

            #endregion

        #region Passagem para o Pdf locação.

            doc.Open();

            doc.Add(logo);
            doc.Add(titulo);
            doc.Add(pulaLinha);
            doc.Add(tituloSecaoCliente);
            doc.Add(cliente);
            doc.Add(pulaLinha);
            doc.Add(linebreak);
            doc.Add(pulaLinha);
            doc.Add(tituloSecaoCondutor);
            doc.Add(nomeCondutor);
            doc.Add(tituloDocumentosCondutor);
            doc.Add(textoDocumentosCondutor);
            doc.Add(tituloContatoCondutor);
            doc.Add(textoContatoCondutor);
            doc.Add(tituloEnderecoCondutor);
            doc.Add(textoEnderecoCondutor);
            doc.Add(pulaLinha);
            doc.Add(linebreak);
            doc.Add(pulaLinha);
            doc.Add(tituloVeiculo);
            doc.Add(textoVeiculo);
            doc.Add(linebreak);
            doc.Add(pulaLinha);
            doc.Add(tabelaDatas);
            doc.Add(pulaLinha);

            if (locacao.PlanoSelecionado == "Diário")
                doc.Add(tabelaPlanoCobrancaDiario);

            else if (locacao.PlanoSelecionado == "Km Controlado")
                doc.Add(tabelaPlanoCobrancaKmControlado);

            else if (locacao.PlanoSelecionado == "Livre")
                doc.Add(tabelaPlanoCobrancaKmLivre);

            doc.Add(pulaLinha);

            if (locacao.Taxas.Count > 0)
                doc.Add(tabelaTaxas);

            else
                doc.Add(avisoSemTaxa);

            doc.Add(pulaLinha);
            doc.Add(totalPorDia);
            doc.Add(totalPrevisto);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);
            doc.Add(aviso);
            doc.Add(pulaLinha);
            doc.Add(pulaLinha);
            doc.Add(dataEmissao);

            doc.Close();

            System.Diagnostics.Process.Start(nomeArquivo);

        }
        #endregion


        #region Nomes dos arquivos.

        public string GerarNomeArquivoPdfLocacao(Locacao locacao)
        {
            string nomeArquivo = "";

            nomeArquivo = $"relatorio-locacao-" + locacao.Cliente.Nome + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";

            return nomeArquivo;
        }

        #endregion
    }

}

