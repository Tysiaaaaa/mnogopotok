using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mnogopotok
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string purchaseDate = txtPurchaseDate.Text; // формат YYYY-MM-DD
            string orderNumber = txtOrderNumber.Text;

            // Вставка данных в БД в отдельном потоке
            Task.Run(() =>
            {
                DatabaseHelper.InsertPurchase(firstName, lastName, purchaseDate, orderNumber);

                // Обновление UI из фонового потока
                this.Invoke((Action)(() =>
                {
                    MessageBox.Show("Данные успешно добавлены!");
                }));
            });
        }
    }
}
