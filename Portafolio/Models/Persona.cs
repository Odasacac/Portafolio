namespace Portafolio.Models
{
    public class Persona
    {
        public string nombre;
        public int edad;

        public Persona(String nombre, int edad)
        { 
            setNombre(nombre);
            setEdad(edad); 
        }

        public String getNombre()
        {
            return this.nombre;
        }

        public int getEdad()
        {
            return this.edad;
        }

        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        public void setEdad(int edad)
        { 
            this.edad = edad;
        }
    }


}
