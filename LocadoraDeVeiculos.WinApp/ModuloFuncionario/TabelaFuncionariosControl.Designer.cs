namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    partial class TabelaFuncionariosControl
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
            this.GridFuncionarios = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.GridFuncionarios)).BeginInit();
            this.SuspendLayout();
            // 
            // GridFuncionarios
            // 
            this.GridFuncionarios.AllowUserToAddRows = false;
            this.GridFuncionarios.AllowUserToDeleteRows = false;
            this.GridFuncionarios.AllowUserToResizeRows = false;
            this.GridFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridFuncionarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridFuncionarios.Location = new System.Drawing.Point(0, 0);
            this.GridFuncionarios.Name = "GridFuncionarios";
            this.GridFuncionarios.RowHeadersWidth = 51;
            this.GridFuncionarios.RowTemplate.Height = 29;
            this.GridFuncionarios.Size = new System.Drawing.Size(774, 477);
            this.GridFuncionarios.TabIndex = 0;
            // 
            // TabelaFuncionariosControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GridFuncionarios);
            this.Name = "TabelaFuncionariosControl";
            this.Size = new System.Drawing.Size(774, 477);
            ((System.ComponentModel.ISupportInitialize)(this.GridFuncionarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GridFuncionarios;
    }
}
