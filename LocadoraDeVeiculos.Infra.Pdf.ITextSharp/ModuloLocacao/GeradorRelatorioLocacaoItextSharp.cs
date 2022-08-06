using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloRelatorio;
using System;
using System.IO;

namespace LocadoraDeVeiculos.Infra.Pdf.ITextSharp.ModuloLocacao
{
    public class GeradorRelatorioLocacaoItextSharp : IGeradorRelatorio
    {

        public void GerarRelatorioPdf(Locacao locacao)
        {


            //FileStream arquivoContrato = new FileStream(nomeArquivo, FileMode.Create, FileAccess.Read);

            //Document doc = new Document(PageSize.A4);

            //PdfWriter escritorPdf = PdfWriter.GetInstance(doc, arquivoContrato);

            //Image logo = Image.GetInstance(Environment.CurrentDirectory + @"\iconeLocadora.png");
            //logo.ScaleToFit(140f, 120f);
            //logo.Alignment = Element.ALIGN_LEFT;

            //string dados = "";

            //Paragraph paragrafo1 = new (dados, new Font(Font.NORMAL, 14, (int)System.Drawing.FontStyle.Bold));

            //paragrafo1.Alignment = Element.ALIGN_RIGHT;
            //paragrafo1.Add("TESTE\n");
            //paragrafo1.Add("Teste PDF");

            //Paragraph paragrafo2 = new(dados, new Font(Font.NORMAL, 14, (int)System.Drawing.FontStyle.Italic));
            //paragrafo1.Alignment = Element.ALIGN_LEFT;
            //string texto = "Texto parágrafo 2.";
            //paragrafo2.Add(texto);


            //doc.Open();
            //doc.Add(logo);
            //doc.Add(paragrafo1);
            //doc.Add(paragrafo2);
            //doc.Close();

            //------------------------------------------------------------------//
            #region Escrita do pdf

            string localDoArquivo = Environment.CurrentDirectory + @"\contratos\";

            if (Directory.Exists(localDoArquivo) == false)
                Directory.CreateDirectory(localDoArquivo);

            var nomeArquivo = GerarNomeArquivo(locacao);

            FileStream arquivoContrato = new FileStream(nomeArquivo, FileMode.Create, FileAccess.Read);

            var doc = new Document(PageSize.A4);

            PdfWriter escritorPdf = PdfWriter.GetInstance(doc, arquivoContrato);

            Paragraph pulaLinha = new Paragraph("\n");
            Font fonteNormal = FontFactory.GetFont("Arial", 12, Font.NORMAL, new BaseColor(0, 0, 0));
            Font fonteNegrito = FontFactory.GetFont("Arial", 12, Font.BOLD, new BaseColor(0, 0, 0));
            Chunk linebreak = new Chunk(new LineSeparator(2f, 100f, new BaseColor(192, 192, 192), Element.ALIGN_CENTER, -1));


            Image logo = Image.GetInstance(Environment.CurrentDirectory + @"\iconeLocadora.png");
            logo.ScaleToFit(140f, 120f);
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

            Paragraph tituloEnderecoCondutor = new Paragraph("Endereço:\n", fonteNegrito);
            Phrase textoEnderecoCondutor = new Phrase(
                $"Endereço: {locacao.Condutor.Endereco}", fonteNormal);

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
            $"Grupo: {locacao.Veiculo.Grupo}\n", fonteNormal);

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

            else if (locacao.PlanoSelecionado == "Livre")
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

            Paragraph totalPorDia = new Paragraph($"Valor previsto por dia R${locacao.ValorDiario}\n", fonteNegrito);
            Paragraph totalPrevisto = new Paragraph($"Valor total previsto: R${locacao.Subtotal}\n", fonteNegrito);
            totalPrevisto.Alignment = Element.ALIGN_CENTER;

            Paragraph aviso = new Paragraph("Os valores acima informados são uma previsão conforme o contrato selecionado pelo cliente e podem sofrer" +
                                               "alteração com a contratação de novos serviços e/ou a necessidade de cobrança de taxas adicionais e multa.", fonteNormal);
            
            var dataEmissao = new Paragraph("Emitido em: " + DateTime.Now, fonteNormal);
            dataEmissao.Alignment = Element.ALIGN_BOTTOM;
            dataEmissao.Alignment = Element.ALIGN_RIGHT;

            #endregion

            #region Passagem para o Pdf.

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
            doc.Add(aviso);
            doc.Add(dataEmissao);

            doc.Close();

            #endregion
        }

