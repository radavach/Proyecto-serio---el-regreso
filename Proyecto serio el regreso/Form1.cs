using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace Proyecto_serio_el_regreso
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tipos_dato = new string[]{"Numerico", "Nominal", "Binario Asimetrico", "Binario Simetrico", "Texto"};
            cant_instancias = 0;
            cant_columnas = 0;
            datoTexto = "";
            //rellenarCombobox();
            tablaSeleccionada = false;
        }

        private int cant_instancias;
        private int cant_columnas;
        private string datoTexto;
        private string []tipos_dato;
        private Dictionary<string, int> valores_faltantes;
        private Dictionary<string, KeyValuePair<string, string>> encabezado;
        private Dictionary<string, List<string>> instancias;
        private OpenFileDialog archivo;
        //direccion momentanea del archivo properties
        private OpenFileDialog properties;
        private KeyValuePair<string,string> tipoTexto = new KeyValuePair<string, string>("Texto", "/b(?<word>)/b");
        private bool archivoTieneMysql = false;
        List<string> tipos = new List<string>();
        List<string> valoresFueraDeDominio = new List<string>();
        Dictionary<string, List<KeyValuePair<int, string>>> valoresFueraDeDominio2 = new Dictionary<string, List<KeyValuePair<int, string>>>();
        private string server;
        private string database;
        private string uid;
        private string password;
        private MySqlConnection connection;
        private MySqlDataAdapter mySqlDataAdapter;
        private bool tablaSeleccionada;

        private Dictionary<string, int> valoresFaltantes()
        {
            Dictionary<string, int> lista = new Dictionary<string, int>();

            foreach(string columna in encabezado.Keys)
            {

                lista[columna] = instancias[columna].FindAll(x => x.Equals("?")).Count();
            }

            return lista;
        }

        private void recalcularValores()
        {
            cant_instancias = dataGridView1.RowCount;
            cant_columnas = encabezado.Count;
            valores_faltantes = valoresFaltantes();

            int cant_faltantes = valores_faltantes.Values.Sum();

            lblCantInstancias.Text = ("Cantidad de instancias:\n" + cant_instancias);
            lblCantAtributos.Text = ("Cantidad de atributos:\n" + cant_columnas);
            lblValoresFaltantes.Text = ("Cantidad de valores faltanes:\n" + cant_faltantes + "(" + Convert.ToDecimal((cant_faltantes * 100) / (cant_instancias * cant_columnas)).ToString() + "%" + ")");

            if (archivoTieneMysql == false)
            {
                verificarDominios();
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog archivo = new OpenFileDialog
            {
                Filter = "Archivo separado por comas (*.csv)|*.csv|Archivo data(*.data)|*.data|Archivo propiedades(*.properties)|*.properties",
                Title = "Indica el archivo que deseas abrir"
            };
            if (archivo.ShowDialog().Equals(DialogResult.OK))
            {
                string extension = Path.GetExtension(archivo.FileName);
                instancias = new Dictionary<string, List<string>>();
                encabezado = new Dictionary<string, KeyValuePair<string, string>>();
                cant_instancias = 0;
                cmboxDatos.Items.AddRange(tipos_dato);

                if (extension.Equals(".csv"))
                {
                    cargarCsv(archivo.FileName);
                }
                else if(extension.Equals(".properties"))
                {
                    cargarProperties(archivo.FileName);
                }
                this.archivo = archivo;
                this.properties = archivo;
                if (archivoTieneMysql == false)
                {
                    cargarGrid();
                    recalcularValores();
                }
            }
            else {
                MessageBox.Show("El archivo no se abrio");
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string extension = Path.GetExtension(archivo.FileName);

                if (extension.Equals(".csv"))
                {
                    guardarCsv(archivo.FileName);
                }
                else if(extension.Equals(".data"))
                {
                    //pendiente
                }
            }
            catch(System.NullReferenceException)
            {
                MessageBox.Show("Aún no has abierto archivo");
            }
            

        }
        
        //Guardar propiedades pendiente
        private void guardarPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cargarCsv(string direccionArchivo)
        {
            MessageBox.Show("Se cargara el archivo con la direccion " + direccionArchivo);
            StreamReader leerCsv = new StreamReader(direccionArchivo);
            
            if (!leerCsv.EndOfStream)
            {
                foreach(string columna in leerCsv.ReadLine().Split(','))
                {
                    encabezado.Add(columna, new KeyValuePair<string, string>(tipoTexto.Key, tipoTexto.Value));
                }

                cant_columnas = encabezado.Count();
                
                while (!leerCsv.EndOfStream)
                {
                    string[] instancia = leerCsv.ReadLine().Split(',');
                    int indice = encabezado.Count - 1;

                    List<string> iterador = encabezado.Keys.ToList();
                    List<string> elementos;

                    cant_instancias++;

                    while(indice >= 0)
                    {
                        try
                        { 
                            for (; indice >= 0;  indice--)
                            {
                                if (instancias.ContainsKey(iterador[indice]))
                                {
                                    elementos = instancias[iterador[indice]];
                                }
                                else
                                {
                                    elementos = new List<string>();
                                    instancias[iterador[indice]] = elementos;
                                }
                                elementos.Add(instancia[indice]);
                            }
                        }
                        catch (System.IndexOutOfRangeException) {
                        
                            if (instancias.ContainsKey(iterador[indice]))
                            {
                                elementos = instancias[iterador[indice]];
                            }
                            else
                            {
                                elementos = new List<string>();
                                instancias[iterador[indice]] = elementos;
                            }
                            elementos.Add("?");

                            indice--;
                        }
                    }
                }

                valores_faltantes = valoresFaltantes();
            }
            else
            {
                MessageBox.Show("Es el final del archivo");
            }
            leerCsv.Close();
        }

        private void cargarProperties(string direccionArchivo)
        {
            MessageBox.Show("Se cargara el archivo con la direccion " + direccionArchivo);
            //Dictionary<string, List<string>> instancias = new Dictionary<string, List<string>>();

            StreamReader streamReader = new StreamReader(direccionArchivo);

            string nombreColumna;
            string linea = streamReader.ReadLine();
            string descripcion="";
            string tempDesc = "";
            bool existe = linea.Contains("@data");
            bool existeMysql = linea.Contains("@mysql");
            //string tempServer = "@server=";
            //linea = streamReader.ReadLine();

            //Primero lee el archivo para buscar el tag '@mysql'
            while (!streamReader.EndOfStream)
            {
                if (linea.Contains("%%"))
                {
                    tempDesc = linea.Replace("%% ", "");
                    descripcion = descripcion + tempDesc;
                }

                linea = streamReader.ReadLine();
                existeMysql = linea.Contains("@mysql");


                if (linea.Contains("@mysql"))
                {
                    //se activa la bandera cuando es encontrado el tag
                    archivoTieneMysql = true;
                }

                if (archivoTieneMysql == true)
                {
                    if (linea.Contains("@server") == true)
                    {
                        server = linea.Substring(linea.IndexOf('=')+1);
                        
                    }

                    if (linea.Contains("@database") == true)
                    {
                        database = linea.Substring(linea.IndexOf('=') + 1);
                        
                    }

                    if (linea.Contains("@uid") == true)
                    {
                        uid = linea.Substring(linea.IndexOf('=') + 1);
                       
                    }

                    if (linea.Contains("@password") == true)
                    {
                        password = linea.Substring(linea.IndexOf('=') + 1);
                        
                    }
                }
                //labelDescripcion.Text = descripcion;
            }
            
            if (archivoTieneMysql==true)
            {
                labelDescripcion.Text = descripcion;
                rellenarCombobox();
            }

            //si no se encontró el tag '@mysql'
            else
            {
                //se vuelve a leer el archivo desde el inicio
                streamReader.DiscardBufferedData();
                streamReader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
                tempDesc = "";
                descripcion = "";
                //se obtiene el encabezado
                while (existe != true)
                {
                    
                    if (linea.Contains("%%"))
                    {
                        tempDesc = linea.Replace("%% ", "");
                        descripcion = descripcion + tempDesc;
                        //descripcion = tempDesc + Environment.NewLine;

                    }
                    //descripcion = descripcion + tempDesc;

                    linea = streamReader.ReadLine();
                    existe = linea.Contains("@data");
                   

                    if (linea.Contains("@attribute"))
                    {

                        if (linea.Contains("["))
                        {
                            //se obtiene la expresión regular
                            string domNum = @"^" + linea.Substring(linea.IndexOf('[')) + @"$";
                            //se limpia la cadena
                            nombreColumna = linea.Substring(0, linea.IndexOf("numeric"));
                            nombreColumna = nombreColumna.Replace("@attribute", "");
                            encabezado.Add(nombreColumna, new KeyValuePair<string, string>("Numerico", domNum));
                        }
                        else if (linea.Contains("("))
                        {
                            string domNom = @"\b" + linea.Substring(linea.IndexOf('(')) + @"\b";
                            nombreColumna = linea.Substring(0, linea.IndexOf("nominal"));
                            nombreColumna = nombreColumna.Replace("@attribute", "");
                            encabezado.Add(nombreColumna, new KeyValuePair<string, string>("Nominal", Regex.Replace(domNom, @"\s+", "")));
                        }
                    }
                    
                }
                labelDescripcion.Text = descripcion;

                //se lee la ruta del .csv dentro del .properties
                linea = streamReader.ReadLine();
                streamReader = new StreamReader(File.OpenRead(linea));

                while (!streamReader.EndOfStream)
                {
                    string[] instancia = streamReader.ReadLine().Split(',');
                    int indice = encabezado.Count - 1;

                    List<string> iterador = encabezado.Keys.ToList();
                    List<string> elementos;

                    cant_instancias++;

                    while (indice >= 0)
                    {
                        try
                        {
                            for (; indice >= 0; indice--)
                            {
                                if (instancias.ContainsKey(iterador[indice]))
                                {
                                    elementos = instancias[iterador[indice]];
                                }
                                else
                                {
                                    elementos = new List<string>();
                                    instancias[iterador[indice]] = elementos;
                                }
                                elementos.Add(instancia[indice]);
                            }
                        }
                        catch (System.IndexOutOfRangeException)
                        {

                            if (instancias.ContainsKey(iterador[indice]))
                            {
                                elementos = instancias[iterador[indice]];
                            }
                            else
                            {
                                elementos = new List<string>();
                                instancias[iterador[indice]] = elementos;
                            }
                            elementos.Add("?");

                            indice--;
                        }
                    }
                    valores_faltantes = valoresFaltantes();
                }

            }
            //labelDescripcion.Text = descripcion;

            streamReader.Close();
            if(existeMysql)
            {
                rellenarCombobox();
            }
        }

        void verificarDominios()
        {
            int indice = 0;
            valoresFueraDeDominio2 = new Dictionary<string, List<KeyValuePair<int, string>>>();

            while (indice != cant_instancias)
            {
                foreach (string columna in encabezado.Keys)
                {
                    //En encabezado, con columna accedes a los datos de la columna, key es para el tipo de dato y value para la expresion regular
                    Regex regex = new Regex(encabezado[columna].Value);
                    
                    if (!regex.IsMatch(instancias[columna][indice]))
                    {
                        dataGridView1.Rows[indice].Cells[columna].Style.BackColor = Color.Yellow;

                        if (!valoresFueraDeDominio2.ContainsKey(columna))
                        {
                            valoresFueraDeDominio2[columna] = new List<KeyValuePair<int, string>>();
                        }
                        valoresFueraDeDominio2[columna].Add(new KeyValuePair<int, string>(indice, instancias[columna][indice]));
                        
                        valoresFueraDeDominio.Add(instancias[columna][indice].ToString());
                    }
                }
                indice++;
            }

        }



        //Opcion para guardar las instancias como csv
        private void guardarCsv(string direccionArchivo)
        {
            //StreamWriter escribir = new StreamWriter(direccionArchivo);
            StreamWriter escribir = File.AppendText(direccionArchivo);

            int contador = 1;
            foreach(string columna in encabezado.Keys)
            {
                escribir.Write(columna);

                if(encabezado.Keys.Count() > contador)
                {
                    escribir.Write(',');
                }
                else
                {
                    escribir.WriteLine("");
                }
                contador += 1;
            }

            for(int fila = 0; fila < cant_instancias; fila+=1)
            {
                contador = 1;
                foreach (string columna in encabezado.Keys)
                {
                    escribir.Write(instancias[columna].ElementAt(fila));

                    if (encabezado.Keys.Count() > contador)
                    {
                        escribir.Write(',');
                    }
                    else
                    {
                        escribir.WriteLine("");
                    }
                    contador += 1;
                }
            }

            escribir.Close();
        }

        private void actualizarCsv(string accion)
        {
            //Genera la variante del nombre para guardar el archivo
            DateTime time = System.DateTime.Now;
            string direccionArchivo = archivo.FileName;

            string name = Path.GetFileNameWithoutExtension(direccionArchivo);
            string nuevoNombre = time.ToString("yyyyMMdd_HHmmss");

            //Obtiene la direccion de la carpeta para guardar el archivo
            string carpeta = Path.GetDirectoryName(direccionArchivo);

            //Se crea y abre el nuevo archivo
            string direccion = carpeta + "\\" + nuevoNombre;

            //actualiza el log con la accion que se realizo y le pasa el nombre del archivo.
            actualizarLog(time.ToString("yyyyMMdd_HHmmss"), accion);

            guardarCsv(direccion + Path.GetExtension(direccionArchivo));
        }

        private void actualizarLog(string direccion, string accion)
        {
            StreamWriter escribir = File.AppendText(Path.GetDirectoryName(properties.FileName) + "\\" + Path.GetFileNameWithoutExtension(properties.FileName) + ".log");
            escribir.WriteLine(direccion + " => " + accion);
            escribir.Close();
        }

        private void cargarGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            cmBoxColumnas.Items.Clear();
            foreach(string a in encabezado.Keys)
            {
                DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn { HeaderText = a, Name = a, SortMode = DataGridViewColumnSortMode.NotSortable};
                dataGridView1.Columns.Add(columna);

                cmBoxColumnas.Items.Add(a);
            }

            int indice = 0;
            int renglon = 0;

            dataGridView1.Rows.Add(cant_instancias);
            
            while (indice != cant_instancias)
            {
                //renglon = dataGridView1.Rows.Add();
                foreach (string columna in encabezado.Keys)
                {
                    dataGridView1.Rows[renglon].Cells[columna].Value = instancias[columna][indice];
                    if (instancias[columna][indice] == "?")
                    {
                        dataGridView1.Rows[renglon].Cells[columna].Style.BackColor = Color.Red;
                        //valores_faltantes++;
                    }
                }
                indice++;
                renglon++;
            }
            

        }


        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string texto = dataGridView1.Columns[e.ColumnIndex].HeaderText;
            txbNombre.Text = texto;
            txbRegex.Text = encabezado[texto].Value;
            cmboxDatos.SelectedItem = encabezado[texto].Key;
            cmBoxColumnas.SelectedItem = texto;
        }
        
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string texto, textoAnterior;
            try
            {
                texto = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
            catch(System.NullReferenceException)
            {
                texto = datoTexto;
            }

            int columna = e.ColumnIndex, fila = e.RowIndex;

            textoAnterior = instancias[dataGridView1.Columns[e.ColumnIndex].HeaderText][e.RowIndex];
            instancias[dataGridView1.Columns[e.ColumnIndex].HeaderText][e.RowIndex] = texto;

            if(texto == "?")
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
            }
            else
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.WhiteSmoke;
            }

            recalcularValores();
            actualizarCsv("editar valor - " + textoAnterior + " => " + texto);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            List<string> valoresColumnaActuales = new List<string>();
            List<string> valoresColumnaAnteriores = new List<string>();

            string nombre = txbNombre.Text;
            string tipoDato = cmboxDatos.Text;
            string columna = cmBoxColumnas.Text;

            //cargando los valores en una lista para mostrarlos en el mensaje del log
            valoresColumnaAnteriores.Add(columna);
            valoresColumnaAnteriores.Add(encabezado[columna].Key);
            valoresColumnaAnteriores.Add(encabezado[columna].Value);

            valoresColumnaActuales.Add(nombre);
            valoresColumnaActuales.Add(tipoDato);
            valoresColumnaActuales.Add(txbRegex.Text);

            dataGridView1.Columns[cmBoxColumnas.SelectedIndex].HeaderText = nombre;
            dataGridView1.Columns[cmBoxColumnas.SelectedIndex].Name = nombre;

            cmBoxColumnas.Items[cmBoxColumnas.SelectedIndex] = nombre;

            encabezado.Remove(columna);
            encabezado[nombre] = new KeyValuePair<string, string>(tipoDato, txbRegex.Text);


            List<string> instanciaAux = instancias[columna];
            instancias.Remove(columna);
            instancias[nombre] = instanciaAux;

            int faltantesAux = valores_faltantes[columna];
            valores_faltantes.Remove(columna);
            valores_faltantes[nombre] = faltantesAux;

            actualizarCsv("editar columna - " + string.Join("|", valoresColumnaAnteriores) + " => " + string.Join("|", valoresColumnaActuales));
        }

        private void btnInfo_Click(object sender, EventArgs e)//Obteniendo informacion de las instancias
        {
            Dictionary<string,int> valores = valoresFaltantes();
            string info = "";
            foreach (string columna in encabezado.Keys)
            {
                info = info + "\nNombre del atributo: " + columna;
                info += "\nTipo de dato: " + encabezado[columna].Key;
                info += "\nValores faltantes: " + valores[columna] + "(" + Convert.ToDecimal(valores[columna] * 100 / cant_instancias).ToString() + "%" + ")";
                info += "\n\n";
            }
            MessageBox.Show(info);
        }

        private void btnEliminarSeleccionado_Click(object sender, EventArgs e)//Eliminando una instancia
        {
            string mensaje = "Se van a eliminar las instancias seleccionadas ";

            foreach (DataGridViewRow fila in dataGridView1.SelectedRows)
            {
                List<string> atributosInstancia = new List<string>();

                mensaje += fila.Index.ToString() + " ";
                foreach(string columna in encabezado.Keys)
                {
                    atributosInstancia.Add(instancias[columna].ElementAt(fila.Index));
                    instancias[columna].RemoveAt(fila.Index);
                }
                dataGridView1.Rows.RemoveAt(fila.Index);

                recalcularValores();
                actualizarCsv("eliminar instancia - " + string.Join(",", atributosInstancia));
            }
        }

        private void btnEliminarAtributo_Click(object sender, EventArgs e)//Eliminando una columna
        {
            if (string.IsNullOrEmpty(cmBoxColumnas.Text))
            {
                MessageBox.Show("Debes seleccionar la columna a eliminar");
            }
            else
            {
                string columna = cmBoxColumnas.Text;

                if (dataGridView1.Columns.Contains(columna))
                {
                    encabezado.Remove(columna);
                    instancias.Remove(columna);
                    valores_faltantes.Remove(columna);
                    dataGridView1.Columns.Remove(columna);
                    cmBoxColumnas.Items.Remove(columna);

                    txbNombre.Text = "";
                    cmboxDatos.SelectedItem = null;
                    txbRegex.Text = "";
                }

                recalcularValores();
                actualizarCsv("eliminar atributo - " + columna);
            }

        }

        private void btnAgregarInstancia_Click(object sender, EventArgs e)//Crear una nueva instancia de datos
        {
            dataGridView1.Rows.Add();
            foreach(string columna in encabezado.Keys)
            {
                instancias[columna].Add("");
            }
            recalcularValores();
        }

        //pendiente se debe preguntar con que valor rellenar por defecto? si es asi, habilitar en una ventana emergente
        private void btnAgregarColumna_Click(object sender, EventArgs e)//Creando una nueva columna
        {
            //pendiente revalidar el contenido de la nueva columna con la expresion regular
            string columna = "columnaN";
            encabezado[columna] = new KeyValuePair<string, string>(tipoTexto.Key, tipoTexto.Value);
            instancias[columna] = Enumerable.Repeat("?", cant_instancias).Select(x => x.ToString()).ToList();
            valores_faltantes[columna] = valoresFaltantes().Count();

            cargarGrid();
            recalcularValores();
        }

        private void univariableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this, encabezado, instancias, valores_faltantes, cant_instancias, cant_columnas, tipos_dato);
            form2.Show();
        }

        private void bivariableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(this, encabezado, instancias);
            form3.Show();
        }

        private void cmBoxColumnas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            if (combo.Focused)
            {
                string texto = cmBoxColumnas.Text;
                txbNombre.Text = texto;
                txbRegex.Text = encabezado[texto].Value;
                cmboxDatos.SelectedItem = encabezado[texto].Key;
            }
        }
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void rellenarCombobox()
        {
            button1.Show();
            comboBoxTablas.Show();
            label1.Show();
            sentenciaBox.Show();
            enviarButton.Show();
            label3.Show();
            //server = "localhost";
            //database = "hotel";
            //uid = "root";
            //password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
            string cmdstr = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA='"+database+"';";
            DataTable dt = new DataTable();
            MySqlDataAdapter sda = new MySqlDataAdapter(cmdstr, connection);
            try
            {
                sda.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    comboBoxTablas.Items.Add(row[0]);
                }
                MessageBox.Show("Se ha cargado correctamente la base de datos");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CloseConnection();
        }

        private void cargarBase(string tabla, string sentencia)
        {
            //server = "localhost";
            //database = "hotel";
            //uid = "root";
            //password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

            if (this.OpenConnection() == true)
            {
                mySqlDataAdapter = new MySqlDataAdapter(sentencia, connection);
                DataSet DS = new DataSet();
                try
                {
                    mySqlDataAdapter.Fill(DS);
                    dataGridView1.DataSource = DS.Tables[0];
                    //close connection
                    this.CloseConnection(); ;

                    encabezado = new Dictionary<string, KeyValuePair<string, string>>();
                    instancias = new Dictionary<string, List<string>>();

                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        string columna = dataGridView1.Columns[i].Name;
                        encabezado.Add(columna, new KeyValuePair<string, string>(tipoTexto.Key, tipoTexto.Value));
                        cmBoxColumnas.Items.Add(columna);

                        //instancias[columna] = DS.Tables[0].AsEnumerable().Select(a => a.Field<string>(columna).ToString()).ToList();
                        instancias[columna] = dataGridView1.Rows.Cast<DataGridViewRow>().Select(a => a.Cells[i].Value.ToString()).ToList();
                    }

                    recalcularValores();
                    cmboxDatos.Items.AddRange(tipos_dato);
                    valores_faltantes = valoresFaltantes();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxTablas.SelectedIndex != -1)
            {
                string tabla = comboBoxTablas.SelectedItem.ToString();
                dataGridView1.DataSource = null;
                encabezado = null;
                cargarBase(tabla, "select * from " + tabla);
            }
            else
            {
                MessageBox.Show("No se ha seleccioando ninguna tabla");
            }
        }

        private void enviarButton_Click(object sender, EventArgs e)
        {
            if(comboBoxTablas.SelectedIndex != -1)
            {
                dataGridView1.DataSource = null;
                encabezado = null;
                string tabla = comboBoxTablas.SelectedItem.ToString();
                cargarBase(tabla, sentenciaBox.Text);
            }
            else
            {
                MessageBox.Show("No se ha seleccioando ninguna tabla");
            }
        }
    }
}
