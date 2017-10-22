**Esta aplicacion es una POC de las siguientes cosas**

1. Librería workflow-core
2. Proyecto ASP.NET Core 2
3. Esquema de deployment usando releases de github

**Requisitos**

* Visual Studio (Mac o Windows)
* Net 4.6 o superior. (En el cliente y en el servidor)
* Herramienta dotnet. (En el cliente y en el servidor)

**Configuracion de IIS**

* Crear una carpeta en el FileSystem, (por ejemplo C:\MMD\deploy\workflow-core-poc) En esta carpeta se van a crear los directorios de instalacion de la aplicación ASP.NET Core
* Crear una aplicación en IIS que apunte al directorio anterior.
* Asegurarse que la aplicación incluye el módulo AspNetCoreModule
* En la configuración del Application Pool, poner _No Managed Code_ ya que IIS es simplemente un proxy reverso

**Deployment**

Del lado del cliente ejecutar el script publish.sh, este script ejecuta los siguientes pasos
1. Corre el comando dotnet publish y genera el directorio de instalacion
2. Comprime el directorio en un archivo .zip
3. Crea el tag para el release en github

En github ejecutar los siguientes pasos

* Ir releases
* Seleccionar el release recien creado
* Edit tag
* Subir el binario generado por el script anterior
* Guardar


Del lado del servidor ejecutar el script deploy.cmd, este script ejecuta los siguientes pasos
1. Descarga el release de github
2. Detiene el aplication pool
3. Descomprime el release de github en el directorio creado en la configuracion de IIS
4. Reinicia el application pool

_Ejemplo_

* ./publish.sh 0.0.1-master
Y en el server con IIS:
* .\deploy.ps1 -repo charlygrappa/workflow-core-poc -tag 0.0.1-master
