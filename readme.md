# **Store**

### Markdown Presentation Ecosystem

 Saydenier Palacios
###### 10-05-2024
---
## Descripción
Demo de **aplicación web ecommerce** para la venta de artículos a convenir, que permite a los usuarios registrarse, iniciar sesión, ver productos, agregar productos al carrito de compras y realizar el pago.

Para este desarrollo decidí hacer uso del patrón de arquitectura clean **DDD o Domain Drive Design** lo que permite un muy buen escalado general de la aplicación, así como un fácil mantenimiento y una correcta separación de las distintas capas del aplicativo y las reglas de negocio.

---

El framework utilizado para el backend fue **.Net 8** con **Entity Framework** como **ORM**. Para el front-end se utilizará **Astro** por su versatilidad y simpleza al momento de integrar apis interesantes para el desarrollo de una interface intuitiva y atractiva (como las **view transitions**), además de complementarse y atomizarse mediante componentes de **React**. 

Como motor de Base de Datos se utilizó **Microsoft SQL Server** con una BD local. El enfoque de desarrollo fue **Code First**, por lo que es necesario correr el comando:

Add-Migration {Nombre de la migración}

---

Para poder levantar la aplicación (es importante aclarar que MSSM debe estar instalado para poder ejecutar el ambiente, así como el framework de .Net con su runtime).

Por motivos de tiempo se utilizaran solo 3 controladores para la funcionalidad de la aplicación, siendo estos OAuth para el login de usuarios, Productos y CarritoPorUsuario. Hay otras aproximaciones más recomendables para este tipo de aplicación, pero el tiempo apremia.

