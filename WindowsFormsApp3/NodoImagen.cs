using System.Drawing;

namespace WindowsFormsApp3
{
    internal class NodoImagen
    {
        public string RutaArchivo { get; set; }
        public Image Imagen { get; set; }
        public NodoImagen Siguiente { get; set; }

        public NodoImagen(string ruta)
        {
            RutaArchivo = ruta;
            Imagen = Image.FromFile(ruta);
            Siguiente = null;
        }
    }
}