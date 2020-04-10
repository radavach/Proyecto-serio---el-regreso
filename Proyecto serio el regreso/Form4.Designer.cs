namespace Proyecto_serio_el_regreso
{
    partial class Form4
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabKNN = new System.Windows.Forms.TabPage();
            this.radiobtnManhattan = new System.Windows.Forms.RadioButton();
            this.radiobtnEuclidiana = new System.Windows.Forms.RadioButton();
            this.btnIniciarOneR = new System.Windows.Forms.Button();
            this.btnIniciarZeroR = new System.Windows.Forms.Button();
            this.dataGridViewInstancia = new System.Windows.Forms.DataGridView();
            this.lblDescripcionKNN = new System.Windows.Forms.Label();
            this.lblVecinos = new System.Windows.Forms.Label();
            this.btnIniciarKNN = new System.Windows.Forms.Button();
            this.NudVecinos = new System.Windows.Forms.NumericUpDown();
            this.cmBoxColumna = new System.Windows.Forms.ComboBox();
            this.dataGridViewKNN = new System.Windows.Forms.DataGridView();
            this.tabKmeans = new System.Windows.Forms.TabPage();
            this.tabOneR = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabKNN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInstancia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudVecinos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKNN)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabKNN);
            this.tabControl1.Controls.Add(this.tabKmeans);
            this.tabControl1.Controls.Add(this.tabOneR);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 426);
            this.tabControl1.TabIndex = 0;
            // 
            // tabKNN
            // 
            this.tabKNN.Controls.Add(this.radiobtnManhattan);
            this.tabKNN.Controls.Add(this.radiobtnEuclidiana);
            this.tabKNN.Controls.Add(this.btnIniciarOneR);
            this.tabKNN.Controls.Add(this.btnIniciarZeroR);
            this.tabKNN.Controls.Add(this.dataGridViewInstancia);
            this.tabKNN.Controls.Add(this.lblDescripcionKNN);
            this.tabKNN.Controls.Add(this.lblVecinos);
            this.tabKNN.Controls.Add(this.btnIniciarKNN);
            this.tabKNN.Controls.Add(this.NudVecinos);
            this.tabKNN.Controls.Add(this.cmBoxColumna);
            this.tabKNN.Controls.Add(this.dataGridViewKNN);
            this.tabKNN.Location = new System.Drawing.Point(4, 22);
            this.tabKNN.Name = "tabKNN";
            this.tabKNN.Padding = new System.Windows.Forms.Padding(3);
            this.tabKNN.Size = new System.Drawing.Size(768, 400);
            this.tabKNN.TabIndex = 0;
            this.tabKNN.Text = "K-NN";
            this.tabKNN.UseVisualStyleBackColor = true;
            // 
            // radiobtnManhattan
            // 
            this.radiobtnManhattan.AutoSize = true;
            this.radiobtnManhattan.Location = new System.Drawing.Point(672, 136);
            this.radiobtnManhattan.Name = "radiobtnManhattan";
            this.radiobtnManhattan.Size = new System.Drawing.Size(76, 17);
            this.radiobtnManhattan.TabIndex = 10;
            this.radiobtnManhattan.Text = "Manhattan";
            this.radiobtnManhattan.UseVisualStyleBackColor = true;
            this.radiobtnManhattan.CheckedChanged += new System.EventHandler(this.radiobtnManhattan_CheckedChanged);
            // 
            // radiobtnEuclidiana
            // 
            this.radiobtnEuclidiana.AutoSize = true;
            this.radiobtnEuclidiana.Checked = true;
            this.radiobtnEuclidiana.Location = new System.Drawing.Point(672, 112);
            this.radiobtnEuclidiana.Name = "radiobtnEuclidiana";
            this.radiobtnEuclidiana.Size = new System.Drawing.Size(74, 17);
            this.radiobtnEuclidiana.TabIndex = 9;
            this.radiobtnEuclidiana.TabStop = true;
            this.radiobtnEuclidiana.Text = "Euclidiana";
            this.radiobtnEuclidiana.UseVisualStyleBackColor = true;
            this.radiobtnEuclidiana.CheckedChanged += new System.EventHandler(this.radiobtnEuclidiana_CheckedChanged);
            // 
            // btnIniciarOneR
            // 
            this.btnIniciarOneR.Location = new System.Drawing.Point(590, 210);
            this.btnIniciarOneR.Name = "btnIniciarOneR";
            this.btnIniciarOneR.Size = new System.Drawing.Size(75, 23);
            this.btnIniciarOneR.TabIndex = 8;
            this.btnIniciarOneR.Text = "Iniciar OneR";
            this.btnIniciarOneR.UseVisualStyleBackColor = true;
            this.btnIniciarOneR.Click += new System.EventHandler(this.btnIniciarOneR_Click);
            // 
            // btnIniciarZeroR
            // 
            this.btnIniciarZeroR.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarZeroR.Location = new System.Drawing.Point(590, 160);
            this.btnIniciarZeroR.Name = "btnIniciarZeroR";
            this.btnIniciarZeroR.Size = new System.Drawing.Size(75, 23);
            this.btnIniciarZeroR.TabIndex = 7;
            this.btnIniciarZeroR.Text = "Iniciar ZeroR";
            this.btnIniciarZeroR.UseVisualStyleBackColor = true;
            this.btnIniciarZeroR.Click += new System.EventHandler(this.btnIniciarZeroR_Click);
            // 
            // dataGridViewInstancia
            // 
            this.dataGridViewInstancia.AllowUserToAddRows = false;
            this.dataGridViewInstancia.AllowUserToDeleteRows = false;
            this.dataGridViewInstancia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInstancia.Location = new System.Drawing.Point(6, 294);
            this.dataGridViewInstancia.Name = "dataGridViewInstancia";
            this.dataGridViewInstancia.Size = new System.Drawing.Size(578, 100);
            this.dataGridViewInstancia.TabIndex = 6;
            // 
            // lblDescripcionKNN
            // 
            this.lblDescripcionKNN.AutoSize = true;
            this.lblDescripcionKNN.Location = new System.Drawing.Point(590, 7);
            this.lblDescripcionKNN.Name = "lblDescripcionKNN";
            this.lblDescripcionKNN.Size = new System.Drawing.Size(157, 26);
            this.lblDescripcionKNN.TabIndex = 5;
            this.lblDescripcionKNN.Text = "Elige el elemento que debemos \r\nobtener (target)";
            // 
            // lblVecinos
            // 
            this.lblVecinos.AutoSize = true;
            this.lblVecinos.Location = new System.Drawing.Point(593, 66);
            this.lblVecinos.Name = "lblVecinos";
            this.lblVecinos.Size = new System.Drawing.Size(45, 13);
            this.lblVecinos.TabIndex = 4;
            this.lblVecinos.Text = "Vecinos";
            // 
            // btnIniciarKNN
            // 
            this.btnIniciarKNN.Location = new System.Drawing.Point(590, 111);
            this.btnIniciarKNN.Name = "btnIniciarKNN";
            this.btnIniciarKNN.Size = new System.Drawing.Size(75, 23);
            this.btnIniciarKNN.TabIndex = 3;
            this.btnIniciarKNN.Text = "Iniciar KNN";
            this.btnIniciarKNN.UseVisualStyleBackColor = true;
            this.btnIniciarKNN.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // NudVecinos
            // 
            this.NudVecinos.Location = new System.Drawing.Point(593, 85);
            this.NudVecinos.Name = "NudVecinos";
            this.NudVecinos.Size = new System.Drawing.Size(120, 20);
            this.NudVecinos.TabIndex = 2;
            // 
            // cmBoxColumna
            // 
            this.cmBoxColumna.FormattingEnabled = true;
            this.cmBoxColumna.Location = new System.Drawing.Point(590, 36);
            this.cmBoxColumna.Name = "cmBoxColumna";
            this.cmBoxColumna.Size = new System.Drawing.Size(172, 21);
            this.cmBoxColumna.TabIndex = 1;
            // 
            // dataGridViewKNN
            // 
            this.dataGridViewKNN.AllowUserToAddRows = false;
            this.dataGridViewKNN.AllowUserToDeleteRows = false;
            this.dataGridViewKNN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKNN.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewKNN.Name = "dataGridViewKNN";
            this.dataGridViewKNN.Size = new System.Drawing.Size(578, 281);
            this.dataGridViewKNN.TabIndex = 0;
            // 
            // tabKmeans
            // 
            this.tabKmeans.Location = new System.Drawing.Point(4, 22);
            this.tabKmeans.Name = "tabKmeans";
            this.tabKmeans.Padding = new System.Windows.Forms.Padding(3);
            this.tabKmeans.Size = new System.Drawing.Size(768, 400);
            this.tabKmeans.TabIndex = 1;
            this.tabKmeans.Text = "K-Means";
            this.tabKmeans.UseVisualStyleBackColor = true;
            // 
            // tabOneR
            // 
            this.tabOneR.Location = new System.Drawing.Point(4, 22);
            this.tabOneR.Name = "tabOneR";
            this.tabOneR.Size = new System.Drawing.Size(768, 400);
            this.tabOneR.TabIndex = 3;
            this.tabOneR.Text = "One-R";
            this.tabOneR.UseVisualStyleBackColor = true;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form4_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabKNN.ResumeLayout(false);
            this.tabKNN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInstancia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudVecinos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKNN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabKmeans;
        private System.Windows.Forms.TabPage tabKNN;
        private System.Windows.Forms.DataGridView dataGridViewKNN;
        private System.Windows.Forms.Label lblVecinos;
        private System.Windows.Forms.Button btnIniciarKNN;
        private System.Windows.Forms.NumericUpDown NudVecinos;
        private System.Windows.Forms.ComboBox cmBoxColumna;
        private System.Windows.Forms.TabPage tabOneR;
        private System.Windows.Forms.Label lblDescripcionKNN;
        private System.Windows.Forms.DataGridView dataGridViewInstancia;
        private System.Windows.Forms.Button btnIniciarZeroR;
        private System.Windows.Forms.RadioButton radiobtnManhattan;
        private System.Windows.Forms.RadioButton radiobtnEuclidiana;
        private System.Windows.Forms.Button btnIniciarOneR;
    }
}