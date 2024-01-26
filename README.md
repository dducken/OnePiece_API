# API de One Piece

¡Bienvenido al mundo de One Piece a través de esta API desarrollada con .NET 6! Este proyecto te sumergirá en un emocionante viaje a través de las acciones CRUD relacionadas con Personajes, Tripulaciones y Roles en el universo de One Piece.

<img src='https://i.pinimg.com/564x/bd/23/eb/bd23eb0b41dac4248d7e1f2efdca7a4c.jpg'/>

## Características Principales:

- **Acciones CRUD**: Realiza operaciones de Crear, Leer, Actualizar y Eliminar sobre los datos de tus personajes favoritos, sus tripulaciones y roles.
  
- **Modelos Genéricos**: Implementa modelos genéricos para la creación de entidades y DTOs, permitiendo una flexibilidad y reutilización eficiente en la manipulación de datos.
    
- **Patrones de Diseño**: Implementa sólidas prácticas y patrones de diseño, como Unit of Work, Generic Repository y Clean Architecture, para asegurar una estructura robusta y mantenible del código.

- **Inyección de Dependencias**: Aprovecha el poder de Dependency Injection para lograr una gestión eficiente de las dependencias, mejorando la modularidad y la testabilidad del código.

- **Code First**: Adopta la metodología Code First para la generación de la base de datos, permitiendo una fácil evolución del esquema a medida que tu aplicación se desarrolla.

## Tecnologías Utilizadas:

- **.NET CORE 6**, **Entity Framework Core**, **PostgreSQL**


## Arquitectura:
 ![image](https://github.com/dducken/OnePiece_API/assets/64493715/4e0e391e-433c-424e-8e3b-246f5da3294d)

## Metodos API:
- **Todos los metodos de la entidad Character**
  ![image](https://github.com/dducken/OnePiece_API/assets/64493715/75923fca-947e-4b45-8b7b-fe440b7ff0b5)
  
- **api/characters** [GET] --> Muestra todos los personajes.
![image](https://github.com/dducken/OnePiece_API/assets/64493715/11602725-20e8-44ce-9711-961366c880bb)

- **api/characters** [POST] --> Permite crear un personaje.
  
- **api/characters/{id}** [GET] --> Obtiene info mas detallada de un personaje.
![image](https://github.com/dducken/OnePiece_API/assets/64493715/f6bfb2c7-86f9-41d8-bb13-a67665a67982)

- **api/characters/{id}** [PATCH] --> Permite actualizar un campo en especifico de la entidad.
  **Ejemplo para actualizar el campo reward del character con id = 1**
  
![image](https://github.com/dducken/OnePiece_API/assets/64493715/b207953e-0641-4151-9868-94c995217d90)

- **api/characters/{id}** [DELETE] --> Realiza un soft delete al character indicado.
  
![image](https://github.com/dducken/OnePiece_API/assets/64493715/34fc5d97-f646-4d6b-9f64-8df8054deeca)





