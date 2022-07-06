namespace LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca
{
    partial class TelaPlanoDeCobrancaForm
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
            this.tabControlPlanos = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtValorPorDia_PlanoDiario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValorKmRodado_PlanoDiario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKmLivreIncluso_PlanoKmControlado = new System.Windows.Forms.TextBox();
            this.txtValorPorDia_PlanoKmControlado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValorKmRodado_PlanoKmControlado = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtValorPorDia_PlanoKmLivre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxGrupoVeiculos = new System.Windows.Forms.ComboBox();
            this.tabControlPlanos.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlPlanos
            // 
            this.tabControlPlanos.Controls.Add(this.tabPage1);
            this.tabControlPlanos.Controls.Add(this.tabPage2);
            this.tabControlPlanos.Controls.Add(this.tabPage3);
            this.tabControlPlanos.Location = new System.Drawing.Point(12, 125);
            this.tabControlPlanos.Name = "tabControlPlanos";
            this.tabControlPlanos.SelectedIndex = 0;
            this.tabControlPlanos.Size = new System.Drawing.Size(455, 240);
            this.tabControlPlanos.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtValorPorDia_PlanoDiario);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtValorKmRodado_PlanoDiario);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(447, 207);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Plano Diário";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtValorPorDia_PlanoDiario
            // 
            this.txtValorPorDia_PlanoDiario.Location = new System.Drawing.Point(21, 130);
            this.txtValorPorDia_PlanoDiario.Name = "txtValorPorDia_PlanoDiario";
            this.txtValorPorDia_PlanoDiario.Size = new System.Drawing.Size(186, 27);
            this.txtValorPorDia_PlanoDiario.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Valor Por Dia:";
            // 
            // txtValorKmRodado_PlanoDiario
            // 
            this.txtValorKmRodado_PlanoDiario.Location = new System.Drawing.Point(21, 63);
            this.txtValorKmRodado_PlanoDiario.Name = "txtValorKmRodado_PlanoDiario";
            this.txtValorKmRodado_PlanoDiario.Size = new System.Drawing.Size(186, 27);
            this.txtValorKmRodado_PlanoDiario.TabIndex = 1;
            this.txtValorKmRodado_PlanoDiario.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor Km Rodado:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtKmLivreIncluso_PlanoKmControlado);
            this.tabPage2.Controls.Add(this.txtValorPorDia_PlanoKmControlado);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtValorKmRodado_PlanoKmControlado);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(447, 207);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Plano Km Controlado";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(237, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Km Livre Incluso:";
            // 
            // txtKmLivreIncluso_PlanoKmControlado
            // 
            this.txtKmLivreIncluso_PlanoKmControlado.Location = new System.Drawing.Point(237, 66);
            this.txtKmLivreIncluso_PlanoKmControlado.Name = "txtKmLivreIncluso_PlanoKmControlado";
            this.txtKmLivreIncluso_PlanoKmControlado.Size = new System.Drawing.Size(186, 27);
            this.txtKmLivreIncluso_PlanoKmControlado.TabIndex = 8;
            // 
            // txtValorPorDia_PlanoKmControlado
            // 
            this.txtValorPorDia_PlanoKmControlado.Location = new System.Drawing.Point(22, 141);
            this.txtValorPorDia_PlanoKmControlado.Name = "txtValorPorDia_PlanoKmControlado";
            this.txtValorPorDia_PlanoKmControlado.Size = new System.Drawing.Size(186, 27);
            this.txtValorPorDia_PlanoKmControlado.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Valor Por Dia:";
            // 
            // txtValorKmRodado_PlanoKmControlado
            // 
            this.txtValorKmRodado_PlanoKmControlado.Location = new System.Drawing.Point(22, 66);
            this.txtValorKmRodado_PlanoKmControlado.Name = "txtValorKmRodado_PlanoKmControlado";
            this.txtValorKmRodado_PlanoKmControlado.Size = new System.Drawing.Size(186, 27);
            this.txtValorKmRodado_PlanoKmControlado.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Valor Km Rodado:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtValorPorDia_PlanoKmLivre);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(447, 207);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Plano Km Livre";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtValorPorDia_PlanoKmLivre
            // 
            this.txtValorPorDia_PlanoKmLivre.Location = new System.Drawing.Point(21, 68);
            this.txtValorPorDia_PlanoKmLivre.Name = "txtValorPorDia_PlanoKmLivre";
            this.txtValorPorDia_PlanoKmLivre.Size = new System.Drawing.Size(186, 27);
            this.txtValorPorDia_PlanoKmLivre.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Valor Por Dia:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(369, 371);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(94, 29);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSalvar.Location = new System.Drawing.Point(269, 371);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(94, 29);
            this.btnSalvar.TabIndex = 2;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 20);
            this.label7.TabIndex = 3;
            this.label7.Text = "Grupo de Veículos:";
            // 
            // comboBoxGrupoVeiculos
            // 
            this.comboBoxGrupoVeiculos.FormattingEnabled = true;
            this.comboBoxGrupoVeiculos.Location = new System.Drawing.Point(37, 62);
            this.comboBoxGrupoVeiculos.Name = "comboBoxGrupoVeiculos";
            this.comboBoxGrupoVeiculos.Size = new System.Drawing.Size(186, 28);
            this.comboBoxGrupoVeiculos.TabIndex = 4;
            // 
            // TelaPlanoDeCobrancaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 425);
            this.Controls.Add(this.comboBoxGrupoVeiculos);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.tabControlPlanos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaPlanoDeCobrancaForm";
            this.Text = "Plano de Cobrança";
            this.tabControlPlanos.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlPlanos;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtValorPorDia_PlanoDiario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValorKmRodado_PlanoDiario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKmLivreIncluso_PlanoKmControlado;
        private System.Windows.Forms.TextBox txtValorPorDia_PlanoKmControlado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtValorKmRodado_PlanoKmControlado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtValorPorDia_PlanoKmLivre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxGrupoVeiculos;
    }
}