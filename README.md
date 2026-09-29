# 🎧 Proyecto Integral Unidad 2: SoundCore Engine GUI
### *DJ Queue & Transition Manager — Listas Enlazadas Simples vs. Colecciones Nativas .NET 10*

> **TecNM Campus Monclova — Ingeniería en Informática**  
> **Asignatura:** Estructura de Datos (3er Semestre)  
> **Unidad:** 2 — Estructuras de Datos Lineales  

---

## 📌 1. Contexto y Justificación Académica

En los sistemas modernos de streaming de audio y software profesional para DJ (como *Pioneer Rekordbox*, *Serato DJ* o *Spotify*), la cola de reproducción (*DJ Play Queue*) requiere manipular dinámicamente el orden de los elementos en memoria en tiempo real, sin incurrir en costos computacionales excesivos causados por el desplazamiento de arreglos.

El propósito de este reto es **confrontar de manera práctica, visual y cuantitativa**:
1. **Una Lista Enlazada Simple genérica construida desde cero** (`ListaSimpleEnlazada<T>` y `Nodo<T>`), mediante manipulación directa de punteros/referencias y sin usar estructuras auxiliares.
2. **Las colecciones nativas estándar de .NET 10** (`System.Collections.Generic.LinkedList<T>` y `System.Collections.Generic.List<T>`).
3. **El impacto en rendimiento y memoria** de estas estructuras mediante una Interfaz Gráfica de Usuario (**GUI en Windows Forms**), dotada de un panel interactivo de reproducción y un módulo de **benchmark en tiempo real** con telemetría.

---

## ⚙️ 2. Requisitos Técnicos del Entorno

| Parámetro | Especificación |
| :--- | :--- |
| **Lenguaje** | C# 14 / .NET 10.0 |
| **Tipo de Proyecto** | Windows Forms (`<TargetFramework>net10.0-windows</TargetFramework>`) |
| **Arquitectura / Patrón** | Separación en capas: Lógica de negocio/estructuras (`SoundCore.EstructurasPropias`, `SoundCore.Modelos`) y Presentación (`SoundCore.UI`) |
| **Dependencias** | Ninguna librería externa obligatoria (Uso exclusivo de BCL de .NET) |

---

## 🖥️ 3. Especificación de la Interfaz Gráfica (Windows Forms)

### 3.1. Distribución Visual (Layout Mockup)

El formulario principal (`MainForm`) se organiza en 4 secciones funcionales clave:

```text
+---------------------------------------------------------------------------------------------------+
|  SoundCore Engine v2.0 - DJ Set Controller [TecNM Monclova]                           [_][X]     |
+---------------------------------------------------------------------------------------------------+
| [ PANEL SUPERIOR: REGISTRO DE PISTA ]                                                             |
| Título: [___________]  Artista: [___________]  BPM: [ 124 ]  Duración(s): [ 210 ]                 |
| Modo de Estructura: (o) Lista Simple Propia (Nodos)    ( ) .NET LinkedList<T>    ( ) .NET List<T> |
+---------------------------------+-----------------------------------------------------------------+
| [ ACCIONES DE COLA ]            | [ PLAYLIST VISUAL / COLA EN VIVO ]                              |
| [ + Encolar al Final ]          | Estado Actual: ▶ Reproduciendo: "Strobe - deadmau5 (128 BPM)"   |
| [ ⏭ Reproducir Siguiente ]      |-----------------------------------------------------------------|
| [ ⏩ Avanzar Pista ]            | [001] "Ghost Voices" | Virtual Self | 120 BPM | [Nodo 0x4A -> Next]  |
| [ ⇅ Invertir Lista (In-Place)]  | [002] "Opus"         | Eric Prydz   | 126 BPM | [Nodo 0x8F -> Next]  |
| [ ⚡ Ordenar por Curva BPM ]     | [003] "Language"     | Porter R.    | 128 BPM | [Nodo 0x1C -> Null]  |
| [ 🧹 Purgar Duplicados ]        | Total en cola: 3 pistas | Duración acumulada: 14m 32s           |
+---------------------------------+-----------------------------------------------------------------+
| [ PANEL DE BENCHMARK Y TELEMETRÍA ]                                                               |
| Cantidad de pistas para test de estrés: [ 25,000 ]   [ 🚀 Iniciar Prueba de Rendimiento ]        |
| - Lista Propia (Nodos):      14.2 ms | Operaciones: Inserción intermedia O(1)                     |
| - .NET LinkedList<T>:        12.8 ms | Operaciones: Inserción con LinkedListNode O(1)             |
| - .NET List<T> (Array Din.): 89.4 ms | Operaciones: Insert(idx) sufre degradación por Array.Copy  |
+---------------------------------------------------------------------------------------------------+
```

