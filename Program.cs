using MinimalWeather.Vistas;
using System;
using System.Windows.Forms;

namespace MinimalWeather
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Properties.Settings.Default.primeraEjecucion)
            {
                Properties.Settings.Default.tipoUbicacion = null;
                Properties.Settings.Default.ciudad = null;
                Properties.Settings.Default.Save();

                if (!MostrarDialogo(new VistaBienvenida())) return;
                if (!MostrarDialogo(new VistaConfiguracion())) return;

                Properties.Settings.Default.primeraEjecucion = false;
                Properties.Settings.Default.Save();
            }

            Application.Run(new VistaPrincipal());
        }

        private static bool MostrarDialogo(Form formulario)
        {
            using (formulario) return formulario.ShowDialog() == DialogResult.OK;
        }
    }
}
