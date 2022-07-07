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
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modeloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marcaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.corDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoCombustivelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capacidadeTanqueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kmPercorridoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridVeiculo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.veiculoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridVeiculo
            // 
            this.gridVeiculo.AllowUserToAddRows = false;
            this.gridVeiculo.AllowUserToDeleteRows = false;
            this.gridVeiculo.AllowUserToOrderColumns = true;
            this.gridVeiculo.AutoGenerateColumns = false;
            this.gridVeiculo.ColumnHeadersHeight = 29;
            this.gridVeiculo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.grupoDataGridViewTextBoxColumn,
            this.placaDataGridViewTextBoxColumn,
            this.modeloDataGridViewTextBoxColumn,
            this.marcaDataGridViewTextBoxColumn,
            this.corDataGridViewTextBoxColumn,
            this.tipoCombustivelDataGridViewTextBoxColumn,
            this.capacidadeTanqueDataGridViewTextBoxColumn,
            this.anoDataGridViewTextBoxColumn,
            this.kmPercorridoDataGridViewTextBoxColumn});
            this.gridVeiculo.DataSource = this.veiculoBindingSource;
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
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 51;
            // 
            // grupoDataGridViewTextBoxColumn
            // 
            this.grupoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.grupoDataGridViewTextBoxColumn.DataPropertyName = "Grupo";
            this.grupoDataGridViewTextBoxColumn.HeaderText = "Grupo";
            this.grupoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.grupoDataGridViewTextBoxColumn.Name = "grupoDataGridViewTextBoxColumn";
            this.grupoDataGridViewTextBoxColumn.ReadOnly = true;
            this.grupoDataGridViewTextBoxColumn.Width = 79;
            // 
            // placaDataGridViewTextBoxColumn
            // 
            this.placaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.placaDataGridViewTextBoxColumn.DataPropertyName = "Placa";
            this.placaDataGridViewTextBoxColumn.HeaderText = "Placa";
            this.placaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.placaDataGridViewTextBoxColumn.Name = "placaDataGridViewTextBoxColumn";
            this.placaDataGridViewTextBoxColumn.ReadOnly = true;
            this.placaDataGridViewTextBoxColumn.Width = 73;
            // 
            // modeloDataGridViewTextBoxColumn
            // 
            this.modeloDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.modeloDataGridViewTextBoxColumn.DataPropertyName = "Modelo";
            this.modeloDataGridViewTextBoxColumn.HeaderText = "Modelo";
            this.modeloDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.modeloDataGridViewTextBoxColumn.Name = "modeloDataGridViewTextBoxColumn";
            this.modeloDataGridViewTextBoxColumn.ReadOnly = true;
            this.modeloDataGridViewTextBoxColumn.Width = 90;
            // 
            // marcaDataGridViewTextBoxColumn
            // 
            this.marcaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.marcaDataGridViewTextBoxColumn.DataPropertyName = "Fabricante";
            this.marcaDataGridViewTextBoxColumn.HeaderText = "Fabricante";
            this.marcaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.marcaDataGridViewTextBoxColumn.Name = "marcaDataGridViewTextBoxColumn";
            this.marcaDataGridViewTextBoxColumn.ReadOnly = true;
            this.marcaDataGridViewTextBoxColumn.Width = 106;
            // 
            // corDataGridViewTextBoxColumn
            // 
            this.corDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.corDataGridViewTextBoxColumn.DataPropertyName = "Cor";
            this.corDataGridViewTextBoxColumn.HeaderText = "Cor";
            this.corDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.corDataGridViewTextBoxColumn.Name = "corDataGridViewTextBoxColumn";
            this.corDataGridViewTextBoxColumn.ReadOnly = true;
            this.corDataGridViewTextBoxColumn.Width = 61;
            // 
            // tipoCombustivelDataGridViewTextBoxColumn
            // 
            this.tipoCombustivelDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.tipoCombustivelDataGridViewTextBoxColumn.DataPropertyName = "TipoCombustivel";
            this.tipoCombustivelDataGridViewTextBoxColumn.HeaderText = "Combustivel";
            this.tipoCombustivelDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tipoCombustivelDataGridViewTextBoxColumn.Name = "tipoCombustivelDataGridViewTextBoxColumn";
            this.tipoCombustivelDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoCombustivelDataGridViewTextBoxColumn.Width = 120;
            // 
            // capacidadeTanqueDataGridViewTextBoxColumn
            // 
            this.capacidadeTanqueDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.capacidadeTanqueDataGridViewTextBoxColumn.DataPropertyName = "CapacidadeTanque";
            this.capacidadeTanqueDataGridViewTextBoxColumn.HeaderText = "Capacidade do tanque";
            this.capacidadeTanqueDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.capacidadeTanqueDataGridViewTextBoxColumn.Name = "capacidadeTanqueDataGridViewTextBoxColumn";
            this.capacidadeTanqueDataGridViewTextBoxColumn.ReadOnly = true;
            this.capacidadeTanqueDataGridViewTextBoxColumn.Width = 189;
            // 
            // anoDataGridViewTextBoxColumn
            // 
            this.anoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.anoDataGridViewTextBoxColumn.DataPropertyName = "Ano";
            this.anoDataGridViewTextBoxColumn.HeaderText = "Ano";
            this.anoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.anoDataGridViewTextBoxColumn.Name = "anoDataGridViewTextBoxColumn";
            this.anoDataGridViewTextBoxColumn.ReadOnly = true;
            this.anoDataGridViewTextBoxColumn.Width = 65;
            // 
            // kmPercorridoDataGridViewTextBoxColumn
            // 
            this.kmPercorridoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.kmPercorridoDataGridViewTextBoxColumn.DataPropertyName = "KmPercorrido";
            this.kmPercorridoDataGridViewTextBoxColumn.HeaderText = "Quilometragem";
            this.kmPercorridoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.kmPercorridoDataGridViewTextBoxColumn.Name = "kmPercorridoDataGridViewTextBoxColumn";
            this.kmPercorridoDataGridViewTextBoxColumn.ReadOnly = true;
            this.kmPercorridoDataGridViewTextBoxColumn.Width = 143;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn placaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modeloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marcaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn corDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoCombustivelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn capacidadeTanqueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn anoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kmPercorridoDataGridViewTextBoxColumn;
    }
}