### 3.2. Controles Requeridos y Nombres Estándar

| Control | Nombre Sugerido | Función |
| :--- | :--- | :--- |
| `TextBox` | `txtTitulo`, `txtArtista` | Captura de metadatos de la pista musical. |
| `NumericUpDown` | `numBpm`, `numDuracion` | BPM (Rango: 60-220) y duración en segundos. |
| `RadioButton` | `rbPropia`, `rbLinkedList`, `rbList` | Conmutador de la estructura activa a operar y visualizar. |
| `Button` | `btnEncolarFinal` | Inserta al final de la cola activa ($O(n)$ o $O(1)$). |
| `Button` | `btnReproducirSiguiente` | Aplica la lógica *"Up Next"* inmediatamente después de la cabeza ($O(1)$). |
| `Button` | `btnAvanzar` | Desencola la pista actual en cabeza y actualiza el reproductor ($O(1)$). |
| `Button` | `btnInvertir` | Invierte los enlaces de los nodos estrictamente *in-place* ($O(n)$ tiempo, $O(1)$ espacio). |
| `Button` | `btnOrdenarBpm` | Inserta/ordena según la curva armónica de tempo BPM. |
| `Button` | `btnPurgar` | Elimina pistas repetidas por título sin crear estructuras intermedias. |
| `DataGridView` | `dgvCola` | Muestra los nodos en memoria, su posición y metadatos. |
| `Label` | `lblNowPlaying` | Muestra la pista en curso con formato destacado. |
| `Label` | `lblEstadisticas` | Muestra conteo total de pistas y duración acumulada. |
| `Button` | `btnBenchmark` | Ejecuta el test de estrés con `Stopwatch` para contrastar estructuras. |
| `TextBox` | `txtResultadosBenchmark` | Salida multilínea de telemetría y conclusiones técnicas. |

---

## 🧱 4. Modelo de Datos y Estructura Base

### 4.1. Definición del Registro `Pista`

```csharp
namespace SoundCore.Modelos
{
    public record Pista(int Id, string Titulo, string Artista, int Bpm, int DuracionSegundos)
    {
        public override string ToString() =>
            $"[ID: {Id:D3}] {Titulo} - {Artista} | {Bpm} BPM ({DuracionSegundos}s)";
    }
}
```

### 4.2. Lista Enlazada Simple desde Cero (`ListaSimpleEnlazada<T>`)

> [!IMPORTANT]
> **Regla de Oro Algorítmica:**  
> La clase `ListaSimpleEnlazada<T>` debe operar directamente sobre punteros `Nodo<T>.Siguiente`. Queda estrictamente prohibido usar arrays internos, `System.Collections.Generic.List<T>` o bibliotecas auxiliares para implementar los métodos requeridos.

```csharp
using System.Collections;

namespace SoundCore.EstructurasPropias
{
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

    public class ListaSimpleEnlazada<T> : IEnumerable<T>
    {
        public Nodo<T>? Cabeza { get; private set; }
        public int Conteo { get; private set; }

        public bool EstaVacia => Cabeza == null;

        // 1. Inserción al final: O(n) (u O(1) si se mantiene puntero a la cola)
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

        // 2. Up Next: Inserción inmediata tras la cabeza: O(1)
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

        // 4. Inversión In-Place: O(n) tiempo, O(1) memoria auxiliar
        // ESTRICTO: Prohibido crear listas nuevas o alterar valores; solo redirigir enlaces 'Siguiente'
        public void Invertir()
        {
            Nodo<T>? previo = null;
            Nodo<T>? actual = Cabeza;
            Nodo<T>? siguiente = null;

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
```

---

## 💻 5. Implementación del Formulario Principal (`MainForm.cs`)

A continuación se detalla la lógica de sincronización reactiva entre la GUI y las 3 estructuras de datos:

```csharp
using System.Diagnostics;
using SoundCore.EstructurasPropias;
using SoundCore.Modelos;

namespace SoundCore.UI
{
    public partial class MainForm : Form
    {
        // Estructuras paralelas
        private readonly ListaSimpleEnlazada<Pista> _colaPropia = new();
        private readonly LinkedList<Pista> _colaLinkedList = new();
        private readonly List<Pista> _colaList = new();

        private int _contadorId = 1;
        private Pista? _pistaSonando = null;

        public MainForm()
        {
            InitializeComponent();
            ConfigurarColumnasGrid();
            CargarDatosSemilla();
            RefrescarVista();
        }

        private void ConfigurarColumnasGrid()
        {
            dgvCola.ColumnCount = 5;
            dgvCola.Columns[0].Name = "Pos";
            dgvCola.Columns[1].Name = "ID";
            dgvCola.Columns[2].Name = "Título / Artista";
            dgvCola.Columns[3].Name = "BPM";
            dgvCola.Columns[4].Name = "Duración";
            dgvCola.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDatosSemilla()
        {
            var demo = new[]
            {
                new Pista(_contadorId++, "Strobe", "deadmau5", 128, 634),
                new Pista(_contadorId++, "Midnight City", "M83", 105, 243),
                new Pista(_contadorId++, "Animals", "Martin Garrix", 130, 304)
            };

            foreach (var p in demo)
            {
                _colaPropia.AgregarAlFinal(p);
                _colaLinkedList.AddLast(p);
                _colaList.Add(p);
            }
        }

        private Pista CrearPistaDesdeFormulario()
        {
            string titulo = string.IsNullOrWhiteSpace(txtTitulo.Text) ? $"Pista {_contadorId}" : txtTitulo.Text.Trim();
            string artista = string.IsNullOrWhiteSpace(txtArtista.Text) ? "DJ Desconocido" : txtArtista.Text.Trim();
            int bpm = (int)numBpm.Value;
            int duracion = (int)numDuracion.Value;

            return new Pista(_contadorId++, titulo, artista, bpm, duracion);
        }

        private void btnEncolarFinal_Click(object sender, EventArgs e)
        {
            var pista = CrearPistaDesdeFormulario();

            if (rbPropia.Checked) _colaPropia.AgregarAlFinal(pista);
            else if (rbLinkedList.Checked) _colaLinkedList.AddLast(pista);
            else _colaList.Add(pista);

            RefrescarVista();
        }

        private void btnReproducirSiguiente_Click(object sender, EventArgs e)
        {
            var pista = CrearPistaDesdeFormulario();

            if (rbPropia.Checked)
            {
                _colaPropia.ReproducirSiguiente(pista);
            }
            else if (rbLinkedList.Checked)
            {
                if (_colaLinkedList.First == null)
                    _colaLinkedList.AddFirst(pista);
                else
                    _colaLinkedList.AddAfter(_colaLinkedList.First, pista);
            }
            else
            {
                if (_colaList.Count <= 1) _colaList.Add(pista);
                else _colaList.Insert(1, pista);
            }

            RefrescarVista();
        }

        private void btnAvanzar_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbPropia.Checked)
                {
                    _pistaSonando = _colaPropia.AvanzarPista();
                }
                else if (rbLinkedList.Checked)
                {
                    if (_colaLinkedList.First == null) throw new InvalidOperationException();
                    _pistaSonando = _colaLinkedList.First.Value;
                    _colaLinkedList.RemoveFirst();
                }
                else
                {
                    if (_colaList.Count == 0) throw new InvalidOperationException();
                    _pistaSonando = _colaList[0];
                    _colaList.RemoveAt(0);
                }

                lblNowPlaying.Text = $"▶ Sonando: {_pistaSonando.Titulo} - {_pistaSonando.Artista} ({_pistaSonando.Bpm} BPM)";
                lblNowPlaying.ForeColor = Color.DarkGreen;
                RefrescarVista();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("No hay pistas pendientes en la cola.", "Fin del Setlist", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnInvertir_Click(object sender, EventArgs e)
        {
            if (rbPropia.Checked)
            {
                _colaPropia.Invertir();
            }
            else if (rbLinkedList.Checked)
            {
                var listaTemporal = new List<Pista>(_colaLinkedList);
                listaTemporal.Reverse();
                _colaLinkedList.Clear();
                foreach (var item in listaTemporal) _colaLinkedList.AddLast(item);
            }
            else
            {
                _colaList.Reverse();
            }

            RefrescarVista();
        }

        private void btnOrdenarBpm_Click(object sender, EventArgs e)
        {
            if (rbPropia.Checked)
            {
                var temporal = new ListaSimpleEnlazada<Pista>();
                foreach (var pista in _colaPropia)
                {
                    temporal.InsertarOrdenado(pista, (a, b) => a.Bpm.CompareTo(b.Bpm));
                }
                _colaPropia.Limpiar();
                foreach (var p in temporal) _colaPropia.AgregarAlFinal(p);
            }
            else if (rbLinkedList.Checked)
            {
                var ordenadas = _colaLinkedList.OrderBy(p => p.Bpm).ToList();
                _colaLinkedList.Clear();
                foreach (var p in ordenadas) _colaLinkedList.AddLast(p);
            }
            else
            {
                _colaList.Sort((a, b) => a.Bpm.CompareTo(b.Bpm));
            }

            RefrescarVista();
        }

        private void btnPurgar_Click(object sender, EventArgs e)
        {
            if (rbPropia.Checked)
            {
                _colaPropia.DepurarDuplicados((a, b) => a.Titulo.Equals(b.Titulo, StringComparison.OrdinalIgnoreCase));
            }
            else if (rbLinkedList.Checked)
            {
                var unicos = _colaLinkedList.DistinctBy(p => p.Titulo).ToList();
                _colaLinkedList.Clear();
                foreach (var p in unicos) _colaLinkedList.AddLast(p);
            }
            else
            {
                var unicos = _colaList.DistinctBy(p => p.Titulo).ToList();
                _colaList.Clear();
                _colaList.AddRange(unicos);
            }

            RefrescarVista();
        }

        private void RefrescarVista()
        {
            dgvCola.Rows.Clear();
            IEnumerable<Pista> coleccion = rbPropia.Checked ? _colaPropia :
                                           rbLinkedList.Checked ? _colaLinkedList : _colaList;

            int index = 1;
            int duracionTotal = 0;

            foreach (var p in coleccion)
            {
                dgvCola.Rows.Add(index++, p.Id, $"{p.Titulo} — {p.Artista}", $"{p.Bpm} BPM", $"{p.DuracionSegundos}s");
                duracionTotal += p.DuracionSegundos;
            }

            lblEstadisticas.Text = $"Total en cola: {index - 1} | Tiempo total: {TimeSpan.FromSeconds(duracionTotal):mm\\:ss}";
        }

        private void btnBenchmark_Click(object sender, EventArgs e)
        {
            int n = 20_000;
            var random = new Random(42);
            var sw = new Stopwatch();

            // 1. Test Inserción Intermedia: Lista Propia
            var testPropia = new ListaSimpleEnlazada<Pista>();
            testPropia.AgregarAlFinal(new Pista(0, "Head", "DJ", 120, 200));
            sw.Start();
            for (int i = 0; i < n; i++)
            {
                testPropia.ReproducirSiguiente(new Pista(i, $"Pista {i}", "DJ", random.Next(100, 150), 180));
            }
            sw.Stop();
            long tiempoPropia = sw.ElapsedMilliseconds;

            // 2. Test Inserción Intermedia: List<T> (Array Copy)
            var testList = new List<Pista> { new Pista(0, "Head", "DJ", 120, 200) };
            sw.Restart();
            for (int i = 0; i < n; i++)
            {
                testList.Insert(1, new Pista(i, $"Pista {i}", "DJ", random.Next(100, 150), 180));
            }
            sw.Stop();
            long tiempoList = sw.ElapsedMilliseconds;

            txtResultadosBenchmark.Text = 
                $"=== RESULTADOS DE ESTRÉS ({n:N0} INSERCIONES INTERMEDIAS) ===\r\n" +
                $"• Lista Enlazada Propia (Nodos):   {tiempoPropia} ms  [Operación O(1) por reconexión]\r\n" +
                $"• .NET List<T> (Arreglo Dinámico):  {tiempoList} ms  [Operación O(n) por desplazamiento de memoria]\r\n\r\n" +
                $"Conclusión Técnica: En inserciones intermedias frecuentes, la Lista Enlazada supera a List<T> " +
                $"porque no ejecuta Array.Copy ni redimensionamiento de búfer.";
        }
    }
}
```

