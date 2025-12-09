using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace MeuRH
{
    public class RelatorioService
    {
        private readonly BancoDados _bd;

        public RelatorioService()
        {
            _bd = new BancoDados(); // agora usa sempre o mesmo local do banco!
        }

        public void GerarRelatorioFuncionariosPdf(string caminhoPdfSaida)
        {
            var funcionarios = LerFuncionarios();

            if (File.Exists(caminhoPdfSaida))
            {
                try
                {
                    File.Delete(caminhoPdfSaida);
                }
                catch
                {
                    MessageBox.Show(
                        "Feche o PDF antes de gerar um novo.",
                        "Arquivo em uso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
            }

            using (Document doc = new Document(PageSize.A4, 30, 30, 30, 30))
            {
                using (FileStream fs = new FileStream(caminhoPdfSaida, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    writer.PageEvent = new RodapePdf();

                    doc.Open();

                    var titulo = new Paragraph(
                        $"Relatório de Funcionários - {DateTime.Now:yyyy-MM-dd HH:mm}",
                        FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14)
                    );
                    titulo.Alignment = Element.ALIGN_CENTER;
                    doc.Add(titulo);

                    doc.Add(new Paragraph("\n"));

                    PdfPTable tabela = new PdfPTable(3);
                    tabela.WidthPercentage = 100;
                    tabela.SetWidths(new float[] { 4f, 2f, 2f });

                    tabela.AddCell(CelulaCabecalho("Nome"));
                    tabela.AddCell(CelulaCabecalho("Cargo"));
                    tabela.AddCell(CelulaCabecalho("CPF"));

                    PdfPCell linha = new PdfPCell(new Phrase(""))
                    {
                        Colspan = 3,
                        BorderWidthBottom = 1,
                        PaddingBottom = 6
                    };
                    tabela.AddCell(linha);

                    foreach (var f in funcionarios)
                    {
                        tabela.AddCell(CelulaNormal(f.Nome));
                        tabela.AddCell(CelulaNormal(f.Cargo));
                        tabela.AddCell(CelulaNormal(f.CPF));
                    }

                    doc.Add(tabela);

                    doc.Close();
                    writer.Close();
                }
            }
        }

        private PdfPCell CelulaCabecalho(string texto)
        {
            return new PdfPCell(new Phrase(texto, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new BaseColor(230, 230, 230)
            };
        }

        private PdfPCell CelulaNormal(string texto)
        {
            return new PdfPCell(new Phrase(texto, FontFactory.GetFont(FontFactory.HELVETICA, 10)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5
            };
        }

        private List<(string Nome, string Cargo, string CPF)> LerFuncionarios()
        {
            var lista = new List<(string, string, string)>();

            using (var conn = _bd.Conectar())
            using (var cmd = new SQLiteCommand(
                "SELECT nome, cargo, CPF FROM funcionarios ORDER BY nome;", conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string nome = reader["nome"]?.ToString() ?? "";
                    string cargo = reader["cargo"]?.ToString() ?? "";
                    string cpf = reader["CPF"]?.ToString() ?? "";
                    lista.Add((nome, cargo, cpf));
                }
            }

            return lista;
        }
    }

    public class RodapePdf : PdfPageEventHelper
    {
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            PdfPTable rodape = new PdfPTable(1);
            rodape.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;

            PdfPCell cell = new PdfPCell(new Phrase(
                $"Página {writer.PageNumber}",
                FontFactory.GetFont(FontFactory.HELVETICA, 9)))
            {
                Border = Rectangle.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_CENTER,
                PaddingTop = 5
            };

            rodape.AddCell(cell);
            rodape.WriteSelectedRows(0, -1, document.LeftMargin, document.BottomMargin - 5, writer.DirectContent);
        }
    }
}
