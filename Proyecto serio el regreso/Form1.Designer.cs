namespace Proyecto_serio_el_regreso
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmBoxColumnas = new System.Windows.Forms.ComboBox();
            this.lblTipoDato = new System.Windows.Forms.Label();
            this.cmboxDatos = new System.Windows.Forms.ComboBox();
            this.lblRegex = new System.Windows.Forms.Label();
            this.txbRegex = new System.Windows.Forms.TextBox();
            this.btnActualizarColumna = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnAgregarInstancia = new System.Windows.Forms.Button();
            this.btnEliminarAtributo = new System.Windows.Forms.Button();
            this.btnEliminarSeleccionado = new System.Windows.Forms.Button();
            this.btnAgregarColumna = new System.Windows.Forms.Button();
            this.lblCantInstancias = new System.Windows.Forms.Label();
            this.lblValoresFaltantes = new System.Windows.Forms.Label();
            this.lblCantAtributos = new System.Windows.Forms.Label();
            this.txbNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tratamientoDeLosDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analisisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.univariableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bivariableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aprendizajeAutomaticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.knnYKmeansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxTablas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sentenciaBox = new System.Windows.Forms.TextBox();
            this.enviarButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(277, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(578, 412);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // cmBoxColumnas
            // 
            this.cmBoxColumnas.FormattingEnabled = true;
            this.cmBoxColumnas.Location = new System.Drawing.Point(862, 60);
            this.cmBoxColumnas.Name = "cmBoxColumnas";
            this.cmBoxColumnas.Size = new System.Drawing.Size(194, 21);
            this.cmBoxColumnas.TabIndex = 3;
            this.cmBoxColumnas.SelectedIndexChanged += new System.EventHandler(this.cmBoxColumnas_SelectedIndexChanged);
            // 
            // lblTipoDato
            // 
            this.lblTipoDato.AutoSize = true;
            this.lblTipoDato.Location = new System.Drawing.Point(862, 139);
            this.lblTipoDato.Name = "lblTipoDato";
            this.lblTipoDato.Size = new System.Drawing.Size(67, 13);
            this.lblTipoDato.TabIndex = 4;
            this.lblTipoDato.Text = "Tipo de dato";
            // 
            // cmboxDatos
            // 
            this.cmboxDatos.FormattingEnabled = true;
            this.cmboxDatos.Location = new System.Drawing.Point(862, 156);
            this.cmboxDatos.Name = "cmboxDatos";
            this.cmboxDatos.Size = new System.Drawing.Size(121, 21);
            this.cmboxDatos.TabIndex = 5;
            // 
            // lblRegex
            // 
            this.lblRegex.AutoSize = true;
            this.lblRegex.Location = new System.Drawing.Point(862, 184);
            this.lblRegex.Name = "lblRegex";
            this.lblRegex.Size = new System.Drawing.Size(93, 13);
            this.lblRegex.TabIndex = 6;
            this.lblRegex.Text = "Expresion Regular";
            // 
            // txbRegex
            // 
            this.txbRegex.Location = new System.Drawing.Point(862, 201);
            this.txbRegex.Name = "txbRegex";
            this.txbRegex.Size = new System.Drawing.Size(121, 20);
            this.txbRegex.TabIndex = 7;
            // 
            // btnActualizarColumna
            // 
            this.btnActualizarColumna.Location = new System.Drawing.Point(908, 238);
            this.btnActualizarColumna.Name = "btnActualizarColumna";
            this.btnActualizarColumna.Size = new System.Drawing.Size(75, 23);
            this.btnActualizarColumna.TabIndex = 8;
            this.btnActualizarColumna.Text = "Actualizar columna";
            this.btnActualizarColumna.UseVisualStyleBackColor = true;
            this.btnActualizarColumna.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(77, 415);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(127, 24);
            this.btnInfo.TabIndex = 9;
            this.btnInfo.Text = "Informacion";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnAgregarInstancia
            // 
            this.btnAgregarInstancia.Location = new System.Drawing.Point(12, 385);
            this.btnAgregarInstancia.Name = "btnAgregarInstancia";
            this.btnAgregarInstancia.Size = new System.Drawing.Size(127, 24);
            this.btnAgregarInstancia.TabIndex = 11;
            this.btnAgregarInstancia.Text = "Agregar Instancia";
            this.btnAgregarInstancia.UseVisualStyleBackColor = true;
            this.btnAgregarInstancia.Click += new System.EventHandler(this.btnAgregarInstancia_Click);
            // 
            // btnEliminarAtributo
            // 
            this.btnEliminarAtributo.Location = new System.Drawing.Point(144, 355);
            this.btnEliminarAtributo.Name = "btnEliminarAtributo";
            this.btnEliminarAtributo.Size = new System.Drawing.Size(127, 24);
            this.btnEliminarAtributo.TabIndex = 12;
            this.btnEliminarAtributo.Text = "Eliminar atributo";
            this.btnEliminarAtributo.UseVisualStyleBackColor = true;
            this.btnEliminarAtributo.Click += new System.EventHandler(this.btnEliminarAtributo_Click);
            // 
            // btnEliminarSeleccionado
            // 
            this.btnEliminarSeleccionado.Location = new System.Drawing.Point(12, 355);
            this.btnEliminarSeleccionado.Name = "btnEliminarSeleccionado";
            this.btnEliminarSeleccionado.Size = new System.Drawing.Size(127, 24);
            this.btnEliminarSeleccionado.TabIndex = 13;
            this.btnEliminarSeleccionado.Text = "Eliminar seleccionado";
            this.btnEliminarSeleccionado.UseVisualStyleBackColor = true;
            this.btnEliminarSeleccionado.Click += new System.EventHandler(this.btnEliminarSeleccionado_Click);
            // 
            // btnAgregarColumna
            // 
            this.btnAgregarColumna.Location = new System.Drawing.Point(144, 385);
            this.btnAgregarColumna.Name = "btnAgregarColumna";
            this.btnAgregarColumna.Size = new System.Drawing.Size(127, 24);
            this.btnAgregarColumna.TabIndex = 18;
            this.btnAgregarColumna.Text = "Agregar Columna";
            this.btnAgregarColumna.UseVisualStyleBackColor = true;
            this.btnAgregarColumna.Click += new System.EventHandler(this.btnAgregarColumna_Click);
            // 
            // lblCantInstancias
            // 
            this.lblCantInstancias.AutoSize = true;
            this.lblCantInstancias.Location = new System.Drawing.Point(13, 38);
            this.lblCantInstancias.Name = "lblCantInstancias";
            this.lblCantInstancias.Size = new System.Drawing.Size(120, 13);
            this.lblCantInstancias.TabIndex = 19;
            this.lblCantInstancias.Text = "Cantidad de instancias: ";
            // 
            // lblValoresFaltantes
            // 
            this.lblValoresFaltantes.AutoSize = true;
            this.lblValoresFaltantes.Location = new System.Drawing.Point(13, 133);
            this.lblValoresFaltantes.Name = "lblValoresFaltantes";
            this.lblValoresFaltantes.Size = new System.Drawing.Size(150, 13);
            this.lblValoresFaltantes.TabIndex = 20;
            this.lblValoresFaltantes.Text = "Cantidad de valores faltantes: ";
            // 
            // lblCantAtributos
            // 
            this.lblCantAtributos.AutoSize = true;
            this.lblCantAtributos.Location = new System.Drawing.Point(13, 88);
            this.lblCantAtributos.Name = "lblCantAtributos";
            this.lblCantAtributos.Size = new System.Drawing.Size(113, 13);
            this.lblCantAtributos.TabIndex = 21;
            this.lblCantAtributos.Text = "Cantidad de atributos: ";
            // 
            // txbNombre
            // 
            this.txbNombre.Location = new System.Drawing.Point(862, 106);
            this.txbNombre.Name = "txbNombre";
            this.txbNombre.Size = new System.Drawing.Size(121, 20);
            this.txbNombre.TabIndex = 23;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(862, 89);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(113, 13);
            this.lblNombre.TabIndex = 22;
            this.lblNombre.Text = "Nombre de la columna";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarPropertiesToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // guardarPropertiesToolStripMenuItem
            // 
            this.guardarPropertiesToolStripMenuItem.Name = "guardarPropertiesToolStripMenuItem";
            this.guardarPropertiesToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.guardarPropertiesToolStripMenuItem.Text = "Guardar propiedades";
            this.guardarPropertiesToolStripMenuItem.Click += new System.EventHandler(this.guardarPropertiesToolStripMenuItem_Click);
            // 
            // proyectoToolStripMenuItem
            // 
            this.proyectoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tratamientoDeLosDatosToolStripMenuItem,
            this.analisisToolStripMenuItem,
            this.aprendizajeAutomaticoToolStripMenuItem});
            this.proyectoToolStripMenuItem.Name = "proyectoToolStripMenuItem";
            this.proyectoToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.proyectoToolStripMenuItem.Text = "Proyecto";
            // 
            // tratamientoDeLosDatosToolStripMenuItem
            // 
            this.tratamientoDeLosDatosToolStripMenuItem.Name = "tratamientoDeLosDatosToolStripMenuItem";
            this.tratamientoDeLosDatosToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.tratamientoDeLosDatosToolStripMenuItem.Text = "Tratamiento de los datos";
            // 
            // analisisToolStripMenuItem
            // 
            this.analisisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.univariableToolStripMenuItem,
            this.bivariableToolStripMenuItem});
            this.analisisToolStripMenuItem.Name = "analisisToolStripMenuItem";
            this.analisisToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.analisisToolStripMenuItem.Text = "Analisis";
            // 
            // univariableToolStripMenuItem
            // 
            this.univariableToolStripMenuItem.Name = "univariableToolStripMenuItem";
            this.univariableToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.univariableToolStripMenuItem.Text = "Univariable";
            this.univariableToolStripMenuItem.Click += new System.EventHandler(this.univariableToolStripMenuItem_Click);
            // 
            // bivariableToolStripMenuItem
            // 
            this.bivariableToolStripMenuItem.Name = "bivariableToolStripMenuItem";
            this.bivariableToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.bivariableToolStripMenuItem.Text = "Bivariable";
            this.bivariableToolStripMenuItem.Click += new System.EventHandler(this.bivariableToolStripMenuItem_Click);
            // 
            // aprendizajeAutomaticoToolStripMenuItem
            // 
            this.aprendizajeAutomaticoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.knnYKmeansToolStripMenuItem});
            this.aprendizajeAutomaticoToolStripMenuItem.Name = "aprendizajeAutomaticoToolStripMenuItem";
            this.aprendizajeAutomaticoToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.aprendizajeAutomaticoToolStripMenuItem.Text = "Aprendizaje Automatico";
            // 
            // knnYKmeansToolStripMenuItem
            // 
            this.knnYKmeansToolStripMenuItem.Name = "knnYKmeansToolStripMenuItem";
            this.knnYKmeansToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.knnYKmeansToolStripMenuItem.Text = "KNN y KMeans";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.proyectoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1056, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Seleccionar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxTablas
            // 
            this.comboBoxTablas.FormattingEnabled = true;
            this.comboBoxTablas.Location = new System.Drawing.Point(12, 239);
            this.comboBoxTablas.Name = "comboBoxTablas";
            this.comboBoxTablas.Size = new System.Drawing.Size(127, 21);
            this.comboBoxTablas.TabIndex = 25;
            this.comboBoxTablas.Text = "--Selecciona tu tabla--";
            this.comboBoxTablas.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Selecciona tu tabla:";
            this.label1.Visible = false;
            // 
            // sentenciaBox
            // 
            this.sentenciaBox.Location = new System.Drawing.Point(277, 460);
            this.sentenciaBox.Name = "sentenciaBox";
            this.sentenciaBox.Size = new System.Drawing.Size(487, 20);
            this.sentenciaBox.TabIndex = 27;
            this.sentenciaBox.Visible = false;
            // 
            // enviarButton
            // 
            this.enviarButton.Location = new System.Drawing.Point(771, 457);
            this.enviarButton.Name = "enviarButton";
            this.enviarButton.Size = new System.Drawing.Size(84, 23);
            this.enviarButton.TabIndex = 28;
            this.enviarButton.Text = "Aceptar";
            this.enviarButton.UseVisualStyleBackColor = true;
            this.enviarButton.Visible = false;
            this.enviarButton.Click += new System.EventHandler(this.enviarButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 446);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Sentencias SQL:";
            this.label3.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 492);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.enviarButton);
            this.Controls.Add(this.sentenciaBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxTablas);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txbNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblCantAtributos);
            this.Controls.Add(this.lblValoresFaltantes);
            this.Controls.Add(this.lblCantInstancias);
            this.Controls.Add(this.btnAgregarColumna);
            this.Controls.Add(this.btnEliminarSeleccionado);
            this.Controls.Add(this.btnEliminarAtributo);
            this.Controls.Add(this.btnAgregarInstancia);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnActualizarColumna);
            this.Controls.Add(this.txbRegex);
            this.Controls.Add(this.lblRegex);
            this.Controls.Add(this.cmboxDatos);
            this.Controls.Add(this.lblTipoDato);
            this.Controls.Add(this.cmBoxColumnas);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmBoxColumnas;
        private System.Windows.Forms.Label lblTipoDato;
        private System.Windows.Forms.ComboBox cmboxDatos;
        private System.Windows.Forms.Label lblRegex;
        private System.Windows.Forms.TextBox txbRegex;
        private System.Windows.Forms.Button btnActualizarColumna;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnAgregarInstancia;
        private System.Windows.Forms.Button btnEliminarAtributo;
        private System.Windows.Forms.Button btnEliminarSeleccionado;
        private System.Windows.Forms.Button btnAgregarColumna;
        private System.Windows.Forms.Label lblCantInstancias;
        private System.Windows.Forms.Label lblValoresFaltantes;
        private System.Windows.Forms.Label lblCantAtributos;
        private System.Windows.Forms.TextBox txbNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proyectoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tratamientoDeLosDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analisisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem univariableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bivariableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aprendizajeAutomaticoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem knnYKmeansToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxTablas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sentenciaBox;
        private System.Windows.Forms.Button enviarButton;
        private System.Windows.Forms.Label label3;
    }
}

