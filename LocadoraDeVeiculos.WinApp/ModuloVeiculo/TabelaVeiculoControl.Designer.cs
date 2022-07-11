namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    partial class TabelaVeiculoControl
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
            this.components = new System.ComponentModel.Container();
            this.gridVeiculo = new System.Windows.Forms.DataGridView();
            this.veiculoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.IdVeiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModeloVeiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FabricanteVeiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlacaVeiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KmPercorrido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusVeiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridVeiculo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.veiculoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridVeiculo
            // 
            this.gridVeiculo.AllowUserToAddRows = false;
            this.gridVeiculo.AllowUserToDeleteRows = false;
            this.gridVeiculo.AllowUserToOrderColumns = true;
            this.gridVeiculo.ColumnHeadersHeight = 29;
            this.gridVeiculo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdVeiculo,
            this.ModeloVeiculo,
            this.FabricanteVeiculo,
            this.PlacaVeiculo,
            this.KmPercorrido,
            this.StatusVeiculo});
            this.gridVeiculo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridVeiculo.Location = new System.Drawing.Point(0, 0);
            this.gridVeiculo.Name = "gridVeiculo";
            this.gridVeiculo.ReadOnly = true;
            this.gridVeiculo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridVeiculo.RowHeadersWidth = 51;
            this.gridVeiculo.RowTemplate.Height = 29;
            this.gridVeiculo.Size = new System.Drawing.Size(774, 477);
            this.gridVeiculo.TabIndex = 0;
            // 
            // veiculoBindingSource
            // 
            this.veiculoBindingSource.DataSource = typeof(LocadoraDeVeiculos.Dominio.ModuloVeiculo.Veiculo);
            // 
            // IdVeiculo
            // 
            this.IdVeiculo.HeaderText = "ID";
            this.IdVeiculo.MinimumWidth = 6;
            this.IdVeiculo.Name = "IdVeiculo";
            this.IdVeiculo.ReadOnly = true;
            this.IdVeiculo.Width = 50;
            // 
            // ModeloVeiculo
            // 
            this.ModeloVeiculo.HeaderText = "Modelo";
            this.ModeloVeiculo.MinimumWidth = 6;
            this.ModeloVeiculo.Name = "ModeloVeiculo";
            this.ModeloVeiculo.ReadOnly = true;
            this.ModeloVeiculo.Width = 125;
            // 
            // FabricanteVeiculo
            // 
            this.FabricanteVeiculo.HeaderText = "Fabricante";
            this.FabricanteVeiculo.MinimumWidth = 6;
            this.FabricanteVeiculo.Name = "FabricanteVeiculo";
            this.FabricanteVeiculo.ReadOnly = true;
            this.FabricanteVeiculo.Width = 125;
            // 
            // PlacaVeiculo
            // 
            this.PlacaVeiculo.HeaderText = "Placa";
            this.PlacaVeiculo.MinimumWidth = 6;
            this.PlacaVeiculo.Name = "PlacaVeiculo";
            this.PlacaVeiculo.ReadOnly = true;
            this.PlacaVeiculo.Width = 125;
            // 
            // KmPercorrido
            // 
            this.KmPercorrido.HeaderText = "Quilometragem";
            this.KmPercorrido.MinimumWidth = 6;
            this.KmPercorrido.Name = "KmPercorrido";
            this.KmPercorrido.ReadOnly = true;
            this.KmPercorrido.Width = 125;
            // 
            // StatusVeiculo
            // 
            this.StatusVeiculo.HeaderText = "Status";
            this.StatusVeiculo.MinimumWidth = 6;
            this.StatusVeiculo.Name = "StatusVeiculo";
            this.StatusVeiculo.ReadOnly = true;
            this.StatusVeiculo.Width = 125;
            // 
            // TabelaVeiculoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridVeiculo);
            this.Name = "TabelaVeiculoControl";
            this.Size = new System.Drawing.Size(774, 477);
            ((System.ComponentModel.ISupportInitialize)(this.gridVeiculo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.veiculoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridVeiculo;
        private System.Windows.Forms.BindingSource veiculoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdVeiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModeloVeiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FabricanteVeiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlacaVeiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn KmPercorrido;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusVeiculo;
    }
}
