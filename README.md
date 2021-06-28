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

Vacunación de El Salvador es un software desarrollado para mejorar la eficacia del proceso de vacunación en la República de El Salvador, con el propósito de agendar citas y darles seguimientos mediante algunos requerimientos necesarios del paciente, cuyo acceso estará limitado a los empleados con el rango de Gestores que podrán registrar empleados, agendar citas y darle seguimiento a estas mismas mediante el software.

--1.Formulario Login: Es el primer formulario que se le muestra al Gestor, en este se ingresará a la Plataforma de citas al ingresar el Usuario (en este caso será la Identificación del Gestor) y la contraseña, también aparece el botón “New Staff” donde podrá registrarse un Usuario o un Gestor.
 
--2.Formulario Registro de Empleado: Se abre al presionar el botón New Staff y en el se registrarán los datos de un Empleado, si solo se ingresará un empleado o Encargado de cabina, solo accederán a este Formulario, de ser un Gestor, accederá a uno nuevo donde colocará su contraseña para tener acceso al programa

--2.1. Formulario de Información del Gestor: En este formulario se pedirá la contraseña del Gestor al haber registrado un Usuario tipo Gestor, su usuario se establecerá predeterminado a su Identificación.

--3.Formulario Principal, Proceso de cita: En este formulario se registrará el paciente, este solo podrá entrar al registro al pertenecer a un grupo de prioridad, para poder registrarse se necesitará que el paciente tenga más de 60 años, si es mayor de 18 pero menor a 60 necesitará tener una enfermedad crónica (enfermedades no transmisibles o alguna discapacidad.) o pertenecer a alguna institución del sistema integrado de salud, encargados de la seguridad nacional 
 
-En caso que el paciente tenga alguna enfermedad crónica se necesitará marcar el recuadro de “¿Posee alguna enfermedad crónica?” y escribir el nombre de la enfermedad y el tipo de esta
 
-Luego al agregarla, esta aparecerá en la tabla mostrada, para borrar alguna de la lista se necesitará seleccionar la fila y presionar suprimir en el teclado.
 
--3.1. Formulario de institución: Este servirá para agregar alguna institución, marcando el recuadro de “¿Pertenece a alguna institución?” en caso que el paciente pertenezca a alguna Institución de prioridad, y en este necesitará escribir el nombre y el tipo de la Institución a la que pertenece.
  
-En el formulario principal, en la pestaña “Vacunación” aparecerá el siguiente mensaje, el cual podrá ser impreso para entregárselo al paciente con el día de su fecha guardándose como PDF.
  
-En el formulario principal, en la pestaña “Seguimiento de cita” para buscar la cita de algún paciente registrado se deberá ingresar el DUI en el campo indicado y aparecerá la información, también se podrá volver a imprimir la primera cita.
 
-En la pestaña de “Proceso de Vacunación” se ingresará la fecha/hora y el DUI de la persona que ingresó a la fila de espera y en “Recibió la Vacuna” se ingresará la fecha/hora y el DUI de la persona que se vacunó. En “Efectos secundarios” después de vigilar 30 minutos al paciente se ingresarán los efectos secundarios que obtuvo el paciente si es que los hubiesen.
Al finalizar la vacunación en caso de ser la primera dosis, se escribirá el DUI del paciente en “Registro de Segunda Dosis” y al registrarse, aparecerá una ventana que indique la fecha y hora que se le dará la Segunda Dosis al paciente.
   

--Simbolos de Error--

-Login: Al querer ingresar un usuario que no sea gestor o un usuario que no exista, es necesario revisar que el usuario/contraseña estén bien escritos o que estén registrados

-Registro empleado: Al dejar los campos vacíos aparecerá el recuadro, es necesario que los campos se llenen correctamente	 

-Registro empleado: Al querer registrar un usuario con el mismo identificador aparecerá el error, es necesario verificar que este usuario no exista para registrarlo.

-Registro empleado: Si se ingresa en el campo de Email texto sin formato de correo, aparecerá la ventana, es necesario que siga el formato: [texto]@[correo].com	 

-Principal, Proceso de cita: Al ingresar un DUI o teléfono inválido se mostrará la ventana, el teléfono debe empezar con 2,6 o 7 y tener 8 dígitos para que sea válido, y el dui empezar con cero seguido de 8 caracteres y un -# de último.	 

-Principal, Proceso de cita: Si no pertenece a un grupo de prioridad, no dejará registrar al paciente, para pertenecer a este grupo debe o tener una edad arriba de 70 años o ser mayor de 18 años y ser parte del sistema de salud, seguridad nacional o Gobierno central o padecer de alguna enfermedad no transmisible o discapacidad.	 

-Principal, Proceso de cita: Si se ingresa en el campo de Email texto sin formato de correo, aparecerá la ventana, es necesario que siga el formato: [texto]@[correo].com

Principal, seguimiento de cita: Al ingresar un DUI no registrado en el buscador se mostrará la ventana, se debe verificar que el DUI ingresado esté registrado, si no lo encuentra es porque debe hacer su primer registro	 

-Principal, seguimiento de cita: Si no se ha buscado nada o no ha encontrado el DUI, no permitirá imprimir ya que los campos están vacíos, es necesario que estos contengan algo para porder imprimir.	

-Principal, proceso de vacunación: Si se ingresa un DUI en los campos que no ha sido registrado se mostrará la pestaña, se debe primero registrar al paciente y el programa dará la fecha indicada	 

