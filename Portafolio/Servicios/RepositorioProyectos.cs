using Portafolio.Models;

namespace Portafolio.Servicios
{
	/*
	 PRINCIPIO DE RESPONSABILIDAD UNICA: es una guia, no hay que irse al extremo
	Basicamente que cada clase debe tener un solo motivo para ser llamada
	Por eso, el tema metodos que hacen cosas, por asi decirlo, se entienden como servicios
	Servicios/Clases
	Se codifican en interfaces que seran inyectadas como dependencias en las clases que las usen

	En este caso, se hace la interfaz IRepositorioProyectos, implementada en la clase RepositorioProyectos
	Esta interfaz sera un atributo de la clase que la necesite, HomeController en este caso
	Este atributo sera definido en el constructor
	Y ya de ahi podran accederse a sus metodos

	Es importante ir a la clase Program.cs para configurar la inyeccion de dependencias y allí:
	builder.Services.AddTransient<IRepositorioProyectos, RepositorioProyectos>();
	De esta forma tenemos la interfaz y la clase configuradas en el sistema de inyeccion de dependencias

	¿Por que usar interfaces y no la clase directamente?
	Porque usar una interfaz es mas flexible que una clase
	Una interfaz no sabe realmente con que clase trabaja
	Por lo que se puede cambiar de clase facilmente sin cambiar mucho codigo
	Yo haria el objeto directamente y listo, pero bueno de esta forma es como mejor

	Esto es el PRINCIPIO DE INVERSION DE DEPENDENCIAS
	Es decir, que una clase no depende de otra clase, sino que depende de tipos abstractos, como una interfaz

	 */

	public interface IRepositorioProyectos
	{
		List<Proyecto> ObtenerProyectos();
	}

	public class RepositorioProyectos:IRepositorioProyectos
	{
        /*
		Este metodo lo que hace es devolver una lista de objetos tipo Proyecto
		Crea y retorna una nueva instancia de List<Proyecto>
		La lista es inicializada con cuatro objetos Proyecto
		 */
        public List<Proyecto> ObtenerProyectos()
		{
			return new List<Proyecto> 
			{
				new Proyecto
				{
					titulo = "Amazon",
					descripcion = "E-Commerce realizado en ASP.NET Core",
					link = "https://amazon.com",
					imagenURL = ""
				},
				 new Proyecto
				{
					titulo = "New York Times",
					descripcion = "Pagina de noticias en React",
					link = "https://nytimes.com",
					imagenURL = ""
				},
				  new Proyecto
				{
					titulo = "Reddit",
					descripcion = "Red para compartir",
					link = "https://reddit.com",
					imagenURL = ""
				},
				   new Proyecto
				{
					titulo = "Steam",
					descripcion = "Para videojuegos",
					link = "https://store.steampowered.com",
					imagenURL = ""
				},

			};
		}
	}
}
