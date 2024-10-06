/*
Vale, .NET

Hay una Solucion la cual contiene proyectos, en este caso: Portafolio es el proyecto

Si clickamos en el Proyecto (a partir de ahora Portafolio), veremos un archivo csproj.
En este archivo esta la configuracion central de la aplicacion.

Dentro del proyecto tenemos:

	1 - Connected Services: Para conectar servicios.

	2 - Dependencies: Las dependencias, principalmente los paquetes de Nu Get que se vayan instalando
		Nu Get basicamente permite importar codigo para usarlo

	3 - Properties: propiedades del proyecto: launchSetting.json
		Dentro vemos, en profile, el nombre del proyecto y la url donde se ejecutara
		Se pueden tener diferentes perfiles con diferentes configuraciones
		Por ejemplo, en environmentVariables se puede poner algun perfil que trabaje en "Production" y no en "Development"
	
	4 - wwwroot: aqui van los archivos estaticos del proyecto: css, js, librerias, imagenes...

	5 - Controllers: Los controladores son las clases que reciben las peticiones http, las procesan y devuelven una respuesta
		En el contexto MVC, la respuesta suele ser una vista, pero no tiene por que ser asi

	6 - Models: Son las clases que representan los datos que se quieren mostrar al usuario en una vista

	7 - Vistas: La parte visual del proyecto, Front vaya

	8 - appsettings.json: permiten guardar datos de configuracion que el proyecto va a usar
	Si es el .Development es el que se usa en el desarrollo, el que no lo es es para produccion
	Esta preferencia se cambia en el archivo lanchSetting.json, profile, environmentVariables

	9 - Program.cs: Se encuentra la pieza central del proyecto, aqui es donde todo comienza
	Configuramos los servicios, los middelwares
		
	Vale, ahora vamos a Controller/HomeController











 */