        public void GerarRelatorioDevolucaoPDF(Locacao locacao, Devolucao devolucao)
        {
            string localDoArquivo = Environment.CurrentDirectory + @"\contratos\";

            if (Directory.Exists(localDoArquivo) == false)
                Directory.CreateDirectory(localDoArquivo);

            var nomeArquivo = GerarNomeArquivo(locacao);

            FileStream arquivoContrato = new FileStream(nomeArquivo, FileMode.Create, FileAccess.Read);

            var doc = new Document(PageSize.A4);

            PdfWriter escritorPdf = PdfWriter.GetInstance(doc, arquivoContrato);

            Paragraph pulaLinha = new Paragraph("\n");
            Font fonteNormal = FontFactory.GetFont("Arial", 12, Font.NORMAL, new BaseColor(0, 0, 0));
            Font fonteNegrito = FontFactory.GetFont("Arial", 12, Font.BOLD, new BaseColor(0, 0, 0));
            Chunk linebreak = new Chunk(new LineSeparator(2f, 100f, new BaseColor(192, 192, 192), Element.ALIGN_CENTER, -1));


            Image logo = Image.GetInstance(Environment.CurrentDirectory + @"\iconeLocadora.png");
            logo.ScaleToFit(140f, 120f);
            logo.Alignment = Element.ALIGN_LEFT;
            logo.Alignment = Element.ALIGN_TOP;


            Paragraph titulo = new Paragraph("Informações de Devolução\n\n\n", FontFactory.GetFont("Arial", 14, Font.BOLD, new BaseColor(0, 0, 0)));
            titulo.Alignment = Element.ALIGN_CENTER;

            Paragraph tituloSecaoCliente = new Paragraph("Informações do Cliente\n", fonteNegrito);
            Phrase cliente = null;

            if (locacao.Cliente.CPF != null)
                cliente = new Phrase($"Nome: {locacao.Condutor.Cliente.Nome}\nCPF: {locacao.Condutor.Cliente.CPF}\n", fonteNormal);

            else if (locacao.Cliente.CNPJ != null)
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

            Paragraph tituloEnderecoCondutor = new Paragraph("Endereço:\n", fonteNegrito);
            Phrase textoEnderecoCondutor = new Phrase(
                $"Endereço: {locacao.Condutor.Endereco}", fonteNormal);

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
            $"Grupo: {locacao.Veiculo.Grupo}\n", fonteNormal);


            PdfPTable tabelaDatas = new PdfPTable(3);

            PdfPCell cell = new PdfPCell(new Phrase("Datas do contrato: ", fonteNegrito));
            cell.Colspan = 3;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            tabelaDatas.AddCell(cell);

            tabelaDatas.AddCell(new Phrase("Data da locação", fonteNegrito));
            tabelaDatas.AddCell(new Phrase("Data de devolução prevista", fonteNegrito));
            tabelaDatas.AddCell(new Phrase("Devolução feita no dia", fonteNegrito));


            tabelaDatas.AddCell(new Phrase($"{locacao.DataLocacao.ToShortDateString()}\n", fonteNormal));
            tabelaDatas.AddCell(new Phrase($"{locacao.PrevisaoDevolucao.ToShortDateString()}\n", fonteNormal));
            tabelaDatas.AddCell(new Phrase($"{devolucao.DataDevolucao.ToShortDateString()}\n", fonteNormal));

            TimeSpan qtdDiasPrevistos = Convert.ToDateTime(devolucao.Locacao.PrevisaoDevolucao) - Convert.ToDateTime(devolucao.Locacao.PrevisaoDevolucao);
            int qtdDiasP = qtdDiasPrevistos.Days;

            TimeSpan qtdDiasLocacao = Convert.ToDateTime(devolucao.Locacao.DataLocacao) - Convert.ToDateTime(devolucao.Locacao.DataLocacao);
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

            else if (locacao.PlanoSelecionado == "Livre")
            {
                PdfPCell cellPlanoCobrancaKmLivreHeader = new PdfPCell(new Phrase("Plano Quilometragem Livre", fonteNegrito));
                cellPlanoCobrancaKmLivreHeader.HorizontalAlignment = Element.ALIGN_CENTER;
                tabelaPlanoCobrancaKmLivre.AddCell(cellPlanoCobrancaKmLivreHeader);

                tabelaPlanoCobrancaKmLivre.AddCell(new Phrase($"Valor por dia: R$ {locacao.PlanoDeCobranca.ValorPorDia_PlanoKmLivre}", fonteNormal));

            }

            PdfPTable tabelaKM = new PdfPTable(2);

            PdfPCell cellQuilometragemHeader = new PdfPCell(new Phrase("Quilometragem", fonteNegrito));
            cellQuilometragemHeader.Colspan = 2;
            cellQuilometragemHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            tabelaKM.AddCell(cellQuilometragemHeader);

            tabelaKM.AddCell(new Phrase($"Inicial: {devolucao.Locacao.Veiculo.KmPercorrido}", fonteNormal));
            tabelaKM.AddCell(new Phrase($"Final: {devolucao.Quilometragem}", fonteNormal));

