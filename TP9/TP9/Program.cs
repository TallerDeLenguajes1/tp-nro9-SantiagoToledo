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
            convertir();

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

        public static void convertir()
        {
            string dir = SoporteParaConfiguracion.LeerConfiguracion() + @"Morse\";
            string nameMorse = "morse_" + DateTime.Today.ToString("dd_MM_yyyy") +".txt";
            string nameText = "text_" + DateTime.Today.ToString("dd_MM_yyyy") + ".txt";
         
            Directory.CreateDirectory(dir);

            Console.WriteLine("Ingrese una oracion: ");
            string cadena = Console.ReadLine();

            cadena = ConversorDeMorse.TextoAMorse(cadena);
            File.WriteAllText(dir + nameMorse, cadena);

            cadena = File.ReadAllText(dir + nameMorse);
            cadena = ConversorDeMorse.MorseATexto(cadena);

            Console.WriteLine("{0}", cadena);
            File.WriteAllText(dir + nameText, cadena);

        }

    }
}
