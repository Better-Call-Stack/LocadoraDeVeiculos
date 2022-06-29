namespace LocadoraDeVeiculos.WinApp.ModuloGrupoVeiculos
{
    partial class TelaCadastroGrupoVeiculosForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtValorPlanoDiario = new System.Windows.Forms.NumericUpDown();
            this.txtValorDiariaKmControlado = new System.Windows.Forms.NumericUpDown();
            this.txtValorDiariaKmLivre = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorPlanoDiario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorDiariaKmControlado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorDiariaKmLivre)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(26, 41);
            this.txtNome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(289, 23);
            this.txtNome.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Valor Plano Diário:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Valor Diária Km Controlado:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Valor Diária Km Livre:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(233, 240);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(82, 22);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSalvar.Location = new System.Drawing.Point(145, 240);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(82, 22);
            this.btnSalvar.TabIndex = 9;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtValorPlanoDiario
            // 
            this.txtValorPlanoDiario.Location = new System.Drawing.Point(26, 89);
            this.txtValorPlanoDiario.Name = "txtValorPlanoDiario";
            this.txtValorPlanoDiario.Size = new System.Drawing.Size(178, 23);
            this.txtValorPlanoDiario.TabIndex = 10;
            // 
            // txtValorDiariaKmControlado
            // 
            this.txtValorDiariaKmControlado.Location = new System.Drawing.Point(26, 142);
            this.txtValorDiariaKmControlado.Name = "txtValorDiariaKmControlado";
            this.txtValorDiariaKmControlado.Size = new System.Drawing.Size(178, 23);
            this.txtValorDiariaKmControlado.TabIndex = 11;
            // 
            // txtValorDiariaKmLivre
            // 
            this.txtValorDiariaKmLivre.Location = new System.Drawing.Point(26, 197);
            this.txtValorDiariaKmLivre.Name = "txtValorDiariaKmLivre";
            this.txtValorDiariaKmLivre.Size = new System.Drawing.Size(178, 23);
            this.txtValorDiariaKmLivre.TabIndex = 12;
            // 
            // TelaCadastroGrupoVeiculosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 288);
            this.Controls.Add(this.txtValorDiariaKmLivre);
            this.Controls.Add(this.txtValorDiariaKmControlado);
            this.Controls.Add(this.txtValorPlanoDiario);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroGrupoVeiculosForm";
            this.Text = "Cadastro Grupo de Veiculos";
            ((System.ComponentModel.ISupportInitialize)(this.txtValorPlanoDiario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorDiariaKmControlado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorDiariaKmLivre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.NumericUpDown txtValorPlanoDiario;
        private System.Windows.Forms.NumericUpDown txtValorDiariaKmControlado;
        private System.Windows.Forms.NumericUpDown txtValorDiariaKmLivre;
    }
}