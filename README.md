# NEWSHORE
Título: Conectando viajes alrededor del mundo - NEWSHORE

Descripción del Proyecto:
El proyecto consiste en desarrollar una solución backend para Newshore, una empresa de viajes que busca conectar destinos a nivel mundial. La solución permite a los usuarios consultar rutas de viaje entre un origen y un destino dados, utilizando la información de vuelos asociados proporcionada por la empresa.

Se sigue una arquitectura que permite un manejo eficiente y escalable de la información.

Los aspectos clave que se consideraron son: encontrar el modelado de clases para trabajar con los vuelos, el consumo de una API REST para obtener la información de vuelos disponibles, la implementación de un API que permita calcular y devolver rutas de viaje basadas en los parámetros de origen y destino proporcionados por el usuario, y finalmente, la gestión de persistencia de las rutas consultadas para un acceso rápido en consultas futuras.

Estado del proyecto: 100%

Funcionalidades del proyecto:

-Modelo estándar
-Consumo de API REST
-Obtención de la ruta
-Acceso a datos
-Ruta de prueba https://localhost:44340/api/Journey?Origin=MZL&Destination=CTG

Acceso al Proyecto:
https://github.com/CristianOrtega12/NEWSHORE.git

Recomendaciones:
-Cambiar la cadena de conexion del appsettings.json a la de servidor a alojar esta base de datos
-Se debe abrir la consola del administrador de paquetes, cambiar el proyecto determinado a Infra.Data y realizar el update-database para subir 
    todas las Migrations
-Se puede probar la API por el Swagger 

Tecnologías utilizadas:

-C#
-.Net 6.0 
-ASP.Net 
-SQL

Personas Desarrolladoras del Proyecto:
CristianOrtega12