---

## 🧪 6. Casos de Prueba Formales para Evaluación

| ID | Operación / Escenario | Pasos | Resultado Esperado en Pantalla |
| :--- | :--- | :--- | :--- |
| **CP-01** | Inserción al Final | Ingresar *"Track 1"* (120 BPM) y presionar `[+ Encolar al Final]`. | Se agrega a la última fila del `DataGridView` sin alterar las anteriores. |
| **CP-02** | Prioridad *Up Next* | Seleccionar `[Reproducir Siguiente]` con *"Track VIP"*. | Se posiciona en la fila 2 (inmediatamente detrás del tema en cabeza). |
| **CP-03** | Avanzar Pista | Clic en `[Avanzar Pista]`. | `lblNowPlaying` actualiza su texto con la pista cabecera; desaparece la primera fila del grid. |
| **CP-04** | Inversión *In-Place* | Setlist con BPMs `[100, 110, 120]`, pulsar `[Invertir Lista]`. | El grid refleja `[120, 110, 100]` sin alterar la memoria consumida. |
| **CP-05** | Curva Ascendente BPM | Insertar desordenado: `128, 115, 140, 120`. Pulsar `[Ordenar por Curva BPM]`. | Grid reordena de menor a mayor tempo: `115 -> 120 -> 128 -> 140`. |
| **CP-06** | Purga de Duplicados | Insertar dos pistas con el mismo título (`"Strobe"`). Pulsar `[Purgar]`. | Se preserva la primera aparición y se elimina la réplica sin romper los enlaces. |
| **CP-07** | Manejo de Excepciones | Pulsar `[Avanzar Pista]` con la cola en 0 elementos. | Muestra `MessageBox` controlado, sin congelamiento ni caída de la aplicación. |

