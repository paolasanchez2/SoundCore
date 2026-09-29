// =============================================================================
// Proyecto Integral Unidad 2: SoundCore Engine GUI
// Archivo: ListaSimpleEnlazada.cs
// Integrantes: [Nombre completo del integrante 1] - [Número de control]
//              [Nombre completo del integrante 2] - [Número de control]
// TecNM Campus Monclova - Ingeniería en Informática
// Asignatura: Estructura de Datos (3er Semestre)
// Fecha: 27/09/2026  Versión: 1.0
//
// Regla de oro algorítmica: esta clase opera exclusivamente sobre punteros
// Nodo<T>.Siguiente. Prohibido usar arrays internos, List<T> u otras
// estructuras auxiliares para implementar los métodos requeridos.
// =============================================================================

using System.Collections;

namespace SoundCore.EstructurasPropias
{
    /// <summary>
    /// Lista enlazada simple genérica implementada desde cero mediante
    /// manipulación directa de referencias (sin colecciones de la BCL).
    /// </summary>
    public class ListaSimpleEnlazada<T> : IEnumerable<T>
    {
        public Nodo<T>? Cabeza { get; private set; }
        public int Conteo { get; private set; }

        public bool EstaVacia => Cabeza == null;

        // 1. Inserción al final: O(n)
        public void AgregarAlFinal(T valor)
        {
            var nuevoNodo = new Nodo<T>(valor);
            if (EstaVacia)
            {
                Cabeza = nuevoNodo;
            }
            else
            {
                var actual = Cabeza!;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }
            Conteo++;
        }

        // 2. Up Next: inserción inmediata tras la cabeza: O(1)
        public void ReproducirSiguiente(T valor)
        {
            var nuevoNodo = new Nodo<T>(valor);
            if (EstaVacia)
            {
                Cabeza = nuevoNodo;
            }
            else
            {
                nuevoNodo.Siguiente = Cabeza!.Siguiente;
                Cabeza.Siguiente = nuevoNodo;
            }
            Conteo++;
        }

        // 3. Desencolar pista actual (eliminar cabeza): O(1)
        public T AvanzarPista()
        {
            if (EstaVacia)
                throw new InvalidOperationException("La cola de reproducción está vacía.");

            T valor = Cabeza!.Valor;
            Cabeza = Cabeza.Siguiente;
            Conteo--;
            return valor;
        }

        // 4. Inversión in-place: O(n) tiempo, O(1) memoria auxiliar
        // Estricto: prohibido crear listas nuevas o alterar valores;
        // solo se redirigen los enlaces 'Siguiente'.
        public void Invertir()
        {
            Nodo<T>? previo = null;
            Nodo<T>? actual = Cabeza;
            Nodo<T>? siguiente;

            while (actual != null)
            {
                siguiente = actual.Siguiente; // Guardar puntero al resto de la lista
                actual.Siguiente = previo;    // Invertir la referencia
                previo = actual;              // Desplazar previo
                actual = siguiente;           // Desplazar actual
            }

            Cabeza = previo;
        }

        // 5. Inserción ordenada por criterio (ej. BPM): O(n)
        // Inserta un nodo NUEVO en su posición correcta. Se usa solo para
        // agregar valores sueltos a una lista ya ordenada.
        public void InsertarOrdenado(T valor, Comparison<T> comparador)
        {
            var nuevo = new Nodo<T>(valor);

            if (EstaVacia || comparador(valor, Cabeza!.Valor) < 0)
            {
                nuevo.Siguiente = Cabeza;
                Cabeza = nuevo;
                Conteo++;
                return;
            }

            var actual = Cabeza;
            while (actual.Siguiente != null && comparador(valor, actual.Siguiente.Valor) >= 0)
            {
                actual = actual.Siguiente;
            }

            nuevo.Siguiente = actual.Siguiente;
            actual.Siguiente = nuevo;
            Conteo++;
        }

        // 5b. Ordenamiento in-place (insertion sort enlazado): O(n^2) tiempo, O(1) memoria auxiliar.
        // Reorganiza los nodos YA EXISTENTES desenganchándolos uno a uno de la
        // lista desordenada y reconectándolos dentro de una sublista ordenada.
        // No se crea ningún Nodo<T> nuevo ni ninguna estructura auxiliar: solo
        // se manipulan los punteros Siguiente de los nodos originales.
        public void OrdenarPorCriterio(Comparison<T> comparador)
        {
            if (EstaVacia || Cabeza!.Siguiente == null) return; // 0 o 1 elemento: ya está ordenada

            Nodo<T>? sinOrdenar = Cabeza.Siguiente; // Resto de la lista aún por procesar
            Cabeza.Siguiente = null;                // La sublista ordenada empieza solo con el primer nodo

            while (sinOrdenar != null)
            {
                Nodo<T> actual = sinOrdenar;
                sinOrdenar = sinOrdenar.Siguiente;   // Desenganchar 'actual' del resto sin ordenar

                if (comparador(actual.Valor, Cabeza.Valor) < 0)
                {
                    // 'actual' va antes que la cabeza de la parte ordenada
                    actual.Siguiente = Cabeza;
                    Cabeza = actual;
                }
                else
                {
                    // Buscar el punto de inserción dentro de la parte ya ordenada
                    Nodo<T> puntero = Cabeza;
                    while (puntero.Siguiente != null && comparador(actual.Valor, puntero.Siguiente.Valor) >= 0)
                    {
                        puntero = puntero.Siguiente;
                    }
                    actual.Siguiente = puntero.Siguiente;
                    puntero.Siguiente = actual;
                }
            }
        }

        // 6. Depurar duplicados sin estructuras externas: O(n^2) tiempo, O(1) espacio
        public void DepurarDuplicados(Func<T, T, bool> sonIguales)
        {
            var actual = Cabeza;

            while (actual != null)
            {
                var corredor = actual;
                while (corredor.Siguiente != null)
                {
                    if (sonIguales(actual.Valor, corredor.Siguiente.Valor))
                    {
                        // Saltear el nodo duplicado para desconectarlo de la memoria
                        corredor.Siguiente = corredor.Siguiente.Siguiente;
                        Conteo--;
                    }
                    else
                    {
                        corredor = corredor.Siguiente;
                    }
                }
                actual = actual.Siguiente;
            }
        }

        public void Limpiar()
        {
            Cabeza = null;
            Conteo = 0;
        }

        // Habilita data binding y foreach en Windows Forms
        public IEnumerator<T> GetEnumerator()
        {
            var actual = Cabeza;
            while (actual != null)
            {
                yield return actual.Valor;
                actual = actual.Siguiente;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
