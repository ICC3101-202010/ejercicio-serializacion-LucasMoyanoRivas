using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace SerializacionEjercicioClase
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Persona persona = new Persona("", "", 1);
            bool exec = true;
            while (exec)
            {
                string chosen = ShowOptions(new List<string>() { "Crear persona", "Ver personas registradas", "Almacenar", "Cargar", "Salir" });
                switch (chosen)
                {
                    case "Crear persona":
                        Console.WriteLine("Cual seria su nombre?");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Cual seria su apellido?");
                        string apellido = Console.ReadLine();
                        Console.WriteLine("Cual seria su edad?");
                        int edad = Convert.ToInt32(Console.ReadLine());
                        persona.crearpersona(nombre, apellido, edad);
                        Console.Clear();
                        break;
                    case "Ver personas registradas":
                        Console.Clear();
                        persona.verpersonasregistrada();
                        break;
                    case "Almacenar":
                        Console.Clear();
                        foreach(Persona p in persona.listapersona)
                        {
                            IFormatter formatter = new BinaryFormatter();
                            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                            formatter.Serialize(stream, p);
                            stream.Close();
                        }
                        break;
                    case "Cargar":
                        Console.Clear();
                        foreach (Persona p in persona.listapersona)
                        { 
                            IFormatter formatter = new BinaryFormatter();
                            Stream stream = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                            Persona persona1 = (Persona)formatter.Deserialize(stream);
                            stream.Close();
                        }
                        break;
                    case "Salir":
                        exec = false;
                        break;
                }
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
        private static string ShowOptions(List<string> options)
        {
            int i = 0;
            Console.WriteLine("\n\nSelecciona una opcion:");
            foreach (string option in options)
            {
                Console.WriteLine(Convert.ToString(i) + ". " + option);
                i += 1;
            }
            return options[Convert.ToInt16(Console.ReadLine())];
        }
    }
}
