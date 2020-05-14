using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Este form dentro de mi entendimiento debera usarse para algoritmos de aprendizaje automatico, dentro de los cuales están Zero-R One-R Naive-Bayes K-Means K-NN

namespace Proyecto_serio_el_regreso
{
    public partial class Form4 : Form
    {
        private Dictionary<string, KeyValuePair<string, string>> encabezado;
        private Dictionary<string, List<string>> instancias;
        private int cant_instancias;
        private int cant_columnas=0;
        private Form1 form1;

        public Form4(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            form1.Hide();
        }

        public Form4(Form1 form1, Dictionary<string, KeyValuePair<string, string>> encabezado, Dictionary<string, List<string>> instancias, int cant_instancias) : this(form1)
        {
            this.encabezado = encabezado;
            this.instancias = instancias;
            this.cant_instancias = cant_instancias;

            iniciarNumercUpDown();
            iniciarComboBox();
            limpiarDataGrid();
        }

        //
        private void iniciarNumercUpDown()
        {
            NudVecinos.Maximum = cant_instancias;
        }

        private void iniciarComboBox()
        {
            cmBoxColumna.Items.AddRange(encabezado.Keys.ToArray());
        }

        private void cargarDataGrid()
        {
            //Lamentablemente se tienen que agregar las columas primero para agregar el contenido de las celdas
            foreach (string columna in encabezado.Keys)
            {
                DataGridViewTextBoxColumn dataGridColumnaKNN = new DataGridViewTextBoxColumn
                {
                    Name = columna,
                    HeaderText = columna,
                    SortMode = DataGridViewColumnSortMode.NotSortable
                };
                DataGridViewTextBoxColumn dataGridColumnaInstancia = new DataGridViewTextBoxColumn
                {
                    Name = columna,
                    HeaderText = columna,
                    SortMode = DataGridViewColumnSortMode.NotSortable
                };

                dataGridViewInstancia.Columns.Add(dataGridColumnaInstancia);
                dataGridViewKNN.Columns.Add(dataGridColumnaKNN);
            }

            dataGridViewKNN.Rows.Add(cant_instancias);

            foreach (string columna in encabezado.Keys)
            {
                cant_columnas++;
                for (int i = 0; i < cant_instancias; i++)
                {
                    dataGridViewKNN.Rows[i].Cells[columna].Value = instancias[columna][i];
                }
            }

            dataGridViewInstancia.Rows.Add(1);
        }

        private void limpiarDataGrid()
        {
            while (dataGridViewKNN.Columns.Count > 0)
            {
                dataGridViewKNN.Columns.RemoveAt(0);
            }
            while (dataGridViewInstancia.Columns.Count > 0)
            {
                dataGridViewInstancia.Columns.RemoveAt(0);
            }
            dataGridViewInstancia.Rows.Clear();
            dataGridViewKNN.Rows.Clear();
            cant_columnas = 0;
            cargarDataGrid();
        }

