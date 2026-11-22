using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaSimplementeEnlazadaVideo
{
    public partial class Form1 : Form
    {
        private ListaSimpleEnlazadaCanales galeriaCanales;
        public Form1()
        {
            InitializeComponent();
            InicializarCanales();
        }

        private void InicializarCanales()
        {
            galeriaCanales = new ListaSimpleEnlazadaCanales();

            galeriaCanales.AgregarCanal("Video 1", System.IO.Path.Combine(Application.StartupPath, "videos", "Video1.mp4"));
            galeriaCanales.AgregarCanal("Video 2", System.IO.Path.Combine(Application.StartupPath, "videos", "Video2.mp4"));
            galeriaCanales.AgregarCanal("Video 3", System.IO.Path.Combine(Application.StartupPath, "videos", "Video3.mp4"));
            galeriaCanales.AgregarCanal("Video 4", System.IO.Path.Combine(Application.StartupPath, "videos", "Video4.mp4"));
            // Iniciar con el primer canal
            ReproducirCanal(galeriaCanales.ObtenerCanalActual());
        }

        private void ReproducirCanal(NodoCanal canal)
        {
            if (canal != null)
            {
                // 1. Mostrar el nombre del canal
                lblNombreCanal.Text = $"🔴 En Vivo: {canal.Nombre}";

                // 2. Cargar y reproducir el stream en el AxWindowsMediaPlayer
                // La propiedad URL es la clave para iniciar la reproducción.
                axWindowsMediaPlayer1.URL = canal.UrlStream;
            }
            else
            {
                lblNombreCanal.Text = "FIN DE LA LISTA DE CANALES";
                axWindowsMediaPlayer1.URL = string.Empty; // Detener la reproducción
            }
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            // Pide a la lista enlazada que avance su puntero al siguiente nodo
            NodoCanal siguienteCanal = galeriaCanales.ObtenerSiguienteCanal();

            // Actualiza la visualización
            ReproducirCanal(siguienteCanal);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            // Vuelve al primer nodo y actualiza la visualización
            galeriaCanales.Reiniciar();
            ReproducirCanal(galeriaCanales.ObtenerCanalActual());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NodoCanal canalAnterior = galeriaCanales.ObtenerCanalAnterior();
            ReproducirCanal(canalAnterior);
        }
    }
}
