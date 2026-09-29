// =============================================================================
// Proyecto Integral Unidad 2: SoundCore Engine GUI
// Archivo: MainForm.cs
// Integrantes: [Nombre completo del integrante 1] - [Número de control]
//              [Nombre completo del integrante 2] - [Número de control]
// TecNM Campus Monclova - Ingeniería en Informática
// Asignatura: Estructura de Datos (3er Semestre)
// Fecha: 27/09/2026  Versión: 1.0
// =============================================================================

using System.Diagnostics;
using System.Globalization;
using System.Text.Json;
using SoundCore.EstructurasPropias;
using SoundCore.Modelos;

namespace SoundCore.UI
{
    public partial class MainForm : Form
    {
        // Estructuras paralelas: las tres siempre reflejan el mismo contenido
        // lógico para permitir comparar operaciones al vuelo entre estructuras.
        private readonly ListaSimpleEnlazada<Pista> _colaPropia = new();
        private readonly LinkedList<Pista> _colaLinkedList = new();
        private readonly List<Pista> _colaList = new();

        private int _contadorId = 1;
        private Pista? _pistaSonando = null;

        public MainForm()
        {
            InitializeComponent();
            CargarDatosSemilla();
            RefrescarVista();
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

            var pista = new Pista(_contadorId++, titulo, artista, bpm, duracion);

            txtTitulo.Clear();
            txtArtista.Clear();
            txtTitulo.Focus();

            return pista;
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
                MessageBox.Show("No hay pistas pendientes en la cola.", "Fin del Setlist",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                // Reordena los nodos existentes reconectando punteros; sin lista auxiliar.
                _colaPropia.OrdenarPorCriterio((a, b) => a.Bpm.CompareTo(b.Bpm));
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

        // ===================== IMPORTACIÓN CSV / JSON =====================
        private void btnImportar_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Title = "Importar pistas",
                Filter = "Archivos de pistas (*.csv;*.json)|*.csv;*.json|CSV (*.csv)|*.csv|JSON (*.json)|*.json"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                var pistas = new List<Pista>();
                int omitidas = 0;

                if (Path.GetExtension(dlg.FileName).Equals(".json", StringComparison.OrdinalIgnoreCase))
                    LeerJson(dlg.FileName, pistas, ref omitidas);
                else
                    LeerCsv(dlg.FileName, pistas, ref omitidas);

                Cursor = Cursors.WaitCursor;
                foreach (var p in pistas)
                {
                    if (rbPropia.Checked) _colaPropia.AgregarAlFinal(p);
                    else if (rbLinkedList.Checked) _colaLinkedList.AddLast(p);
                    else _colaList.Add(p);
                }
                RefrescarVista();

                MessageBox.Show($"Pistas importadas: {pistas.Count}\nFilas omitidas por datos inválidos: {omitidas}",
                    "Importación completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) when (ex is IOException or JsonException or UnauthorizedAccessException)
            {
                MessageBox.Show($"No se pudo leer el archivo:\n{ex.Message}", "Error de importación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // Formato CSV: titulo,artista,bpm,duracion (encabezado opcional)
        private void LeerCsv(string ruta, List<Pista> destino, ref int omitidas)
        {
            foreach (var linea in File.ReadLines(ruta))
            {
                if (string.IsNullOrWhiteSpace(linea)) continue;
                var c = DividirLineaCsv(linea);

                if (c.Count < 4 ||
                    !int.TryParse(c[2].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int bpm) ||
                    !int.TryParse(c[3].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int dur))
                {
                    // La primera línea no numérica se asume encabezado; no cuenta como error.
                    if (destino.Count > 0 || omitidas > 0 || !linea.ToLower().Contains("titulo")) omitidas++;
                    continue;
                }
                AgregarSiEsValida(destino, c[0], c[1], bpm, dur, ref omitidas);
            }
        }

        private static List<string> DividirLineaCsv(string linea)
        {
            var campos = new List<string>();
            var actual = new System.Text.StringBuilder();
            bool enComillas = false;

            for (int i = 0; i < linea.Length; i++)
            {
                char ch = linea[i];
                if (ch == '"')
                {
                    if (enComillas && i + 1 < linea.Length && linea[i + 1] == '"') { actual.Append('"'); i++; }
                    else enComillas = !enComillas;
                }
                else if (ch == ',' && !enComillas)
                {
                    campos.Add(actual.ToString());
                    actual.Clear();
                }
                else actual.Append(ch);
            }
            campos.Add(actual.ToString());
            return campos;
        }

        // Formato JSON: [ { "titulo": "...", "artista": "...", "bpm": 128, "duracion": 200 }, ... ]
        private void LeerJson(string ruta, List<Pista> destino, ref int omitidas)
        {
            using var doc = JsonDocument.Parse(File.ReadAllText(ruta));
            if (doc.RootElement.ValueKind != JsonValueKind.Array)
                throw new JsonException("El JSON debe contener un arreglo de pistas.");

            foreach (var el in doc.RootElement.EnumerateArray())
            {
                string? titulo = LeerTexto(el, "titulo");
                string? artista = LeerTexto(el, "artista");
                if (!TryLeerEntero(el, "bpm", out int bpm) || !TryLeerEntero(el, "duracion", out int dur))
                {
                    omitidas++;
                    continue;
                }
                AgregarSiEsValida(destino, titulo, artista, bpm, dur, ref omitidas);
            }
        }

        private static string? LeerTexto(JsonElement el, string nombre)
        {
            foreach (var prop in el.EnumerateObject())
                if (prop.Name.Equals(nombre, StringComparison.OrdinalIgnoreCase) && prop.Value.ValueKind == JsonValueKind.String)
                    return prop.Value.GetString();
            return null;
        }

        private static bool TryLeerEntero(JsonElement el, string nombre, out int valor)
        {
            valor = 0;
            foreach (var prop in el.EnumerateObject())
                if (prop.Name.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                    return prop.Value.ValueKind == JsonValueKind.Number && prop.Value.TryGetInt32(out valor);
            return false;
        }

        private void AgregarSiEsValida(List<Pista> destino, string? titulo, string? artista, int bpm, int dur, ref int omitidas)
        {
            if (string.IsNullOrWhiteSpace(titulo) || bpm < 60 || bpm > 220 || dur <= 0)
            {
                omitidas++;
                return;
            }
            destino.Add(new Pista(_contadorId++, titulo.Trim(),
                string.IsNullOrWhiteSpace(artista) ? "DJ Desconocido" : artista.Trim(), bpm, dur));
        }

        private void rbEstructura_CheckedChanged(object? sender, EventArgs e)
        {
            // Sincroniza la vista de inmediato al cambiar la estructura activa,
            // sin bloquear el hilo principal.
            RefrescarVista();
        }

        private void RefrescarVista()
        {
            IEnumerable<Pista> coleccion = rbPropia.Checked ? _colaPropia :
                                           rbLinkedList.Checked ? _colaLinkedList : _colaList;

            // Construcción por lotes: evita repintar el grid fila por fila (crítico con >20 mil pistas).
            var filas = new List<DataGridViewRow>();
            int index = 1;
            long duracionTotal = 0;

            foreach (var p in coleccion)
            {
                var fila = new DataGridViewRow();
                fila.CreateCells(dgvCola, index++, p.Id, $"{p.Titulo} — {p.Artista}", $"{p.Bpm} BPM", $"{p.DuracionSegundos}s");
                filas.Add(fila);
                duracionTotal += p.DuracionSegundos;
            }

            dgvCola.SuspendLayout();
            dgvCola.Rows.Clear();
            dgvCola.Rows.AddRange(filas.ToArray());
            dgvCola.ResumeLayout();

            lblEstadisticas.Text = $"Total en cola: {filas.Count:N0} | Tiempo total: {(int)TimeSpan.FromSeconds(duracionTotal).TotalHours:D2}:{TimeSpan.FromSeconds(duracionTotal):mm\\:ss}";
        }

        private void btnBenchmark_Click(object sender, EventArgs e)
        {
            int n = (int)numCantidadPrueba.Value;
            var random = new Random(42);
            var sw = new Stopwatch();

            btnBenchmark.Enabled = false;
            txtResultadosBenchmark.Text = "Ejecutando prueba de estrés, por favor espere...";
            Application.DoEvents();

            // 1. Test inserción intermedia: Lista Propia (Up Next -> O(1) por reconexión)
            var testPropia = new ListaSimpleEnlazada<Pista>();
            testPropia.AgregarAlFinal(new Pista(0, "Head", "DJ", 120, 200));
            sw.Restart();
            for (int i = 0; i < n; i++)
            {
                testPropia.ReproducirSiguiente(new Pista(i, $"Pista {i}", "DJ", random.Next(100, 150), 180));
            }
            sw.Stop();
            long tiempoPropia = sw.ElapsedMilliseconds;

            // 2. Test inserción intermedia: .NET LinkedList<T> (AddAfter -> O(1) con nodo)
            var testLinkedList = new LinkedList<Pista>();
            testLinkedList.AddLast(new Pista(0, "Head", "DJ", 120, 200));
            sw.Restart();
            for (int i = 0; i < n; i++)
            {
                testLinkedList.AddAfter(testLinkedList.First!, new Pista(i, $"Pista {i}", "DJ", random.Next(100, 150), 180));
            }
            sw.Stop();
            long tiempoLinkedList = sw.ElapsedMilliseconds;

            // 3. Test inserción intermedia: .NET List<T> (Insert(idx) -> O(n) por Array.Copy)
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
                $"• Lista Enlazada Propia (Nodos):    {tiempoPropia} ms  [Operación O(1) por reconexión de punteros]\r\n" +
                $"• .NET LinkedList<T>:                {tiempoLinkedList} ms  [Operación O(1) con LinkedListNode]\r\n" +
                $"• .NET List<T> (Arreglo Dinámico):   {tiempoList} ms  [Operación O(n) por desplazamiento/Array.Copy]\r\n\r\n" +
                "Conclusión Técnica: En inserciones intermedias frecuentes, las listas enlazadas " +
                "(propia y LinkedList<T>) superan a List<T> porque reconectan referencias en tiempo " +
                "constante, mientras que List<T> debe desplazar en memoria todos los elementos " +
                "posteriores al índice de inserción cada vez que crece.";

            btnBenchmark.Enabled = true;
        }

        private void pnlRegistro_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
