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
                MessageBox.Show("Debes seleccionar la columna a eliminar");
            }
            else
            {
                columna = cmBoxColumnas.Text;
                tipoDato = encabezado[columna].Key;

                if (tipoDato == "Nominal")
                {
                    MessageBox.Show("Tabla de frecuencias aquí");
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
                }
                else if(tipoDato == "Texto")
                {
                    MessageBox.Show("El tipo de dato texto es incompatible para el analisis");
                }
            }

        }
    }
}
