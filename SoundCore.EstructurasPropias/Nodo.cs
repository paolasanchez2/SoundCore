// =============================================================================
// Proyecto Integral Unidad 2: SoundCore Engine GUI
// Archivo: Nodo.cs
// Integrantes: [Nombre completo del integrante 1] - [Número de control]
//              [Nombre completo del integrante 2] - [Número de control]
// TecNM Campus Monclova - Ingeniería en Informática
// Asignatura: Estructura de Datos (3er Semestre)
// Fecha: 27/09/2026  Versión: 1.0
// =============================================================================

namespace SoundCore.EstructurasPropias
{
    /// <summary>
    /// Bloque constructivo básico de la lista enlazada simple: un valor y
    /// una referencia al siguiente nodo de la secuencia.
    /// </summary>
    public class Nodo<T>
    {
        public T Valor { get; set; }
        public Nodo<T>? Siguiente { get; set; }

        public Nodo(T valor)
        {
            Valor = valor;
            Siguiente = null;
        }
    }
}
