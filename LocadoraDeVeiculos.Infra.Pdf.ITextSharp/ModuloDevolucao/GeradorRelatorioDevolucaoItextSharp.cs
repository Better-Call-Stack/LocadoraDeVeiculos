using iTextSharp.text;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using System;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using LocadoraDeVeiculos.Dominio.ModuloRelatorio.ModuloDevolucao;
using System.Diagnostics;

namespace LocadoraDeVeiculos.Infra.Pdf.ITextSharp.ModuloDevolucao
{
    public class GeradorRelatorioDevolucaoItextSharp : IGeradorRelatorioDevolucao
    {
        #region Escrita do pdf devolução.
        public void GerarRelatorioDevolucaoPDF(Devolucao devolucao)
        {
            string localDoArquivo = Environment.CurrentDirectory + @"\contratos\";

            if (Directory.Exists(localDoArquivo) == false)
                Directory.CreateDirectory(localDoArquivo);

            var nomeArquivo = localDoArquivo + GerarNomeArquivoPdfDevolucao(devolucao);

            FileStream arquivoContrato = new FileStream(nomeArquivo, FileMode.Create);

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


            Paragraph titulo = new Paragraph("Informações de Devolução\n\n\n", FontFactory.GetFont("Arial", 14, Font.BOLD, new BaseColor(0, 0, 0)));
            titulo.Alignment = Element.ALIGN_CENTER;

            Paragraph tituloSecaoCliente = new Paragraph("Informações do Cliente\n", fonteNegrito);
            Phrase cliente = null;

            if (devolucao.Locacao.Cliente.CPF != null)
                cliente = new Phrase($"Nome: {devolucao.Locacao.Condutor.Cliente.Nome}\nCPF: {devolucao.Locacao.Condutor.Cliente.CPF}\n", fonteNormal);

            else if (devolucao.Locacao.Cliente.CNPJ != null)
                cliente = new Phrase($"Nome: {devolucao.Locacao.Condutor.Cliente.Nome}\nCNPJ: {devolucao.Locacao.Cliente.CNPJ}\n", fonteNormal);

            Paragraph tituloSecaoCondutor = new Paragraph("Informações do Condutor\n", fonteNegrito);

            Phrase nomeCondutor = new Phrase($"Nome: {devolucao.Locacao.Condutor.Nome}\n", fonteNormal);

            Paragraph tituloDocumentosCondutor = new Paragraph("Documentos\n", fonteNegrito);
            Phrase textoDocumentosCondutor = new Phrase(
                $"CPF: {devolucao.Locacao.Condutor.CPF}\n" +
                $"CNH: {devolucao.Locacao.Condutor.CNH}\n" +
                $"Validade CNH: {devolucao.Locacao.Condutor.ValidadeCNH.ToShortDateString()}\n",
                fonteNormal);

            Paragraph tituloContatoCondutor = new Paragraph("Contato:\n", fonteNegrito);
            Phrase textoContatoCondutor = new Phrase(
                $"Email: {devolucao.Locacao.Condutor.Email}\n", fonteNormal);

            Paragraph tituloEnderecoCondutor = new Paragraph("Endereço:", fonteNegrito);
            Phrase textoEnderecoCondutor = new Phrase(
                $"{devolucao.Locacao.Condutor.Endereco}", fonteNormal);

            Paragraph tituloVeiculo = new Paragraph("Veículo contratado\n", fonteNegrito);

            Phrase textoVeiculo = new Phrase(
            $"Fabricante: {devolucao.Locacao.Veiculo.Fabricante}\n" +
            $"Modelo: {devolucao.Locacao.Veiculo.Modelo}\n" +
            $"Ano: {devolucao.Locacao.Veiculo.Ano}\n" +
            $"Cor: {devolucao.Locacao.Veiculo.Cor}\n" +
            $"Placa: {devolucao.Locacao.Veiculo.Placa}\n" +
            $"Combustível: {devolucao.Locacao.Veiculo.TipoCombustivel}\n" +
            $"Capacidade do Tanque: {devolucao.Locacao.Veiculo.CapacidadeTanque}\n" +
            $"Quilometragem na data de contratação: {devolucao.Locacao.Veiculo.KmPercorrido}\n");


            PdfPTable tabelaDatas = new PdfPTable(3);

            PdfPCell cell = new PdfPCell(new Phrase("Datas do contrato: ", fonteNegrito));
            cell.Colspan = 3;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            tabelaDatas.AddCell(cell);

            tabelaDatas.AddCell(new Phrase("Data da locação", fonteNegrito));
            tabelaDatas.AddCell(new Phrase("Data de devolução prevista", fonteNegrito));
            tabelaDatas.AddCell(new Phrase("Devolução feita no dia", fonteNegrito));


            tabelaDatas.AddCell(new Phrase($"{devolucao.Locacao.DataLocacao.ToShortDateString()}\n", fonteNormal));
            tabelaDatas.AddCell(new Phrase($"{devolucao.Locacao.PrevisaoDevolucao.ToShortDateString()}\n", fonteNormal));
            tabelaDatas.AddCell(new Phrase($"{devolucao.DataDevolucao.ToShortDateString()}\n", fonteNormal));

            TimeSpan qtdDiasPrevistos = Convert.ToDateTime(devolucao.Locacao.PrevisaoDevolucao) - Convert.ToDateTime(devolucao.Locacao.DataLocacao);
            int qtdDiasP = qtdDiasPrevistos.Days;

            TimeSpan qtdDiasLocacao = Convert.ToDateTime(devolucao.DataDevolucao) - Convert.ToDateTime(devolucao.Locacao.DataLocacao);
            int qtdDiasL = qtdDiasLocacao.Days;

            string statusDevolucao = qtdDiasL > qtdDiasP ? $"Atrasada" : "No prazo";

            PdfPCell cell2 = new PdfPCell(new Phrase("Devolução " + statusDevolucao + ".", fonteNegrito));
            cell2.Colspan = 3;
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            tabelaDatas.AddCell(cell2);

            PdfPCell cell3 = new PdfPCell(new Phrase("Duração do contrato: " + qtdDiasL + " dias.", fonteNegrito));
            cell3.Colspan = 3;
            cell3.HorizontalAlignment = Element.ALIGN_CENTER;
            tabelaDatas.AddCell(cell3);

            PdfPTable tabelaKM = new PdfPTable(2);

            PdfPCell cellQuilometragemHeader = new PdfPCell(new Phrase("Quilometragem", fonteNegrito));
            cellQuilometragemHeader.Colspan = 2;
            cellQuilometragemHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            tabelaKM.AddCell(cellQuilometragemHeader);

            int qtdKmCliente = (int)(devolucao.Quilometragem + devolucao.Locacao.Veiculo.KmPercorrido);

            tabelaKM.AddCell(new Phrase($"Inicial: {devolucao.Locacao.Veiculo.KmPercorrido}", fonteNormal));
            tabelaKM.AddCell(new Phrase($"Final: {qtdKmCliente}", fonteNormal));


            PdfPCell totalKmPercorridos = new PdfPCell(new Phrase($"Km percorridos: {devolucao.Quilometragem}", fonteNegrito));
            totalKmPercorridos.Colspan = 2;
            totalKmPercorridos.HorizontalAlignment = Element.ALIGN_CENTER;
            tabelaKM.AddCell(totalKmPercorridos);

            PdfPTable tabelaTaxas = new PdfPTable(3);

            if (devolucao.Locacao.Taxas.Count > 0)
            {
                PdfPCell cell1 = new PdfPCell(new Phrase("Serviços adicionais", fonteNegrito));
                cell1.Colspan = 3;
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                tabelaTaxas.AddCell(cell1);

                tabelaTaxas.AddCell(new Phrase("Serviço", fonteNegrito));
                tabelaTaxas.AddCell(new Phrase("Valor", fonteNegrito));
                tabelaTaxas.AddCell(new Phrase("Tipo de Cálculo", fonteNegrito));

                foreach (var t in devolucao.Taxas)
                {
                    tabelaTaxas.AddCell(new Phrase($"{t.Nome}", fonteNormal));
                    tabelaTaxas.AddCell(new Phrase($"{t.Valor}", fonteNormal));
                    tabelaTaxas.AddCell(new Phrase($"{t.Tipo}", fonteNormal));

                }
            }

            PdfPTable tabelaValores = new PdfPTable(3);
            var taxas = devolucao.Locacao.Taxas;

            PdfPCell cellValorFinalHeader = new PdfPCell(new Phrase("Valor total da locação", fonteNegrito));
            cellValorFinalHeader.Colspan = 3;
            cellValorFinalHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            tabelaValores.AddCell(cellValorFinalHeader);

            if (devolucao.Locacao.PlanoSelecionado == "Diário")
            {
                tabelaValores.AddCell(new Phrase($"Plano Diário - Valor por dia", fonteNormal));
                tabelaValores.AddCell(new Phrase($"{devolucao.Locacao.PlanoDeCobranca.ValorPorDia_PlanoDiario} x {qtdDiasL}", fonteNormal));
                tabelaValores.AddCell(new Phrase($"{devolucao.Locacao.PlanoDeCobranca.ValorPorDia_PlanoDiario * qtdDiasL}", fonteNormal));

                tabelaValores.AddCell(new Phrase($"Plano Diário - Valor por Km", fonteNormal));
                tabelaValores.AddCell(new Phrase($"{devolucao.Locacao.PlanoDeCobranca.ValorKmRodado_PlanoDiario} x {qtdKmCliente}", fonteNormal));
                tabelaValores.AddCell(new Phrase($"{devolucao.Locacao.PlanoDeCobranca.ValorKmRodado_PlanoDiario * qtdKmCliente}", fonteNormal));
            }
            else if (devolucao.Locacao.PlanoSelecionado == "Km Controlado")
            {
                tabelaValores.AddCell(new Phrase($"Plano Quilometragem Limitada - Valor por dia", fonteNormal));
                tabelaValores.AddCell(new Phrase($"{devolucao.Locacao.PlanoDeCobranca.ValorPorDia_PlanoKmControlado} x {qtdDiasL}", fonteNormal));
                tabelaValores.AddCell(new Phrase($"{devolucao.Locacao.PlanoDeCobranca.ValorPorDia_PlanoKmControlado * qtdDiasL}", fonteNormal));

                if (qtdKmCliente > devolucao.Locacao.PlanoDeCobranca.KmLivreIncluso_PlanoKmControlado)
                {
                    tabelaValores.AddCell(new Phrase($"Plano Quilometragem Limitada - Valor por Km Excedente", fonteNormal));
                    tabelaValores.AddCell(new Phrase($"{devolucao.Locacao.PlanoDeCobranca.ValorKmRodado_PlanoKmControlado} x {qtdKmCliente}", fonteNormal));
                    tabelaValores.AddCell(new Phrase($"{devolucao.Locacao.PlanoDeCobranca.ValorKmRodado_PlanoKmControlado * qtdKmCliente}", fonteNormal));
                }
            }
            else if (devolucao.Locacao.PlanoSelecionado == "Km Livre")
            {
                tabelaValores.AddCell(new Phrase($"Plano Livre - Valor por dia", fonteNormal));
                tabelaValores.AddCell(new Phrase($"{devolucao.Locacao.PlanoDeCobranca.ValorPorDia_PlanoKmLivre} x {qtdDiasL}", fonteNormal));
                tabelaValores.AddCell(new Phrase($"{devolucao.Locacao.PlanoDeCobranca.ValorPorDia_PlanoKmLivre * qtdDiasL}", fonteNormal));
            }

            if (devolucao.VolumeTanque != "Cheio")
            {
                decimal qtdComb = 0;
                if (devolucao.VolumeTanque == "Vazio")
                {
                    tabelaValores.AddCell(new Phrase($"Taxa de reabastecimento.", fonteNormal));

                    qtdComb = devolucao.Locacao.Veiculo.CapacidadeTanque;

                    tabelaValores.AddCell(new Phrase($" {devolucao.ValorCombustivel} x {qtdComb}L", fonteNormal));

                    tabelaValores.AddCell(new Phrase($"R${devolucao.ValorCombustivel * qtdComb}", fonteNormal));

                }

                else if (devolucao.VolumeTanque == "Meio")
                {
                    tabelaValores.AddCell(new Phrase($"Taxa de reabastecimento", fonteNormal));

                    qtdComb = devolucao.Locacao.Veiculo.CapacidadeTanque / (decimal)2.0;

                    tabelaValores.AddCell(new Phrase($" {devolucao.ValorCombustivel} x {qtdComb}L", fonteNormal));

                    tabelaValores.AddCell(new Phrase($"R${devolucao.ValorCombustivel * qtdComb}", fonteNormal));
                }

                else if (devolucao.VolumeTanque == "2/5")
                {
                    tabelaValores.AddCell(new Phrase($"Taxa de reabastecimento", fonteNormal));

                    qtdComb = devolucao.Locacao.Veiculo.CapacidadeTanque * (decimal)(3.0 / 5.0);

                    tabelaValores.AddCell(new Phrase($" {devolucao.ValorCombustivel} x {qtdComb}L", fonteNormal));

                    tabelaValores.AddCell(new Phrase($"R${devolucao.ValorCombustivel * qtdComb}", fonteNormal));
                }

                else if (devolucao.VolumeTanque == "4/5")
                {
                    tabelaValores.AddCell(new Phrase($"Taxa de reabastecimento.", fonteNormal));

                    qtdComb = devolucao.Locacao.Veiculo.CapacidadeTanque * (decimal)(1.0 / 5.0);

                    tabelaValores.AddCell(new Phrase($" {devolucao.ValorCombustivel} x {qtdComb}L", fonteNormal));

                    tabelaValores.AddCell(new Phrase($"R${devolucao.ValorCombustivel * qtdComb}", fonteNormal));
                }
            }

            PdfPCell cellValorFinal = new PdfPCell(new Phrase("Valor total", fonteNegrito));
            cellValorFinal.Colspan = 2;
            cellValorFinal.HorizontalAlignment = Element.ALIGN_CENTER;
            tabelaValores.AddCell(cellValorFinal);
            tabelaValores.AddCell(new Phrase($"R${devolucao.Valor}", fonteNegrito));

            var dataEmissao = new Paragraph("Emitido em: " + DateTime.Now, fonteNormal);
            dataEmissao.Alignment = Element.ALIGN_BOTTOM;
            dataEmissao.Alignment = Element.ALIGN_RIGHT;

            #endregion

        #region Passagem para o Pdf devolução.

            doc.Open();

            doc.Add(logo);
            doc.Add(titulo);
            doc.Add(pulaLinha);
            doc.Add(tituloSecaoCliente);
            doc.Add(cliente);
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
            doc.Add(tabelaKM);
            doc.Add(pulaLinha);
            doc.Add(tabelaTaxas);
            doc.Add(tabelaValores);
            doc.Add(dataEmissao);

            doc.Close();

            Process abrirPdf = new Process();

            abrirPdf.StartInfo = new ProcessStartInfo()
            {
                CreateNoWindow = true,
                UseShellExecute=true,
                FileName = nomeArquivo
            };

            abrirPdf.Start();
        }
        #endregion

        public string GerarNomeArquivoPdfDevolucao(Devolucao devolucao)
        {
            string nomeArquivo = "";

            nomeArquivo = $"relatorio-devolucao-" + devolucao.Locacao.Cliente.Nome + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";

            return nomeArquivo;
        }
    }
}
