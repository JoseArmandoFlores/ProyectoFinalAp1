# ProyectoFinal-Agroquímicos Fuentes
## Comenzando
Estas instrucciones permitirán utilizar el programa correctamente y así evitar posibles errores en su funcionalidad.

![Login](https://user-images.githubusercontent.com/54611432/69515327-9fa74400-0f24-11ea-8f30-78358a450231.png)

Esta ventana es la primera que se mostrará al iniciar el programa. En ella se deberán ingresar el **Usuario** y **Contraseña**. 
Si es la primera vez que se ejecuta el programa, por defecto el usuario es *Admin* y la contraseña es *admin123*. Luego estaría a 
opción del usuario modificar los datos.

## Menú
![Menu](https://user-images.githubusercontent.com/54611432/69515701-cca82680-0f25-11ea-951b-f3d74e3b11f5.png)

Esta ventana es el menu principal en la que se encuentran diferentes registros para comenzar a utilizar el programa. Cabe destacar que
solo se puede acceder al registro y consulta de **Usuarios**, si la cuenta es la del Administrador.

Dentro de los registros están los siguientes:

## Usuarios
![RegistroUsuarios](https://user-images.githubusercontent.com/54611432/69515984-b51d6d80-0f26-11ea-914a-2eda1dd8d27c.png)

Este registro permite la creación de usuarios. Todos los campos deben ser llenados, en caso contrario, no se puede registrar.

## Proveedores
![RegistroProveedores](https://user-images.githubusercontent.com/54611432/69516345-c4e98180-0f27-11ea-9380-c91e94a761f8.png)

En este registro se agregan los datos de los proveedores a los cuales se les encargará la compra de los productos. 
Todos los campos deben ser llenados.

## Productos
![RegistroProductos](https://user-images.githubusercontent.com/54611432/69516262-92d81f80-0f27-11ea-86d5-4c12a09ba24e.png)

En este formulario es donde se registrarán los productos que serán comprados. Cabe destacar, que el costo del producto no puede 
ser mayor que el precio. En caso que el usuario lo ponga de esta forma, no se podrá guardar, de igual forma se deben llenar todos los campos.

## Compra de productos
![RegistroCompraProductos](https://user-images.githubusercontent.com/54611432/69516921-89e84d80-0f29-11ea-91ba-3548f34f0d95.png)

En esta ventana es donde se realizarán las compras de los productos ya registrados. Para ello se debe de seleccionar un **Proveedor**
y un **Producto**, luego se ingresa la cantidad, y automáticamente se llenan los campos: **Marca**, **Unidad de medida**,
**Precio** e **Importe**. Para agregar dicho producto a la compra, se le da click al botón *Agregar*. El botón imprimir sirve para
imprimir los datos que están en el detalle.

En caso de no tener algún proveedor o algún producto registrado, desde ésta ventana se puede hacer. Si es para agregar un proveedor,
se procede a dar click al botón **+** que está a su lado.
En caso que sea para agregar un producto, es similar, se procede a dar click al botón **+** que está a su lado.

# Consultas
Cada registro antes mencionado tiene una consulta.
Las consultas son de acceso público a todos los usuarios, excepto la consulta de usuarios, a quien sólo tiene permitido acceder el
adminitrador.
## Consulta de compras de productos
![Consulta](https://user-images.githubusercontent.com/54611432/69559649-bb403800-0f80-11ea-9556-b8ce5732821b.png)
En esta consulta, podemos consultar con rango de fechas, elegimos la fecha desde, hasta la que queremos consultar. En el criterio se coloca lo que se va a consultar dependiendo de lo que esté seleccionado en el filtro. En caso que no se seleccione ningún filtro cuando se le da click al botón *consultar*, se consultan todas las compras existentes (dependiendo del rango de fechas). El botón imprimir, es para imprimir un reporte de acuerdo con lo que se consulte.

Las demás consultas son similar a ésta, la única diferencia es que no tienen rango de fechas.

## Pre-Requisitos
Para el buen funcionamiento de este programa, se necesita una computadora con las siguientes características:
### Requisitos
**Sistema Operativo:** *Windows 10, 64 bits.*

**Procesador:** *Intel Core i5 a 2.5Ghz.*

**Memoria RAM:** *DDR4 8 gigabyte(Gb).*

**Almacenamiento:** *1 terabyte(Tb).*

## Herramientas con las que fue construído:
-*Visual Studio, C#.*

-*SQL Server 2017.*

-*Google Chrome.*

-*Photoshop Cs6.*

## Autor
**José Armando Flores Baldera**
