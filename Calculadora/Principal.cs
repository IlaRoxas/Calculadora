using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    /*
     En C#, las enumeraciones se utilizan para definir un conjunto de valores constantes relacionados. 
     */
    //Ayuda a definir todos los valores posibles que puede contener un dato, en este caso la operación
    //Además, lo hace más legible
    public enum Operacion
    {
        noDefinida = 0,
        Suma = 1,
        Resta = 2,
        Multiplicacion = 3,
        Division = 4
    }
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        double valor1 = 0;
        double valor2 = 0;
        Operacion operador = Operacion.noDefinida;
        bool nroLeido=false;
        private void btn0_Click_1(object sender, EventArgs e)
        {
            nroLeido= true;
            if (txtScreen.Text == "0") return;
            else txtScreen.Text += "0";
        }
        private void LeerNro(string numero)
        {
            nroLeido = true;
            /* REEMPLAZA EL PRIMER "0" POR EL NÚMERO INGRESADO Y APILA NÚMEROS EN LA CAJA DE TEXTO Y */
            if (txtScreen.Text == "0" && txtScreen.Text != null)
            {
                txtScreen.Text = numero;
            }
            else
            {
                txtScreen.Text += numero;
            }
        }
        private void btn1_Click_1(object sender, EventArgs e)
        {
            LeerNro("1");
          
        }
        private void btn2_Click_1(object sender, EventArgs e)
        {
            LeerNro("2");
           
        }
        private void btn3_Click_1(object sender, EventArgs e)
        {
            LeerNro("3");
            
        }
        private void btn4_Click_1(object sender, EventArgs e)
        {
            LeerNro("4");
            
        }
        private void btn5_Click_1(object sender, EventArgs e)
        {
            LeerNro("5");
           
        }
        private void btn6_Click_1(object sender, EventArgs e)
        {
            LeerNro("6");
           
        }
        private void btn7_Click_1(object sender, EventArgs e)
        {
            LeerNro("7");
           
        }
        private void btn8_Click_1(object sender, EventArgs e)
        {
            LeerNro("8");

        }
        private void btn9_Click_1(object sender, EventArgs e)
        {
            LeerNro("9");

            
        }
        private void ImprimirValoresDeOperadoresPorPantalla(string operador)//LABEL CON VALOR NUMÉRICO MÁS LOS OPERADORES
        {
            valor1 = Convert.ToDouble(txtScreen.Text); //CONVIERTO EL VALOR DE LA CAJA DE TEXTO EN DOUBLE
            lblHistorial.Text = txtScreen.Text + operador; /*EL LABEL LEERÁ ESE VALOR Y LE AGREGARÁ EL OPERADOR INGRESADO  
                                                             (SUMA, RESTA, MULTIPLICACION Y DIVISION) */
            txtScreen.Text = ""; //LIMPIA LA CAJA DE TEXTO PARA RECIBIR EL SIGUIENTE VALOR.
        }
        private double EjecutarOperacion()// AQUÍ ESTÁN LOS RESULTADOS DE LAS 4 OPERACIONES //
        {
            double resultado = 0;
            switch (operador)
            {
                case Operacion.Suma:
                    resultado = valor1 + valor2;
                    break;
                case Operacion.Resta:
                    resultado = valor1 - valor2;
                    break;
                case Operacion.Multiplicacion:
                    resultado = valor1 * valor2;
                    break;
                case Operacion.Division:
                    if (valor2 == 0)
                    {
                        lblHistorial.Text = "No se puede dividir entre 0";
                        resultado = 0;
                    }
                    else
                    {
                        resultado = valor1 / valor2;
                    }
                    break;
            }
            return resultado;
        }
        private void btnSuma_Click_1(object sender, EventArgs e)
        {
            operador = Operacion.Suma;
            ImprimirValoresDeOperadoresPorPantalla("+");
        }
        private void btnResta_Click_1(object sender, EventArgs e)
        {
            operador = Operacion.Resta;
            ImprimirValoresDeOperadoresPorPantalla("-");
            
        }
        private void btnMultiplicacion_Click(object sender, EventArgs e)
        {
            operador = Operacion.Multiplicacion;
            ImprimirValoresDeOperadoresPorPantalla("*");
            
        }
        private void btnDivision_Click(object sender, EventArgs e)
        {
            operador = Operacion.Division;
            ImprimirValoresDeOperadoresPorPantalla("/");
            
        }
        private void btnResultado_Click_1(object sender, EventArgs e)
        {
            if (valor2 == 0 && nroLeido)
            {
                valor2 = Convert.ToDouble(txtScreen.Text);
                lblHistorial.Text += valor2 + "="; //Le concateno lo que tenga "valor2" más el "="
                double resultado = EjecutarOperacion();
                txtScreen.Text = Convert.ToString(resultado); //El resultado de la operación se
                                                              //muestra en la pantalla de la calculadora.
                valor1 = 0;
                valor2 = 0;
                nroLeido= false;
            }
        }
        private void btnLogo_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text.Length > 1)
            {
                string cajaScreen= txtScreen.Text;
                cajaScreen= cajaScreen.Substring(0, cajaScreen.Length - 1);//elimina desde la posición "0" hasta lo que mide esa 
                                                                          //esa cadena -1
                if (cajaScreen.Length == 1 && cajaScreen.Contains("-")) //borra el último dígito si éste es negativo
                    txtScreen.Text = "0"; 
                else 
                    txtScreen.Text = cajaScreen;
            }
            else
            {
                txtScreen.Text = "0";
            }
            
        }
        private void btnC_Click(object sender, EventArgs e)
        {
            txtScreen.Text = "0";
            lblHistorial.Text= "";
            
        }
        private void btnComa_Click(object sender, EventArgs e)
        {
            if(txtScreen.Text.Contains(",")) return;
            else txtScreen.Text += ",";
        }
        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.Equals(Keys.Add) || e.KeyCode.Equals(Keys.Oemplus))
            {
                
            }
        }


    }
}
