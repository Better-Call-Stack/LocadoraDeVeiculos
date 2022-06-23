namespace LocadoraDeVeiculos.WinApp.ModuloGrupoVeiculos
{
    partial class TabelaGrupoVeiculosControl
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorPlanoDiario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorDiariaKmControlado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorDiarioKmLivre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nome,
            this.ValorPlanoDiario,
            this.ValorDiariaKmControlado,
            this.ValorDiarioKmLivre});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(767, 610);
            this.dataGridView1.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.HeaderText = "id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.Width = 125;
            // 
            // Nome
            // 
            this.Nome.HeaderText = "Nome";
            this.Nome.MinimumWidth = 6;
            this.Nome.Name = "Nome";
            this.Nome.Width = 125;
            // 
            // ValorPlanoDiario
            // 
            this.ValorPlanoDiario.HeaderText = "Plano Diário";
            this.ValorPlanoDiario.MinimumWidth = 6;
            this.ValorPlanoDiario.Name = "ValorPlanoDiario";
            this.ValorPlanoDiario.Width = 125;
            // 
            // ValorDiariaKmControlado
            // 
            this.ValorDiariaKmControlado.HeaderText = "Diária Km Controlado";
            this.ValorDiariaKmControlado.MinimumWidth = 6;
            this.ValorDiariaKmControlado.Name = "ValorDiariaKmControlado";
            this.ValorDiariaKmControlado.Width = 125;
            // 
            // ValorDiarioKmLivre
            // 
            this.ValorDiarioKmLivre.HeaderText = "Diária Km Livre";
            this.ValorDiarioKmLivre.MinimumWidth = 6;
            this.ValorDiarioKmLivre.Name = "ValorDiarioKmLivre";
            this.ValorDiarioKmLivre.Width = 125;
            // 
            // TabelaGrupoVeiculosControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "TabelaGrupoVeiculosControl";
            this.Size = new System.Drawing.Size(767, 610);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorPlanoDiario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorDiariaKmControlado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorDiarioKmLivre;
    }
}
