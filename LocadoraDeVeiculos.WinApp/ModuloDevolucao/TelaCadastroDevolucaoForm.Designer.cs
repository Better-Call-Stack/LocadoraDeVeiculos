namespace LocadoraDeVeiculos.WinApp.ModuloDevolucao
{
    partial class TelaCadastroDevolucaoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVeiculo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DataDevolucao = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxVolumeTanque = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.cklistTaxas = new System.Windows.Forms.CheckedListBox();
            this.ValorGasolina = new System.Windows.Forms.NumericUpDown();
            this.Quilometragem = new System.Windows.Forms.NumericUpDown();
            this.label = new System.Windows.Forms.Label();
            this.txtValorTotalGasolina = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ValorGasolina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quilometragem)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCliente
            // 
            this.txtCliente.Enabled = false;
            this.txtCliente.Location = new System.Drawing.Point(42, 62);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(223, 27);
            this.txtCliente.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cliente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Veículo:";
            // 
            // txtVeiculo
            // 
            this.txtVeiculo.Enabled = false;
            this.txtVeiculo.Location = new System.Drawing.Point(42, 126);
            this.txtVeiculo.Name = "txtVeiculo";
            this.txtVeiculo.Size = new System.Drawing.Size(223, 27);
            this.txtVeiculo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Quilometragem:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Data de Dovolução:";
            // 
            // DataDevolucao
            // 
            this.DataDevolucao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DataDevolucao.Location = new System.Drawing.Point(338, 126);
            this.DataDevolucao.Name = "DataDevolucao";
            this.DataDevolucao.Size = new System.Drawing.Size(223, 27);
            this.DataDevolucao.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(338, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Valor Atual Gasolina:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Volume do Tanque:";
            // 
            // comboBoxVolumeTanque
            // 
            this.comboBoxVolumeTanque.FormattingEnabled = true;
            this.comboBoxVolumeTanque.Items.AddRange(new object[] {
            "Vazio",
            "2/5",
            "Meio",
            "4/5",
            "Cheio"});
            this.comboBoxVolumeTanque.Location = new System.Drawing.Point(42, 190);
            this.comboBoxVolumeTanque.Name = "comboBoxVolumeTanque";
            this.comboBoxVolumeTanque.Size = new System.Drawing.Size(223, 28);
            this.comboBoxVolumeTanque.TabIndex = 12;
            this.comboBoxVolumeTanque.SelectedIndexChanged += new System.EventHandler(this.comboBoxVolumeTanque_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Taxas Adicionais:";
            // 
            // sqlCommandBuilder1
            // 
            this.sqlCommandBuilder1.DataAdapter = null;
            this.sqlCommandBuilder1.QuotePrefix = "[";
            this.sqlCommandBuilder1.QuoteSuffix = "]";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(467, 477);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(94, 29);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSalvar.Location = new System.Drawing.Point(361, 477);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(94, 29);
            this.btnSalvar.TabIndex = 16;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(338, 403);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Valor Total R$:";
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Enabled = false;
            this.txtValorTotal.Location = new System.Drawing.Point(338, 426);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(223, 27);
            this.txtValorTotal.TabIndex = 18;
            // 
            // cklistTaxas
            // 
            this.cklistTaxas.FormattingEnabled = true;
            this.cklistTaxas.Location = new System.Drawing.Point(42, 256);
            this.cklistTaxas.Name = "cklistTaxas";
            this.cklistTaxas.Size = new System.Drawing.Size(519, 136);
            this.cklistTaxas.TabIndex = 19;
            // 
            // ValorGasolina
            // 
            this.ValorGasolina.Location = new System.Drawing.Point(338, 191);
            this.ValorGasolina.Name = "ValorGasolina";
            this.ValorGasolina.Size = new System.Drawing.Size(223, 27);
            this.ValorGasolina.TabIndex = 20;
            // 
            // Quilometragem
            // 
            this.Quilometragem.Location = new System.Drawing.Point(338, 62);
            this.Quilometragem.Name = "Quilometragem";
            this.Quilometragem.Size = new System.Drawing.Size(223, 27);
            this.Quilometragem.TabIndex = 21;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(42, 403);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(144, 20);
            this.label.TabIndex = 22;
            this.label.Text = "Valor Total Gasolina:";
            // 
            // txtValorTotalGasolina
            // 
            this.txtValorTotalGasolina.Enabled = false;
            this.txtValorTotalGasolina.Location = new System.Drawing.Point(42, 426);
            this.txtValorTotalGasolina.Name = "txtValorTotalGasolina";
            this.txtValorTotalGasolina.Size = new System.Drawing.Size(223, 27);
            this.txtValorTotalGasolina.TabIndex = 23;
            // 
            // TelaCadastroDevolucaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 534);
            this.Controls.Add(this.txtValorTotalGasolina);
            this.Controls.Add(this.label);
            this.Controls.Add(this.Quilometragem);
            this.Controls.Add(this.ValorGasolina);
            this.Controls.Add(this.cklistTaxas);
            this.Controls.Add(this.txtValorTotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxVolumeTanque);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DataDevolucao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVeiculo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroDevolucaoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Devolução";
            ((System.ComponentModel.ISupportInitialize)(this.ValorGasolina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quilometragem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVeiculo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DataDevolucao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxVolumeTanque;
        private System.Windows.Forms.Label label7;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.CheckedListBox cklistTaxas;
        private System.Windows.Forms.NumericUpDown ValorGasolina;
        private System.Windows.Forms.NumericUpDown Quilometragem;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox txtValorTotalGasolina;
    }
}