using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;


/*
    Los Controladores son clases que van a recibir las peticiones http y van a dar una respuesta

    Esta clase es un Controlador porque hereda de la clase Controller
    Ademas, tiene metodos que devuelven IActionResult, estos metodos se llaman acciones
    Las acciones son metodos que se ejecutan cuando se realiza una peticion http a una ruta especifica de la aplicacion
    Entonces, un Controlador contiene una o mas acciones

    El navegador realiza una peticion http get hacia la ruta que esta en el launchSetting.json, por ejemplo:
    https://localhost:7039
    Esta ruta es procesada por un Controlador que decide con que Vista responder, entonces:

    1 - ¿Donde esta ese Controlador?
    2 - ¿Que Vista se muestra?

    Ambas preguntas se responden a la vez, y es con el archivo Program.cs
    Aqui se encuentra la definicion del Ruteo, y ahi se define por defecto que Controlador y que accion se ejecutara

        app.MapControllerRoute
        (
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
        );

    Aqui dice que por defecto se ejecutará la accion Index del controlador Home, vamos para allá

 */


namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos IRepositorioProyectos;
       


		public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos)
        {
            _logger = logger;
            /*
             El ILogger es para poner mensajes en la consola:
            _logger.LogInformation("Mensaje");
             */

            this.IRepositorioProyectos = repositorioProyectos;

        }



		//Accion Index del controlador Home
		public IActionResult Index()
        {
            /*
           
            Hay varias cosas ahora, pero lo importante es que devuelve una Vista: return View()
            El parametro ahora no es importante
            ¿Donde se encuentra la Vista que devuelve?
            La clave esta en el nombre del Controlador: Home, y el nombre de la accion: Index
            Si vamos al explorador, veremos que dentro de Views existe la carpeta Home y el cshtml Index
            
            Tambien tenemos la accion Privacy, la cual ejecutara: Home/Privacy.cshtml

            Ahora, si el View() se llama sin parametro, lo que hace es llamar a una Vista con el mismo nombre que la accion, Index en este caso
            Pero si se le pasa como String el nombre de una Vista existente, llamara a esa y no a la de la accion

            Bien, vamos ahora a ver el Layout: View/Shared/_Layout

            */




            /*
             Ahora, con la interfaz IrepositorioProyectos, cuyos metodos estan implementados en RepositorioProyectos
            Servicios/RepositorioProyectos
            Se llama al metodo obtenerProyectos(), el cual devuelve una lista de proyectos y se seleccionan los 3 primeros
            Luego se instancia un objeto tipo HomeIndexViewModel
            Cuyo atributo Proyectos, que es un IEnumerable de Proyectos, se define con la variable proyectos
            Y es este objeto es el que se pasa a la Vista Index
            
             */
            var proyectos = IRepositorioProyectos.ObtenerProyectos().Take(3);
            var modelo = new HomeIndexViewModel() {Proyectos = proyectos};
            return View(modelo);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
		public IActionResult Contacto()
		{
			return View();
		}

        [HttpPost]
		/*
            
            Con el atributo [HttpPost] se le dice esta Action se va a usar cuando se reciba un HttpPost hacia Home/Contacto

            Si se recibe un HttpGet, vamos a IActionResult Contacto()
            Si se recibe un HttpPost, vamos IActionResult Contacto(ContactoViewModel contactoViewModel)

            ¿Que define que sea un Get o un Post?
            Bueno, por defecto va a ser un Get
            Para indicar que es un Post, en la vista, asp-action="Contacto" ya define que es un Post
        */
        public IActionResult Contacto(ContactoViewModel contactoViewModel)
        {
			return RedirectToAction("Gracias", contactoViewModel);

			/*

	        Y magia, porque realmente lo que le enviamos aqui es, en este caso y por ejemplo:

		    Nombre: "Carlos"
		    Email: "carlos@gmail.com"
		    Mensaje: "Hola"

	        Los campos es lo que se introduce en el formulario y lo de Nombre, Email y Mensaje viene de los name="nombre" de los inputs

	        ¿Que pasa? Que como Nombre, Email y Mensaje coinciden con los atributos del objeto que pide la accion, el propio programa crea el objeto con esos datos

	        Tambien podria ser asi:

	    	public IActionResult Contacto(string nombre, string email, string mensaje)
		    {
		    	ContactoViewModel contactoviewModel = new ContactoViewModel (nombre, email, mensaje);
		    	return RedirectToAction("Gracias", contactoViewModel);
		    }	 

	        Ambos enfoques son validos, pero es mejor la opcion sin comentar

            El tema del RedirectToAction() y no View()

            Se hace para evitar que se envie el formulario de nuevo si el usuario refresca la pagina

                Usando RedirectToAction:
                    1 - El usuario envía el formulario.
                    2 - El servidor procesa los datos y luego redirige a la acción "Gracias".
                    3 - El navegador realiza una nueva solicitud GET a la acción "Gracias".
                    4 - La acción "Gracias" renderiza la vista "Gracias".

                Usando View
                    1 - El usuario envía el formulario.
                    2 - El servidor procesa los datos y luego renderiza directamente la vista "Gracias" en la misma solicitud.
                    3 - El navegador muestra la vista "Gracias".
            
            Con el RedirectToAction() se lleva a cabo un Post/Redirect/Get
            Ya que con el View("Gracias"), la Vista "Gracias" estaria dentro de la peticion POST
            Por lo que, aunque no este en la vista propia del formulario, si se refresca la vista "Gracias" el formulario se reenviara

	        */

	}

	public IActionResult Gracias(ContactoViewModel contactoViewModel)
        {
            return View(contactoViewModel);
        }


		public IActionResult Proyectos()
		{

            var proyectos = IRepositorioProyectos.ObtenerProyectos();
			/*
            La diferencia aqui con la Accion Index es
            1 - No se seleccionan solo 3 Proyectos
            2 - No se envia un objeto tipo HomeIndexViewModel, sino un IEnumerable

            No hay ningún problema en que ObtenerProyectos devuelva una List y la vista acepte un IEnumerable
		    Aquí es donde el polimorfismo de interfaces de C# es útil.

             */

			return View(proyectos);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
