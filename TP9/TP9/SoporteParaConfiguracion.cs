﻿using System;
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
        private static readonly Dictionary<char, string> LetraMorse = new Dictionary<char, string>
        {
            {'a', ".-"},
            {'b', "-..."},
            {'c', "-.-."},
            {'d', "-.."},
            {'e', "."},
            {'f', "..-."},
            {'g', "--."},
            {'h', "...."},
            {'i', ".."},
            {'j', ".---"},
            {'k', "-.-"},
            {'l', ".-.."},
            {'m', "--"},
            {'n', "-."},
            {'o', "---"},
            {'p', ".--."},
            {'q', "--.-"},
            {'r', ".-."},
            {'s', "..."},
            {'t', "-"},
            {'u', "..-"},
            {'v', "...-"},
            {'w', ".--"},
            {'x', "-..-"},
            {'y', "-.--"},
            {'z', "--.."}
        };

        private static readonly Dictionary<string, char> MorseLetra = LetraMorse.ToDictionary(kvp => kvp.Value,kvp => kvp.Key);


        public static string MorseATexto(string morse)
        {
            string texto = "";
            string[] palabras = morse.Split(new string[] { "  " }, StringSplitOptions.None);
            foreach(string palabra in palabras)
            {
                string[] letras = palabra.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

                foreach(string letra in letras)
                {
                    texto += MorseLetra[letra];
                }
                texto += " ";
            }
            return texto;
        }

        public static string TextoAMorse(string texto)
        {
            string morse = "";
            foreach(char c in texto)
            {
                if (char.IsLetter(c))
                {
                    morse += LetraMorse[char.ToLower(c)] + " ";
                }
                else
                {
                    morse += c;
                }
            }
            return morse;
        }
    }
}
