namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    partial class TabelaCondutoresControl
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
            this.gridCondutores = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValidadeCNH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridCondutores)).BeginInit();
            this.SuspendLayout();
            // 
            // gridCondutores
            // 
            this.gridCondutores.AllowUserToAddRows = false;
            this.gridCondutores.AllowUserToDeleteRows = false;
            this.gridCondutores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCondutores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nome,
            this.CPF,
            this.CNH,
            this.ValidadeCNH,
            this.Cliente});
            this.gridCondutores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCondutores.Location = new System.Drawing.Point(0, 0);
            this.gridCondutores.Name = "gridCondutores";
            this.gridCondutores.ReadOnly = true;
            this.gridCondutores.RowTemplate.Height = 25;
            this.gridCondutores.Size = new System.Drawing.Size(782, 335);
            this.gridCondutores.TabIndex = 0;
            this.gridCondutores.DoubleClick += new System.EventHandler(this.gridCondutores_DoubleClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Nome
            // 
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            // 
            // CPF
            // 
            this.CPF.HeaderText = "CPF";
            this.CPF.Name = "CPF";
            this.CPF.ReadOnly = true;
            // 
            // CNH
            // 
            this.CNH.HeaderText = "CNH ";
            this.CNH.Name = "CNH";
            this.CNH.ReadOnly = true;
            // 
            // ValidadeCNH
            // 
            this.ValidadeCNH.HeaderText = "Validade CNH";
            this.ValidadeCNH.Name = "ValidadeCNH";
            this.ValidadeCNH.ReadOnly = true;
            // 
            // Cliente
            // 
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            // 
            // TabelaCondutoresControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridCondutores);
            this.Name = "TabelaCondutoresControl";
            this.Size = new System.Drawing.Size(782, 335);
            ((System.ComponentModel.ISupportInitialize)(this.gridCondutores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridCondutores;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPF;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNH;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValidadeCNH;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
    }
}
