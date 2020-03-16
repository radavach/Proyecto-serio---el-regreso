using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Proyecto_serio_el_regreso
{
    public partial class Form2 : Form
    {
        private Form1 form1;
        private Dictionary<string, KeyValuePair<string, string>> encabezado;
        private Dictionary<string, List<string>> instancias;
        private Dictionary<string, int> valores_faltantes;
        private int cant_instancias;
        private int cant_columnas;
        private string[] tipos_dato;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 form1, Dictionary<string, KeyValuePair<string, string>> encabezado, Dictionary<string, List<string>> instancias, Dictionary<string, int> valores_faltantes, int cant_instancias, int cant_columnas, string[] tipos_dato)
        {
            InitializeComponent();
            form1.Hide();
            this.form1 = form1;
            this.encabezado = encabezado;
            this.instancias = instancias;
            this.valores_faltantes = valores_faltantes;
            this.cant_instancias = cant_instancias;
            this.cant_columnas = cant_columnas;
            this.tipos_dato = tipos_dato;

            cmBoxColumnas.Items.AddRange(encabezado.Keys.ToArray());
        }



        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            List<double> valoresOrdenados = new List<double>();
            double sumatoria = 0;
            double media = 0;
            double mediana = 0;
            int indiceMedio = cant_instancias / 2;
            string columna;
            string tipoDato;

            lblResultado.Text = "Resultado:";

            //valor = Microsoft.VisualBasic.Interaction.InputBox("Teclea el numero de columna:", "Analisis univariable", "0");
            //nuValor = Convert.ToInt32(valor);
             
            if (string.IsNullOrEmpty(cmBoxColumnas.Text))
            {
                MessageBox.Show("Debes seleccionar la columna a analizar");
            }
            else
            {
                columna = cmBoxColumnas.Text;
                tipoDato = encabezado[columna].Key;

                if (tipoDato == "Nominal")
                {
                    MessageBox.Show("Tabla de frecuencias aquí");
                    List<KeyValuePair<string, int>> frecuencias = new List<KeyValuePair<string, int>>
                    {
                        new KeyValuePair<string, int>("Dinosaurios", 12),
                        new KeyValuePair<string, int>("Cucarachas", 32),
                        new KeyValuePair<string, int>("Venados", 20)
                    };
                    pruebaHistograma(frecuencias);
                    tabControl1.SelectedIndex = 1;
                }
                else if(tipoDato == "Numerico")
                {
                    //Media
                    //for (int i = 0; i < cant_instancias; i++)
                    //{
                    //    valoresOrdenados.Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[nuValor].Value));
                    //    sumatoria = sumatoria + Convert.ToDouble(dataGridView1.Rows[i].Cells[nuValor].Value);
                    //}
                    //valoresOrdenados.Sort();

                    valoresOrdenados.AddRange(instancias[columna].Select(double.Parse));
                    sumatoria = valoresOrdenados.Sum();

                    valoresOrdenados.Sort();
                    
                    //Moda
                    var moda = valoresOrdenados.GroupBy(n => n).OrderByDescending(g => g.Count()).Select(g => g.Key).FirstOrDefault();
                    //Mediana
                    if ((cant_instancias % 2) == 0)
                    {
                        mediana = ((valoresOrdenados.ElementAt(indiceMedio) +
                            valoresOrdenados.ElementAt((indiceMedio - 1))) / 2);
                    }
                    else
                    {
                        mediana = valoresOrdenados.ElementAt(indiceMedio);
                    }

                    //Desviacion estandar
                    double avg = valoresOrdenados.Average();
                    double desvStd = Math.Sqrt(valoresOrdenados.Average(v => Math.Pow(v - avg, 2)));

                    media = sumatoria / cant_instancias;
                    //MessageBox.Show(media.ToString(), "Media");
                    //MessageBox.Show(mediana.ToString(), "Mediana");
                    //MessageBox.Show(moda.ToString(), "Moda");
                    //MessageBox.Show(desvStd.ToString(), "Desviacion Estandar");

                    lblResultado.Text += Environment.NewLine + Environment.NewLine +
                        "Media:" + Environment.NewLine + media.ToString() + Environment.NewLine + Environment.NewLine +
                        "Mediana:" + Environment.NewLine + mediana.ToString() + Environment.NewLine + Environment.NewLine +
                        "Moda:" + Environment.NewLine + moda.ToString() + Environment.NewLine + Environment.NewLine +
                        "Desviacion Estandar:" + Environment.NewLine + desvStd.ToString();

                    pruebaBoxplot(valoresOrdenados, columna, media, mediana);
                    tabControl1.SelectedIndex = 0;
                }
                else if(tipoDato == "Texto")
                {
                    MessageBox.Show("El tipo de dato texto es incompatible para el analisis");
                }
            }
        }

        private void pruebaBoxplot(List<double> valoresOrdenados, string columna, double media, double mediana)
        {
            //BoxPlot
            double conversion = Convert.ToDouble(cant_instancias);
            int indiceMedio = cant_instancias / 2;

            double valorMinimo = valoresOrdenados.First();
            double valorMaximo = valoresOrdenados.Last();

            double q1 = (Convert.ToDouble(cant_instancias) + 1) / 4;
            double q3 = (3 * ((Convert.ToDouble(cant_instancias) + 1)) / 4);
            double iqr = 0;

            chartBoxplot.Series["s1"].Points.Clear();

            if (q1 % 1 == 0 || q3 % 1 == 0)
            {
                q1 = valoresOrdenados.ElementAt((cant_instancias + 1) / 4);
                q3 = valoresOrdenados.ElementAt((3 * (cant_instancias + 1)) / 4);
            }
            else
            {
                double indiceCuarto = Convert.ToDouble(indiceMedio) / 2;
                double valor1 = 0;
                double valor2 = 0;

                valor1 = ((Convert.ToDouble(cant_instancias) + 1) / 4);
                valor2 = ((3 * (Convert.ToDouble(cant_instancias) + 1)) / 4);

                // var valores1= valor1.ToString(CultureInfo.InvariantCulture).Split('.');
                // int indice1 = int.Parse(valores1[0]);
                // int d1 = int.Parse(valores1[1]);
                double indice1 = System.Math.Floor(valor1);
                double d1 = valor1 - indice1;
                double indice2 = System.Math.Floor(valor2);
                double d2 = valor2 - indice2;
                //MessageBox.Show(valor1.ToString(), "Original");
                //MessageBox.Show(indice1.ToString(), "Dollars");
                //MessageBox.Show(d1.ToString(), "Cents");
                //MessageBox.Show(valor2.ToString(), "Original");
                //MessageBox.Show(indice2.ToString(), "Dollars");
                //MessageBox.Show(d2.ToString(), "Cents");

                lblDatos.Text += "1. \n" + "Original: " + valor1.ToString() + Environment.NewLine +
                    "Dollars: " + indice1.ToString() + Environment.NewLine +
                    "Cents: " + d1.ToString() + Environment.NewLine + Environment.NewLine;

                lblDatos.Text += "2. \n" + "Original: " + valor2.ToString() + Environment.NewLine +
                    "Dollars: " + indice2.ToString() + Environment.NewLine +
                    "Cents: " + d2.ToString() + Environment.NewLine + Environment.NewLine;

                int index1 = Convert.ToInt32(indice1);
                int index2 = Convert.ToInt32(indice2);
                //double xi1 = Convert.ToDouble(valoresOrdenados.ElementAt(index1));
                //double xj1 = valoresOrdenados.ElementAt(index1+1);
                //MessageBox.Show(xi1.ToString(), "Dollars");
                //MessageBox.Show(xj1.ToString(), "Cents");

                q1 = Convert.ToDouble(valoresOrdenados.ElementAt(index1 - 1)) + (d1 * (Convert.ToDouble(valoresOrdenados.ElementAt(index1)) - Convert.ToDouble(valoresOrdenados.ElementAt(index1 - 1))));
                q3 = Convert.ToDouble(valoresOrdenados.ElementAt(index2 - 1)) + (d2 * (Convert.ToDouble(valoresOrdenados.ElementAt(index2)) - Convert.ToDouble(valoresOrdenados.ElementAt(index2 - 1))));
            }

            //MessageBox.Show(q1.ToString(), "Cuartil 1");
            //MessageBox.Show(q3.ToString(), "Cuartil 3");

            lblDatos.Text += "Cuartil 1: " + q1.ToString() + Environment.NewLine +
                "Cuartil 2: " + q3.ToString();

            iqr = q3 - q1;
            double outlierBajo = q1 - (1.5 * iqr);
            double outlierAlto = q3 + (1.5 * iqr);

            for (int m = 0; m < cant_instancias; m++)
            {
                //if (Convert.ToDouble(dataGridView1.Rows[m].Cells[nuValor].Value) > outlierAlto || Convert.ToDouble(dataGridView1.Rows[m].Cells[nuValor].Value) < outlierBajo)
                if (Convert.ToDouble(instancias[columna][m]) > outlierAlto || Convert.ToDouble(instancias[columna][m]) < outlierBajo)
                {
                    DialogResult dialogResult = MessageBox.Show("Se detectaron outliers, ¿Deseas reemplazarlos?", "Outliers detectados", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        for (int n = 0; n < cant_instancias; n++)
                        {
                            //if (Convert.ToDouble(dataGridView1.Rows[n].Cells[nuValor].Value) > outlierAlto || Convert.ToDouble(dataGridView1.Rows[n].Cells[nuValor].Value) < outlierBajo)
                            if (Convert.ToDouble(instancias[columna][n]) > outlierAlto || Convert.ToDouble(instancias[columna][n]) < outlierBajo)
                            {
                                //dataGridView1.Rows[n].Cells[nuValor].Value = Convert.ToString(media);
                                instancias[columna][n] = Convert.ToString(media);
                            }

                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        break;
                    }
                }

            }

            //chart1.Series["s1"].Points.AddXY(Nombre del boxplot, valorMinimo, valorMaximo, q1, q3, mediana, media);
            chartBoxplot.Series["s1"].Points.AddXY(columna, valorMinimo, valorMaximo, q1, q3, mediana, media);

            ChartArea ca = chartBoxplot.ChartAreas.First();
            Axis ay = ca.AxisY;
            Series boxplot = chartBoxplot.Series.First();

            double yMin = chartBoxplot.Series.Select(s => s.Points.Min(x => x.YValues.Min())).Min();
            double yMax = chartBoxplot.Series.Select(s => s.Points.Max(x => x.YValues.Max())).Max();

            ay.Maximum = yMax + (yMax/10);
            ay.Minimum = yMin - (yMin/10);
        }

        private void pruebaHistograma(List<KeyValuePair<string, int>>frecuencias)
        {
            chartHistograma.Series["s1"].Points.Clear();
            lblFrecuencias.Text = "";

            foreach(KeyValuePair<string, int> valor in frecuencias)
            {
                chartHistograma.Series["s1"].Points.AddXY(valor.Key, valor.Value);
                lblFrecuencias.Text += valor.Key + ": " + valor.Value.ToString() + "\n";
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }
    }
}
