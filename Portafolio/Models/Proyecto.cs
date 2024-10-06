namespace Portafolio.Models
{
    /*
    Básicamente un modelo es una clase con atributos
    De esta forma se organiza la informacion
     */
	public class Proyecto
	{
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string imagenURL { get; set; }
        public string link { get; set; }
    }
}