            int qtdKmCliente = (int)(devolucao.Quilometragem - devolucao.Locacao.Veiculo.KmPercorrido);

            PdfPCell totalKmPercorridos = new PdfPCell(new Phrase($"Km percorridos: {qtdKmCliente}", fonteNegrito));
            totalKmPercorridos.Colspan = 2;
            totalKmPercorridos.HorizontalAlignment = Element.ALIGN_CENTER;
            tabelaKM.AddCell(totalKmPercorridos);

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

                foreach (var t in devolucao.Taxas)
                {
                    tabelaTaxas.AddCell(new Phrase($"{t.Nome}", fonteNormal));
                    tabelaTaxas.AddCell(new Phrase($"{t.Valor}", fonteNormal));
                    tabelaTaxas.AddCell(new Phrase($"{t.Tipo}", fonteNormal));

                }
            }

            Paragraph avisoSemTaxa = new Paragraph("Nenhum serviço adicional foi contratado.", fonteNegrito);
            
            Paragraph totalPorDia = new Paragraph($"Valor previsto por dia R${locacao.ValorDiario}\n", fonteNegrito);
            Paragraph totalPrevisto = new Paragraph($"Valor total previsto: R${locacao.Subtotal}\n", fonteNegrito);
            totalPrevisto.Alignment = Element.ALIGN_CENTER;

            Paragraph aviso = new Paragraph("Os valores acima informados são uma previsão conforme o contrato selecionado pelo cliente e podem sofrer" +
                                               "alteração com a contratação de novos serviços e/ou a necessidade de cobrança de taxas adicionais e multa.", fonteNormal);

            var dataEmissao = new Paragraph("Emitido em: " + DateTime.Now, fonteNormal);
            dataEmissao.Alignment = Element.ALIGN_BOTTOM;
            dataEmissao.Alignment = Element.ALIGN_RIGHT;

            #region Passagem para o Pdf.

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

            doc.Add(tabelaKM);
            doc.Add(pulaLinha);

            if (locacao.Taxas.Count > 0)
                doc.Add(tabelaTaxas);

            else
                doc.Add(avisoSemTaxa);

            doc.Add(pulaLinha);
            doc.Add(totalPorDia);
            doc.Add(totalPrevisto);
            doc.Add(aviso);
            doc.Add(dataEmissao);

            doc.Close();

            #endregion

            PdfPTable tabelaValores = new PdfPTable(3);
            var taxas = devolucao.Locacao.Taxas;

            PdfPCell cellValorFinalHeader = new PdfPCell(new Phrase("Valor total da locação", fonteNegrito));
            cellValorFinalHeader.Colspan = 3;
            cellValorFinalHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            tabelaValores.AddCell(cellValorFinalHeader);

            #region planocobranca

            if (devolucao.Locacao.PlanoSelecionado == "Diario") //diario
            {
                tabelaValores.AddCell(new Phrase($"Plano de Cobrança - Valor por dia", fonteNormal));
                tabelaValores.AddCell(new Phrase($"{devolucao.Locacao.PlanoDeCobranca.ValorPorDia_PlanoDiario} x {qtdDiasL}", fonteNormal));
                tabelaValores.AddCell(new Phrase($"{devolucao.Locacao.PlanoCobranca.DiarioValorDia * qtdDiasL}",devolucao. fonteNormal));

                tabelaValores.AddCell(new Phrase($"Plano de Cobrança - Valor por Km", fonteNormal));
                tabelaValores.AddCell(new Phrase($"{devolucao.Locacao.PlanoCobranca.DiarioValorKm} x {nKmpercorridos}", fonteNormal));
                tabelaValores.AddCell(new Phrase($"{devolucao.Locacao.PlanoCobranca.DiarioValorKm * nKmpercorridos}", fonteNormal));
            }
            else if (devolucao.Locacao.PlanoSelecionado == "Km Controlado") //diario
            {
                tabelaValores.AddCell(new Phrase($"Plano de Cobrança - Valor por dia", fonteNormal));
                tabelaValores.AddCell(new Phrase($"{devolucao.Locacao.PlanoCobranca.KmControladoValorDia} x {diasL}", fonteNormal));
                tabelaValores.AddCell(new Phrase($"{devolucao.Locacao.PlanoCobranca.KmControladoValorDia * diasL}", fonteNormal));

                if (nKmpercorridos > locacao.PlanoCobranca.KmControladoLimiteKm)
                {
                    tabelaValores.AddCell(new Phrase($"Plano de Cobrança - Valor por Km Excedente", fonteNormal));
                    tabelaValores.AddCell(new Phrase($"{devolucao.Locacao.PlanoCobranca.KmControladoValorKm} x {nKmpercorridos}", fonteNormal));
                    tabelaValores.AddCell(new Phrase($"{devolucao.Locacao.PlanoCobranca.KmControladoValorKm * nKmpercorridos}", fonteNormal));
                }
            }
            else if (devolucao.Locacao.PlanoSelecionado == "Km Livre")
            {
                tabelaValores.AddCell(new Phrase($"Plano de Cobrança - Valor por dia", fonteNormal));
                tabelaValores.AddCell(new Phrase($"{devolucao.Locacao.PlanoCobranca.KmLivreValorDia} x {diasL}", fonteNormal));
                tabelaValores.AddCell(new Phrase($"{devolucao.Locacao.PlanoCobranca.KmLivreValorDia * diasL}", fonteNormal));
            }

            #endregion

            #region taxas
            int tipoCalculo;
            foreach (var t in taxas)
            {
                tabelaValores.AddCell(new Phrase($"{t.Descricao}", fonteNormal));

                if (t.TipoCalculo == 0) //diario
                    tipoCalculo = diasL;
                else
                    tipoCalculo = 1; //fixo

                tabelaValores.AddCell(new Phrase($"{t.Valor} x {tipoCalculo}", fonteNormal));
                tabelaValores.AddCell(new Phrase($"{t.Valor * tipoCalculo}", fonteNormal));

            }
            #endregion

            if (locacao.NivelTanqueDevolucao != NivelTanque.Cheio)
            {
                decimal preco = 0m;
                string tipo = devolucao.Locacao.Veiculo.TipoCombustivel;
                if (tipo == "Gasolina")
                    preco = calculadoraValoresLocacao.PrecoGasolina;
                else if (tipo == "Álcool")
                    preco = calculadoraValoresLocacao.PrecoAlcool;
                else if (tipo == "Diesel")
                    preco = calculadoraValoresLocacao.PrecoDiesel;
                else if (tipo == "GNV")
                    preco = calculadoraValoresLocacao.PrecoGNV;

                decimal tanqueEmQuatro = locacao.Veiculo.CapacidadeTanque / 4;

                if (devolucao.VolumeTanque == VolumeTanque.Vazio)
                {
                    tabelaValores.AddCell(new Phrase($"Taxa nível do combustível", fonteNormal));

                    tabelaValores.AddCell(new Phrase($" {preco} x {locacao.Veiculo.CapacidadeTanque}L", fonteNormal));

                    tabelaValores.AddCell(new Phrase($"{preco * locacao.Veiculo.CapacidadeTanque}", fonteNormal));

                }

                else if (locacao.NivelTanqueDevolucao == NivelTanque.UmQuarto)
                {
                    tabelaValores.AddCell(new Phrase($"Taxa nível do combustível", fonteNormal));

                    var dif = tanqueEmQuatro * 3;
                    tabelaValores.AddCell(new Phrase($" {preco} x {dif}L", fonteNormal));

                    tabelaValores.AddCell(new Phrase($"{preco * dif}", fontNormal));
                }
                else if (locacao.NivelTanqueDevolucao == NivelTanque.Meio)
                {
                    tabelaValores.AddCell(new Phrase($"Taxa nível do combustível", fonteNormal));

                    var dif = tanqueEmQuatro * 2;
                    tabelaValores.AddCell(new Phrase($" {preco} x {dif}L", fonteNormal));

                    tabelaValores.AddCell(new Phrase($"{preco * dif}", fonteNormal));
                }
                else if (locacao.NivelTanqueDevolucao == NivelTanque.TresQuartos)
                {
                    tabelaValores.AddCell(new Phrase($"Taxa nível do combustível", fonteNormal));

                    var dif = tanqueEmQuatro;

                    tabelaValores.AddCell(new Phrase($" {preco} x {dif}L", fonteNormal));

                    tabelaValores.AddCell(new Phrase($"{preco * dif}", fonteNormal));
                }
            }

            doc.NewPage();
            PdfPCell cellValorFinal = new PdfPCell(new Phrase("Valor total", fonteNegrito));
            cellValorFinal.Colspan = 2;
            cellValorFinal.HorizontalAlignment = Element.ALIGN_CENTER;
            tabelaValores.AddCell(cellValorFinal);
            tabelaValores.AddCell(new Phrase($"R$ {locacao.ValorTotalEfetivo}", fonteNegrito));
            doc.Add(tabelaValores);
            #endregion

            doc.Close();

        }

        public string GerarNomeArquivo(Locacao locacao)
        {
            string nomeArquivo = "";

            if (locacao.StatusLocacao == StatusLocacao.Aberta)

                nomeArquivo = $"relatorio-locacao-" + locacao.Cliente.Nome + DateTime.Now.ToString("yyyyMMddHHmmss");
            else
                nomeArquivo = $"relatorio-devolucao-" + locacao.Cliente.Nome + DateTime.Now.ToString("yyyyMMddHHmmss");

            return nomeArquivo;
        }
    }
    
}

