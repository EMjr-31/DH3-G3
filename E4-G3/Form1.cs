using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E4_G3
{      
    public partial class Form1 : Form
    {
        private List<producto> Productos = new List<producto>();
        private int edit_indice = -1;

        ///method update grid
        private void UpdateGrid()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = Productos;
        }

        /// method reset
        private void reset()
        {
            txtNombre.Clear();
            txtDesc.Clear();
            txtMarca.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtNombre.Focus();
            pictureBox1.Image = null;                               
        } 
        
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Descripcion_Click(object sender, EventArgs e)
        {

        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvProductos_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow select = dgvProductos.SelectedRows[0];
            int posicion = dgvProductos.Rows.IndexOf(select);
            edit_indice = posicion;

            producto product = Productos[posicion];
            txtNombre.Text = product.Nombre;
            txtDesc.Text = product.Descripcion;
            txtMarca.Text = product.Marca;
            txtPrecio.Text = Convert.ToString(product.Precio);
            txtStock.Text = Convert.ToString(product.Stock);
            pictureBox1.Image = Image.FromFile(product.Img);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (edit_indice > -1)
            {
                Productos.RemoveAt(edit_indice);
                edit_indice = -1;
                UpdateGrid();
            }
            else
            {
                MessageBox.Show("Selecion el producto dando Doble Click");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            producto product = new producto();
            product.Nombre = txtNombre.Text;
            product.Descripcion= txtDesc.Text;
            product.Marca = txtMarca.Text;
            product.Precio = float.Parse(txtPrecio.Text);
            product.Stock = int.Parse(txtStock.Text);
            
            product.Img = Direccion;
            if (edit_indice > -1)
            {
                Productos[edit_indice] = product;
                edit_indice = -1;
            }
            else
            {
                Productos.Add(product);
            }
            UpdateGrid();
            reset();
        }
        ///Variable de venta de dialogo
        public OpenFileDialog buscar = new OpenFileDialog();
        private void button1_Click(object sender, EventArgs e)
        {
            BuscarImagen();
        }
        //metodo ded buscar img
        public void BuscarImagen()
        {
            buscar.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            DialogResult r = buscar.ShowDialog();
            if (r == DialogResult.Abort)
            {
                return;
            }
            if (r == DialogResult.Cancel)
            {
                return;
            }
            Direccion = buscar.FileName;
            pictureBox1.Image = Image.FromFile(buscar.FileName);
        }
        ///Clase almacendaro de direcion
        private string direccion;
        public string Direccion { get => direccion; set => direccion = value; }

        private void brnCancelar_Click(object sender, EventArgs e)
        {
            reset();
            edit_indice = -1;
        }
    }
}
