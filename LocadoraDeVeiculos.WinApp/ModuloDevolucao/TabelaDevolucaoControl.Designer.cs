namespace LocadoraDeVeiculos.WinApp.ModuloDevolucao
{
    partial class TabelaDevolucaoControl
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
            this.tabelaControl = new System.Windows.Forms.TabControl();
            this.tabAtivos = new System.Windows.Forms.TabPage();
            this.gridAtivos = new System.Windows.Forms.DataGridView();
            this.tabInativo = new System.Windows.Forms.TabPage();
            this.gridInativo = new System.Windows.Forms.DataGridView();
            this.tabelaControl.SuspendLayout();
            this.tabAtivos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAtivos)).BeginInit();
            this.tabInativo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInativo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabelaControl
            // 
            this.tabelaControl.Controls.Add(this.tabAtivos);
            this.tabelaControl.Controls.Add(this.tabInativo);
            this.tabelaControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabelaControl.Location = new System.Drawing.Point(0, 0);
            this.tabelaControl.Name = "tabelaControl";
            this.tabelaControl.SelectedIndex = 0;
            this.tabelaControl.Size = new System.Drawing.Size(621, 409);
            this.tabelaControl.TabIndex = 1;
            // 
            // tabAtivos
            // 
            this.tabAtivos.Controls.Add(this.gridAtivos);
            this.tabAtivos.Location = new System.Drawing.Point(4, 24);
            this.tabAtivos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabAtivos.Name = "tabAtivos";
            this.tabAtivos.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabAtivos.Size = new System.Drawing.Size(613, 381);
            this.tabAtivos.TabIndex = 0;
            this.tabAtivos.Text = "Locações Ativas";
            this.tabAtivos.UseVisualStyleBackColor = true;
            // 
            // gridAtivos
            // 
            this.gridAtivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAtivos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAtivos.Location = new System.Drawing.Point(3, 2);
            this.gridAtivos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridAtivos.Name = "gridAtivos";
            this.gridAtivos.RowHeadersWidth = 51;
            this.gridAtivos.RowTemplate.Height = 29;
            this.gridAtivos.Size = new System.Drawing.Size(607, 377);
            this.gridAtivos.TabIndex = 0;
            // 
            // tabInativo
            // 
            this.tabInativo.Controls.Add(this.gridInativo);
            this.tabInativo.Location = new System.Drawing.Point(4, 24);
            this.tabInativo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabInativo.Name = "tabInativo";
            this.tabInativo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabInativo.Size = new System.Drawing.Size(613, 381);
            this.tabInativo.TabIndex = 1;
            this.tabInativo.Text = "Devoluções";
            this.tabInativo.UseVisualStyleBackColor = true;
            // 
            // gridInativo
            // 
            this.gridInativo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridInativo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridInativo.Location = new System.Drawing.Point(3, 2);
            this.gridInativo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridInativo.Name = "gridInativo";
            this.gridInativo.RowHeadersWidth = 51;
            this.gridInativo.RowTemplate.Height = 29;
            this.gridInativo.Size = new System.Drawing.Size(607, 377);
            this.gridInativo.TabIndex = 0;
            // 
            // TabelaDevolucaoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabelaControl);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TabelaDevolucaoControl";
            this.Size = new System.Drawing.Size(621, 409);
            this.tabelaControl.ResumeLayout(false);
            this.tabAtivos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAtivos)).EndInit();
            this.tabInativo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridInativo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabelaControl;
        private System.Windows.Forms.TabPage tabAtivos;
        private System.Windows.Forms.TabPage tabInativo;
        private System.Windows.Forms.DataGridView gridAtivos;
        private System.Windows.Forms.DataGridView gridInativo;
    }
}
