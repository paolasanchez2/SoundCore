namespace SoundCore.UI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            pnlRegistro = new Panel();
            lblTitulo = new Label();
            txtTitulo = new TextBox();
            lblArtista = new Label();
            txtArtista = new TextBox();
            lblBpm = new Label();
            numBpm = new NumericUpDown();
            lblDuracion = new Label();
            numDuracion = new NumericUpDown();
            lblModo = new Label();
            rbPropia = new RadioButton();
            rbLinkedList = new RadioButton();
            rbList = new RadioButton();
            pnlAcciones = new Panel();
            btnImportar = new Button();
            btnEncolarFinal = new Button();
            btnReproducirSiguiente = new Button();
            btnAvanzar = new Button();
            btnInvertir = new Button();
            btnOrdenarBpm = new Button();
            btnPurgar = new Button();
            pnlPlaylist = new Panel();
            dgvCola = new DataGridView();
            lblEstadisticas = new Label();
            lblNowPlaying = new Label();
            pnlBenchmark = new Panel();
            txtResultadosBenchmark = new TextBox();
            lblCantidadPrueba = new Label();
            numCantidadPrueba = new NumericUpDown();
            btnBenchmark = new Button();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            pnlRegistro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numBpm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDuracion).BeginInit();
            pnlAcciones.SuspendLayout();
            pnlPlaylist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCola).BeginInit();
            pnlBenchmark.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidadPrueba).BeginInit();
            SuspendLayout();
            // 
            // pnlRegistro
            // 
            pnlRegistro.Controls.Add(lblTitulo);
            pnlRegistro.Controls.Add(txtTitulo);
            pnlRegistro.Controls.Add(lblArtista);
            pnlRegistro.Controls.Add(txtArtista);
            pnlRegistro.Controls.Add(lblBpm);
            pnlRegistro.Controls.Add(numBpm);
            pnlRegistro.Controls.Add(lblDuracion);
            pnlRegistro.Controls.Add(numDuracion);
            pnlRegistro.Controls.Add(lblModo);
            pnlRegistro.Controls.Add(rbPropia);
            pnlRegistro.Controls.Add(rbLinkedList);
            pnlRegistro.Controls.Add(rbList);
            pnlRegistro.Dock = DockStyle.Top;
            pnlRegistro.Location = new Point(0, 0);
            pnlRegistro.Name = "pnlRegistro";
            pnlRegistro.Padding = new Padding(10);
            pnlRegistro.Size = new Size(1000, 90);
            pnlRegistro.TabIndex = 3;
            pnlRegistro.Paint += pnlRegistro_Paint;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(10, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(41, 15);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Título:";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(65, 12);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(160, 23);
            txtTitulo.TabIndex = 1;
            // 
            // lblArtista
            // 
            lblArtista.AutoSize = true;
            lblArtista.Location = new Point(235, 15);
            lblArtista.Name = "lblArtista";
            lblArtista.Size = new Size(44, 15);
            lblArtista.TabIndex = 2;
            lblArtista.Text = "Artista:";
            // 
            // txtArtista
            // 
            txtArtista.Location = new Point(290, 12);
            txtArtista.Name = "txtArtista";
            txtArtista.Size = new Size(160, 23);
            txtArtista.TabIndex = 3;
            // 
            // lblBpm
            // 
            lblBpm.AutoSize = true;
            lblBpm.Location = new Point(465, 15);
            lblBpm.Name = "lblBpm";
            lblBpm.Size = new Size(35, 15);
            lblBpm.TabIndex = 4;
            lblBpm.Text = "BPM:";
            // 
            // numBpm
            // 
            numBpm.Location = new Point(510, 12);
            numBpm.Maximum = new decimal(new int[] { 220, 0, 0, 0 });
            numBpm.Minimum = new decimal(new int[] { 60, 0, 0, 0 });
            numBpm.Name = "numBpm";
            numBpm.Size = new Size(70, 23);
            numBpm.TabIndex = 5;
            numBpm.Value = new decimal(new int[] { 124, 0, 0, 0 });
            // 
            // lblDuracion
            // 
            lblDuracion.AutoSize = true;
            lblDuracion.Location = new Point(595, 15);
            lblDuracion.Name = "lblDuracion";
            lblDuracion.Size = new Size(74, 15);
            lblDuracion.TabIndex = 6;
            lblDuracion.Text = "Duración (s):";
            // 
            // numDuracion
            // 
            numDuracion.Location = new Point(680, 12);
            numDuracion.Maximum = new decimal(new int[] { 3600, 0, 0, 0 });
            numDuracion.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDuracion.Name = "numDuracion";
            numDuracion.Size = new Size(80, 23);
            numDuracion.TabIndex = 7;
            numDuracion.Value = new decimal(new int[] { 210, 0, 0, 0 });
            // 
            // lblModo
            // 
            lblModo.AutoSize = true;
            lblModo.Location = new Point(10, 50);
            lblModo.Name = "lblModo";
            lblModo.Size = new Size(114, 15);
            lblModo.TabIndex = 8;
            lblModo.Text = "Modo de Estructura:";
            // 
            // rbPropia
            // 
            rbPropia.AutoSize = true;
            rbPropia.Checked = true;
            rbPropia.Location = new Point(150, 48);
            rbPropia.Name = "rbPropia";
            rbPropia.Size = new Size(171, 19);
            rbPropia.TabIndex = 9;
            rbPropia.TabStop = true;
            rbPropia.Text = "Lista Simple Propia (Nodos)";
            rbPropia.CheckedChanged += rbEstructura_CheckedChanged;
            // 
            // rbLinkedList
            // 
            rbLinkedList.AutoSize = true;
            rbLinkedList.Location = new Point(370, 48);
            rbLinkedList.Name = "rbLinkedList";
            rbLinkedList.Size = new Size(129, 19);
            rbLinkedList.TabIndex = 10;
            rbLinkedList.Text = ".NET LinkedList<T>";
            rbLinkedList.CheckedChanged += rbEstructura_CheckedChanged;
            // 
            // rbList
            // 
            rbList.AutoSize = true;
            rbList.Location = new Point(540, 48);
            rbList.Name = "rbList";
            rbList.Size = new Size(94, 19);
            rbList.TabIndex = 11;
            rbList.Text = ".NET List<T>";
            rbList.CheckedChanged += rbEstructura_CheckedChanged;
            // 
            // pnlAcciones
            // 
            pnlAcciones.Controls.Add(btnImportar);
            pnlAcciones.Controls.Add(btnEncolarFinal);
            pnlAcciones.Controls.Add(btnReproducirSiguiente);
            pnlAcciones.Controls.Add(btnAvanzar);
            pnlAcciones.Controls.Add(btnInvertir);
            pnlAcciones.Controls.Add(btnOrdenarBpm);
            pnlAcciones.Controls.Add(btnPurgar);
            pnlAcciones.Dock = DockStyle.Left;
            pnlAcciones.Location = new Point(0, 90);
            pnlAcciones.Name = "pnlAcciones";
            pnlAcciones.Padding = new Padding(10);
            pnlAcciones.Size = new Size(220, 340);
            pnlAcciones.TabIndex = 1;
            // 
            // btnImportar
            // 
            btnImportar.Location = new Point(15, 265);
            btnImportar.Name = "btnImportar";
            btnImportar.Size = new Size(190, 32);
            btnImportar.TabIndex = 0;
            btnImportar.Text = "📂 Importar CSV / JSON";
            btnImportar.Click += btnImportar_Click;
            // 
            // btnEncolarFinal
            // 
            btnEncolarFinal.Location = new Point(15, 15);
            btnEncolarFinal.Name = "btnEncolarFinal";
            btnEncolarFinal.Size = new Size(190, 32);
            btnEncolarFinal.TabIndex = 1;
            btnEncolarFinal.Text = "+ Encolar al Final";
            btnEncolarFinal.Click += btnEncolarFinal_Click;
            // 
            // btnReproducirSiguiente
            // 
            btnReproducirSiguiente.Location = new Point(15, 55);
            btnReproducirSiguiente.Name = "btnReproducirSiguiente";
            btnReproducirSiguiente.Size = new Size(190, 32);
            btnReproducirSiguiente.TabIndex = 2;
            btnReproducirSiguiente.Text = "⏭ Reproducir Siguiente";
            btnReproducirSiguiente.Click += btnReproducirSiguiente_Click;
            // 
            // btnAvanzar
            // 
            btnAvanzar.Location = new Point(15, 95);
            btnAvanzar.Name = "btnAvanzar";
            btnAvanzar.Size = new Size(190, 32);
            btnAvanzar.TabIndex = 3;
            btnAvanzar.Text = "⏩ Avanzar Pista";
            btnAvanzar.Click += btnAvanzar_Click;
            // 
            // btnInvertir
            // 
            btnInvertir.Location = new Point(15, 135);
            btnInvertir.Name = "btnInvertir";
            btnInvertir.Size = new Size(190, 32);
            btnInvertir.TabIndex = 4;
            btnInvertir.Text = "⇅ Invertir Lista (In-Place)";
            btnInvertir.Click += btnInvertir_Click;
            // 
            // btnOrdenarBpm
            // 
            btnOrdenarBpm.Location = new Point(15, 175);
            btnOrdenarBpm.Name = "btnOrdenarBpm";
            btnOrdenarBpm.Size = new Size(190, 32);
            btnOrdenarBpm.TabIndex = 5;
            btnOrdenarBpm.Text = "⚡ Ordenar por Curva BPM";
            btnOrdenarBpm.Click += btnOrdenarBpm_Click;
            // 
            // btnPurgar
            // 
            btnPurgar.Location = new Point(15, 215);
            btnPurgar.Name = "btnPurgar";
            btnPurgar.Size = new Size(190, 32);
            btnPurgar.TabIndex = 6;
            btnPurgar.Text = "\U0001f9f9 Purgar Duplicados";
            btnPurgar.Click += btnPurgar_Click;
            // 
            // pnlPlaylist
            // 
            pnlPlaylist.Controls.Add(dgvCola);
            pnlPlaylist.Controls.Add(lblEstadisticas);
            pnlPlaylist.Controls.Add(lblNowPlaying);
            pnlPlaylist.Dock = DockStyle.Fill;
            pnlPlaylist.Location = new Point(220, 90);
            pnlPlaylist.Name = "pnlPlaylist";
            pnlPlaylist.Padding = new Padding(10);
            pnlPlaylist.Size = new Size(780, 340);
            pnlPlaylist.TabIndex = 0;
            // 
            // dgvCola
            // 
            dgvCola.AllowUserToAddRows = false;
            dgvCola.AllowUserToDeleteRows = false;
            dgvCola.AllowUserToResizeRows = false;
            dgvCola.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCola.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dgvCola.Dock = DockStyle.Fill;
            dgvCola.Location = new Point(10, 40);
            dgvCola.Name = "dgvCola";
            dgvCola.ReadOnly = true;
            dgvCola.RowHeadersVisible = false;
            dgvCola.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCola.Size = new Size(760, 266);
            dgvCola.TabIndex = 0;
            // 
            // lblEstadisticas
            // 
            lblEstadisticas.Dock = DockStyle.Bottom;
            lblEstadisticas.Location = new Point(10, 306);
            lblEstadisticas.Name = "lblEstadisticas";
            lblEstadisticas.Size = new Size(760, 24);
            lblEstadisticas.TabIndex = 1;
            lblEstadisticas.Text = "Total en cola: 0 | Tiempo total: 00:00";
            // 
            // lblNowPlaying
            // 
            lblNowPlaying.Dock = DockStyle.Top;
            lblNowPlaying.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNowPlaying.Location = new Point(10, 10);
            lblNowPlaying.Name = "lblNowPlaying";
            lblNowPlaying.Size = new Size(760, 30);
            lblNowPlaying.TabIndex = 2;
            lblNowPlaying.Text = "▶ Sonando: (sin pista actual)";
            // 
            // pnlBenchmark
            // 
            pnlBenchmark.Controls.Add(txtResultadosBenchmark);
            pnlBenchmark.Controls.Add(lblCantidadPrueba);
            pnlBenchmark.Controls.Add(numCantidadPrueba);
            pnlBenchmark.Controls.Add(btnBenchmark);
            pnlBenchmark.Dock = DockStyle.Bottom;
            pnlBenchmark.Location = new Point(0, 430);
            pnlBenchmark.Name = "pnlBenchmark";
            pnlBenchmark.Padding = new Padding(10);
            pnlBenchmark.Size = new Size(1000, 220);
            pnlBenchmark.TabIndex = 2;
            // 
            // txtResultadosBenchmark
            // 
            txtResultadosBenchmark.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtResultadosBenchmark.Font = new Font("Consolas", 9F);
            txtResultadosBenchmark.Location = new Point(10, 50);
            txtResultadosBenchmark.Multiline = true;
            txtResultadosBenchmark.Name = "txtResultadosBenchmark";
            txtResultadosBenchmark.ReadOnly = true;
            txtResultadosBenchmark.ScrollBars = ScrollBars.Vertical;
            txtResultadosBenchmark.Size = new Size(1750, 150);
            txtResultadosBenchmark.TabIndex = 0;
            // 
            // lblCantidadPrueba
            // 
            lblCantidadPrueba.AutoSize = true;
            lblCantidadPrueba.Location = new Point(10, 15);
            lblCantidadPrueba.Name = "lblCantidadPrueba";
            lblCantidadPrueba.Size = new Size(204, 15);
            lblCantidadPrueba.TabIndex = 1;
            lblCantidadPrueba.Text = "Cantidad de pistas para test de estrés:";
            // 
            // numCantidadPrueba
            // 
            numCantidadPrueba.Increment = new decimal(new int[] { 500, 0, 0, 0 });
            numCantidadPrueba.Location = new Point(260, 12);
            numCantidadPrueba.Maximum = new decimal(new int[] { 200000, 0, 0, 0 });
            numCantidadPrueba.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            numCantidadPrueba.Name = "numCantidadPrueba";
            numCantidadPrueba.Size = new Size(100, 23);
            numCantidadPrueba.TabIndex = 2;
            numCantidadPrueba.Value = new decimal(new int[] { 25000, 0, 0, 0 });
            // 
            // btnBenchmark
            // 
            btnBenchmark.Location = new Point(380, 10);
            btnBenchmark.Name = "btnBenchmark";
            btnBenchmark.Size = new Size(230, 30);
            btnBenchmark.TabIndex = 3;
            btnBenchmark.Text = "🚀 Iniciar Prueba de Rendimiento";
            btnBenchmark.Click += btnBenchmark_Click;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // MainForm
            // 
            ClientSize = new Size(1000, 650);
            Controls.Add(pnlPlaylist);
            Controls.Add(pnlAcciones);
            Controls.Add(pnlBenchmark);
            Controls.Add(pnlRegistro);
            MinimumSize = new Size(900, 600);
            Name = "MainForm";
            Text = "SoundCore Engine v2.0 - DJ Set Controller [TecNM Monclova]";
            pnlRegistro.ResumeLayout(false);
            pnlRegistro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numBpm).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDuracion).EndInit();
            pnlAcciones.ResumeLayout(false);
            pnlPlaylist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCola).EndInit();
            pnlBenchmark.ResumeLayout(false);
            pnlBenchmark.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidadPrueba).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRegistro;
        private Label lblTitulo;
        private TextBox txtTitulo;
        private Label lblArtista;
        private TextBox txtArtista;
        private Label lblBpm;
        private NumericUpDown numBpm;
        private Label lblDuracion;
        private NumericUpDown numDuracion;
        private Label lblModo;
        private RadioButton rbPropia;
        private RadioButton rbLinkedList;
        private RadioButton rbList;

        private Panel pnlAcciones;
        private Button btnEncolarFinal;
        private Button btnReproducirSiguiente;
        private Button btnAvanzar;
        private Button btnInvertir;
        private Button btnOrdenarBpm;
        private Button btnPurgar;
        private Button btnImportar;

        private Panel pnlPlaylist;
        private Label lblNowPlaying;
        private DataGridView dgvCola;
        private Label lblEstadisticas;

        private Panel pnlBenchmark;
        private Label lblCantidadPrueba;
        private NumericUpDown numCantidadPrueba;
        private Button btnBenchmark;
        private TextBox txtResultadosBenchmark;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}
