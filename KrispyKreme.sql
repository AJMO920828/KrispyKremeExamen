-- Crear la tabla usuarios
CREATE TABLE usuarios (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    correo NVARCHAR(150) NOT NULL UNIQUE,
    rol NVARCHAR(100) NOT NULL UNIQUE,
    usuario NVARCHAR(50) NOT NULL UNIQUE,
    contrasena NVARCHAR(255) NOT NULL,
    fecha_alta DATETIME DEFAULT GETDATE(),
    activo BIT DEFAULT 1
);
GO

-- Descripción de la tabla
EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Tabla que almacena los usuarios del sistema.', 
    @level0type = N'SCHEMA', @level0name = 'dbo', 
    @level1type = N'TABLE',  @level1name = 'usuarios';
GO

-- Descripciones por columna
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'Identificador único del usuario.',
    @level0type = N'SCHEMA', @level0name = 'dbo', @level1type = N'TABLE', @level1name = 'usuarios', @level2type = N'COLUMN', @level2name = 'id';

EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'Nombre completo del usuario.',
    @level0type = N'SCHEMA', @level0name = 'dbo', @level1type = N'TABLE', @level1name = 'usuarios', @level2type = N'COLUMN', @level2name = 'nombre';

EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'Correo electrónico del usuario.',
    @level0type = N'SCHEMA', @level0name = 'dbo', @level1type = N'TABLE', @level1name = 'usuarios', @level2type = N'COLUMN', @level2name = 'correo';

EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'Nombre de usuario (login) del sistema.',
    @level0type = N'SCHEMA', @level0name = 'dbo', @level1type = N'TABLE', @level1name = 'usuarios', @level2type = N'COLUMN', @level2name = 'usuario';

EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'Contraseña encriptada del usuario.',
    @level0type = N'SCHEMA', @level0name = 'dbo', @level1type = N'TABLE', @level1name = 'usuarios', @level2type = N'COLUMN', @level2name = 'contrasena';

EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha en que se dio de alta el usuario.',
    @level0type = N'SCHEMA', @level0name = 'dbo', @level1type = N'TABLE', @level1name = 'usuarios', @level2type = N'COLUMN', @level2name = 'fecha_alta';

EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'Indica si el usuario está activo (1) o inactivo (0).',
    @level0type = N'SCHEMA', @level0name = 'dbo', @level1type = N'TABLE', @level1name = 'usuarios', @level2type = N'COLUMN', @level2name = 'activo';
GO

-- Crear tabla ventas con relaciones y descripciones
CREATE TABLE ventas (
    id INT PRIMARY KEY IDENTITY(1,1),
    descripcion NVARCHAR(255) NOT NULL,
    monto DECIMAL(18, 2) NOT NULL,
    fecha DATETIME NOT NULL DEFAULT GETDATE(),
    usuario_alta INT,
    fecha_alta DATETIME DEFAULT GETDATE(),
    usuario_modificacion INT,
    fecha_modificacion DATETIME DEFAULT GETDATE(),
    activo BIT DEFAULT 1,

    CONSTRAINT FK_ventas_usuario_alta FOREIGN KEY (usuario_alta) REFERENCES usuarios(id),
    CONSTRAINT FK_ventas_usuario_modificacion FOREIGN KEY (usuario_modificacion) REFERENCES usuarios(id)
);
GO

-- Descripción general de la tabla
EXEC sp_addextendedproperty 
    @name = N'MS_Description', 
    @value = N'Tabla que almacena las ventas realizadas en Krispy Kreme.', 
    @level0type = N'SCHEMA', @level0name = 'dbo', 
    @level1type = N'TABLE',  @level1name = 'ventas';
GO

-- Descripciones por columna
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'Identificador único de la venta.',
    @level0type = N'SCHEMA', @level0name = 'dbo', @level1type = N'TABLE', @level1name = 'ventas', @level2type = N'COLUMN', @level2name = 'id';

EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'Descripción del producto o servicio vendido.',
    @level0type = N'SCHEMA', @level0name = 'dbo', @level1type = N'TABLE', @level1name = 'ventas', @level2type = N'COLUMN', @level2name = 'descripcion';

EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'Monto total de la venta.',
    @level0type = N'SCHEMA', @level0name = 'dbo', @level1type = N'TABLE', @level1name = 'ventas', @level2type = N'COLUMN', @level2name = 'monto';

EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha en la que se realizó la venta.',
    @level0type = N'SCHEMA', @level0name = 'dbo', @level1type = N'TABLE', @level1name = 'ventas', @level2type = N'COLUMN', @level2name = 'fecha';

EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'ID del usuario que dio de alta la venta (FK a usuarios).',
    @level0type = N'SCHEMA', @level0name = 'dbo', @level1type = N'TABLE', @level1name = 'ventas', @level2type = N'COLUMN', @level2name = 'usuario_alta';

EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha en la que se dio de alta la venta.',
    @level0type = N'SCHEMA', @level0name = 'dbo', @level1type = N'TABLE', @level1name = 'ventas', @level2type = N'COLUMN', @level2name = 'fecha_alta';

EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'ID del usuario que modificó la venta por última vez (FK a usuarios).',
    @level0type = N'SCHEMA', @level0name = 'dbo', @level1type = N'TABLE', @level1name = 'ventas', @level2type = N'COLUMN', @level2name = 'usuario_modificacion';

EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'Fecha en la que se realizó la última modificación.',
    @level0type = N'SCHEMA', @level0name = 'dbo', @level1type = N'TABLE', @level1name = 'ventas', @level2type = N'COLUMN', @level2name = 'fecha_modificacion';

EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'Indica si la venta está activa (1) o fue cancelada (0).',
    @level0type = N'SCHEMA', @level0name = 'dbo', @level1type = N'TABLE', @level1name = 'ventas', @level2type = N'COLUMN', @level2name = 'activo';
GO



INSERT INTO usuarios (nombre, correo, rol, usuario, contrasena) VALUES(N'Abel Jonathan Mendoza Ortiz', N'abel_mdz@hotmail.com', N'Admin', N'abel', N'123456');
INSERT INTO usuarios (nombre, correo, rol, usuario, contrasena) VALUES(N'Vendedor 1', N'vendedor1@hotmail.com', N'Ventas', N'vendedor1', N'123456');
INSERT INTO usuarios (nombre, correo, rol, usuario, contrasena) VALUES(N'Vendedor 2', N'vendedor2@hotmail.com', N'Ventas', N'vendedor2', N'123456');