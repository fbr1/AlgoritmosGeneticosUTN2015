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
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.imArgentina, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.357542F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.07262F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.681564F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(646, 797);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(640, 28);
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
            this.flowLayoutPanel1.Size = new System.Drawing.Size(250, 22);
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
            this.flowLayoutPanel2.Location = new System.Drawing.Point(259, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(378, 22);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // imArgentina
            // 
            this.imArgentina.Image = null;
            this.imArgentina.Location = new System.Drawing.Point(3, 37);
            this.imArgentina.Name = "imArgentina";
            this.imArgentina.Size = new System.Drawing.Size(550, 734);
            this.imArgentina.TabIndex = 1;
            // 
            // FormularioPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 797);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormularioPrincipal";
            this.Text = "FormularioPrincipal";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
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
    }
}