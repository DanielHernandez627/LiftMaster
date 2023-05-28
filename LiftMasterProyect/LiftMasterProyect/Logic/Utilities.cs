using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftMasterProyect.Logic
{
    internal class Utilities
    {
        public void EscribirLog(string mensaje)
        {
            string filePath = "log.txt";

            try
            {
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    string registro = $"{DateTime.Now}: {mensaje}";
                    sw.WriteLine(registro);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al escribir en el archivo de registro: {ex.Message}");
            }
        }
    }
}
