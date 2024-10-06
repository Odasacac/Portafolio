namespace Portafolio.Servicios
{
	public class ServicioUnico
	{
        public Guid obtenerGuid { get; private set; }

        public ServicioUnico()
        {
            obtenerGuid = Guid.NewGuid();
        }
    }

	public class ServicioDelimitado
	{
		public Guid obtenerGuid { get; private set; }

		public ServicioDelimitado()
		{
			obtenerGuid = Guid.NewGuid();
		}
	}

	public class ServicioTransitorio
	{
		public Guid obtenerGuid { get; private set; }

		public ServicioTransitorio()
		{
			obtenerGuid = Guid.NewGuid();
		}
	}
}