---

## 📊 7. Rúbrica de Evaluación por Competencias (TecNM)

| Dimensión | Criterio Específico | Excelente (100 - 95) | Notable (94 - 80) | Suficiente (79 - 70) | Insuficiente (< 70) |
| :--- | :--- | :--- | :--- | :--- | :--- |
| **Estructuras desde Cero (40%)** | Punteros, nodos y métodos algorítmicos. | Implementa los 6 métodos sin fugas de enlace; `Invertir()` es estrictamente *in-place* sin listas auxiliares. | Implementa todos los métodos pero la inversión usa estructuras auxiliares. | Falla en 1 o 2 métodos (ej. duplicados desalinea punteros). | No implementa la clase propia o utiliza arreglos internos. |
| **Integración .NET 10 (20%)** | Uso de `LinkedList<T>` y `List<T>`. | Emplea correctamente las colecciones genéricas modernas y sus métodos de búsqueda/inserción. | Emplea las colecciones nativas pero con conversiones redundantes de tipo. | Implementación parcial de alguna de las colecciones. | Omite el uso de las clases nativas de .NET. |
| **Interfaz Gráfica WinForms (25%)** | Usabilidad, binding y robustez de la GUI. | Interfaz intuitiva, data binding reactivo al cambiar de radio button, validaciones de campo y controles coherentes. | Funciona visualmente pero no sincroniza el cambio de estructura de datos en vivo. | GUI desordenada, no valida cadenas vacías o bloquea el hilo principal. | La interfaz colapsa con excepciones no capturadas. |
| **Benchmark y Análisis (15%)** | Medición empírica y justificación teórica. | Demuestra con `Stopwatch` la diferencia de complejidad temporal y explica el impacto de `Array.Copy`. | Mide los tiempos pero no fundamenta la diferencia entre $\mathcal{O}(1)$ y $\mathcal{O}(n)$. | Muestra datos incongruentes en las pruebas de estrés. | No incluye el módulo de benchmark o no arroja métricas. |

---

## 📦 8. Guía de Entrega y Criterios de Aceptación

1. **Repositorio Git:**
   - Subir la solución `.sln` completa.
   - Incluir comentarios de cabecera en cada archivo fuente con:
     - Nombre completo de los integrantes del equipo.
     - Números de control TecNM.
     - Fecha y versión.

2. **Video Demostrativo (Máximo 3 minutos):**
   - ⏱️ **0:00 - 1:15:** Demostración de las operaciones de la cola en vivo desde la GUI (Encolar, Up Next, Invertir, Ordenar, Purgar).
   - ⏱️ **1:15 - 2:00:** Ejecución del benchmark de estrés en pantalla con 20,000+ elementos y explicación del resultado.
   - ⏱️ **2:00 - 3:00:** Explicación breve del código del método `Invertir()` señalando las tres referencias auxiliares (`previo`, `actual`, `siguiente`).
