using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Words.NET;

namespace mnogopotok
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();
        }

        private void btnOpenInputForm_Click(object sender, EventArgs e)
        {
            InputForm inputForm = new InputForm();
            inputForm.Show();
        }
        private void btnGenerateInvoice_Click(object sender, EventArgs e)
        {
            // Генерация накладной в отдельном потоке
            Task.Run(() =>
            {
                var purchases = DatabaseHelper.GetPurchases();

                if (purchases.Rows.Count > 0)
                {
                    var doc = DocX.Create("invoice.docx");
                    doc.InsertParagraph("Накладная").FontSize(20).Bold();

                    var table = doc.InsertTable(1, 4);
                    table.Rows[0].Cells[0].Paragraphs[0].Append("Имя");
                    table.Rows[0].Cells[1].Paragraphs[0].Append("Фамилия");
                    table.Rows[0].Cells[2].Paragraphs[0].Append("Дата покупки");
                    table.Rows[0].Cells[3].Paragraphs[0].Append("Номер заказа");

                    foreach (DataRow row in purchases.Rows)
                    {
                        var newRow = table.InsertRow();
                        newRow.Cells[0].Paragraphs[0].Append(row["first_name"].ToString());
                        newRow.Cells[1].Paragraphs[0].Append(row["last_name"].ToString());
                        newRow.Cells[2].Paragraphs[0].Append(row["purchase_date"].ToString());
                        newRow.Cells[3].Paragraphs[0].Append(row["order_number"].ToString());
                    }

                    doc.Save();

                    // Обновление UI из фонового потока
                    this.Invoke((Action)(() =>
                    {
                        MessageBox.Show("Накладная создана: invoice.docx");
                    }));
                }
                else
                {
                    // Обновление UI из фонового потока
                    this.Invoke((Action)(() =>
                    {
                        MessageBox.Show("Нет данных для генерации накладной.");
                    }));
                }
            });
        }
    }
}
