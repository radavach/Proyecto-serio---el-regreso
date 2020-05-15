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
            this.lblresultado = new System.Windows.Forms.Label();
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numIteraciones = new System.Windows.Forms.NumericUpDown();
            this.numClusters = new System.Windows.Forms.NumericUpDown();
            this.distanciaBox = new System.Windows.Forms.ComboBox();
            this.btnKMeans = new System.Windows.Forms.Button();
            this.dataGridViewClusters = new System.Windows.Forms.DataGridView();
            this.dataGridViewKM = new System.Windows.Forms.DataGridView();
            this.tabOneR = new System.Windows.Forms.TabPage();
            this.lblResultados = new System.Windows.Forms.Label();
            this.btnHoldOut = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioBtnManhattanKfold = new System.Windows.Forms.RadioButton();
            this.radioBtnEuclidianaKfold = new System.Windows.Forms.RadioButton();
            this.NudVecinosKFold = new System.Windows.Forms.NumericUpDown();
            this.lblVecinosKfold = new System.Windows.Forms.Label();
            this.cmboxTargetKFold = new System.Windows.Forms.ComboBox();
            this.dataGridViewKFold = new System.Windows.Forms.DataGridView();
            this.NudFold = new System.Windows.Forms.NumericUpDown();
            this.btnKfold = new System.Windows.Forms.Button();
            this.lblFold = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabKNN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInstancia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudVecinos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKNN)).BeginInit();
            this.tabKmeans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIteraciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClusters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClusters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKM)).BeginInit();
            this.tabOneR.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudVecinosKFold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKFold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFold)).BeginInit();
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
            this.tabKNN.Controls.Add(this.lblresultado);
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
            // lblresultado
            // 
            this.lblresultado.Location = new System.Drawing.Point(591, 240);
            this.lblresultado.Name = "lblresultado";
            this.lblresultado.Size = new System.Drawing.Size(171, 157);
            this.lblresultado.TabIndex = 11;
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
            this.tabKmeans.Controls.Add(this.label4);
            this.tabKmeans.Controls.Add(this.label3);
            this.tabKmeans.Controls.Add(this.label2);
            this.tabKmeans.Controls.Add(this.label1);
            this.tabKmeans.Controls.Add(this.numIteraciones);
            this.tabKmeans.Controls.Add(this.numClusters);
            this.tabKmeans.Controls.Add(this.distanciaBox);
            this.tabKmeans.Controls.Add(this.btnKMeans);
            this.tabKmeans.Controls.Add(this.dataGridViewClusters);
            this.tabKmeans.Controls.Add(this.dataGridViewKM);
            this.tabKmeans.Location = new System.Drawing.Point(4, 22);
            this.tabKmeans.Name = "tabKmeans";
            this.tabKmeans.Padding = new System.Windows.Forms.Padding(3);
            this.tabKmeans.Size = new System.Drawing.Size(768, 400);
            this.tabKmeans.TabIndex = 1;
            this.tabKmeans.Text = "K-Means";
            this.tabKmeans.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Valores generados de los clusters";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Distancia:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Numero de iteraciones:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Numero de clusters (K):";
            // 
            // numIteraciones
            // 
            this.numIteraciones.Location = new System.Drawing.Point(38, 115);
            this.numIteraciones.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numIteraciones.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numIteraciones.Name = "numIteraciones";
            this.numIteraciones.Size = new System.Drawing.Size(120, 20);
            this.numIteraciones.TabIndex = 5;
            this.numIteraciones.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // numClusters
            // 
            this.numClusters.Location = new System.Drawing.Point(38, 67);
            this.numClusters.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numClusters.Name = "numClusters";
            this.numClusters.Size = new System.Drawing.Size(120, 20);
            this.numClusters.TabIndex = 4;
            this.numClusters.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // distanciaBox
            // 
            this.distanciaBox.FormattingEnabled = true;
            this.distanciaBox.Items.AddRange(new object[] {
            "Euclidiana",
            "Manhattan",
            "Hamming"});
            this.distanciaBox.Location = new System.Drawing.Point(38, 162);
            this.distanciaBox.Name = "distanciaBox";
            this.distanciaBox.Size = new System.Drawing.Size(121, 21);
            this.distanciaBox.TabIndex = 3;
            // 
            // btnKMeans
            // 
            this.btnKMeans.Location = new System.Drawing.Point(37, 201);
            this.btnKMeans.Name = "btnKMeans";
            this.btnKMeans.Size = new System.Drawing.Size(121, 23);
            this.btnKMeans.TabIndex = 2;
            this.btnKMeans.Text = "Iniciar K-Means";
            this.btnKMeans.UseVisualStyleBackColor = true;
            this.btnKMeans.Click += new System.EventHandler(this.btnKMeans_Click);
            // 
            // dataGridViewClusters
            // 
            this.dataGridViewClusters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClusters.Location = new System.Drawing.Point(38, 262);
            this.dataGridViewClusters.Name = "dataGridViewClusters";
            this.dataGridViewClusters.Size = new System.Drawing.Size(242, 108);
            this.dataGridViewClusters.TabIndex = 1;
            // 
            // dataGridViewKM
            // 
            this.dataGridViewKM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKM.Location = new System.Drawing.Point(297, 24);
            this.dataGridViewKM.Name = "dataGridViewKM";
            this.dataGridViewKM.Size = new System.Drawing.Size(447, 346);
            this.dataGridViewKM.TabIndex = 0;
            this.dataGridViewKM.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewKM_CellContentClick);
            // 
            // tabOneR
            // 
            this.tabOneR.Controls.Add(this.lblResultados);
            this.tabOneR.Controls.Add(this.btnHoldOut);
            this.tabOneR.Controls.Add(this.groupBox1);
            this.tabOneR.Controls.Add(this.NudVecinosKFold);
            this.tabOneR.Controls.Add(this.lblVecinosKfold);
            this.tabOneR.Controls.Add(this.cmboxTargetKFold);
            this.tabOneR.Controls.Add(this.dataGridViewKFold);
            this.tabOneR.Controls.Add(this.NudFold);
            this.tabOneR.Controls.Add(this.btnKfold);
            this.tabOneR.Controls.Add(this.lblFold);
            this.tabOneR.Location = new System.Drawing.Point(4, 22);
            this.tabOneR.Name = "tabOneR";
            this.tabOneR.Size = new System.Drawing.Size(768, 400);
            this.tabOneR.TabIndex = 3;
            this.tabOneR.Text = "One-R";
            this.tabOneR.UseVisualStyleBackColor = true;
            // 
            // lblResultados
            // 
            this.lblResultados.Location = new System.Drawing.Point(7, 162);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(187, 235);
            this.lblResultados.TabIndex = 10;
            // 
            // btnHoldOut
            // 
            this.btnHoldOut.Location = new System.Drawing.Point(99, 132);
            this.btnHoldOut.Name = "btnHoldOut";
            this.btnHoldOut.Size = new System.Drawing.Size(75, 23);
            this.btnHoldOut.TabIndex = 9;
            this.btnHoldOut.Text = "Hold-Out";
            this.btnHoldOut.UseVisualStyleBackColor = true;
            this.btnHoldOut.Click += new System.EventHandler(this.btnHoldOut_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioBtnManhattanKfold);
            this.groupBox1.Controls.Add(this.radioBtnEuclidianaKfold);
            this.groupBox1.Location = new System.Drawing.Point(7, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 26);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // radioBtnManhattanKfold
            // 
            this.radioBtnManhattanKfold.AutoSize = true;
            this.radioBtnManhattanKfold.Location = new System.Drawing.Point(88, 8);
            this.radioBtnManhattanKfold.Name = "radioBtnManhattanKfold";
            this.radioBtnManhattanKfold.Size = new System.Drawing.Size(76, 17);
            this.radioBtnManhattanKfold.TabIndex = 1;
            this.radioBtnManhattanKfold.Text = "Manhattan";
            this.radioBtnManhattanKfold.UseVisualStyleBackColor = true;
            // 
            // radioBtnEuclidianaKfold
            // 
            this.radioBtnEuclidianaKfold.AutoSize = true;
            this.radioBtnEuclidianaKfold.Checked = true;
            this.radioBtnEuclidianaKfold.Location = new System.Drawing.Point(6, 9);
            this.radioBtnEuclidianaKfold.Name = "radioBtnEuclidianaKfold";
            this.radioBtnEuclidianaKfold.Size = new System.Drawing.Size(74, 17);
            this.radioBtnEuclidianaKfold.TabIndex = 0;
            this.radioBtnEuclidianaKfold.TabStop = true;
            this.radioBtnEuclidianaKfold.Text = "Euclidiana";
            this.radioBtnEuclidianaKfold.UseVisualStyleBackColor = true;
            // 
            // NudVecinosKFold
            // 
            this.NudVecinosKFold.Location = new System.Drawing.Point(54, 74);
            this.NudVecinosKFold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudVecinosKFold.Name = "NudVecinosKFold";
            this.NudVecinosKFold.Size = new System.Drawing.Size(120, 20);
            this.NudVecinosKFold.TabIndex = 6;
            this.NudVecinosKFold.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblVecinosKfold
            // 
            this.lblVecinosKfold.AutoSize = true;
            this.lblVecinosKfold.Location = new System.Drawing.Point(7, 76);
            this.lblVecinosKfold.Name = "lblVecinosKfold";
            this.lblVecinosKfold.Size = new System.Drawing.Size(45, 13);
            this.lblVecinosKfold.TabIndex = 5;
            this.lblVecinosKfold.Text = "Vecinos";
            // 
            // cmboxTargetKFold
            // 
            this.cmboxTargetKFold.FormattingEnabled = true;
            this.cmboxTargetKFold.Location = new System.Drawing.Point(7, 48);
            this.cmboxTargetKFold.Name = "cmboxTargetKFold";
            this.cmboxTargetKFold.Size = new System.Drawing.Size(167, 21);
            this.cmboxTargetKFold.TabIndex = 4;
            // 
            // dataGridViewKFold
            // 
            this.dataGridViewKFold.AllowUserToAddRows = false;
            this.dataGridViewKFold.AllowUserToDeleteRows = false;
            this.dataGridViewKFold.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKFold.Location = new System.Drawing.Point(200, 3);
            this.dataGridViewKFold.Name = "dataGridViewKFold";
            this.dataGridViewKFold.ReadOnly = true;
            this.dataGridViewKFold.Size = new System.Drawing.Size(565, 394);
            this.dataGridViewKFold.TabIndex = 3;
            // 
            // NudFold
            // 
            this.NudFold.Location = new System.Drawing.Point(54, 22);
            this.NudFold.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NudFold.Name = "NudFold";
            this.NudFold.Size = new System.Drawing.Size(120, 20);
            this.NudFold.TabIndex = 2;
            this.NudFold.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btnKfold
            // 
            this.btnKfold.Location = new System.Drawing.Point(7, 132);
            this.btnKfold.Name = "btnKfold";
            this.btnKfold.Size = new System.Drawing.Size(75, 23);
            this.btnKfold.TabIndex = 1;
            this.btnKfold.Text = "K-Fold";
            this.btnKfold.UseVisualStyleBackColor = true;
            this.btnKfold.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblFold
            // 
            this.lblFold.AutoSize = true;
            this.lblFold.Location = new System.Drawing.Point(4, 24);
            this.lblFold.Name = "lblFold";
            this.lblFold.Size = new System.Drawing.Size(41, 13);
            this.lblFold.TabIndex = 0;
            this.lblFold.Text = "Folders";
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
            this.tabKmeans.ResumeLayout(false);
            this.tabKmeans.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIteraciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numClusters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClusters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKM)).EndInit();
            this.tabOneR.ResumeLayout(false);
            this.tabOneR.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudVecinosKFold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKFold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFold)).EndInit();
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
        private System.Windows.Forms.Button btnKMeans;
        private System.Windows.Forms.DataGridView dataGridViewClusters;
        private System.Windows.Forms.DataGridView dataGridViewKM;
        private System.Windows.Forms.ComboBox distanciaBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numIteraciones;
        private System.Windows.Forms.NumericUpDown numClusters;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewKFold;
        private System.Windows.Forms.NumericUpDown NudFold;
        private System.Windows.Forms.Button btnKfold;
        private System.Windows.Forms.Label lblFold;
        private System.Windows.Forms.ComboBox cmboxTargetKFold;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioBtnEuclidianaKfold;
        private System.Windows.Forms.NumericUpDown NudVecinosKFold;
        private System.Windows.Forms.Label lblVecinosKfold;
        private System.Windows.Forms.RadioButton radioBtnManhattanKfold;
        private System.Windows.Forms.Button btnHoldOut;
        private System.Windows.Forms.Label lblResultados;
        private System.Windows.Forms.Label lblresultado;
    }
}