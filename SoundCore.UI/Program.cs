// =============================================================================
// Proyecto Integral Unidad 2: SoundCore Engine GUI
// Archivo: Program.cs
// Integrantes: [Nombre completo del integrante 1] - [Número de control]
//              [Nombre completo del integrante 2] - [Número de control]
// TecNM Campus Monclova - Ingeniería en Informática
// Asignatura: Estructura de Datos (3er Semestre)
// Fecha: 27/09/2026  Versión: 1.0
// =============================================================================

namespace SoundCore.UI
{
    internal static class A3Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
