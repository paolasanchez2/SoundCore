// =============================================================================
// Proyecto Integral Unidad 2: SoundCore Engine GUI
// Archivo: Pista.cs
// Integrantes: [Nombre completo del integrante 1] - [Número de control]
//              [Nombre completo del integrante 2] - [Número de control]
// TecNM Campus Monclova - Ingeniería en Informática
// Asignatura: Estructura de Datos (3er Semestre)
// Fecha: 27/09/2026  Versión: 1.0
// =============================================================================

namespace SoundCore.Modelos
{
    /// <summary>
    /// Representa una pista musical dentro de la cola de reproducción del DJ.
    /// </summary>
    public record Pista(int Id, string Titulo, string Artista, int Bpm, int DuracionSegundos)
    {
        public override string ToString() =>
            $"[ID: {Id:D3}] {Titulo} - {Artista} | {Bpm} BPM ({DuracionSegundos}s)";
    }
}
