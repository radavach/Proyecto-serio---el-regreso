using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Proyecto_serio_el_regreso
{
    public partial class Form3 : Form
    {
        private Dictionary<string, KeyValuePair<string, string>> encabezado;
        private Dictionary<string, List<string>> instancias;
        Form1 form1;

        public Form3()
        {
            InitializeComponent();
        }

        public Form3(Form1 form1, Dictionary<string, KeyValuePair<string,string>>encabezado, Dictionary<string, List<string>> instancias) : this()
        {
            form1.Hide();
            this.encabezado = encabezado;
            this.instancias = instancias;
            this.form1 = form1;
            try
            {
                cmBoxDato1.Items.AddRange(encabezado.Keys.ToArray());
                cmBoxDato2.Items.AddRange(encabezado.Keys.ToArray());
            }
            catch (System.NullReferenceException) { }
        }

        private double tschuprow(List<string> a, List<string> b, List<string> posiblesValoresA, List<string> posiblesValoresB)
        {
            double resultado = 0;
            double chiCuadrada = 0;
            double temp = 0;
            double e = 0;
            double totalInstancias = 0;
            int[,] frecuencias = new int[posiblesValoresA.Count, posiblesValoresB.Count];
            Dictionary<string, int> totales_A = new Dictionary<string, int>();
            Dictionary<string, int> totales_B = new Dictionary<string, int>();

            //Aumenta 1 a la matriz de frecuencias para no tener errores y dividir por 0
            for(int i = 0; i < posiblesValoresA.Count; i++)
            {
                for(int j = 0; j < posiblesValoresB.Count; j++)
                {
                    frecuencias[i,j] = 1;
                    
                    //Aqui se evalua si el valor esta en la lista de totales, si esta se obtiene el valor y se suma uno, en caso contrario se asigna el 1
                    totales_A[posiblesValoresA[i]] = totales_A.ContainsKey(posiblesValoresA[i]) ? totales_A[posiblesValoresA[i]] + 1 : 1;
                    totales_B[posiblesValoresB[j]] = totales_B.ContainsKey(posiblesValoresB[j]) ? totales_B[posiblesValoresB[j]] + 1 : 1;

                    totalInstancias++;
                }
            }

            //Recorre las instancias y llena la matriz
            for (int i = 0, j = 0; i < a.Count && j < b.Count; i++, j++)
            {
                string elementoA = Regex.Replace(a[i], @"\s", "");
                string elementoB = Regex.Replace(b[j], @"\s", "");
                if (posiblesValoresA.Contains(elementoA) && posiblesValoresB.Contains(elementoB))
                {
                    frecuencias[posiblesValoresA.IndexOf(elementoA), posiblesValoresB.IndexOf(elementoB)]++;

                    //cuenta el total de elementos de cada dominio
                    if (!totales_A.ContainsKey(elementoA))
                    {
                        totales_A[elementoA] = 1;
                    }
                    if (!totales_B.ContainsKey(elementoB))
                    {
                        totales_B[elementoB] = 1;
                    }
                    totales_A[elementoA]++;
                    totales_B[elementoB]++;
                    totalInstancias++;
                }
                else
                {
                    //El par de elementos en a y b no se encuenta en los dominio asignado para estas instancias
                    //No se suma, no se hace nada
                }
            }

            //Recorre los dominios para hacer los calculos de la matriz
            foreach (string valorA in posiblesValoresA.ToList())
            {
                foreach (string valorB in posiblesValoresB.ToList())
                {
                    e = 0;
                    temp = 0;
                    e = (totales_A[valorA] * totales_B[valorB]) / totalInstancias;
                    temp = Math.Pow(frecuencias[posiblesValoresA.IndexOf(valorA), posiblesValoresB.IndexOf(valorB)] - e, 2) / e;
                    chiCuadrada = chiCuadrada + temp;
                }
            }

            double denominador = 0;
            denominador = Math.Sqrt((posiblesValoresA.Count - 1) * (posiblesValoresB.Count - 1));
            denominador = denominador * totalInstancias;

            resultado = chiCuadrada / denominador;
            resultado = Math.Sqrt(resultado);

            return resultado;

        }

        private double pearson(List<string> a, List<string> b)
        {
            double promedioA = promedio(a);
            double promedioB = promedio(b);

            double conversionA, conversionB;
            double numerador = 0;
            double denominador = 0;
            double resultado = 0;

            for (int i = 0, j = 0; i < a.Count && j < b.Count; i++, j++)
            {
                if (double.TryParse(a[i], out conversionA) && double.TryParse(b[j], out conversionB))
                {
                    numerador = numerador + ((conversionA - promedioA) * (conversionB - promedioB));
                }
            }

            denominador = (a.Count) * (desviacion(a)) * (desviacion(b));

            resultado = numerador / denominador;

            return resultado;
        }

        private double promedio(List<string> a)
        {
            double resultado = 0;
            double conversion;
            foreach (string valor in a)
            {
                if (double.TryParse(valor, out conversion))
                {
                    resultado += conversion;
                }
            }
            resultado = resultado / a.Count();
            return resultado;
        }

        private double desviacion(List<string> a)
        {
            double resultado = 0;
            double conversion;
            double prom = promedio(a);

            foreach (string valor in a)
            {
                if (double.TryParse(valor, out conversion))
                {
                    resultado += Math.Pow(conversion - prom, 2);
                }
            }
            resultado = resultado / a.Count();
            resultado = Math.Sqrt(resultado);

            return resultado;
        }
        
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }

        private void btnAnalisis_Click(object sender, EventArgs e)

        {
            try
            {
                string elemento1 = cmBoxDato1.Text;
                string elemento2 = cmBoxDato2.Text;

                lblResultado.Text += "";

                if (encabezado[elemento1].Key == encabezado[elemento2].Key)
                {
                    if (encabezado[elemento1].Key == "Numerico")
                    {
                        lblResultado.Text = "El coeficiente de pearson es: " + pearson(instancias[elemento1], instancias[elemento2]);
                    }
                    else if (encabezado[elemento1].Key == "Nominal")
                    {
                        List<string> posiblesValoresA = new List<string>();
                        List<string> posiblesValoresB = new List<string>();

                        string dominiosA = encabezado[elemento1].Value;
                        string dominiosB = encabezado[elemento2].Value;

                        string[] elementos = dominiosA.TrimStart('\\', 'b', '(').TrimEnd(')', '\\', 'b').Split('|');
                        foreach (string i in elementos)
                        {
                            posiblesValoresA.Add(Regex.Replace(i, @"\s", ""));
                        }

                        elementos = dominiosB.TrimStart('\\', 'b', '(').TrimEnd(')', '\\', 'b').Split('|');
                        foreach (string i in elementos)
                        {
                            posiblesValoresB.Add(Regex.Replace(i, @"\s", ""));
                        }

                        lblResultado.Text = "Los datos son Nominales, el coeficiente es: " + tschuprow(instancias[elemento1], instancias[elemento2], posiblesValoresA, posiblesValoresB);
                    }
                    else
                    {
                        lblResultado.Text = "No se pueden comparar estos elementos";
                    }

                    while (dataGridView1.Columns.Count > 0)
                    {
                        dataGridView1.Columns.RemoveAt(0);
                    }
                    dataGridView1.Rows.Clear();

                    dataGridView1.Columns.Add(elemento1, elemento1);
                    dataGridView1.Columns.Add(elemento2, elemento2);

                    for (int i = 0; i < instancias[elemento1].Count; i++)
                    {
                        int fila = dataGridView1.Rows.Add();
                        dataGridView1.Rows[fila].Cells[elemento1].Value = instancias[elemento1][i];
                        dataGridView1.Rows[fila].Cells[elemento2].Value = instancias[elemento2][i];
                    }
                }
                else
                {
                    lblResultado.Text = "No se pueden comparar estos elementos";
                }
            }
            catch(System.NullReferenceException)
            { MessageBox.Show("No se ha cargado el archivo"); }
        }

    }
}
