namespace EjercicioViajante
{
    partial class FormularioPrincipal
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rbExhaustivo = new System.Windows.Forms.RadioButton();
            this.rbHeuristico = new System.Windows.Forms.RadioButton();
            this.rbGenetico = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.imArgentina = new DotNetOpenSource.Controls.ImageMap();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDistanciaRecorrida = new System.Windows.Forms.Label();
            this.txtDistanciaRecorrida = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.imArgentina, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(620, 567);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.09146F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.90854F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(614, 34);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.rbExhaustivo);
            this.flowLayoutPanel1.Controls.Add(this.rbHeuristico);
            this.flowLayoutPanel1.Controls.Add(this.rbGenetico);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(240, 28);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // rbExhaustivo
            // 
            this.rbExhaustivo.AutoSize = true;
            this.rbExhaustivo.Location = new System.Drawing.Point(3, 3);
            this.rbExhaustivo.Name = "rbExhaustivo";
            this.rbExhaustivo.Size = new System.Drawing.Size(77, 17);
            this.rbExhaustivo.TabIndex = 0;
            this.rbExhaustivo.TabStop = true;
            this.rbExhaustivo.Text = "Exhaustivo";
            this.rbExhaustivo.UseVisualStyleBackColor = true;
            // 
            // rbHeuristico
            // 
            this.rbHeuristico.AutoSize = true;
            this.rbHeuristico.Location = new System.Drawing.Point(86, 3);
            this.rbHeuristico.Name = "rbHeuristico";
            this.rbHeuristico.Size = new System.Drawing.Size(74, 17);
            this.rbHeuristico.TabIndex = 1;
            this.rbHeuristico.TabStop = true;
            this.rbHeuristico.Text = "Heurístico";
            this.rbHeuristico.UseVisualStyleBackColor = true;
            this.rbHeuristico.CheckedChanged += new System.EventHandler(this.rbHeuristico_CheckedChanged);
            // 
            // rbGenetico
            // 
            this.rbGenetico.AutoSize = true;
            this.rbGenetico.Location = new System.Drawing.Point(166, 3);
            this.rbGenetico.Name = "rbGenetico";
            this.rbGenetico.Size = new System.Drawing.Size(68, 17);
            this.rbGenetico.TabIndex = 2;
            this.rbGenetico.TabStop = true;
            this.rbGenetico.Text = "Genético";
            this.rbGenetico.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(249, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(362, 28);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // imArgentina
            // 
            this.imArgentina.Image = null;
            this.imArgentina.Location = new System.Drawing.Point(3, 43);
            this.imArgentina.Name = "imArgentina";
            this.imArgentina.Size = new System.Drawing.Size(550, 491);
            this.imArgentina.TabIndex = 1;
            this.imArgentina.Paint += new System.Windows.Forms.PaintEventHandler(this.imArgentina_Paint);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.lblDistanciaRecorrida);
            this.flowLayoutPanel3.Controls.Add(this.txtDistanciaRecorrida);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 540);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(447, 24);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // lblDistanciaRecorrida
            // 
            this.lblDistanciaRecorrida.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDistanciaRecorrida.AutoSize = true;
            this.lblDistanciaRecorrida.Location = new System.Drawing.Point(3, 6);
            this.lblDistanciaRecorrida.Name = "lblDistanciaRecorrida";
            this.lblDistanciaRecorrida.Size = new System.Drawing.Size(100, 13);
            this.lblDistanciaRecorrida.TabIndex = 0;
            this.lblDistanciaRecorrida.Text = "Distancia Recorrida";
            // 
            // txtDistanciaRecorrida
            // 
            this.txtDistanciaRecorrida.Location = new System.Drawing.Point(109, 3);
            this.txtDistanciaRecorrida.Name = "txtDistanciaRecorrida";
            this.txtDistanciaRecorrida.Size = new System.Drawing.Size(100, 20);
            this.txtDistanciaRecorrida.TabIndex = 1;
            // 
            // FormularioPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 567);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormularioPrincipal";
            this.Text = "FormularioPrincipal";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton rbExhaustivo;
        private System.Windows.Forms.RadioButton rbHeuristico;
        private System.Windows.Forms.RadioButton rbGenetico;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private DotNetOpenSource.Controls.ImageMap imArgentina;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label lblDistanciaRecorrida;
        private System.Windows.Forms.TextBox txtDistanciaRecorrida;
    }
}