        /// <summary>Crea una lista con las distancias entre la lista de instancias de prueba y la instancia para la prueba <para>Los valores no sufren cambios durante la ejecucion de la funcion</para></summary>
        /// <param name="encabezado">Es un diccionario que contiene en el key el nombre de la columna, el value es un KeyValuePair con el tipo de dato y la expresion general</param>
        /// <param name="instancias">Son las instancias con las que se va a realizar la comparacion en distancia, puede recibir los valores normalizados</param>
        /// <param name="instancia_prueba">Es la instancia contra la que se va a comparar la distancia, puede recibir los valores normalizados</param>
        /// <param name="cantidad_instancias">El total de instancias que contiene la variable, instancias</param>
        /// <param name="potencia">Hace referencia a la formula para las distancias, 2 para euclidiana y 1 para manhattan</param>
        private List<KeyValuePair<int, double>> kNearest(Dictionary<string, KeyValuePair<string, string>> encabezado, Dictionary<string, List<string>> instancias, Dictionary<string, string> instancia_prueba, int cantidad_instancias, int potencia)
        {
            List<KeyValuePair<int, double>> resultados = new List<KeyValuePair<int, double>>();

            for (int indice = 0; indice < cantidad_instancias; indice++)
            {
                double distancia_total = 0;
                double distancia_instancias = 0;
                foreach (string columna in encabezado.Keys)
                {
                    if (encabezado[columna].Key == "Nominal" || encabezado[columna].Key == "Binario Asimetrico" ||
                            encabezado[columna].Key == "Binario Simetrico")
                    {
                        distancia_total += (instancias[columna][indice] == instancia_prueba[columna]) ? 0 : 1;
                    }
                    else if (encabezado[columna].Key == "Numerico")
                    {
                        double.TryParse(instancias[columna][indice], out double valor1);
                        double.TryParse(instancia_prueba[columna], out double valor2);

                        valor1 = Math.Abs(valor1);
                        valor2 = Math.Abs(valor2);

                        distancia_instancias += Math.Pow(Math.Abs(valor1 - valor2), potencia);
                    }
                }
                distancia_total = Convert.ToDouble(distancia_total) + Math.Pow(distancia_instancias, 1 / Convert.ToDouble(potencia)); 
                resultados.Add(new KeyValuePair<int, double>(indice, distancia_total));
            }

            resultados.Sort((a, b) => {
                int result = a.Value.CompareTo(b.Value);
                return result == 0 ? b.Value.CompareTo(a.Value) : result;
            });

            return resultados;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (cant_instancias <= 1)
            {
                MessageBox.Show("La cantidad de instancias para el analisis es invalida");
            }
            else
            {
                iniciarKNN();
            }
        }

