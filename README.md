# proyecto-final-grupo-28
proyecto-final-grupo-28 created by GitHub Classroom

*ASPECTOS TECNICOS*
- Visual Studio 2019
- .NET 5.0 
- SQL Server 2019
- Se desarrollo en Windows
- Se utilizo el patron de diseño de Repositorio debido a que utilizabamos muchas veces el mismo codigo para manejar datos y que al mismo tiempo se podia reutilizar por ejemplo el    crear un nuevo usuario, una nueva cita, registrar un nuevo ciudadano, todo lo podemos resumir en funciones dentro del patron de repositorio.
   En nuestro programa se implemento a la hora de registrar un nuevo ciudadano y un nuevo empleado, por lo que se ahorraria codigo utilizando la funcion "create()" de nuestro        repositorio.
-Extensiones:
1-Microsft Visual Studio Installer Projects: es la extension que se utilizo para la creacion del instalador del proyecto "Application"
Nugget:
1-iTextSharp: Se utilizo este nugget para poder convertir una interfaz a pdf en los archivos seleccionado por el usuario.
2-EntityFramewrokCore: Es la manera con la que se trabajo con la base de datos para poder conetarnos desde codigo 

--Instalador--
El instalador se encuentra dentro de la carpeta Programacion Orientada a objetos luego acceder a SetupVaccination seguida de la carpeta debug 
adentro de la carpeta debug se encuentra "setup"
--dandole un click nos tira la opcion y le damos a "siguiente"
--Nos tira las opciones de donde deciamos guardarlo segun los gustos "Examinar"
--Le damos "siguiente"  y nos mostrara una ventana para confirmar la instalacion y le daremos "siguiente"
--Nos pedira realizar en el dispositivo y daremos acceso seleccionando "si"
--Posteriormente se instalara y se generara un acceso directo en el escritorio o donde se selecciono guardar la appication 

--Version del Framework : 5.0.7
--Es requisito tener una base de datos existente "creada anteriormente"
--Gestor de BDD :  SQL Server 2019
--Manual de Usuario--

