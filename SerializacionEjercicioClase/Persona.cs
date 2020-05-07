using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
namespace SerializacionEjercicioClase
{
    [Serializable]
    public class Persona
    {
        private string nombre;
        private string apellido;
        private int edad;
        public List<Persona> listapersona = new List<Persona>();
        public Persona(string nombre, string apellido, int edad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
        }
        public void crearpersona(string nombre, string apellido, int edad)
        {
            Persona persona = new Persona(nombre, apellido, edad);
            listapersona.Add(persona);
        }
        public void verpersonasregistrada()
        {
            foreach (Persona p in listapersona)
            {
                p.GetInfo();
            }
        }
        public void GetInfo()
        {
            Console.WriteLine($"Nombre: {nombre}, apellido: {apellido}, edad: {edad}");
        }
    }
}