        private void btnIniciarZeroR_Click(object sender, EventArgs e)
        {
            string col_seleccionada;
            string valor_asignar;

            dataGridViewKNN.ClearSelection();

            if (string.IsNullOrEmpty(cmBoxColumna.Text))
            {
                MessageBox.Show("Debes seleccionar la columna a obtener (target)", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                col_seleccionada = cmBoxColumna.Text;
                if (dataGridViewKNN.Columns.Contains("Distancia"))
                {
                    dataGridViewKNN.Columns.Remove("Distancia");
                }

                valor_asignar = zeroR_valor(this.encabezado, this.instancias, col_seleccionada);

                dataGridViewInstancia.Rows[0].Cells[col_seleccionada].Value = valor_asignar;
            }
        }

        private void btnIniciarOneR_Click(object sender, EventArgs e)
        {
            string valor_asignar;
            string col_seleccionada;

            if (string.IsNullOrEmpty(cmBoxColumna.Text))
            {
                MessageBox.Show("Debes seleccionar la columna a obtener (target)", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                col_seleccionada = cmBoxColumna.Text;
                if (dataGridViewKNN.Columns.Contains("Distancia"))
                {
                    dataGridViewKNN.Columns.Remove("Distancia");
                }

                Dictionary<string, KeyValuePair<string, string>> encabezado = new Dictionary<string, KeyValuePair<string, string>>();
                Dictionary<string, List<string>> instancias = new Dictionary<string, List<string>>();
                Dictionary<string, string> instancia_prueba = new Dictionary<string, string>();

                foreach(KeyValuePair<string, KeyValuePair<string,string>> columna in this.encabezado)
                {
                    //Version 1. Solo toma en cuenta las columnas nominales (aunque la funcion automaticamente detecta las nominales)
                    //pero no diferencia si la celda esta vacia...
                    //if(columna.Value.Key == "Nominal")
                    //{
                    //    if(col_seleccionada != columna.Key)
                    //    { 
                    //        encabezado[columna.Key] = new KeyValuePair<string, string>(columna.Value.Key, columna.Value.Value);
                    //        instancia_prueba[columna.Key] = dataGridViewInstancia[columna.Key, 0].Value.ToString();
                    //    }
                    //    instancias[columna.Key] = new List<string>(this.instancias[columna.Key]);
                    //}

                    //Version 2. Toma en cuenta todas las celdas que no estan vacias
                    if(col_seleccionada == columna.Key)
                    {
                        encabezado[columna.Key] = new KeyValuePair<string, string>(columna.Value.Key, columna.Value.Value);
                        instancias[columna.Key] = new List<string>(this.instancias[columna.Key]);
                    }
                    else if(dataGridViewInstancia.Rows[0].Cells[columna.Key].Value != null)
                    {
                        encabezado[columna.Key] = new KeyValuePair<string, string>(columna.Value.Key, columna.Value.Value);
                        instancias[columna.Key] = new List<string>(this.instancias[columna.Key]);
                        instancia_prueba[columna.Key] = dataGridViewInstancia.Rows[0].Cells[columna.Key].Value.ToString();
                    }
                }

                valor_asignar = oneR_valor(encabezado, instancias, instancia_prueba, col_seleccionada, cant_instancias);

                dataGridViewInstancia.Rows[0].Cells[col_seleccionada].Value = valor_asignar;
            }
        }

        private void iniciarKNN()
        {
            Dictionary<string, KeyValuePair<string, string>> encabezado = new Dictionary<string, KeyValuePair<string, string>>();
            Dictionary<string, string> instancia_prueba = new Dictionary<string, string>();
            Dictionary<string, List<string>> instancias = new Dictionary<string, List<string>>();
            string col_seleccionada = null;

            int potencia = 0;

            if (radiobtnEuclidiana.Checked)
            {
                potencia = 2;
            }
            else if (radiobtnManhattan.Checked)
            {
                potencia = 1;
            }

            dataGridViewKNN.ClearSelection();

            if(!string.IsNullOrEmpty(cmBoxColumna.Text))
            {
                col_seleccionada = cmBoxColumna.Text;
            }

            foreach (var columna in this.encabezado)
            {
                if(col_seleccionada == columna.Key)
                {
                    continue;
                }
                if(dataGridViewInstancia.Rows[0].Cells[columna.Key].Value != null)
                {
                    encabezado[columna.Key] = new KeyValuePair<string,string>(columna.Value.Key, columna.Value.Value);
                    instancias[columna.Key] = new List<string>(this.instancias[columna.Key]);
                    instancia_prueba[columna.Key] = dataGridViewInstancia.Rows[0].Cells[columna.Key].Value.ToString();
                }
            }

            List<KeyValuePair<int,double>> distancias = kNearest(encabezado, instancias, instancia_prueba, cant_instancias, potencia);

            if(!dataGridViewKNN.Columns.Contains("Distancia"))
            {
                DataGridViewTextBoxColumn col_distancia = new DataGridViewTextBoxColumn
                {
                    Name = "Distancia",
                    HeaderText = "Distancia",
                    SortMode = DataGridViewColumnSortMode.NotSortable
                };

                dataGridViewKNN.Columns.Add(col_distancia);
            }

            foreach (KeyValuePair<int,double> distancia in distancias)
            {
                dataGridViewKNN.Rows[distancia.Key].Cells["Distancia"].Value = distancia.Value;
            }

            string valor_asignar = knn_valor(encabezado, instancias, cant_instancias, instancia_prueba, Decimal.ToInt32(NudVecinos.Value), col_seleccionada, 2, this.encabezado, this.instancias, distancias);

            for (int i = 0; i < NudVecinos.Value; i++)
            {
                dataGridViewKNN.Rows[distancias[i].Key].Selected = true;
            }
            dataGridViewInstancia.Rows[0].Cells[col_seleccionada].Value = valor_asignar;
        }

        private string knn_valor(Dictionary<string, KeyValuePair<string,string>> encabezado_calculo, Dictionary<string, List<string>> instancias_calculo,
                int cant_instancias, Dictionary<string, string> instancia_prueba, int cant_vecinos, string col_seleccionada, int potencia,
                Dictionary<string, KeyValuePair<string, string>> encabezado = null, Dictionary<string, List<string>> instancias = null,
                List<KeyValuePair<int, double>> distancias = null)
        {
            if(encabezado == null)
            {
                encabezado = encabezado_calculo;
            }
            if(instancias == null)
            {
                instancias = instancias_calculo;
            }
            if(distancias == null)
            { 
                distancias = kNearest(encabezado_calculo, instancias_calculo, instancia_prueba, cant_instancias, potencia);
            }

            string valor_asignar = "";
            if (!string.IsNullOrEmpty(col_seleccionada))
            {
                if (encabezado[col_seleccionada].Key == "Nominal")
                {
                    Dictionary<string, int> frecuencias = new Dictionary<string, int>();
                    KeyValuePair<string, int> minimo = new KeyValuePair<string, int>("NA", -1);
                    for (int i = 0; i < cant_vecinos; i++)
                    {
                        string valor = instancias[col_seleccionada][distancias[i].Key];
                        if (!frecuencias.ContainsKey(valor))
                        {
                            frecuencias[valor] = 0;
                        }
                        frecuencias[valor]++;
                    }
                    foreach (KeyValuePair<string, int> valores in frecuencias)
                    {
                        if (valores.Value > minimo.Value)
                        {
                            minimo = valores;
                        }
                    }
                    valor_asignar = minimo.Key;
                }
                else if (encabezado[col_seleccionada].Key == "Numerico")
                {
                    List<double> vecinos = new List<double>();
                    double suma, cant_elmentos, resultado;
                    for (int i = 0; i < cant_vecinos; i++)
                    {
                        double.TryParse(instancias[col_seleccionada][distancias[i].Key], out double valor);
                        vecinos.Add(valor);
                    }
                    suma = vecinos.Sum();
                    cant_elmentos = vecinos.Count();
                    resultado = suma / cant_elmentos;

                    valor_asignar = resultado.ToString();
                }
            }

            return valor_asignar;
        }

        private string zeroR_valor(Dictionary<string, KeyValuePair<string,string>> encabezado, Dictionary<string, List<string>>instancias, string col_seleccionada)
        {
            string valor_asignar = "NA";
            if(encabezado.ContainsKey(col_seleccionada))
            {
                if (encabezado[col_seleccionada].Key == "Nominal")
                {
                    Dictionary<string, int> frecuencias = new Dictionary<string, int>();
                    KeyValuePair<string, int> minimo = new KeyValuePair<string, int>("NA", -1);
                    for (int i = 0; i < instancias[col_seleccionada].Count; i++)
                    {
                        string valor = instancias[col_seleccionada][i];
                        if (!frecuencias.ContainsKey(valor))
                        {
                            frecuencias[valor] = 0;
                        }
                        frecuencias[valor]++;
                    }
                    foreach (KeyValuePair<string, int> valores in frecuencias)
                    {
                        if (valores.Value > minimo.Value)
                        {
                            minimo = valores;
                        }
                    }
                    valor_asignar = minimo.Key;
                }
                else if (encabezado[col_seleccionada].Key == "Numerico")
                {
                    List<double> vecinos = new List<double>();
                    double suma, cant_elmentos, resultado;
                    for (int i = 0; i < instancias[col_seleccionada].Count; i++)
                    {
                        double.TryParse(instancias[col_seleccionada][i], out double valor);
                        vecinos.Add(valor);
                    }
                    suma = vecinos.Sum();
                    cant_elmentos = vecinos.Count();
                    resultado = suma / cant_elmentos;

                    valor_asignar = resultado.ToString();
                }
            }
            return valor_asignar;
        }

        private string oneR_valor(Dictionary<string, KeyValuePair<string,string>>encabezado, Dictionary<string, List<string>>instancias, 
                Dictionary<string, string> instancia_prueba, string col_seleccionada, int cant_instancias)
        {
            string valor_asignar = "NA";
            var valores = new Dictionary<string, KeyValuePair<double, Dictionary<string, KeyValuePair<List<string>, List<int>>>>>();

            if(encabezado[col_seleccionada].Key != "Nominal")
            {
                return valor_asignar;
            }

            foreach (KeyValuePair<string, KeyValuePair<string,string>> columnas in encabezado)
            { 
                if(columnas.Key == col_seleccionada){ continue; }
                if(columnas.Value.Key == "Nominal")
                {
                    Dictionary<string, KeyValuePair<List<string>, List<int>>> frecuencias = new Dictionary<string, KeyValuePair<List<string>, List<int>>>();
                    double error_total;

                    for(int i = 0; i < cant_instancias; i++)
                    {
                        string columna = instancias[columnas.Key][i];
                        string clase = instancias[col_seleccionada][i];

                        if(!frecuencias.ContainsKey(columna))
                        {
                            frecuencias[columna] = new KeyValuePair<List<string>, List<int>>(new List<string>(), new List<int>());
                        }

                        if(!frecuencias[columna].Key.Contains(clase))
                        {
                            frecuencias[columna].Key.Add(clase);
                            frecuencias[columna].Value.Add(1);
                        }
                        else
                        {
                            int index = frecuencias[columna].Key.IndexOf(clase);
                            frecuencias[columna].Value[index]++;
                        }
                    }

                    double numerador_total = 0;
                    double denominador_total = 0;

                    foreach(var fila in frecuencias)
                    {
                        numerador_total += fila.Value.Value.Sum() - fila.Value.Value.Max();
                        denominador_total += fila.Value.Value.Sum();
                    }

                    error_total = numerador_total / denominador_total;

                    valores[columnas.Key] = new KeyValuePair<double, Dictionary<string, KeyValuePair<List<string>, List<int>>>>(error_total, frecuencias);
                }
            }

            string columna_seleccionada = null;
            int maximo = 0;
            foreach (var columnas in valores)
            {
                if(columnas.Value.Key > maximo)
                {
                    columna_seleccionada = columnas.Key;
                }
            }

            if(!string.IsNullOrEmpty(columna_seleccionada))
            {
                string valor_prueba = instancia_prueba[columna_seleccionada];
                int frecuencia_maximo = valores[columna_seleccionada].Value[valor_prueba].Value.Max();
                int index = valores[columna_seleccionada].Value[valor_prueba].Value.IndexOf(frecuencia_maximo);
                valor_asignar = valores[columna_seleccionada].Value[valor_prueba].Key[index];
            }

            return valor_asignar;
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }

        private void radiobtnEuclidiana_CheckedChanged(object sender, EventArgs e)
        {
            radiobtnManhattan.Checked = (radiobtnEuclidiana.Checked) ? false : true;
        }

        private void radiobtnManhattan_CheckedChanged(object sender, EventArgs e)
        {
            radiobtnEuclidiana.Checked = (radiobtnManhattan.Checked) ? false: true;
        }

        private void btnKMeans_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Comienza K-Means");

            double[][] arrayDatos = new double[cant_instancias][];
            for (int go = 0; go < cant_instancias; go++)
            {
                arrayDatos[go] = new double[cant_columnas];
            }
            double buffer=0.0;

            int numcol = 0;
            foreach (string columna in encabezado.Keys)
            {
                
                for (int i = 0; i < cant_instancias; i++)
                {
                    // se convierten los datos a Double
                    buffer= Convert.ToDouble(instancias[columna][i]);
                    arrayDatos[i][numcol] = buffer;
                }
                numcol++;
            }

            Console.WriteLine("datos sin clusterizar:");
            Console.WriteLine("-------------------");
            ShowData(arrayDatos, 1, true, true);

            int numClusters = 3;
            Console.WriteLine("Numero de clusters: " + numClusters);

            int[] clustering = Cluster(arrayDatos, numClusters);

            Console.WriteLine("K-means clustering completado");

            Console.WriteLine("Orden final del clustering:");
            MostrarVector(clustering, true);

            Console.WriteLine("Miembros de cada cluster:");
            MostrarClusterizados(arrayDatos, clustering, numClusters, 1);

            Console.WriteLine("Termina K-Means");
            Console.ReadLine();
        }
        public static int[] Cluster(double[][] arrayDatos, int numClusters)
        {
            // k-means clustering
            // indice de return es tupla ID, celda es cluster ID
            // ex: [2 1 0 0 2 2] significa que tupla 0 es cluster 2, tupla 1 es cluster 1, tupla 2 es cluster 0, tupla 3 es cluster 0, etc.
            double[][] data = Normalizar(arrayDatos); // para que no dominen los valores grandes

            bool cambio = true; // sucedio algun cambio en al menos una asignacion de cluster?
            bool exito = true; // se pudieron calcular todas las medias?

            int[] clustering = InitClustering(data.Length, numClusters, 0); // inicializacion
            double[][] means = Asignar(numClusters, data[0].Length);

            int maxCount = data.Length * 10; // limite de iteraciones
            int ct = 0;
            while (cambio == true && exito == true && ct < maxCount)
            {
                ++ct;
                exito = ActualizarMedias(data, clustering, means); // calcula nuevas medias del cluster si es posible. sin efecto si falla
                cambio = ActualizarClustering(data, clustering, means); // reasigna tuplas a los clusters. sin efecto si falla
            }

            return clustering;
        }

        private static double[][] Normalizar(double[][] arrayDatos)
        {
            // normaliza los datos calculado (x - media) / stddev

            // copia los datos
            double[][] result = new double[arrayDatos.Length][];
            for (int i = 0; i < arrayDatos.Length; ++i)
            {
                result[i] = new double[arrayDatos[i].Length];
                Array.Copy(arrayDatos[i], result[i], arrayDatos[i].Length);
            }

            for (int j = 0; j < result[0].Length; ++j) // cada col
            {
                double colSum = 0.0;
                for (int i = 0; i < result.Length; ++i)
                    colSum += result[i][j];
                double mean = colSum / result.Length;
                double sum = 0.0;
                for (int i = 0; i < result.Length; ++i)
                    sum += (result[i][j] - mean) * (result[i][j] - mean);
                double sd = sum / result.Length;
                for (int i = 0; i < result.Length; ++i)
                    result[i][j] = (result[i][j] - mean) / sd;
            }
            return result;
        }

        private static int[] InitClustering(int numTuplas, int numClusters, int randomSeed)
        {
            // init clustering semi-random (al menos una tupla en cada cluster)
            Random random = new Random(randomSeed);
            int[] clustering = new int[numTuplas];
            for (int i = 0; i < numClusters; ++i) // asegura que cada cluster tenga al menos una tupla
                clustering[i] = i;
            for (int i = numClusters; i < clustering.Length; ++i)
                clustering[i] = random.Next(0, numClusters); // los demas al azar
            return clustering;
        }

        private static double[][] Asignar(int numClusters, int numColumnas)
        {
            double[][] result = new double[numClusters][];
            for (int k = 0; k < numClusters; ++k)
                result[k] = new double[numColumnas];
            return result;
        }

        private static bool ActualizarMedias(double[][] data, int[] clustering, double[][] means)
        {
            //retorna false si hay un cluster que no tiene tuplas asignadas

            int numClusters = means.Length;
            int[] clusterCounts = new int[numClusters];
            for (int i = 0; i < data.Length; ++i)
            {
                int cluster = clustering[i];
                ++clusterCounts[cluster];
            }

            for (int k = 0; k < numClusters; ++k)
                if (clusterCounts[k] == 0)
                    return false;

            for (int k = 0; k < means.Length; ++k)
                for (int j = 0; j < means[k].Length; ++j)
                    means[k][j] = 0.0;

            for (int i = 0; i < data.Length; ++i)
            {
                int cluster = clustering[i];
                for (int j = 0; j < data[i].Length; ++j)
                    means[cluster][j] += data[i][j];
            }

            for (int k = 0; k < means.Length; ++k)
                for (int j = 0; j < means[k].Length; ++j)
                    means[k][j] /= clusterCounts[k];
            return true;
        }

        private static bool ActualizarClustering(double[][] data, int[] clustering, double[][] means)
        {
            // reasigna cada tupla a un cluster (media mas cercana)
            // retorna false si no cambian asignaciones de tuplas o
            // si el reasignamiento resulta en un clustering donde
            // uno o mas clusters no tienen tuplas.

            int numClusters = means.Length;
            bool cambio = false;

            int[] newClustering = new int[clustering.Length]; // resultado propuesto
            Array.Copy(clustering, newClustering, clustering.Length);

            double[] distancias = new double[numClusters]; // distancias de tupla actual a cada media

            for (int i = 0; i < data.Length; ++i) // pasa por cada tupla
            {
                for (int k = 0; k < numClusters; ++k)
                    distancias[k] = DistanciaEuclidiana(data[i], means[k]); // calcula distancias de tupla actual a todo k means

                int newClusterID = MinIndex(distancias); // busca el ID de la media mas cercana
                if (newClusterID != newClustering[i])
                {
                    cambio = true;
                    newClustering[i] = newClusterID; // actualiza
                }
            }

            if (cambio == false)
                return false;

            int[] clusterCounts = new int[numClusters];
            for (int i = 0; i < data.Length; ++i)
            {
                int cluster = newClustering[i];
                ++clusterCounts[cluster];
            }

            for (int k = 0; k < numClusters; ++k)
                if (clusterCounts[k] == 0)
                    return false; // mal clustering 

            Array.Copy(newClustering, clustering, newClustering.Length); // actualiza
            return true; // buen clustering
        }

        private static double DistanciaEuclidiana(double[] tupla, double[] mean)
        {
            // Distancia Euclidiana entre dos vectores para ActualizarClustering()
            double sumSquaredDiffs = 0.0;
            for (int j = 0; j < tupla.Length; ++j)
                sumSquaredDiffs += Math.Pow((tupla[j] - mean[j]), 2);
            return Math.Sqrt(sumSquaredDiffs);
        }

        private static int MinIndex(double[] distancias)
        {
            // indice del valor mas pequeño en el array
            int indexOfMin = 0;
            double peqDist = distancias[0];
            for (int k = 0; k < distancias.Length; ++k)
            {
                if (distancias[k] < peqDist)
                {
                    peqDist = distancias[k];
                    indexOfMin = k;
                }
            }
            return indexOfMin;
        }

        // ============================================================================


        static void ShowData(double[][] data, int decimales, bool indices, bool newLine)
        {
            for (int i = 0; i < data.Length; ++i)
            {
                if (indices) Console.Write(i.ToString().PadLeft(3) + " ");
                for (int j = 0; j < data[i].Length; ++j)
                {
                    if (data[i][j] >= 0.0) Console.Write(" ");
                    Console.Write(data[i][j].ToString("F" + decimales) + " ");
                }
                Console.WriteLine("");
            }
            if (newLine) Console.WriteLine("");
        } // ShowData

        static void MostrarVector(int[] vector, bool newLine)
        {
            for (int i = 0; i < vector.Length; ++i)
                Console.Write(vector[i] + " ");
            if (newLine) Console.WriteLine("\n");
        }

        static void MostrarClusterizados(double[][] data, int[] clustering, int numClusters, int decimales)
        {
            for (int k = 0; k < numClusters; ++k)
            {
                Console.WriteLine("================= Cluster "+k.ToString() +" =================");
                for (int i = 0; i < data.Length; ++i)
                {
                    int clusterID = clustering[i];
                    if (clusterID != k) continue;
                    Console.Write(i.ToString().PadLeft(3) + " ");
                    for (int j = 0; j < data[i].Length; ++j)
                    {
                        if (data[i][j] >= 0.0) Console.Write(" ");
                        Console.Write(data[i][j].ToString("F" + decimales) + " ");
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("==============================================");
            } // k

        }

        private void dataGridViewKM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    } // Program
}
//}
