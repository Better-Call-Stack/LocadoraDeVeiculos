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
            this.ColunaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColunaPlaca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColunaModelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColunaFabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColunaGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColunaTipoCombustivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.ColunaId,
            this.ColunaPlaca,
            this.ColunaModelo,
            this.ColunaFabricante,
            this.ColunaGrupo,
            this.Status,
            this.ColunaTipoCombustivel});
            this.gridVeiculo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridVeiculo.Location = new System.Drawing.Point(0, 0);
            this.gridVeiculo.Name = "gridVeiculo";
            this.gridVeiculo.ReadOnly = true;
            this.gridVeiculo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridVeiculo.RowHeadersWidth = 51;
            this.gridVeiculo.RowTemplate.Height = 29;
            this.gridVeiculo.Size = new System.Drawing.Size(774, 477);
            this.gridVeiculo.TabIndex = 0;
            this.gridVeiculo.DoubleClick += new System.EventHandler(this.gridVeiculo_DoubleClick);
            // 
            // veiculoBindingSource
            // 
            this.veiculoBindingSource.DataSource = typeof(LocadoraDeVeiculos.Dominio.ModuloVeiculo.Veiculo);
            // 
            // ColunaId
            // 
            this.ColunaId.HeaderText = "Id";
            this.ColunaId.MinimumWidth = 6;
            this.ColunaId.Name = "ColunaId";
            this.ColunaId.ReadOnly = true;
            this.ColunaId.ToolTipText = "Dois cliques para ver mais detalhes.";
            this.ColunaId.Width = 125;
            // 
            // ColunaPlaca
            // 
            this.ColunaPlaca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColunaPlaca.HeaderText = "Placa";
            this.ColunaPlaca.MinimumWidth = 6;
            this.ColunaPlaca.Name = "ColunaPlaca";
            this.ColunaPlaca.ReadOnly = true;
            this.ColunaPlaca.ToolTipText = "Dois cliques para ver mais detalhes.";
            // 
            // ColunaModelo
            // 
            this.ColunaModelo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColunaModelo.HeaderText = "Modelo";
            this.ColunaModelo.MinimumWidth = 6;
            this.ColunaModelo.Name = "ColunaModelo";
            this.ColunaModelo.ReadOnly = true;
            this.ColunaModelo.ToolTipText = "Dois cliques para ver mais detalhes.";
            // 
            // ColunaFabricante
            // 
            this.ColunaFabricante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColunaFabricante.HeaderText = "Fabricante";
            this.ColunaFabricante.MinimumWidth = 6;
            this.ColunaFabricante.Name = "ColunaFabricante";
            this.ColunaFabricante.ReadOnly = true;
            this.ColunaFabricante.ToolTipText = "Dois cliques para ver mais detalhes.";
            // 
            // ColunaGrupo
            // 
            this.ColunaGrupo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColunaGrupo.HeaderText = "Grupo";
            this.ColunaGrupo.MinimumWidth = 6;
            this.ColunaGrupo.Name = "ColunaGrupo";
            this.ColunaGrupo.ReadOnly = true;
            this.ColunaGrupo.ToolTipText = "Dois cliques para ver mais detalhes.";
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.ToolTipText = "Dois cliques para ver mais detalhes.";
            // 
            // ColunaTipoCombustivel
            // 
            this.ColunaTipoCombustivel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColunaTipoCombustivel.HeaderText = "Combustível";
            this.ColunaTipoCombustivel.MinimumWidth = 6;
            this.ColunaTipoCombustivel.Name = "ColunaTipoCombustivel";
            this.ColunaTipoCombustivel.ReadOnly = true;
            this.ColunaTipoCombustivel.ToolTipText = "Dois cliques para ver mais detalhes.";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn placaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modeloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fabricanteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusVeiculoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kmPercorridoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColunaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColunaPlaca;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColunaModelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColunaFabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColunaGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColunaTipoCombustivel;
    }
}
