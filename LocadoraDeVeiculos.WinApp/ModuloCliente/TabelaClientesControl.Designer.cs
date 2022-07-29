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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPessoaFisica = new System.Windows.Forms.TabPage();
            this.gridPessoaFisica = new System.Windows.Forms.DataGridView();
            this.tabPessoaJuridica = new System.Windows.Forms.TabPage();
            this.gridPessoaJuridica = new System.Windows.Forms.DataGridView();
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
            this.tabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(786, 461);
            this.tabControl.TabIndex = 0;
            // 
            // tabPessoaFisica
            // 
            this.tabPessoaFisica.Controls.Add(this.gridPessoaFisica);
            this.tabPessoaFisica.Location = new System.Drawing.Point(4, 29);
            this.tabPessoaFisica.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPessoaFisica.Name = "tabPessoaFisica";
            this.tabPessoaFisica.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPessoaFisica.Size = new System.Drawing.Size(778, 428);
            this.tabPessoaFisica.TabIndex = 0;
            this.tabPessoaFisica.Text = "Pessoa Física";
            this.tabPessoaFisica.UseVisualStyleBackColor = true;
            // 
            // gridPessoaFisica
            // 
            this.gridPessoaFisica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPessoaFisica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPessoaFisica.Location = new System.Drawing.Point(3, 4);
            this.gridPessoaFisica.Name = "gridPessoaFisica";
            this.gridPessoaFisica.RowHeadersWidth = 51;
            this.gridPessoaFisica.RowTemplate.Height = 29;
            this.gridPessoaFisica.Size = new System.Drawing.Size(772, 420);
            this.gridPessoaFisica.TabIndex = 0;
            // 
            // tabPessoaJuridica
            // 
            this.tabPessoaJuridica.Controls.Add(this.gridPessoaJuridica);
            this.tabPessoaJuridica.Location = new System.Drawing.Point(4, 29);
            this.tabPessoaJuridica.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPessoaJuridica.Name = "tabPessoaJuridica";
            this.tabPessoaJuridica.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPessoaJuridica.Size = new System.Drawing.Size(778, 428);
            this.tabPessoaJuridica.TabIndex = 1;
            this.tabPessoaJuridica.Text = "Pessoa Jurídica";
            this.tabPessoaJuridica.UseVisualStyleBackColor = true;
            // 
            // gridPessoaJuridica
            // 
            this.gridPessoaJuridica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPessoaJuridica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPessoaJuridica.Location = new System.Drawing.Point(3, 4);
            this.gridPessoaJuridica.Name = "gridPessoaJuridica";
            this.gridPessoaJuridica.RowHeadersWidth = 51;
            this.gridPessoaJuridica.RowTemplate.Height = 29;
            this.gridPessoaJuridica.Size = new System.Drawing.Size(772, 420);
            this.gridPessoaJuridica.TabIndex = 0;
            // 
            // TabelaClientesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TabelaClientesControl";
            this.Size = new System.Drawing.Size(786, 461);
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
        private System.Windows.Forms.DataGridView gridPessoaJuridica;
    }
}
