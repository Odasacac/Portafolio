namespace Portafolio.Models
{
	public class HomeIndexViewModel
	{
        public IEnumerable<Proyecto> Proyectos { get; set; }

        /*
        IEnumerable, bueno es una interfaz que se usa para iterar sobre sus elementos
        Es decir, solo para ir mostrandolos
        ¿Podria ser una List? Podria, pero como solo queremos interarlos nos vale con el IEnumerable
        Si quisieramos cosas como Add, Remove.. Entonces ya si que hay que recurrir a las List
        
        Entonces basicamente este Modelo tiene como atributo un IEnumerable de Proyectos llamado Proyectos
         */

    }
}
