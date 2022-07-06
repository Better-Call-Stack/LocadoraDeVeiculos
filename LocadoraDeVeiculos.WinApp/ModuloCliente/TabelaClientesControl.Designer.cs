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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPessoaFisica = new System.Windows.Forms.TabPage();
            this.gridPessoaFisica = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPessoaJuridica = new System.Windows.Forms.TabPage();
            this.gridPessoaJuridica = new System.Windows.Forms.DataGridView();
            this.IDJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNPJJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TelefoneJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl.SuspendLayout();
            this.tabPessoaFisica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPessoaFisica)).BeginInit();
            this.tabPessoaJuridica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPessoaJuridica)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPessoaFisica);
            this.tabControl.Controls.Add(this.tabPessoaJuridica);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(688, 346);
            this.tabControl.TabIndex = 0;
            // 
            // tabPessoaFisica
            // 
            this.tabPessoaFisica.Controls.Add(this.gridPessoaFisica);
            this.tabPessoaFisica.Location = new System.Drawing.Point(4, 24);
            this.tabPessoaFisica.Name = "tabPessoaFisica";
            this.tabPessoaFisica.Padding = new System.Windows.Forms.Padding(3);
            this.tabPessoaFisica.Size = new System.Drawing.Size(680, 318);
            this.tabPessoaFisica.TabIndex = 0;
            this.tabPessoaFisica.Text = "Pessoa Física";
            this.tabPessoaFisica.UseVisualStyleBackColor = true;
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
            // tabPessoaJuridica
            // 
            this.tabPessoaJuridica.Controls.Add(this.gridPessoaJuridica);
            this.tabPessoaJuridica.Location = new System.Drawing.Point(4, 24);
            this.tabPessoaJuridica.Name = "tabPessoaJuridica";
            this.tabPessoaJuridica.Padding = new System.Windows.Forms.Padding(3);
            this.tabPessoaJuridica.Size = new System.Drawing.Size(680, 318);
            this.tabPessoaJuridica.TabIndex = 1;
            this.tabPessoaJuridica.Text = "Pessoa Jurídica";
            this.tabPessoaJuridica.UseVisualStyleBackColor = true;
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
            this.gridPessoaJuridica.DoubleClick += new System.EventHandler(this.gridPessoaJuridica_DoubleClick);
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
            this.Controls.Add(this.tabControl);
            this.Name = "TabelaClientesControl";
            this.Size = new System.Drawing.Size(688, 346);
            this.tabControl.ResumeLayout(false);
            this.tabPessoaFisica.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPessoaFisica)).EndInit();
            this.tabPessoaJuridica.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPessoaJuridica)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPessoaFisica;
        private System.Windows.Forms.TabPage tabPessoaJuridica;
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
