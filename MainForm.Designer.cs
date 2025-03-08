namespace mnogopotok
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpenInputForm = new System.Windows.Forms.Button();
            this.btnGenerateInvoice = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenInputForm
            // 
            this.btnOpenInputForm.Location = new System.Drawing.Point(116, 183);
            this.btnOpenInputForm.Name = "btnOpenInputForm";
            this.btnOpenInputForm.Size = new System.Drawing.Size(202, 78);
            this.btnOpenInputForm.TabIndex = 0;
            this.btnOpenInputForm.Text = "Внести данные в базу";
            this.btnOpenInputForm.UseVisualStyleBackColor = true;
            this.btnOpenInputForm.Click += new System.EventHandler(this.btnOpenInputForm_Click);
            // 
            // btnGenerateInvoice
            // 
            this.btnGenerateInvoice.Location = new System.Drawing.Point(418, 183);
            this.btnGenerateInvoice.Name = "btnGenerateInvoice";
            this.btnGenerateInvoice.Size = new System.Drawing.Size(210, 78);
            this.btnGenerateInvoice.TabIndex = 1;
            this.btnGenerateInvoice.Text = "Сформировать отчет";
            this.btnGenerateInvoice.UseVisualStyleBackColor = true;
            this.btnGenerateInvoice.Click += new System.EventHandler(this.btnGenerateInvoice_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGenerateInvoice);
            this.Controls.Add(this.btnOpenInputForm);
            this.Name = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenInputForm;
        private System.Windows.Forms.Button btnGenerateInvoice;
    }
}

