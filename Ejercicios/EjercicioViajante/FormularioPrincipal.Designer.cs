﻿using System.Collections.Generic;

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
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.imArgentina = new DotNetOpenSource.Controls.ImageMap();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblProvincias = new System.Windows.Forms.Label();
            this.txtListadoProv = new System.Windows.Forms.TextBox();
            this.flpPropiedadesGeneticos = new System.Windows.Forms.FlowLayoutPanel();
            this.lblIteraciones = new System.Windows.Forms.Label();
            this.txtIteraciones = new System.Windows.Forms.TextBox();
            this.lblCiclos = new System.Windows.Forms.Label();
            this.txtCiclos = new System.Windows.Forms.TextBox();
            this.lblCrossover = new System.Windows.Forms.Label();
            this.txtCrossover = new System.Windows.Forms.TextBox();
            this.lblMutacion = new System.Windows.Forms.Label();
            this.txtMutacion = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDistanciaRecorrida = new System.Windows.Forms.Label();
            this.txtDistanciaRecorrida = new System.Windows.Forms.TextBox();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.txtTiempo = new System.Windows.Forms.TextBox();
            this.lblVelocidad = new System.Windows.Forms.Label();
            this.trackBarVelocidad = new System.Windows.Forms.TrackBar();
            this.btnPlay = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flpPropiedadesGeneticos.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVelocidad)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(551, 614);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 245F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel4, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(545, 34);
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
            this.flowLayoutPanel1.Size = new System.Drawing.Size(239, 28);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // rbExhaustivo
            // 
            this.rbExhaustivo.AutoSize = true;
            this.rbExhaustivo.Location = new System.Drawing.Point(3, 3);
            this.rbExhaustivo.Name = "rbExhaustivo";
            this.rbExhaustivo.Size = new System.Drawing.Size(77, 17);
            this.rbExhaustivo.TabIndex = 0;
            this.rbExhaustivo.Text = "Exhaustivo";
            this.rbExhaustivo.UseVisualStyleBackColor = true;
            this.rbExhaustivo.CheckedChanged += new System.EventHandler(this.rbExhaustivo_CheckedChanged);
            // 
            // rbHeuristico
            // 
            this.rbHeuristico.AutoSize = true;
            this.rbHeuristico.Checked = true;
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
            this.rbGenetico.CheckedChanged += new System.EventHandler(this.rbGenetico_CheckedChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.txtProvincia);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(248, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(109, 28);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // txtProvincia
            // 
            this.txtProvincia.Location = new System.Drawing.Point(3, 3);
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.ReadOnly = true;
            this.txtProvincia.Size = new System.Drawing.Size(103, 20);
            this.txtProvincia.TabIndex = 0;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.btnGo);
            this.flowLayoutPanel4.Controls.Add(this.btnLimpiar);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(363, 3);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(163, 28);
            this.flowLayoutPanel4.TabIndex = 2;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(3, 3);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(84, 3);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel3.Controls.Add(this.imArgentina, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel5, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.flpPropiedadesGeneticos, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 43);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(545, 524);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // imArgentina
            // 
            this.imArgentina.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imArgentina.Image = null;
            this.imArgentina.Location = new System.Drawing.Point(3, 3);
            this.imArgentina.Name = "imArgentina";
            this.imArgentina.Size = new System.Drawing.Size(294, 518);
            this.imArgentina.TabIndex = 1;
            this.imArgentina.RegionClick += new DotNetOpenSource.Controls.ImageMap.RegionClickDelegate(this.imArgentina_RegionClick);
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.lblProvincias);
            this.flowLayoutPanel5.Controls.Add(this.txtListadoProv);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(303, 3);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(126, 518);
            this.flowLayoutPanel5.TabIndex = 2;
            // 
            // lblProvincias
            // 
            this.lblProvincias.Location = new System.Drawing.Point(3, 0);
            this.lblProvincias.Name = "lblProvincias";
            this.lblProvincias.Size = new System.Drawing.Size(123, 23);
            this.lblProvincias.TabIndex = 0;
            this.lblProvincias.Text = "Provincias";
            // 
            // txtListadoProv
            // 
            this.txtListadoProv.Location = new System.Drawing.Point(3, 26);
            this.txtListadoProv.Multiline = true;
            this.txtListadoProv.Name = "txtListadoProv";
            this.txtListadoProv.ReadOnly = true;
            this.txtListadoProv.Size = new System.Drawing.Size(123, 459);
            this.txtListadoProv.TabIndex = 1;
            // 
            // flpPropiedadesGeneticos
            // 
            this.flpPropiedadesGeneticos.Controls.Add(this.lblIteraciones);
            this.flpPropiedadesGeneticos.Controls.Add(this.txtIteraciones);
            this.flpPropiedadesGeneticos.Controls.Add(this.lblCiclos);
            this.flpPropiedadesGeneticos.Controls.Add(this.txtCiclos);
            this.flpPropiedadesGeneticos.Controls.Add(this.lblCrossover);
            this.flpPropiedadesGeneticos.Controls.Add(this.txtCrossover);
            this.flpPropiedadesGeneticos.Controls.Add(this.lblMutacion);
            this.flpPropiedadesGeneticos.Controls.Add(this.txtMutacion);
            this.flpPropiedadesGeneticos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpPropiedadesGeneticos.Location = new System.Drawing.Point(435, 3);
            this.flpPropiedadesGeneticos.Name = "flpPropiedadesGeneticos";
            this.flpPropiedadesGeneticos.Size = new System.Drawing.Size(107, 518);
            this.flpPropiedadesGeneticos.TabIndex = 3;
            this.flpPropiedadesGeneticos.Visible = false;
            // 
            // lblIteraciones
            // 
            this.lblIteraciones.AutoSize = true;
            this.lblIteraciones.Location = new System.Drawing.Point(3, 0);
            this.lblIteraciones.Name = "lblIteraciones";
            this.lblIteraciones.Size = new System.Drawing.Size(59, 13);
            this.lblIteraciones.TabIndex = 1;
            this.lblIteraciones.Text = "Iteraciones";
            // 
            // txtIteraciones
            // 
            this.txtIteraciones.Location = new System.Drawing.Point(3, 16);
            this.txtIteraciones.Name = "txtIteraciones";
            this.txtIteraciones.Size = new System.Drawing.Size(100, 20);
            this.txtIteraciones.TabIndex = 6;
            this.txtIteraciones.Text = "100";
            // 
            // lblCiclos
            // 
            this.lblCiclos.AutoSize = true;
            this.lblCiclos.Location = new System.Drawing.Point(3, 39);
            this.lblCiclos.Name = "lblCiclos";
            this.lblCiclos.Size = new System.Drawing.Size(35, 13);
            this.lblCiclos.TabIndex = 0;
            this.lblCiclos.Text = "Ciclos";
            // 
            // txtCiclos
            // 
            this.txtCiclos.Location = new System.Drawing.Point(3, 55);
            this.txtCiclos.Name = "txtCiclos";
            this.txtCiclos.Size = new System.Drawing.Size(100, 20);
            this.txtCiclos.TabIndex = 5;
            this.txtCiclos.Text = "400";
            // 
            // lblCrossover
            // 
            this.lblCrossover.AutoSize = true;
            this.lblCrossover.Location = new System.Drawing.Point(3, 78);
            this.lblCrossover.Name = "lblCrossover";
            this.lblCrossover.Size = new System.Drawing.Size(54, 13);
            this.lblCrossover.TabIndex = 3;
            this.lblCrossover.Text = "Crossover";
            // 
            // txtCrossover
            // 
            this.txtCrossover.Location = new System.Drawing.Point(3, 94);
            this.txtCrossover.Name = "txtCrossover";
            this.txtCrossover.Size = new System.Drawing.Size(100, 20);
            this.txtCrossover.TabIndex = 8;
            this.txtCrossover.Text = "0.75";
            // 
            // lblMutacion
            // 
            this.lblMutacion.AutoSize = true;
            this.lblMutacion.Location = new System.Drawing.Point(3, 117);
            this.lblMutacion.Name = "lblMutacion";
            this.lblMutacion.Size = new System.Drawing.Size(51, 13);
            this.lblMutacion.TabIndex = 2;
            this.lblMutacion.Text = "Mutacion";
            // 
            // txtMutacion
            // 
            this.txtMutacion.Location = new System.Drawing.Point(3, 133);
            this.txtMutacion.Name = "txtMutacion";
            this.txtMutacion.Size = new System.Drawing.Size(100, 20);
            this.txtMutacion.TabIndex = 9;
            this.txtMutacion.Text = "0.5";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.lblDistanciaRecorrida);
            this.flowLayoutPanel3.Controls.Add(this.txtDistanciaRecorrida);
            this.flowLayoutPanel3.Controls.Add(this.lblTiempo);
            this.flowLayoutPanel3.Controls.Add(this.txtTiempo);
            this.flowLayoutPanel3.Controls.Add(this.lblVelocidad);
            this.flowLayoutPanel3.Controls.Add(this.trackBarVelocidad);
            this.flowLayoutPanel3.Controls.Add(this.btnPlay);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 573);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(545, 38);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // lblDistanciaRecorrida
            // 
            this.lblDistanciaRecorrida.AutoSize = true;
            this.lblDistanciaRecorrida.Location = new System.Drawing.Point(3, 0);
            this.lblDistanciaRecorrida.Name = "lblDistanciaRecorrida";
            this.lblDistanciaRecorrida.Size = new System.Drawing.Size(51, 13);
            this.lblDistanciaRecorrida.TabIndex = 0;
            this.lblDistanciaRecorrida.Text = "Distancia";
            // 
            // txtDistanciaRecorrida
            // 
            this.txtDistanciaRecorrida.Location = new System.Drawing.Point(60, 3);
            this.txtDistanciaRecorrida.Name = "txtDistanciaRecorrida";
            this.txtDistanciaRecorrida.ReadOnly = true;
            this.txtDistanciaRecorrida.Size = new System.Drawing.Size(100, 20);
            this.txtDistanciaRecorrida.TabIndex = 1;
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Location = new System.Drawing.Point(166, 0);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(42, 13);
            this.lblTiempo.TabIndex = 4;
            this.lblTiempo.Text = "Tiempo";
            // 
            // txtTiempo
            // 
            this.txtTiempo.Location = new System.Drawing.Point(214, 3);
            this.txtTiempo.Name = "txtTiempo";
            this.txtTiempo.Size = new System.Drawing.Size(100, 20);
            this.txtTiempo.TabIndex = 5;
            // 
            // lblVelocidad
            // 
            this.lblVelocidad.AutoSize = true;
            this.lblVelocidad.Location = new System.Drawing.Point(320, 0);
            this.lblVelocidad.Name = "lblVelocidad";
            this.lblVelocidad.Size = new System.Drawing.Size(57, 13);
            this.lblVelocidad.TabIndex = 3;
            this.lblVelocidad.Text = "Velocidad:";
            // 
            // trackBarVelocidad
            // 
            this.trackBarVelocidad.Location = new System.Drawing.Point(383, 3);
            this.trackBarVelocidad.Minimum = 1;
            this.trackBarVelocidad.Name = "trackBarVelocidad";
            this.trackBarVelocidad.Size = new System.Drawing.Size(104, 45);
            this.trackBarVelocidad.TabIndex = 2;
            this.trackBarVelocidad.Value = 5;
            this.trackBarVelocidad.Scroll += new System.EventHandler(this.trackBarVelocidad_Scroll);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(493, 3);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(43, 23);
            this.btnPlay.TabIndex = 6;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // FormularioPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 614);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormularioPrincipal";
            this.Text = "FormularioPrincipal";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.flpPropiedadesGeneticos.ResumeLayout(false);
            this.flpPropiedadesGeneticos.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVelocidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton rbExhaustivo;
        private System.Windows.Forms.RadioButton rbHeuristico;
        private System.Windows.Forms.RadioButton rbGenetico;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private DotNetOpenSource.Controls.ImageMap imArgentina;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label lblDistanciaRecorrida;
        private System.Windows.Forms.TextBox txtDistanciaRecorrida;
        private System.Windows.Forms.TextBox txtProvincia;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label lblProvincias;
        private System.Windows.Forms.TextBox txtListadoProv;
        private System.Windows.Forms.TrackBar trackBarVelocidad;
        private System.Windows.Forms.Label lblVelocidad;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.TextBox txtTiempo;
        private System.Windows.Forms.FlowLayoutPanel flpPropiedadesGeneticos;
        private System.Windows.Forms.Label lblIteraciones;
        private System.Windows.Forms.TextBox txtIteraciones;
        private System.Windows.Forms.Label lblCiclos;
        private System.Windows.Forms.TextBox txtCiclos;
        private System.Windows.Forms.Label lblCrossover;
        private System.Windows.Forms.TextBox txtCrossover;
        private System.Windows.Forms.Label lblMutacion;
        private System.Windows.Forms.TextBox txtMutacion;
        private System.Windows.Forms.Button btnPlay;
    }
}