using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_serio_el_regreso
{
    public partial class Form5 : Form
    {
        private Form1 form1;
        private Dictionary<string, KeyValuePair<string, string>> encabezado;
        private Dictionary<string, List<KeyValuePair<int, string>>> valoresFueraDeDominio;
        private Dictionary<string, List<string>> instancias;
        private Dictionary<string, int> valores_faltantes;
        private int cant_instancias;
        public Form5(Form1 form1, Dictionary<string, KeyValuePair<string, string>> encabezado, Dictionary<string, List<string>> instancias, Dictionary<string, int> valores_faltantes, Dictionary<string, List<KeyValuePair<int, string>>> valoresFueraDeDominio, int cant_instancias, int clase, string clase2)
        {
            InitializeComponent();
            form1.Hide();
            this.form1 = form1;
            this.encabezado = encabezado;
            this.instancias = instancias;
            this.valores_faltantes = valores_faltantes;
            this.valoresFueraDeDominio = valoresFueraDeDominio;
            this.cant_instancias = cant_instancias;
            this.clase = clase;
            this.clase2 = clase2;
            comboBox1.Items.Add("ZeroR");
            comboBox1.Items.Add("OneR");
            comboBox1.Items.Add("Naive Bayes");
            comboBox2.Items.Add("Hold Out");
            comboBox2.Items.Add("K Fold Cross Validation");
        }
        string tipoDato;
        int clase;
        string clase2;
        string metodoEvaluacion = "";
        public struct matrices
        {
            public int[,] frecuencias;
            public int[] fila;
            public double mejor;
            public int coulmaSeleccionada;
        }

        void llenarFrecuenciasGrid(Dictionary<string, List<string>> instancias)
        {
            matrices max = new matrices();
            List<string> posiblesValC = posiblesValores(clase, instancias);
            List<string> posiblesValA = new List<string>();
            List<int> probabilidades = new List<int>();
            int frecuencia = 0;
            int almacenado = 0;
            int[,] ultimaTab = new int[posiblesValA.Count, posiblesValC.Count]; ;
            DataGridViewTextBoxColumn dgvIdColumn1 = new DataGridViewTextBoxColumn { HeaderText = "columna/clase", Name = "columna/clase" };
            dataGridView2.Columns.Add(dgvIdColumn1);
            for (int m = 0; m < instancias.Count; m++)
            {
                if (m != clase && (encabezado[encabezado.ElementAt(m).Key].Key == "Nominal" || encabezado[encabezado.ElementAt(m).Key].Key == "Nominal"))
                {
                    posiblesValA.Clear();
                    posiblesValA = posiblesValores(m, instancias);
                    max.frecuencias = new int[posiblesValA.Count, posiblesValC.Count];
                    for (int i = 0; i < posiblesValC.Count; i++)
                    {
                        for (int j = 0; j < posiblesValA.Count; j++)
                        {
                            frecuencia = frecuencias(m, clase, posiblesValC.ElementAt(i), posiblesValA.ElementAt(j), instancias);
                            max.frecuencias[j, i] = frecuencia;
                        }
                    }
                }
                if (m == 0)
                {
                    foreach (string col in posiblesValC)
                    {
                        DataGridViewTextBoxColumn dgvIdColumn = new DataGridViewTextBoxColumn { HeaderText = col, Name = col };
                        dataGridView2.Columns.Add(dgvIdColumn);
                    }
                    for (int i = 0; i < posiblesValA.Count; i++)
                    {
                        dataGridView2.Rows.Add();
                        for (int j = 0; j < posiblesValC.Count; j++)
                        {
                            dataGridView2.Rows[i].Cells[j + 1].Value = max.frecuencias[i, j];
                        }
                    }
                    for (int i = 0; i < posiblesValA.Count; i++)
                    {
                        dataGridView2.Rows[i].Cells[0].Value = encabezado.Keys.ElementAt(m) + ": " + posiblesValA.ElementAt(i);
                    }
                }
                else if (m != clase)
                {
                    for (int i = 0; i < posiblesValA.Count; i++)
                    {
                        dataGridView2.Rows.Add();
                        for (int j = 0; j < posiblesValC.Count; j++)
                        {
                            dataGridView2.Rows[i + almacenado].Cells[j + 1].Value = max.frecuencias[i, j];
                        }
                    }
                    for (int i = 0; i < posiblesValA.Count; i++)
                    {
                        dataGridView2.Rows[i + almacenado].Cells[0].Value = encabezado.Keys.ElementAt(m) + ": " + posiblesValA.ElementAt(i);
                    }
                }
                almacenado += posiblesValA.Count();
            }
        }
        void llenarFrecuenciasGridNB(Dictionary<string, List<string>> instancias)
        {
            matrices max = new matrices();
            List<string> posiblesValC = posiblesValores(clase, instancias);
            List<string> posiblesValA = new List<string>();
            List<int> probabilidades = new List<int>();
            int frecuencia = 0;
            int almacenado = 0;
            int[,] ultimaTab = new int[posiblesValA.Count, posiblesValC.Count]; ;
            DataGridViewTextBoxColumn dgvIdColumn1 = new DataGridViewTextBoxColumn { HeaderText = "columna/clase", Name = "columna/clase" };
            dataGridView2.Columns.Add(dgvIdColumn1);
            DataGridViewTextBoxColumn dgvIdColumn2 = new DataGridViewTextBoxColumn { HeaderText = "columna/clase", Name = "columna/clase" };
            dataGridView1.Columns.Add(dgvIdColumn2);
            for (int m = 0; m < instancias.Count; m++)
            {
                if (m != clase && (encabezado[encabezado.ElementAt(m).Key].Key == "Nominal" || encabezado[encabezado.ElementAt(m).Key].Key == "Ordinal"))
                {
                    posiblesValA.Clear();
                    posiblesValA = posiblesValores(m, instancias);
                    max.frecuencias = new int[posiblesValA.Count, posiblesValC.Count];
                    for (int i = 0; i < posiblesValC.Count; i++)
                    {
                        for (int j = 0; j < posiblesValA.Count; j++)
                        {
                            frecuencia = frecuencias(m, clase, posiblesValC.ElementAt(i), posiblesValA.ElementAt(j), instancias) + 1;
                            max.frecuencias[j, i] = frecuencia;
                        }
                    }
                }
                if (m == 0)
                {
                    foreach (string col in posiblesValC)
                    {
                        DataGridViewTextBoxColumn dgvIdColumn = new DataGridViewTextBoxColumn { HeaderText = col, Name = col };
                        dataGridView2.Columns.Add(dgvIdColumn);
                        DataGridViewTextBoxColumn dgvIdColumn3 = new DataGridViewTextBoxColumn { HeaderText = col, Name = col };
                        dataGridView1.Columns.Add(dgvIdColumn3);
                    }
                    for (int i = 0; i < posiblesValA.Count; i++)
                    {
                        dataGridView2.Rows.Add();
                        dataGridView1.Rows.Add();
                        for (int j = 0; j < posiblesValC.Count; j++)
                        {
                            dataGridView2.Rows[i].Cells[j + 1].Value = max.frecuencias[i, j];
                            dataGridView1.Rows[i].Cells[j + 1].Value = max.frecuencias[i, j];
                        }
                    }
                    for (int i = 0; i < posiblesValA.Count; i++)
                    {
                        dataGridView2.Rows[i].Cells[0].Value = encabezado.Keys.ElementAt(m) + ": " + posiblesValA.ElementAt(i);
                        dataGridView1.Rows[i].Cells[0].Value = encabezado.Keys.ElementAt(m) + ": " + posiblesValA.ElementAt(i);
                    }
                }
                else if (m != clase)
                {
                    for (int i = 0; i < posiblesValA.Count; i++)
                    {
                        dataGridView2.Rows.Add();
                        dataGridView1.Rows.Add();
                        for (int j = 0; j < posiblesValC.Count; j++)
                        {
                            dataGridView2.Rows[i + almacenado].Cells[j + 1].Value = max.frecuencias[i, j];
                            dataGridView1.Rows[i + almacenado].Cells[j + 1].Value = max.frecuencias[i, j];
                        }
                    }
                    for (int i = 0; i < posiblesValA.Count; i++)
                    {
                        dataGridView2.Rows[i + almacenado].Cells[0].Value = encabezado.Keys.ElementAt(m) + ": " + posiblesValA.ElementAt(i);
                        dataGridView1.Rows[i + almacenado].Cells[0].Value = encabezado.Keys.ElementAt(m) + ": " + posiblesValA.ElementAt(i);
                    }
                }
                almacenado += posiblesValA.Count();
            }
        }
        public List<string> posiblesValores(int clase, Dictionary<string, List<string>> instancias)
        {
            List<string> valores = new List<string>();
            for (int j = 0; j < instancias[encabezado.Keys.ElementAt(clase)].Count; j++)
            {
                if (!valores.Contains(instancias[encabezado.Keys.ElementAt(clase)].ElementAt(j)))
                    valores.Add(instancias[encabezado.Keys.ElementAt(clase)].ElementAt(j));
            }
            return valores;

        }

        private double calcular_desviacion(List<string> valores)
        {
            double datos_m = 0;
            //calcular media
            for (int i = 0; i < valores.Count; ++i)
            {
                datos_m += Convert.ToInt32(valores.ElementAt(i));
            }
            var tamano_muestra = valores.Count;
            var media = datos_m / tamano_muestra;
            //calcular varianza
            double datos_v = 0;
            for (int i = 0; i < valores.Count; ++i)
            {
                //conversion explicita a double para emplear el metodo pow
                datos_v += Math.Pow((Convert.ToDouble(valores.ElementAt(i)) - Convert.ToDouble(media)), 2); ;
            }
            double total_varianza = datos_v / (valores.Count - 1);
            return Math.Sqrt(total_varianza);


        }
        public double calcularMedia(List<string> valores)
        {
            double datos_m = 0;
            //calcular media
            for (int i = 0; i < valores.Count; ++i)
            {
                datos_m += Convert.ToInt32(valores.ElementAt(i));
            }
            double tamano_muestra = valores.Count;
            double media = datos_m / tamano_muestra;
            return media;
        }
        public List<int> zeroR(List<string> valores, int clase, Dictionary<string, List<string>> instancias)
        {
            List<int> probabilidades = new List<int>();
            int cantidad = 0;
            for (int i = 0; i < valores.Count; i++)
            {
                cantidad = 0;
                for (int j = 0; j < instancias[encabezado.Keys.ElementAt(clase)].Count; j++)
                {
                    if (instancias[encabezado.Keys.ElementAt(clase)].ElementAt(j) == valores.ElementAt(i))
                        cantidad++;
                }
                probabilidades.Add(cantidad);
            }
            return probabilidades;
        }

        int frecuencias(int column, int clas, string clase, string col, Dictionary<string, List<string>> instancias)
        {
            int frec = 0;
            for (int i = 0; i < instancias[encabezado.Keys.ElementAt(column)].Count; i++)
                if (instancias[encabezado.Keys.ElementAt(column)].ElementAt(i) == col && instancias[encabezado.Keys.ElementAt(clas)].ElementAt(i) == clase)
                    frec++;
            return frec;
        }

        double menorError(int[,] frecuencias, int filas, int columnas)
        {
            double menor = 0;
            double maxVal = 0;
            double total = 0;
            double totalTotal = 0;
            double errorTotal = 0;
            for (int i = 0; i < filas; i++)
            {
                maxVal = 0;
                total = 0;
                menor = 0;
                for (int j = 0; j < columnas; j++)
                {
                    if (frecuencias[i, j] > maxVal)
                        maxVal = frecuencias[i, j];
                    total += frecuencias[i, j];
                }
                menor = (total - maxVal);
                totalTotal += total;
                errorTotal += menor;
            }
            errorTotal = errorTotal / totalTotal;
            return errorTotal;
        }

        matrices reglas(int[,] frecuencias, int filas, int columnas)
        {
            matrices max = new matrices();
            double menor = 0;
            double maxVal = 0;
            double total = 0;
            double totalTotal = 0;
            double errorTotal = 0;
            max.fila = new int[filas];
            for (int i = 0; i < filas; i++)
            {
                maxVal = 0;
                total = 0;
                menor = 0;
                for (int j = 0; j < columnas; j++)
                {
                    if (frecuencias[i, j] > maxVal)
                    {
                        max.fila[i] = j;
                    }
                    total += frecuencias[i, j];
                }
                menor = (total - maxVal);
                totalTotal += total;
                errorTotal += menor;
            }
            errorTotal = errorTotal / totalTotal;
            return max;
        }



        matrices oneR(Dictionary<string, List<string>> instancias)
        {
            matrices max = new matrices();
            List<string> posiblesValC = posiblesValores(clase, instancias);
            List<string> posiblesValA = new List<string>();
            List<int> probabilidades = new List<int>();
            double menorFrec = 1;
            int frecuencia = 0;

            int[,] ultimaTab = new int[posiblesValA.Count, posiblesValC.Count]; ;
            for (int m = 0; m < encabezado.Keys.Count; m++)
            {
                if (m != clase && (encabezado[encabezado.ElementAt(m).Key].Key == "Nominal" || encabezado[encabezado.ElementAt(m).Key].Key == "Ordinal"))
                {
                    posiblesValA.Clear();
                    posiblesValA = posiblesValores(m, instancias);
                    max.frecuencias = new int[posiblesValA.Count, posiblesValC.Count];
                    for (int i = 0; i < posiblesValC.Count; i++)
                    {
                        for (int j = 0; j < posiblesValA.Count; j++)
                        {
                            frecuencia = frecuencias(m, clase, posiblesValC.ElementAt(i), posiblesValA.ElementAt(j), instancias);
                            max.frecuencias[j, i] = frecuencia;
                        }
                    }
                    if (menorFrec > menorError(max.frecuencias, posiblesValA.Count, posiblesValC.Count))
                    {
                        ultimaTab = max.frecuencias;
                        matrices ma = new matrices();
                        menorFrec = menorError(max.frecuencias, posiblesValA.Count, posiblesValC.Count);
                        max.coulmaSeleccionada = m;
                        ma = reglas(max.frecuencias, posiblesValA.Count, posiblesValC.Count);
                        max.fila = ma.fila;
                    }
                }
            }
            max.mejor = menorFrec;
            max.frecuencias = ultimaTab;
            return max;
        }

        private void kFoldZeroR(int k, int hold)
        {
            Dictionary<string, List<string>> pruebas = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> entrenamiento = new Dictionary<string, List<string>>();
            List<string> posiblesValC = posiblesValores(clase, instancias);
            List<int> numGen = new List<int>();
            int separador = 0;
            int divicion = cant_instancias/k;
            double exactitud = 0;
            double especificidad = 0;
            double recall = 0;
            int[,] matrizConfusion = new int[posiblesValC.Count, posiblesValC.Count];
            for(int i = 0; i < k; i++)
            {
                for (int oA = 0; oA < posiblesValC.Count; oA++)
                {
                    for (int j = 0; j < posiblesValC.Count; j++)
                    {
                        matrizConfusion[oA, j] = 0;
                    }
                }
                pruebas.Clear();
                entrenamiento.Clear();
                if(comboBox2.SelectedItem.ToString() == "K Fold Cross Validation")
                {
                    for (int m = 0; m < instancias.Count; m++)
                    {
                        List<string> pruebasTemp = new List<string>();
                        List<string> entrenamientoTemp = new List<string>();
                        for (int j = separador; j < divicion + separador; j++)
                        {
                            pruebasTemp.Add(instancias[encabezado.Keys.ElementAt(m)].ElementAt(j));
                        }
                        for (int j = 0; j < cant_instancias; j++)
                        {
                            if (j < separador)
                                entrenamientoTemp.Add(instancias[encabezado.Keys.ElementAt(m)].ElementAt(j));
                            if (j > separador + divicion)
                                entrenamientoTemp.Add(instancias[encabezado.Keys.ElementAt(m)].ElementAt(j));
                        }
                        pruebas.Add(encabezado.Keys.ElementAt(m), pruebasTemp);
                        entrenamiento.Add(encabezado.Keys.ElementAt(m), entrenamientoTemp);
                    }
                }
                if(comboBox2.SelectedItem.ToString() == "Hold Out")
                {
                    pruebas = llenarPruebas(hold, numGen);
                    entrenamiento = llenarEntrenamiento(numGen);
                }
                matrices max = oneR(entrenamiento);
                List<string> posiblesValA = posiblesValores(max.coulmaSeleccionada, instancias);
                for(int x = 0; x < pruebas[encabezado.Keys.ElementAt(0)].Count; x++)
                {
                    for(int z = 0; z < posiblesValA.Count; z++)
                    {
                        if (pruebas[encabezado.Keys.ElementAt(max.coulmaSeleccionada)].ElementAt(x) == posiblesValA.ElementAt(z))
                        {
                            for(int g = 0; g < posiblesValC.Count; g++)
                            {
                                if(pruebas[encabezado.Keys.ElementAt(clase)].ElementAt(x) == posiblesValC.ElementAt(g))
                                {
                                    matrizConfusion[max.fila[z],g]++;
                                }
                            }
                        }
                    }
                } 
                double temp = 0;
                double temp2 = 0;
                for(int m = 0; m < posiblesValC.Count; m++)
                {
                    temp += matrizConfusion[m, m];
                }
                for (int m = 0; m < posiblesValC.Count; m++)
                {
                    for (int n = 0; n < posiblesValC.Count; n++)
                    {
                        temp2 += matrizConfusion[n, m];
                    }
                }
                temp = temp / temp2;
                exactitud = (exactitud + temp);
                temp = 0;
                for(int m = 0; m < posiblesValC.Count; m++)
                {
                    temp2 = 0;
                    for (int n = 0; n < posiblesValC.Count; n++)
                    {
                        temp2 += matrizConfusion[n, m];
                    }
                    temp += matrizConfusion[m, m] / temp2; 
                }
                temp = temp / posiblesValC.Count;
                recall = recall + temp;
                temp = 0;
                for (int m = 0; m < posiblesValC.Count; m++)
                {
                    temp2 = 0;
                    for (int n = 0; n < posiblesValC.Count; n++)
                    {
                        temp2 += matrizConfusion[m, n];
                    }
                    temp += matrizConfusion[m, m] / temp2;
                }
                temp = temp / posiblesValC.Count;
                especificidad += temp;
                separador += divicion;

            }
            exactitud = exactitud / k;
            recall = recall / k;
            especificidad = especificidad / k;
            textBox1.Text = "Recall = " + recall * 100 + "%  Especificidad = " + especificidad * 100 + "%  Exactitud = " + exactitud * 100 + "%";
        }

        void naiveBayes(Dictionary<string, List<string>> instancias, List<double> desviacionEstandar, List<double> media)
        {
            List<string> posiblesValC = posiblesValores(clase, instancias);
            List<string> posiblesValA = new List<string>();
            List<double> resultados = new List<double>();
            List<int> clases = zeroR(posiblesValC, clase, instancias);
            double porcentaje = 1;
            double valorClase = 0;
            double acumulado = 0;
            int frecuencia = 0;
            double mejor = 0;
            int almacenado = 0;
            string cadena = "";
            llenarFrecuenciasGridNB(instancias);
            for (int m = 0; m < encabezado.Keys.Count; m++)
            {
                if (m != clase && encabezado[encabezado.ElementAt(m).Key].Key == "Numerico")
                {
                    posiblesValA.Clear();
                    posiblesValA = posiblesValores(m, instancias);
                    List<string> fr = new List<string>();
                    for (int i = 0; i < posiblesValC.Count; i++)
                    {
                        for (int j = 0; j < posiblesValA.Count; j++)
                        {
                            frecuencia = frecuencias(m, clase, posiblesValC.ElementAt(i), posiblesValA.ElementAt(j), instancias);
                            for (int x = 0; x < frecuencia; x++)
                                fr.Add(posiblesValA.ElementAt(j));
                        }
                        desviacionEstandar.Add(calcular_desviacion(fr));
                        media.Add(calcularMedia(fr));
                    }
                }
            }
            for (int m = 0; m < encabezado.Keys.Count; m++)
            {
                if (m != clase && encabezado[encabezado.ElementAt(m).Key].Key != "Numerico" && encabezado[encabezado.ElementAt(m).Key].Key != "Texto")
                {
                    posiblesValA.Clear();
                    posiblesValA = posiblesValores(m, instancias);
                    for (int i = 0; i < posiblesValC.Count; i++)
                    {
                        acumulado = 0;
                        for (int j = 0; j < posiblesValA.Count; j++)
                        {
                            acumulado += Convert.ToDouble(dataGridView1.Rows[j + almacenado].Cells[i + 1].Value);

                        }
                        for (int j = 0; j < posiblesValA.Count; j++)
                        {
                            dataGridView1.Rows[j + almacenado].Cells[i + 1].Value = Convert.ToDouble(dataGridView1.Rows[j + almacenado].Cells[i + 1].Value) / acumulado;

                        }
                    }
                }
                almacenado += posiblesValA.Count();
            }
        }

        string prediccionesNB(List<string> ingreso, List<double> desviacionEstandar, List<double> media, Dictionary<string, List<string>> instancias)
        {
            List<string> posiblesValC = posiblesValores(clase, instancias);
            List<string> posiblesValA = new List<string>();
            List<double> resultados = new List<double>();
            List<int> clases = zeroR(posiblesValC, clase, instancias);
            double porcentaje = 1;
            double valorClase = 0;
            double mejor = 0;
            int almacenado = 0;
            string cadena = "";
            for (int i = 0; i < posiblesValC.Count; i++)
            {
                valorClase += clases.ElementAt(i);
            }
            for (int j = 0; j < posiblesValC.Count; j++)
            {
                almacenado = 0;
                porcentaje = 1;
                cadena = "";
                cadena += "P(" + posiblesValC.ElementAt(j) + "|A" + ") = ";
                for (int m = 0; m < encabezado.Keys.Count; m++)
                {
                    if (m != clase)
                    {
                        if (encabezado[encabezado.ElementAt(m).Key].Key != "Numerico")
                        {
                            posiblesValA.Clear();
                            posiblesValA = posiblesValores(m, instancias);
                            for (int i = 0; i < posiblesValA.Count; i++)
                            {
                                if (ingreso.ElementAt(m) == posiblesValA.ElementAt(i))
                                {
                                    porcentaje *= Convert.ToDouble(dataGridView1.Rows[i + almacenado].Cells[j + 1].Value);
                                    cadena += Convert.ToDouble(dataGridView1.Rows[i + almacenado].Cells[j + 1].Value).ToString("#.0000") + " x ";
                                }
                            }
                            almacenado += posiblesValA.Count;
                        }
                        else if (encabezado[encabezado.ElementAt(m).Key].Key == "Numerico")
                        {
                            double res = 0;
                            res = (1 / (Math.Sqrt(2 * Math.PI) * desviacionEstandar.ElementAt(j)) * Math.Pow(Math.E, -1 * ((Convert.ToDouble(ingreso.ElementAt(m)) - media.ElementAt(j)) / (2 * Math.Pow(desviacionEstandar.ElementAt(j), 2)))));
                            porcentaje *= res;
                            cadena += res.ToString("#.0000") + " x ";
                            almacenado += posiblesValA.Count;
                        }
                    }
                }
                porcentaje *= Convert.ToDouble(clases.ElementAt(j) / valorClase);
                cadena += Convert.ToDouble(clases.ElementAt(j) / valorClase).ToString("#.0000") + " = " + porcentaje.ToString("#.0000") + "\n";
                textBox1.Text += cadena + "\n";
                resultados.Add(porcentaje);
            }
            double a = 0;
            double b = 0;
            int ultimo = 0;
            foreach (double d in resultados)
            {
                a += d;
            }
            for (int j = 0; j < resultados.Count; j++)
            {
                b = resultados.ElementAt(j) / a;
                if (mejor < b)
                {
                    mejor = b;
                    ultimo = j;
                }
            }
            textBox1.Text += "Prediccion: " + posiblesValC.ElementAt(ultimo) + " con " + (mejor * 100) + "%\n";
            return posiblesValC.ElementAt(ultimo);
        }

        Dictionary<string, List<string>> llenarPruebas(int cantidad, List<int> numerosGenerados)
        {
            Dictionary<string, List<string>> pruebas = new Dictionary<string, List<string>>();
            var seed = Environment.TickCount;
            var random = new Random(seed);
            for(int i = 0; i < encabezado.Keys.Count; i++)
            {
                List<string> pruebasTemp = new List<string>();
                pruebas.Add(encabezado.Keys.ElementAt(i),pruebasTemp);
            }
            while (numerosGenerados.Count < cantidad)
            {
                int numRam = random.Next(0, cant_instancias - 1);
                if (!numerosGenerados.Contains(numRam))
                    numerosGenerados.Add(numRam);
            }
            for(int j = 0; j < numerosGenerados.Count; j++)
            {
                for (int i = 0; i < encabezado.Keys.Count; i++)
                {
                    pruebas[encabezado.Keys.ElementAt(i)].Add(instancias[encabezado.Keys.ElementAt(i)].ElementAt(numerosGenerados[j]));
                }
            }
            return pruebas;
        }

        Dictionary<string, List<string>> llenarEntrenamiento(List<int> numerosGenerados)
        {
            Dictionary<string, List<string>> entrenamiento = new Dictionary<string, List<string>>();
            for (int i = 0; i < encabezado.Keys.Count; i++)
            {
                List<string> pruebasTemp = new List<string>();
                entrenamiento.Add(encabezado.Keys.ElementAt(i), pruebasTemp);
            }
            for (int j = 0; j < cant_instancias; j++)
            {
                if(!numerosGenerados.Contains(j))
                {
                    for (int i = 0; i < encabezado.Keys.Count; i++)
                    {
                        entrenamiento[encabezado.Keys.ElementAt(i)].Add(instancias[encabezado.Keys.ElementAt(i)].ElementAt(j));
                    }
                }
            }
            return entrenamiento;
        }
        void kfoldNB(int k, int hold)
        {
            List<double> desviacionEstandar = new List<double>();
            List<double> media = new List<double>();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            List<string> ingreso = new List<string>();
            Dictionary<string, List<string>> pruebas = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> entrenamiento = new Dictionary<string, List<string>>();
            List<string> posiblesValC = posiblesValores(clase, instancias);
            List<int> numGen = new List<int>();
            int separador = 0;
            int divicion = cant_instancias / k;
            double exactitud = 0;
            double especificidad = 0;
            double recall = 0;
            int[,] matrizConfusion = new int[posiblesValC.Count, posiblesValC.Count];
            for (int m = 0; m < k; m++)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                desviacionEstandar.Clear();
                media.Clear();
                for (int oA = 0; oA < posiblesValC.Count; oA++)
                {
                    for (int j = 0; j < posiblesValC.Count; j++)
                    {
                        matrizConfusion[oA, j] = 0;
                    }
                }
                pruebas.Clear();
                entrenamiento.Clear();
                if(comboBox2.SelectedItem.ToString() == "K Fold Cross Validation")
                {
                    for (int i = 0; i < instancias.Count; i++)
                    {
                        List<string> pruebasTemp = new List<string>();
                        List<string> entrenamientoTemp = new List<string>();
                        for (int j = separador; j < divicion + separador; j++)
                        {
                            pruebasTemp.Add(instancias[encabezado.Keys.ElementAt(i)].ElementAt(j));
                        }
                        for (int j = 0; j < cant_instancias; j++)
                        {
                            if (j < separador)
                                entrenamientoTemp.Add(instancias[encabezado.Keys.ElementAt(i)].ElementAt(j));
                            if (j > separador + divicion)
                                entrenamientoTemp.Add(instancias[encabezado.Keys.ElementAt(i)].ElementAt(j));
                        }
                        pruebas.Add(encabezado.Keys.ElementAt(i), pruebasTemp);
                        entrenamiento.Add(encabezado.Keys.ElementAt(i), entrenamientoTemp);
                    }
                }
                if(comboBox2.SelectedItem.ToString() == "Hold Out")
                {
                    pruebas = llenarPruebas(hold, numGen);
                    entrenamiento = llenarEntrenamiento(numGen);
                }
                naiveBayes(entrenamiento, desviacionEstandar, media);
                for (int i = 0; i < pruebas[encabezado.Keys.ElementAt(0)].Count; i++)
                {
                    ingreso.Clear();
                    for(int j = 0; j < encabezado.Keys.Count; j++)
                    {
                        if (j != clase)
                        {
                            string respuesta = pruebas[encabezado.Keys.ElementAt(j)].ElementAt(i);
                            ingreso.Add(respuesta);
                        }
                    }
                    string prediccion = prediccionesNB(ingreso, desviacionEstandar, media, entrenamiento);
                    int fila = 0;
                    int columna = 0;
                    for (int g = 0; g < posiblesValC.Count; g++)
                    {
                        if(prediccion == posiblesValC.ElementAt(g))
                        {
                            fila = g;
                        }
                        if (pruebas[encabezado.Keys.ElementAt(clase)].ElementAt(i) == posiblesValC.ElementAt(g))
                        {
                            columna = g;
                        }
                    }
                    matrizConfusion[fila, columna]++;
                }
                double temp = 0;
                double temp2 = 0;
                for (int i = 0; i < posiblesValC.Count; i++)
                {
                    temp += matrizConfusion[i, i];
                }
                for (int i = 0; i < posiblesValC.Count; i++)
                {
                    for (int n = 0; n < posiblesValC.Count; n++)
                    {
                        temp2 += matrizConfusion[n, i];
                    }
                }
                temp = temp / temp2;
                exactitud = (exactitud + temp);
                temp = 0;
                for (int i = 0; i < posiblesValC.Count; i++)
                {
                    temp2 = 0;
                    for (int n = 0; n < posiblesValC.Count; n++)
                    {
                        temp2 += matrizConfusion[n, i];
                    }
                    temp += matrizConfusion[i, i] / temp2;
                }
                temp = temp / posiblesValC.Count;
                recall = recall + temp;
                temp = 0;
                for (int i = 0; i < posiblesValC.Count; i++)
                {
                    temp2 = 0;
                    for (int n = 0; n < posiblesValC.Count; n++)
                    {
                        temp2 += matrizConfusion[i, n];
                    }
                    temp += matrizConfusion[i, i] / temp2;
                }
                temp = temp / posiblesValC.Count;
                especificidad += temp;
                separador += divicion;
            }
            exactitud = exactitud / k;
            recall = recall / k;
            especificidad = especificidad / k;
            textBox1.Text = "Recall = " + recall*100 + "%  Especificidad = " + especificidad*100 + "%  Exactitud = " + exactitud*100 + "%";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            int rec = 0;
            int max2 = 0;
            List<string> columna = new List<string>();
            List<string> posiblesVal = new List<string>();
            List<int> resultados = new List<int>();
            double porcentaje = 1;
            int k = 1;
            posiblesVal = posiblesValores(clase, instancias);
            resultados = zeroR(posiblesVal, clase, instancias);
            if (comboBox1.SelectedItem.ToString() == "ZeroR")
            {
                llenarFrecuenciasGrid(instancias);
                foreach (string col in posiblesVal)
                {
                    DataGridViewTextBoxColumn dgvIdColumn = new DataGridViewTextBoxColumn { HeaderText = col, Name = col };
                    dataGridView1.Columns.Add(dgvIdColumn);
                }
                for (int i = 0; i < resultados.Count; i++)
                {
                    if (resultados.ElementAt(i) > max2)
                    {
                        max2 = resultados.ElementAt(i);
                        rec = i;
                    }
                }

                dataGridView1.Rows.Add();
                for (int i = 0; i < posiblesVal.Count; i++)
                    dataGridView1.Rows[0].Cells[i].Value = resultados.ElementAt(i);
            }
            else if(comboBox1.SelectedItem.ToString() == "OneR")
            {
                llenarFrecuenciasGrid(instancias);
                matrices max = oneR(instancias);
            List<string> posiblesValC = posiblesValores(clase, instancias);
            List<string> posiblesValA = posiblesValores(max.coulmaSeleccionada, instancias);
            double porcentaje2 = (1 - max.mejor) * 100;
            string reglas = "Columna: " + encabezado.Keys.ElementAt(max.coulmaSeleccionada);
            if (porcentaje2 != 0)
            {
                reglas += "\nReglas:\n";
                for (int i = 0; i < posiblesValA.Count; i++)
                {
                    reglas += posiblesValA.ElementAt(i) + "--> " + posiblesValC.ElementAt(max.fila[i]) + "\n";
                }
                label2.Text = reglas;
                DataGridViewTextBoxColumn dgvIdColumn1 = new DataGridViewTextBoxColumn { HeaderText = "columna/clase", Name = "columna/clase" };
                dataGridView1.Columns.Add(dgvIdColumn1);
                foreach (string col in posiblesValC)
                {
                    DataGridViewTextBoxColumn dgvIdColumn = new DataGridViewTextBoxColumn { HeaderText = col, Name = col };
                    dataGridView1.Columns.Add(dgvIdColumn);
                }
                for (int i = 0; i < posiblesValA.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    for (int j = 0; j < posiblesValC.Count; j++)
                    {
                        dataGridView1.Rows[i].Cells[j + 1].Value = max.frecuencias[i, j];
                    }
                }
                for (int i = 0; i < posiblesValA.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = posiblesValA.ElementAt(i);
                }
            }
                if(comboBox2.SelectedItem.ToString() == "Hold Out")
                {
                    porcentaje = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Ingrese el porcentaje de pruebas: ", "Valores", "20"));
                    porcentaje = Convert.ToInt32((cant_instancias * porcentaje) / 100);
                    kFoldZeroR(10, Convert.ToInt32(porcentaje));
                }
                if (comboBox2.SelectedItem.ToString() == "K Fold Cross Validation")
                {
                    k = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Ingrese el numero de folders: ", "Valores", "2"));
                    kFoldZeroR(k, 0);
                }
            }
            else if(comboBox1.SelectedItem.ToString() == "Naive Bayes")
            {
                if (comboBox2.SelectedItem.ToString() == "Hold Out")
                {
                    porcentaje = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Ingrese el porcentaje de pruebas: ", "Valores", "20"));
                    porcentaje = Convert.ToInt32((cant_instancias * porcentaje) / 100);
                    kfoldNB(10, Convert.ToInt32(porcentaje));
                }
                if (comboBox2.SelectedItem.ToString() == "K Fold Cross Validation")
                {
                    k = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Ingrese el numero de folders: ", "Valores", "2"));
                    kfoldNB(k, 0);
                }
            }
        }
    }
}
