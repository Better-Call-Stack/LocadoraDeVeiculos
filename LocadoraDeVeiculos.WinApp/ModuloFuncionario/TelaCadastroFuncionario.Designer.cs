namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    partial class TelaCadastroFuncionario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaCadastroFuncionario));
            this.txtSalario = new System.Windows.Forms.NumericUpDown();
            this.lblNomeFuncionario = new System.Windows.Forms.Label();
            this.txtNomeFuncionario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSenhaFuncionario = new System.Windows.Forms.TextBox();
            this.txtLoginFuncionario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAdmissaoFuncionario = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSalvarFuncionario = new System.Windows.Forms.Button();
            this.btnCancelarFuncionario = new System.Windows.Forms.Button();
            this.cmbPerfilFuncionario = new System.Windows.Forms.ComboBox();
            this.labelCPFFuncionario = new System.Windows.Forms.Label();
            this.txtCPFFuncionario = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalario)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSalario
            // 
            this.txtSalario.BackColor = System.Drawing.SystemColors.Window;
            this.txtSalario.DecimalPlaces = 2;
            this.txtSalario.Location = new System.Drawing.Point(390, 74);
            this.txtSalario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSalario.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.txtSalario.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtSalario.Name = "txtSalario";
            this.txtSalario.Size = new System.Drawing.Size(122, 23);
            this.txtSalario.TabIndex = 10;
            this.txtSalario.Value = new decimal(new int[] {
            1001,
            0,
            0,
            0});
            // 
            // lblNomeFuncionario
            // 
            this.lblNomeFuncionario.AutoSize = true;
            this.lblNomeFuncionario.Location = new System.Drawing.Point(24, 22);
            this.lblNomeFuncionario.Name = "lblNomeFuncionario";
            this.lblNomeFuncionario.Size = new System.Drawing.Size(97, 15);
            this.lblNomeFuncionario.TabIndex = 0;
            this.lblNomeFuncionario.Text = "Nome completo:";
            // 
            // txtNomeFuncionario
            // 
            this.txtNomeFuncionario.Location = new System.Drawing.Point(135, 16);
            this.txtNomeFuncionario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNomeFuncionario.Name = "txtNomeFuncionario";
            this.txtNomeFuncionario.Size = new System.Drawing.Size(510, 23);
            this.txtNomeFuncionario.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Salário: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Login: ";
            // 
            // txtSenhaFuncionario
            // 
            this.txtSenhaFuncionario.Location = new System.Drawing.Point(134, 164);
            this.txtSenhaFuncionario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSenhaFuncionario.Name = "txtSenhaFuncionario";
            this.txtSenhaFuncionario.Size = new System.Drawing.Size(150, 23);
            this.txtSenhaFuncionario.TabIndex = 5;
            // 
            // txtLoginFuncionario
            // 
            this.txtLoginFuncionario.Location = new System.Drawing.Point(140, 133);
            this.txtLoginFuncionario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLoginFuncionario.Name = "txtLoginFuncionario";
            this.txtLoginFuncionario.Size = new System.Drawing.Size(120, 23);
            this.txtLoginFuncionario.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Data de admissão: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tipo de perfil:";
            // 
            // txtAdmissaoFuncionario
            // 
            this.txtAdmissaoFuncionario.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtAdmissaoFuncionario.Location = new System.Drawing.Point(135, 75);
            this.txtAdmissaoFuncionario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAdmissaoFuncionario.Name = "txtAdmissaoFuncionario";
            this.txtAdmissaoFuncionario.Size = new System.Drawing.Size(102, 23);
            this.txtAdmissaoFuncionario.TabIndex = 4;
            this.txtAdmissaoFuncionario.Value = new System.DateTime(2022, 6, 23, 16, 42, 33, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Senha de acesso: ";
            // 
            // btnSalvarFuncionario
            // 
            this.btnSalvarFuncionario.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSalvarFuncionario.Location = new System.Drawing.Point(407, 293);
            this.btnSalvarFuncionario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalvarFuncionario.Name = "btnSalvarFuncionario";
            this.btnSalvarFuncionario.Size = new System.Drawing.Size(117, 35);
            this.btnSalvarFuncionario.TabIndex = 13;
            this.btnSalvarFuncionario.Text = "Salvar";
            this.btnSalvarFuncionario.UseVisualStyleBackColor = true;
            this.btnSalvarFuncionario.Click += new System.EventHandler(this.btnSalvarFuncionario_Click);
            // 
            // btnCancelarFuncionario
            // 
            this.btnCancelarFuncionario.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelarFuncionario.Location = new System.Drawing.Point(572, 293);
            this.btnCancelarFuncionario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelarFuncionario.Name = "btnCancelarFuncionario";
            this.btnCancelarFuncionario.Size = new System.Drawing.Size(117, 35);
            this.btnCancelarFuncionario.TabIndex = 14;
            this.btnCancelarFuncionario.Text = "Cancelar";
            this.btnCancelarFuncionario.UseVisualStyleBackColor = true;
            // 
            // cmbPerfilFuncionario
            // 
            this.cmbPerfilFuncionario.FormattingEnabled = true;
            this.cmbPerfilFuncionario.Location = new System.Drawing.Point(135, 104);
            this.cmbPerfilFuncionario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbPerfilFuncionario.Name = "cmbPerfilFuncionario";
            this.cmbPerfilFuncionario.Size = new System.Drawing.Size(150, 23);
            this.cmbPerfilFuncionario.TabIndex = 18;
            // 
            // labelCPFFuncionario
            // 
            this.labelCPFFuncionario.AutoSize = true;
            this.labelCPFFuncionario.Location = new System.Drawing.Point(98, 52);
            this.labelCPFFuncionario.Name = "labelCPFFuncionario";
            this.labelCPFFuncionario.Size = new System.Drawing.Size(31, 15);
            this.labelCPFFuncionario.TabIndex = 19;
            this.labelCPFFuncionario.Text = "CPF:";
            // 
            // txtCPFFuncionario
            // 
            this.txtCPFFuncionario.Location = new System.Drawing.Point(135, 47);
            this.txtCPFFuncionario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCPFFuncionario.Mask = "999.999.999-99";
            this.txtCPFFuncionario.Name = "txtCPFFuncionario";
            this.txtCPFFuncionario.Size = new System.Drawing.Size(125, 23);
            this.txtCPFFuncionario.TabIndex = 21;
            // 
            // TelaCadastroFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnCancelarFuncionario;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.Controls.Add(this.txtCPFFuncionario);
            this.Controls.Add(this.labelCPFFuncionario);
            this.Controls.Add(this.cmbPerfilFuncionario);
            this.Controls.Add(this.btnCancelarFuncionario);
            this.Controls.Add(this.btnSalvarFuncionario);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSalario);
            this.Controls.Add(this.txtAdmissaoFuncionario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLoginFuncionario);
            this.Controls.Add(this.txtSenhaFuncionario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNomeFuncionario);
            this.Controls.Add(this.lblNomeFuncionario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TelaCadastroFuncionario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de colaborador";
            ((System.ComponentModel.ISupportInitialize)(this.txtSalario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNomeFuncionario;
        private System.Windows.Forms.TextBox txtNomeFuncionario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSenhaFuncionario;
        private System.Windows.Forms.TextBox txtLoginFuncionario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker txtAdmissaoFuncionario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSalvarFuncionario;
        private System.Windows.Forms.Button btnCancelarFuncionario;
        private System.Windows.Forms.ComboBox cmbPerfilFuncionario;
        private System.Windows.Forms.Label labelCPFFuncionario;
        private System.Windows.Forms.MaskedTextBox txtCPFFuncionario;
        private System.Windows.Forms.NumericUpDown txtSalario;
    }
}