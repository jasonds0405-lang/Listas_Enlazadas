using System;
using System.Collections.Generic;
using System.Drawing;
using WindowsFormsApp3;

namespace ListaEnlazadalimagenes
{
    public class ListaSimpleEnlazada
    {
        private NodoImagen cabeza;
        private NodoImagen actual;
        private int total;
        private int indiceActual;

        public int Total => total;
        public int IndiceActual => indiceActual;

        public ListaSimpleEnlazada()
        {
            cabeza = null;
            actual = null;
            total = 0;
            indiceActual = 0;
        }

        public bool EstaVacia()
        {
            return cabeza == null;
        }

        // Agregar imagen al final de la lista
        public void AgregarImagen(string ruta)
        {
            NodoImagen nuevoNodo = new NodoImagen(ruta);

            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                actual = cabeza;
                indiceActual = 1;
            }
            else
            {
                NodoImagen ultimo = cabeza;

                while (ultimo.Siguiente != null)
                {
                    ultimo = ultimo.Siguiente;
                }

                ultimo.Siguiente = nuevoNodo;
            }

            total++;
        }

        // Obtener imagen actual
        public Image ObtenerImagenActual()
        {
            if (actual != null)
            {
                return actual.Imagen;
            }

            return null;
        }

        // Avanzar al siguiente nodo sin circularidad
        public void ObtenerSiguienteImagen()
        {
            if (actual != null && actual.Siguiente != null)
            {
                actual = actual.Siguiente;
                indiceActual++;
            }
        }

        // Retroceder al nodo anterior sin circularidad
        public void ObtenerAnteriorImagen()
        {
            if (actual == null || actual == cabeza)
                return;

            NodoImagen temp = cabeza;

            while (temp.Siguiente != actual)
            {
                temp = temp.Siguiente;
            }

            actual = temp;
            indiceActual--;
        }

        // Regresar a la primera imagen
        public void Reiniciar()
        {
            if (cabeza != null)
            {
                actual = cabeza;
                indiceActual = 1;
            }
            else
            {
                actual = null;
                indiceActual = 0;
            }
        }

        // Eliminar imagen actual
        public void EliminarActual()
        {
            if (cabeza == null || actual == null)
                return;

            NodoImagen eliminado = actual;

            // Si el nodo actual es la cabeza
            if (actual == cabeza)
            {
                cabeza = cabeza.Siguiente;
                actual = cabeza;

                total--;

                if (total > 0)
                {
                    indiceActual = 1;
                }
                else
                {
                    actual = null;
                    indiceActual = 0;
                }

                return;
            }

            // Buscar el nodo anterior al actual
            NodoImagen anterior = cabeza;

            while (anterior.Siguiente != actual)
            {
                anterior = anterior.Siguiente;
            }

            // Si existe un nodo siguiente, pasa a él
            if (actual.Siguiente != null)
            {
                anterior.Siguiente = actual.Siguiente;
                actual = actual.Siguiente;
            }
            else
            {
                // Si se elimina el último, pasa al anterior
                anterior.Siguiente = null;
                actual = anterior;
                indiceActual--;
            }

            total--;
        }

        // Obtener todas las rutas de la lista
        public string[] ObtenerTodasLasRutas()
        {
            List<string> listaRutas = new List<string>();

            NodoImagen temp = cabeza;

            while (temp != null)
            {
                if (!string.IsNullOrEmpty(temp.RutaArchivo))
                {
                    listaRutas.Add(temp.RutaArchivo);
                }

                temp = temp.Siguiente;
            }

            return listaRutas.ToArray();
        }
    }
}