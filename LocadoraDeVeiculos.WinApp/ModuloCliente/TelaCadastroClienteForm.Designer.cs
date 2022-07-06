namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    partial class TelaCadastroClienteForm
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
            this.cbxPessoa = new System.Windows.Forms.ComboBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.labelCpfCnpj = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtCpfCnpj = new System.Windows.Forms.MaskedTextBox();
            this.txtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // cbxPessoa
            // 
            this.cbxPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPessoa.FormattingEnabled = true;
            this.cbxPessoa.Items.AddRange(new object[] {
            "Física",
            "Jurídica"});
            this.cbxPessoa.Location = new System.Drawing.Point(34, 56);
            this.cbxPessoa.Name = "cbxPessoa";
            this.cbxPessoa.Size = new System.Drawing.Size(145, 23);
            this.cbxPessoa.TabIndex = 14;
            this.cbxPessoa.SelectedIndexChanged += new System.EventHandler(this.cbxPessoa_SelectedIndexChanged);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(34, 110);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(228, 23);
            this.txtNome.TabIndex = 13;
            // 
            // labelCpfCnpj
            // 
            this.labelCpfCnpj.AutoSize = true;
            this.labelCpfCnpj.Location = new System.Drawing.Point(32, 150);
            this.labelCpfCnpj.Name = "labelCpfCnpj";
            this.labelCpfCnpj.Size = new System.Drawing.Size(31, 15);
            this.labelCpfCnpj.TabIndex = 11;
            this.labelCpfCnpj.Text = "CPF:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nome:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Pessoa:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(359, 222);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(226, 23);
            this.txtEmail.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(359, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Email:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(357, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "Telefone:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(359, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "Endereço:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(359, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "Cidade:";
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(357, 56);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(228, 23);
            this.txtCidade.TabIndex = 26;
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(357, 110);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(228, 23);
            this.txtEndereco.TabIndex = 27;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(499, 279);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(86, 32);
            this.btnCancelar.TabIndex = 30;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSalvar.Location = new System.Drawing.Point(383, 279);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(86, 32);
            this.btnSalvar.TabIndex = 31;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtCpfCnpj
            // 
            this.txtCpfCnpj.Location = new System.Drawing.Point(32, 168);
            this.txtCpfCnpj.Mask = "999.999.999-99";
            this.txtCpfCnpj.Name = "txtCpfCnpj";
            this.txtCpfCnpj.Size = new System.Drawing.Size(230, 23);
            this.txtCpfCnpj.TabIndex = 32;
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(357, 168);
            this.txtTelefone.Mask = "(99) 9 9999-9999";
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(228, 23);
            this.txtTelefone.TabIndex = 33;
            // 
            // TelaCadastroClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 323);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.txtCpfCnpj);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.txtCidade);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbxPessoa);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.labelCpfCnpj);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TelaCadastroClienteForm";
            this.Text = "Cadastro Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbxPessoa;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label labelCpfCnpj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.MaskedTextBox txtCpfCnpj;
        private System.Windows.Forms.MaskedTextBox txtTelefone;
    }
}