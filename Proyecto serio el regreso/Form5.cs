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
        }
        string tipoDato;
        int clase;
        string clase2;
        public struct matrices
        {
            public int[,] frecuencias;
            public int[] fila;
            public double mejor;
            public int coulmaSeleccionada;
        }

        void llenarFrecuenciasGrid()
        {
            matrices max = new matrices();
            List<string> posiblesValC = posiblesValores(clase);
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
                    posiblesValA = posiblesValores(m);
                    max.frecuencias = new int[posiblesValA.Count, posiblesValC.Count];
                    for (int i = 0; i < posiblesValC.Count; i++)
                    {
                        for (int j = 0; j < posiblesValA.Count; j++)
                        {
                            frecuencia = frecuencias(m, clase, posiblesValC.ElementAt(i), posiblesValA.ElementAt(j));
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
        void llenarFrecuenciasGridNB()
        {
            matrices max = new matrices();
            List<string> posiblesValC = posiblesValores(clase);
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
                    posiblesValA = posiblesValores(m);
                    max.frecuencias = new int[posiblesValA.Count, posiblesValC.Count];
                    for (int i = 0; i < posiblesValC.Count; i++)
                    {
                        for (int j = 0; j < posiblesValA.Count; j++)
                        {
                            frecuencia = frecuencias(m, clase, posiblesValC.ElementAt(i), posiblesValA.ElementAt(j)) + 1;
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
        public List<string> posiblesValores(int clase)
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
        public List<int> zeroR(List<string> valores, int clase)
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

        int frecuencias(int column, int clas, string clase, string col)
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



        matrices oneR()
        {
            matrices max = new matrices();
            List<string> posiblesValC = posiblesValores(clase);
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
                    posiblesValA = posiblesValores(m);
                    max.frecuencias = new int[posiblesValA.Count, posiblesValC.Count];
                    for (int i = 0; i < posiblesValC.Count; i++)
                    {
                        for (int j = 0; j < posiblesValA.Count; j++)
                        {
                            frecuencia = frecuencias(m, clase, posiblesValC.ElementAt(i), posiblesValA.ElementAt(j));
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

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            llenarFrecuenciasGrid();
            Form1 f1 = new Form1();
            int rec = 0;
            int max = 0;
            List<string> columna = new List<string>();
            List<string> posiblesVal = new List<string>();
            List<int> resultados = new List<int>();
            posiblesVal = posiblesValores(clase);
            resultados = zeroR(posiblesVal, clase);
            foreach (string col in posiblesVal)
            {
                DataGridViewTextBoxColumn dgvIdColumn = new DataGridViewTextBoxColumn { HeaderText = col, Name = col };
                dataGridView1.Columns.Add(dgvIdColumn);
            }
            for (int i = 0; i < resultados.Count; i++)
            {
                if (resultados.ElementAt(i) > max)
                {
                    max = resultados.ElementAt(i);
                    rec = i;
                }
            }

            dataGridView1.Rows.Add();
            for (int i = 0; i < posiblesVal.Count; i++)
                dataGridView1.Rows[0].Cells[i].Value = resultados.ElementAt(i);
            label1.Text = "Prediccion: " + posiblesVal.ElementAt(rec) + " Con " + ((max * 100) / instancias[encabezado.Keys.ElementAt(clase)].Count) + "%";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            matrices max = oneR();
            List<string> posiblesValC = posiblesValores(clase);
            List<string> posiblesValA = posiblesValores(max.coulmaSeleccionada);
            double porcentaje = (1 - max.mejor) * 100;
            string reglas = "Columna: " + encabezado.Keys.ElementAt(max.coulmaSeleccionada);
            if (porcentaje != 0)
            {
                reglas += "\nReglas:\n";
                for (int i = 0; i < posiblesValA.Count; i++)
                {
                    reglas += posiblesValA.ElementAt(i) + "--> " + posiblesValC.ElementAt(max.fila[i]) + "\n";
                }
                reglas += "Con una presicion de: " + porcentaje + "%";
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
            else
                MessageBox.Show("No hay suficientes valores para predecir valores");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            List<string> posiblesValC = posiblesValores(clase);
            List<string> posiblesValA = new List<string>();
            List<double> resultados = new List<double>();
            List<int> clases = zeroR(posiblesValC, clase);
            double porcentaje = 1;
            double valorClase = 0;
            double acumulado = 0;
            int frecuencia = 0;
            double mejor = 0;
            int almacenado = 0;
            string cadena = "";
            List<double> desviacionEstandar = new List<double>();
            List<double> media = new List<double>();
            List<string> ingreso = new List<string>();
            llenarFrecuenciasGridNB();
            for (int m = 0; m < encabezado.Keys.Count; m++)
            {
                if (m != clase && encabezado[encabezado.ElementAt(m).Key].Key == "Numerico" && encabezado[encabezado.ElementAt(m).Key].Key != "Texto")
                {
                    posiblesValA.Clear();
                    posiblesValA = posiblesValores(m);
                    List<string> fr = new List<string>();
                    for (int i = 0; i < posiblesValC.Count; i++)
                    {
                        for (int j = 0; j < posiblesValA.Count; j++)
                        {
                            frecuencia = frecuencias(m, clase, posiblesValC.ElementAt(i), posiblesValA.ElementAt(j));
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
                    posiblesValA = posiblesValores(m);
                    for (int i = 0; i < posiblesValC.Count; i++)
                    {
                        acumulado = 0;
                        for (int j = 0; j < posiblesValA.Count; j++)
                        {
                            acumulado += Convert.ToDouble(dataGridView1.Rows[i + almacenado].Cells[j + 1].Value);

                        }
                        for (int j = 0; j < posiblesValA.Count; j++)
                        {
                            dataGridView1.Rows[i + almacenado].Cells[j + 1].Value = Convert.ToDouble(dataGridView1.Rows[i + almacenado].Cells[j + 1].Value) / acumulado;

                        }
                    }
                }
                almacenado += posiblesValA.Count();
            }
            for (int i = 0; i < posiblesValC.Count; i++)
            {
                valorClase += clases.ElementAt(i);
            }
            for (int i = 0; i < encabezado.Keys.Count; i++)
            {
                if (i != clase)
                {
                    string respuesta = Microsoft.VisualBasic.Interaction.InputBox("Agregue el valor de: " + this.encabezado.Keys.ElementAt(i), "Valores", "?");
                    ingreso.Add(respuesta);
                }
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
                            posiblesValA = posiblesValores(m);
                            for (int i = 0; i < posiblesValA.Count; i++)
                            {
                                if (ingreso.ElementAt(m) == posiblesValA.ElementAt(i))
                                {
                                    porcentaje *= Convert.ToDouble(dataGridView1.Rows[i + almacenado].Cells[j + 1].Value);
                                    cadena += Convert.ToDouble(dataGridView1.Rows[i + almacenado].Cells[j + 1].Value).ToString() + " x ";
                                }
                            }
                            almacenado += posiblesValA.Count;
                        }
                        else if(encabezado[encabezado.ElementAt(m).Key].Key == "Numerico")
                        {
                            double res = 0;
                            res = (1 / (Math.Sqrt(2 * Math.PI) * desviacionEstandar.ElementAt(j)) * Math.Pow(Math.E, -1 * ((Convert.ToDouble(ingreso.ElementAt(m)) - media.ElementAt(j)) / (2 * Math.Pow(desviacionEstandar.ElementAt(j), 2)))));
                            porcentaje *= res;
                            cadena += res.ToString() + " x ";
                        }
                    }
                }
                porcentaje *= Convert.ToDouble(clases.ElementAt(j) / valorClase);
                cadena += Convert.ToDouble(clases.ElementAt(j) / valorClase).ToString() + " = " + porcentaje.ToString() + "\n";
                label3.Text += cadena;
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
            label3.Text += "Prediccion: " + posiblesValC.ElementAt(ultimo) + " con " + (mejor * 100) + "%";
        }
    }
}
