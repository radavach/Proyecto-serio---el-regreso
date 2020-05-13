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
    }
}
