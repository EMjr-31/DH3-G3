using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E4_G3
{
    class producto
    {
        string nombre;
        string descripcion;
        string marca;
        float precio;
        int stock;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Marca { get => marca; set => marca = value; }
        public float Precio { get => precio; set => precio = value; }
        public int Stock { get => stock; set => stock = value; }
    }
}
