Create Database CompraDb
Use CompraDb

Create Table Usuarios(
	UsuarioId int primary key identity,
	NombreUsuario varchar(30),
	Contrasena varchar(30),
	Nombres varchar(30),
	Apellidos varchar(30),
	Telefono varchar(12),
	Celular varchar(12),
	Email varchar(max),
	Direccion varchar(max)
)

Create Table Productos(
	ProductoId int primary key identity,
	Nombre varchar(30),
	Marca varchar(30),
	UnidadMedida int,
	CantidadMinima int,
	CantidadExistente int,
	Precio decimal(7),
	Costo decimal(7)
)

Create Table Proveedores(
	ProveedorId int primary key identity,
	UsuarioId int,
	Nombres varchar(30),
	Apellidos varchar(30),
	Telefono varchar(12),
	Celular varchar(12),
	Rnc int,
	Email varchar(max),
	Direccion varchar(max),

	constraint FK_UsuarioId foreign key (UsuarioId) References Usuarios(UsuarioId)
)

Create Table CompraProductos(
	CompraId int primary key identity,
	ProveedorId int,
	UsuarioId int,
	Fecha datetime,
	Total decimal(9),

	constraint FK_ProveedorId foreign key (ProveedorId) References Proveedores(ProveedorId),
	constraint FK_UsuarioId_ foreign key (UsuarioId) References Usuarios(UsuarioId)
)

Create Table CompraProductosDetalle(
	CompraId int,
	ProductoId int,
	Cantidad int,
	Precio decimal(7),
	
	constraint FK_CompraId foreign key (CompraId) References CompraProductos(CompraId),
	constraint FK_ProductoId foreign key (ProductoId) References Productos(ProductoId)
)