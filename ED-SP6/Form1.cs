using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ED_SP6
{
    public partial class Form1 : Form
    {
        private Arbol Clientes = new Arbol();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if(txtNumeroCuenta.Text != "" && txtNombre.Text != "" && txtApellido.Text != "" && txtDni.Text !="")
            {
                Nodo cliente = new Nodo(); 
                cliente.NumeroCuenta = int.Parse(txtNumeroCuenta.Text);
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.DNI = txtDni.Text;
                Clientes.Insertar(cliente);
                //
                txtNumeroCuenta.Text = "";
                txtApellido.Text = "";
                txtNombre.Text = "";
                txtDni.Text = "";
                //
                grClientes.Rows.Clear();
                List<Nodo> clientes = new List<Nodo>();
                clientes = Clientes.Listar(Clientes.Raiz);
                foreach(Nodo n in clientes)
                {
                    grClientes.Rows.Add(n.NumeroCuenta.ToString(), n.Nombre, n.Apellido, n.DNI);
                }
            }
            else
            {
                MessageBox.Show("Complete los datos");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int Numero = int.Parse(txtNumeroCuenta.Text);
            //Nodo nodo = Clientes.Buscar(Numero);
            Nodo nodo = Clientes.BuscarRecursivo(Numero, Clientes.Raiz);
            if (nodo != null)
            {
                MessageBox.Show("Cliente: " + nodo.Nombre + ", " + nodo.Apellido);
            }
            else
            {
                MessageBox.Show("No Existe");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Nodo cliente1 = new Nodo();
            cliente1.NumeroCuenta = 100;
            cliente1.Nombre = "Juan";
            cliente1.Apellido = "Perez";
            cliente1.DNI = "3451901";
            Clientes.Insertar(cliente1);
            Nodo cliente2 = new Nodo();
            cliente2.NumeroCuenta = 130;
            cliente2.Nombre = "Luis";
            cliente2.Apellido = "Alonso";
            cliente2.DNI = "4587721";
            Clientes.Insertar(cliente2);
            Nodo cliente3 = new Nodo();
            cliente3.NumeroCuenta = 55;
            cliente3.Nombre = "Mario";
            cliente3.Apellido = "Lopez";
            cliente3.DNI = "2468137";
            Clientes.Insertar(cliente3);
            Nodo cliente4 = new Nodo();
            cliente4.NumeroCuenta = 82;
            cliente4.Nombre = "Liliana";
            cliente4.Apellido = "Benitez";
            cliente4.DNI = "8743432";
            Clientes.Insertar(cliente4);
            Nodo cliente5 = new Nodo();
            cliente5.NumeroCuenta = 144;
            cliente5.Nombre = "Julieta";
            cliente5.Apellido = "Johnson";
            cliente5.DNI = "4523091";
            Clientes.Insertar(cliente5);
            Nodo cliente6 = new Nodo();
            cliente6.NumeroCuenta = 110;
            cliente6.Nombre = "Alberto";
            cliente6.Apellido = "Kunz";
            cliente6.DNI = "3698123";
            Clientes.Insertar(cliente6);
            Nodo cliente7 = new Nodo();
            cliente7.NumeroCuenta = 35;
            cliente7.Nombre = "Cecila";
            cliente7.Apellido = "Toledo";
            cliente7.DNI = "1984363";
            Clientes.Insertar(cliente7);
            Nodo cliente8 = new Nodo();
            cliente8.NumeroCuenta = 21;
            cliente8.Nombre = "Carlos";
            cliente8.Apellido = "Funes";
            cliente8.DNI = "1984363";
            Clientes.Insertar(cliente8);
            Nodo cliente9 = new Nodo();
            cliente9.NumeroCuenta = 9;
            cliente9.Nombre = "Daniel";
            cliente9.Apellido = "Mercado";
            cliente9.DNI = "3897677";
            Clientes.Insertar(cliente9);

            List<Nodo> l = Clientes.Listar(Clientes.Raiz);
            grClientes.Rows.Clear();
            foreach(Nodo n in l)
            {
                grClientes.Rows.Add(n.NumeroCuenta.ToString(),
                    n.Nombre, n.Apellido, n.DNI);
            }
            int nivel = Clientes.Nivel(Clientes.Raiz);
            MessageBox.Show("Nivel del Arbol: " + nivel.ToString());
            nivel = Clientes.Nivel(Clientes.Raiz.Izquierdo);
            MessageBox.Show("Nivel del SubArbol Izquierdo: " + nivel.ToString());
            nivel = Clientes.Nivel(Clientes.Raiz.Derecho);
            MessageBox.Show("Nivel del SubArbol Derecho: " + nivel.ToString());
        }

        private void btnEquilibrar_Click(object sender, EventArgs e)
        {
            grClientes.Rows.Clear();
            Clientes.Equilibrar();
            int nivel = Clientes.Nivel(Clientes.Raiz);
            MessageBox.Show("Nivel del Arbol: " + nivel.ToString());
            nivel = Clientes.Nivel(Clientes.Raiz.Izquierdo);
            MessageBox.Show("Nivel del SubArbol Izquierdo: " + nivel.ToString());
            nivel = Clientes.Nivel(Clientes.Raiz.Derecho);
            MessageBox.Show("Nivel del SubArbol Derecho: " + nivel.ToString());
            List<Nodo> l = Clientes.Listar(Clientes.Raiz);
            grClientes.Rows.Clear();
            foreach (Nodo n in l)
            {
                grClientes.Rows.Add(n.NumeroCuenta.ToString(),
                    n.Nombre, n.Apellido, n.DNI);
            }
        }
    }
}
