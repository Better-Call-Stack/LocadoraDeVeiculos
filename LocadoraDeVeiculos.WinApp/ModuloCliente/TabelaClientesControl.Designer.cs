namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    partial class TabelaClientesControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gridPessoaFisica = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gridPessoaJuridica = new System.Windows.Forms.DataGridView();
            this.IDJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNPJJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TelefoneJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPessoaFisica)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPessoaJuridica)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(688, 346);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gridPessoaFisica);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(680, 318);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pessoa Física";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gridPessoaFisica
            // 
            this.gridPessoaFisica.AllowUserToAddRows = false;
            this.gridPessoaFisica.AllowUserToDeleteRows = false;
            this.gridPessoaFisica.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.gridPessoaFisica.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridPessoaFisica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPessoaFisica.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Nome,
            this.CPF,
            this.Telefone,
            this.Email});
            this.gridPessoaFisica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPessoaFisica.Location = new System.Drawing.Point(3, 3);
            this.gridPessoaFisica.Name = "gridPessoaFisica";
            this.gridPessoaFisica.RowTemplate.Height = 25;
            this.gridPessoaFisica.Size = new System.Drawing.Size(674, 312);
            this.gridPessoaFisica.TabIndex = 0;
            this.gridPessoaFisica.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridPessoaFisica_MouseDoubleClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 40;
            // 
            // Nome
            // 
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.Width = 200;
            // 
            // CPF
            // 
            this.CPF.HeaderText = "CPF";
            this.CPF.Name = "CPF";
            // 
            // Telefone
            // 
            this.Telefone.HeaderText = "Telefone";
            this.Telefone.Name = "Telefone";
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gridPessoaJuridica);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(680, 318);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pessoa Jurídica";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gridPessoaJuridica
            // 
            this.gridPessoaJuridica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPessoaJuridica.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDJ,
            this.NomeJ,
            this.CNPJJ,
            this.TelefoneJ,
            this.EmailJ});
            this.gridPessoaJuridica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPessoaJuridica.Location = new System.Drawing.Point(3, 3);
            this.gridPessoaJuridica.Name = "gridPessoaJuridica";
            this.gridPessoaJuridica.RowTemplate.Height = 25;
            this.gridPessoaJuridica.Size = new System.Drawing.Size(674, 312);
            this.gridPessoaJuridica.TabIndex = 0;
            // 
            // IDJ
            // 
            this.IDJ.HeaderText = "ID";
            this.IDJ.Name = "IDJ";
            // 
            // NomeJ
            // 
            this.NomeJ.HeaderText = "Nome";
            this.NomeJ.Name = "NomeJ";
            // 
            // CNPJJ
            // 
            this.CNPJJ.HeaderText = "CNPJ";
            this.CNPJJ.Name = "CNPJJ";
            // 
            // TelefoneJ
            // 
            this.TelefoneJ.HeaderText = "Telefone";
            this.TelefoneJ.Name = "TelefoneJ";
            // 
            // EmailJ
            // 
            this.EmailJ.HeaderText = "Email";
            this.EmailJ.Name = "EmailJ";
            // 
            // TabelaClientesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "TabelaClientesControl";
            this.Size = new System.Drawing.Size(688, 346);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPessoaFisica)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPessoaJuridica)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView gridPessoaFisica;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPF;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridView gridPessoaJuridica;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNPJJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TelefoneJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailJ;
    }
}
