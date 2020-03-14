namespace Proyecto_serio_el_regreso
{
    partial class Form2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.cmBoxColumnas = new System.Windows.Forms.ComboBox();
            this.lblColumna = new System.Windows.Forms.Label();
            this.btnAnalizar = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBoxplot = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabHistograma = new System.Windows.Forms.TabPage();
            this.lblDatos = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabBoxplot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmBoxColumnas
            // 
            this.cmBoxColumnas.FormattingEnabled = true;
            this.cmBoxColumnas.Location = new System.Drawing.Point(12, 47);
            this.cmBoxColumnas.Name = "cmBoxColumnas";
            this.cmBoxColumnas.Size = new System.Drawing.Size(121, 21);
            this.cmBoxColumnas.TabIndex = 0;
            // 
            // lblColumna
            // 
            this.lblColumna.AutoSize = true;
            this.lblColumna.Location = new System.Drawing.Point(13, 31);
            this.lblColumna.Name = "lblColumna";
            this.lblColumna.Size = new System.Drawing.Size(91, 13);
            this.lblColumna.TabIndex = 1;
            this.lblColumna.Text = "Atributo a analizar";
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.Location = new System.Drawing.Point(160, 45);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(99, 23);
            this.btnAnalizar.TabIndex = 2;
            this.btnAnalizar.Text = "Analizar";
            this.btnAnalizar.UseVisualStyleBackColor = true;
            this.btnAnalizar.Click += new System.EventHandler(this.btnAnalizar_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(12, 84);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(58, 13);
            this.lblResultado.TabIndex = 3;
            this.lblResultado.Text = "Resultado:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBoxplot);
            this.tabControl1.Controls.Add(this.tabHistograma);
            this.tabControl1.Location = new System.Drawing.Point(261, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(768, 425);
            this.tabControl1.TabIndex = 4;
            // 
            // tabBoxplot
            // 
            this.tabBoxplot.Controls.Add(this.lblDatos);
            this.tabBoxplot.Controls.Add(this.chart1);
            this.tabBoxplot.Location = new System.Drawing.Point(4, 22);
            this.tabBoxplot.Name = "tabBoxplot";
            this.tabBoxplot.Padding = new System.Windows.Forms.Padding(3);
            this.tabBoxplot.Size = new System.Drawing.Size(760, 399);
            this.tabBoxplot.TabIndex = 0;
            this.tabBoxplot.Text = "Boxplot";
            this.tabBoxplot.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(7, 4);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.BoxPlot;
            series1.Legend = "Legend1";
            series1.Name = "s1";
            series1.YValuesPerPoint = 6;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(506, 392);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // tabHistograma
            // 
            this.tabHistograma.Location = new System.Drawing.Point(4, 22);
            this.tabHistograma.Name = "tabHistograma";
            this.tabHistograma.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistograma.Size = new System.Drawing.Size(760, 399);
            this.tabHistograma.TabIndex = 1;
            this.tabHistograma.Text = "Histograma";
            this.tabHistograma.UseVisualStyleBackColor = true;
            // 
            // lblDatos
            // 
            this.lblDatos.AutoSize = true;
            this.lblDatos.Location = new System.Drawing.Point(520, 26);
            this.lblDatos.Name = "lblDatos";
            this.lblDatos.Size = new System.Drawing.Size(0, 13);
            this.lblDatos.TabIndex = 1;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.btnAnalizar);
            this.Controls.Add(this.lblColumna);
            this.Controls.Add(this.cmBoxColumnas);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabBoxplot.ResumeLayout(false);
            this.tabBoxplot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmBoxColumnas;
        private System.Windows.Forms.Label lblColumna;
        private System.Windows.Forms.Button btnAnalizar;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabBoxplot;
        private System.Windows.Forms.TabPage tabHistograma;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lblDatos;
    }
}