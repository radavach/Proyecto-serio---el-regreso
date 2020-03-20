namespace Proyecto_serio_el_regreso
{
    partial class Form3
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
            this.lblTexto = new System.Windows.Forms.Label();
            this.cmBoxDato1 = new System.Windows.Forms.ComboBox();
            this.cmBoxDato2 = new System.Windows.Forms.ComboBox();
            this.btnAnalisis = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblResultado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTexto
            // 
            this.lblTexto.AutoSize = true;
            this.lblTexto.Location = new System.Drawing.Point(13, 13);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(295, 13);
            this.lblTexto.TabIndex = 0;
            this.lblTexto.Text = "Selecciona los atributos a comparar (Nominales o Númericos)";
            // 
            // cmBoxDato1
            // 
            this.cmBoxDato1.FormattingEnabled = true;
            this.cmBoxDato1.Location = new System.Drawing.Point(13, 44);
            this.cmBoxDato1.Name = "cmBoxDato1";
            this.cmBoxDato1.Size = new System.Drawing.Size(121, 21);
            this.cmBoxDato1.TabIndex = 1;
            // 
            // cmBoxDato2
            // 
            this.cmBoxDato2.FormattingEnabled = true;
            this.cmBoxDato2.Location = new System.Drawing.Point(187, 43);
            this.cmBoxDato2.Name = "cmBoxDato2";
            this.cmBoxDato2.Size = new System.Drawing.Size(121, 21);
            this.cmBoxDato2.TabIndex = 2;
            // 
            // btnAnalisis
            // 
            this.btnAnalisis.Location = new System.Drawing.Point(346, 43);
            this.btnAnalisis.Name = "btnAnalisis";
            this.btnAnalisis.Size = new System.Drawing.Size(75, 23);
            this.btnAnalisis.TabIndex = 3;
            this.btnAnalisis.Text = "Analizar";
            this.btnAnalisis.UseVisualStyleBackColor = true;
            this.btnAnalisis.Click += new System.EventHandler(this.btnAnalisis_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(444, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(344, 425);
            this.dataGridView1.TabIndex = 4;
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(13, 92);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(0, 13);
            this.lblResultado.TabIndex = 5;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAnalisis);
            this.Controls.Add(this.cmBoxDato2);
            this.Controls.Add(this.cmBoxDato1);
            this.Controls.Add(this.lblTexto);
            this.Name = "Form3";
            this.Text = "Form3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.ComboBox cmBoxDato1;
        private System.Windows.Forms.ComboBox cmBoxDato2;
        private System.Windows.Forms.Button btnAnalisis;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblResultado;
    }
}