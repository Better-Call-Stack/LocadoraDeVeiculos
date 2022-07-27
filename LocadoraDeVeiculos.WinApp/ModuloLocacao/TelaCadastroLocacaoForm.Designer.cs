namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    partial class TelaCadastroLocacaoForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxCondutor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxGrupoVeiculos = new System.Windows.Forms.ComboBox();
            this.cbxPlanoCobranca = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnVeiculo = new System.Windows.Forms.Button();
            this.txtVeiculo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKmRodado = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtKmLivre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDiaria = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.clbTaxas = new System.Windows.Forms.CheckedListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dpLocacao = new System.Windows.Forms.DateTimePicker();
            this.dpDevolucao = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotalPorDia = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(103, 51);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(177, 23);
            this.txtCliente.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(298, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Selecionar Cliente";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Condutor:";
            // 
            // cbxCondutor
            // 
            this.cbxCondutor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCondutor.Enabled = false;
            this.cbxCondutor.FormattingEnabled = true;
            this.cbxCondutor.Location = new System.Drawing.Point(103, 84);
            this.cbxCondutor.Name = "cbxCondutor";
            this.cbxCondutor.Size = new System.Drawing.Size(177, 23);
            this.cbxCondutor.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Grupo de Veículos:";
            // 
            // cbxGrupoVeiculos
            // 
            this.cbxGrupoVeiculos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGrupoVeiculos.FormattingEnabled = true;
            this.cbxGrupoVeiculos.Location = new System.Drawing.Point(144, 141);
            this.cbxGrupoVeiculos.Name = "cbxGrupoVeiculos";
            this.cbxGrupoVeiculos.Size = new System.Drawing.Size(136, 23);
            this.cbxGrupoVeiculos.TabIndex = 6;
            // 
            // cbxPlanoCobranca
            // 
            this.cbxPlanoCobranca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPlanoCobranca.Enabled = false;
            this.cbxPlanoCobranca.FormattingEnabled = true;
            this.cbxPlanoCobranca.Location = new System.Drawing.Point(165, 232);
            this.cbxPlanoCobranca.Name = "cbxPlanoCobranca";
            this.cbxPlanoCobranca.Size = new System.Drawing.Size(136, 23);
            this.cbxPlanoCobranca.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Plano de Cobrança:";
            // 
            // btnVeiculo
            // 
            this.btnVeiculo.Location = new System.Drawing.Point(256, 186);
            this.btnVeiculo.Name = "btnVeiculo";
            this.btnVeiculo.Size = new System.Drawing.Size(123, 23);
            this.btnVeiculo.TabIndex = 13;
            this.btnVeiculo.Text = "Selecionar Veículo";
            this.btnVeiculo.UseVisualStyleBackColor = true;
            // 
            // txtVeiculo
            // 
            this.txtVeiculo.Location = new System.Drawing.Point(91, 186);
            this.txtVeiculo.Name = "txtVeiculo";
            this.txtVeiculo.Size = new System.Drawing.Size(148, 23);
            this.txtVeiculo.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Veículo:";
            // 
            // txtKmRodado
            // 
            this.txtKmRodado.Enabled = false;
            this.txtKmRodado.Location = new System.Drawing.Point(38, 298);
            this.txtKmRodado.Name = "txtKmRodado";
            this.txtKmRodado.Size = new System.Drawing.Size(73, 23);
            this.txtKmRodado.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "Valor Km Rodado";
            // 
            // txtKmLivre
            // 
            this.txtKmLivre.Enabled = false;
            this.txtKmLivre.Location = new System.Drawing.Point(165, 298);
            this.txtKmLivre.Name = "txtKmLivre";
            this.txtKmLivre.Size = new System.Drawing.Size(73, 23);
            this.txtKmLivre.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(157, 280);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "Valor Km Livre";
            // 
            // txtDiaria
            // 
            this.txtDiaria.Enabled = false;
            this.txtDiaria.Location = new System.Drawing.Point(274, 298);
            this.txtDiaria.Name = "txtDiaria";
            this.txtDiaria.Size = new System.Drawing.Size(73, 23);
            this.txtDiaria.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(274, 280);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "Valor Diaria";
            // 
            // clbTaxas
            // 
            this.clbTaxas.FormattingEnabled = true;
            this.clbTaxas.Location = new System.Drawing.Point(27, 374);
            this.clbTaxas.Name = "clbTaxas";
            this.clbTaxas.Size = new System.Drawing.Size(334, 130);
            this.clbTaxas.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(165, 345);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 15);
            this.label9.TabIndex = 21;
            this.label9.Text = "Taxas:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 535);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 15);
            this.label10.TabIndex = 22;
            this.label10.Text = "Data de Locação:";
            // 
            // dpLocacao
            // 
            this.dpLocacao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpLocacao.Location = new System.Drawing.Point(165, 529);
            this.dpLocacao.Name = "dpLocacao";
            this.dpLocacao.Size = new System.Drawing.Size(86, 23);
            this.dpLocacao.TabIndex = 23;
            // 
            // dpDevolucao
            // 
            this.dpDevolucao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDevolucao.Location = new System.Drawing.Point(165, 562);
            this.dpDevolucao.Name = "dpDevolucao";
            this.dpDevolucao.Size = new System.Drawing.Size(86, 23);
            this.dpDevolucao.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 568);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 15);
            this.label11.TabIndex = 24;
            this.label11.Text = "Previsão de Devolução:";
            // 
            // txtTotalPorDia
            // 
            this.txtTotalPorDia.Location = new System.Drawing.Point(103, 619);
            this.txtTotalPorDia.Name = "txtTotalPorDia";
            this.txtTotalPorDia.Size = new System.Drawing.Size(76, 23);
            this.txtTotalPorDia.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 622);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 15);
            this.label12.TabIndex = 26;
            this.label12.Text = "Total Por Dia:";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(311, 619);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(76, 23);
            this.txtSubtotal.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(204, 622);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 15);
            this.label13.TabIndex = 28;
            this.label13.Text = "Subtotal Locação:";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(291, 663);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 32);
            this.button2.TabIndex = 30;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button3.Location = new System.Drawing.Point(180, 663);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 32);
            this.button3.TabIndex = 31;
            this.button3.Text = "Visualizar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // TelaCadastroLocacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 707);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtTotalPorDia);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dpDevolucao);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dpLocacao);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.clbTaxas);
            this.Controls.Add(this.txtDiaria);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtKmLivre);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtKmRodado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnVeiculo);
            this.Controls.Add(this.txtVeiculo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxPlanoCobranca);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxGrupoVeiculos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxCondutor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroLocacaoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Locacao";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxCondutor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxGrupoVeiculos;
        private System.Windows.Forms.ComboBox cbxPlanoCobranca;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnVeiculo;
        private System.Windows.Forms.TextBox txtVeiculo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKmRodado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtKmLivre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDiaria;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckedListBox clbTaxas;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dpLocacao;
        private System.Windows.Forms.DateTimePicker dpDevolucao;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTotalPorDia;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}