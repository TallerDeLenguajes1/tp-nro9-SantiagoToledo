using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class SoporteParaConfiguracion
    {
        static string NombreArchivo = "configuracion.dat";
        static string RutaArchivo = @"C:\ArchivosTP9\";

        public static void CrearArchivoDeConfiguracion()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(RutaArchivo + NombreArchivo, FileMode.Create)))
            {
                writer.Write(RutaArchivo);
            }

        }


        public static string LeerConfiguracion()
        {

            if (!File.Exists(NombreArchivo)) {
                CrearArchivoDeConfiguracion();
            }
            using (BinaryReader reader = new BinaryReader(File.Open(RutaArchivo + NombreArchivo, FileMode.Open)))
            {
                string ruta = reader.ReadString();
                return ruta;
            }
           
        }
    }

    public static class ConversorDeMorse
    {
        private static readonly Dictionary<string, string> LetraMorse = new Dictionary<string, string>
        {
            { "a", ".-" },
            { "b", "-..." },

        };


        public static string MorseATexto(string morse)
        {

        }
        public static string TextoAMorse(string texto)
        {

        }
    }
}
