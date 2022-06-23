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
            System.Windows.Forms.NumericUpDown TxtSalario;
            this.lblNomeFuncionario = new System.Windows.Forms.Label();
            this.txtNomeFuncionario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSenhaFuncionario = new System.Windows.Forms.TextBox();
            this.txtLoginFuncionario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAdmissaoFuncionario = new System.Windows.Forms.DateTimePicker();
            this.cmbPerfilFuncionario = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSalvarFuncionario = new System.Windows.Forms.Button();
            this.btnCancelarFuncionario = new System.Windows.Forms.Button();
            TxtSalario = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(TxtSalario)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNomeFuncionario
            // 
            this.lblNomeFuncionario.AutoSize = true;
            this.lblNomeFuncionario.Location = new System.Drawing.Point(27, 29);
            this.lblNomeFuncionario.Name = "lblNomeFuncionario";
            this.lblNomeFuncionario.Size = new System.Drawing.Size(121, 20);
            this.lblNomeFuncionario.TabIndex = 0;
            this.lblNomeFuncionario.Text = "Nome completo:";
            this.lblNomeFuncionario.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtNomeFuncionario
            // 
            this.txtNomeFuncionario.Location = new System.Drawing.Point(154, 22);
            this.txtNomeFuncionario.Name = "txtNomeFuncionario";
            this.txtNomeFuncionario.Size = new System.Drawing.Size(582, 27);
            this.txtNomeFuncionario.TabIndex = 1;
            this.txtNomeFuncionario.TextChanged += new System.EventHandler(this.txtNomeFuncionario_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(374, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Salário: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Login: ";
            // 
            // txtSenhaFuncionario
            // 
            this.txtSenhaFuncionario.Location = new System.Drawing.Point(154, 237);
            this.txtSenhaFuncionario.Name = "txtSenhaFuncionario";
            this.txtSenhaFuncionario.Size = new System.Drawing.Size(171, 27);
            this.txtSenhaFuncionario.TabIndex = 5;
            // 
            // txtLoginFuncionario
            // 
            this.txtLoginFuncionario.Location = new System.Drawing.Point(154, 186);
            this.txtLoginFuncionario.Name = "txtLoginFuncionario";
            this.txtLoginFuncionario.Size = new System.Drawing.Size(136, 27);
            this.txtLoginFuncionario.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Data de admissão: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tipo de perfil";
            // 
            // txtAdmissaoFuncionario
            // 
            this.txtAdmissaoFuncionario.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtAdmissaoFuncionario.Location = new System.Drawing.Point(154, 74);
            this.txtAdmissaoFuncionario.Name = "txtAdmissaoFuncionario";
            this.txtAdmissaoFuncionario.Size = new System.Drawing.Size(116, 27);
            this.txtAdmissaoFuncionario.TabIndex = 4;
            this.txtAdmissaoFuncionario.Value = new System.DateTime(2022, 6, 23, 16, 42, 33, 0);
            this.txtAdmissaoFuncionario.Visible = false;
            // 
            // TxtSalario
            // 
            TxtSalario.BackColor = System.Drawing.SystemColors.Window;
            TxtSalario.DecimalPlaces = 2;
            TxtSalario.Location = new System.Drawing.Point(442, 77);
            TxtSalario.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            TxtSalario.Minimum = new decimal(new int[] {
            185000,
            0,
            0,
            131072});
            TxtSalario.Name = "TxtSalario";
            TxtSalario.Size = new System.Drawing.Size(140, 27);
            TxtSalario.TabIndex = 10;
            TxtSalario.Value = new decimal(new int[] {
            185000,
            0,
            0,
            131072});
            // 
            // cmbPerfilFuncionario
            // 
            this.cmbPerfilFuncionario.FormattingEnabled = true;
            this.cmbPerfilFuncionario.Location = new System.Drawing.Point(154, 132);
            this.cmbPerfilFuncionario.Name = "cmbPerfilFuncionario";
            this.cmbPerfilFuncionario.Size = new System.Drawing.Size(151, 28);
            this.cmbPerfilFuncionario.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Senha de acesso: ";
            // 
            // btnSalvarFuncionario
            // 
            this.btnSalvarFuncionario.Location = new System.Drawing.Point(442, 350);
            this.btnSalvarFuncionario.Name = "btnSalvarFuncionario";
            this.btnSalvarFuncionario.Size = new System.Drawing.Size(134, 47);
            this.btnSalvarFuncionario.TabIndex = 13;
            this.btnSalvarFuncionario.Text = "Salvar";
            this.btnSalvarFuncionario.UseVisualStyleBackColor = true;
            // 
            // btnCancelarFuncionario
            // 
            this.btnCancelarFuncionario.Location = new System.Drawing.Point(634, 350);
            this.btnCancelarFuncionario.Name = "btnCancelarFuncionario";
            this.btnCancelarFuncionario.Size = new System.Drawing.Size(134, 47);
            this.btnCancelarFuncionario.TabIndex = 14;
            this.btnCancelarFuncionario.Text = "Cancelar";
            this.btnCancelarFuncionario.UseVisualStyleBackColor = true;
            // 
            // TelaCadastroFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancelarFuncionario);
            this.Controls.Add(this.btnSalvarFuncionario);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbPerfilFuncionario);
            this.Controls.Add(TxtSalario);
            this.Controls.Add(this.txtAdmissaoFuncionario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLoginFuncionario);
            this.Controls.Add(this.txtSenhaFuncionario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNomeFuncionario);
            this.Controls.Add(this.lblNomeFuncionario);
            this.Name = "TelaCadastroFuncionario";
            this.ShowIcon = false;
            this.Text = "Cadastro de colaborador";
            ((System.ComponentModel.ISupportInitialize)(TxtSalario)).EndInit();
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
        private System.Windows.Forms.ComboBox cmbPerfilFuncionario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSalvarFuncionario;
        private System.Windows.Forms.Button btnCancelarFuncionario;
    }
}