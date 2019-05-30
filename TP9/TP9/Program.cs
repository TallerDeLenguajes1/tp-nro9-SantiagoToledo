using Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP9
{
    class Program
    {
        static void Main(string[] args)
        {
            MoverArchivos();

        }

        public static void MoverArchivos(){

            string[] archivos = Directory.GetFiles(Directory.GetCurrentDirectory());
            string destino = SoporteParaConfiguracion.LeerConfiguracion();
         
            foreach (string archivo in archivos)
            {
                string extension = Path.GetExtension(archivo);
                if (extension == ".txt" || extension == ".mp3")
                {
                    File.Copy(archivo, destino + Path.GetFileName(archivo), true);
                    Console.WriteLine("Se copio {0}", Path.GetFileName(archivo));
                }
           
            }
        }

    }
}
