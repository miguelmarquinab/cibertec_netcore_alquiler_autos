create database [AlquilerAutosDB]
go

USE [AlquilerAutosDB]
GO
/****** Object:  Table [dbo].[Alquileres] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alquileres](
	[IdAlquiler] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdAuto] [int] NOT NULL,
	[FechaInicio] [date] NOT NULL,
	[FechaFin] [date] NOT NULL,
	[Dias] [int] NOT NULL,
	[PrecioDia] [decimal](10, 2) NOT NULL,
	[Garantia] [decimal](10, 2) NOT NULL,
	[Total] [decimal](10, 2) NOT NULL,
	[Estado] [varchar](20) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[IdUsuario] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAlquiler] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Autos] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autos](
	[IdAuto] [int] IDENTITY(1,1) NOT NULL,
	[Placa] [varchar](15) NOT NULL,
	[Modelo] [varchar](100) NOT NULL,
	[Anio] [int] NOT NULL,
	[Color] [varchar](50) NOT NULL,
	[PrecioPorDia] [decimal](10, 2) NOT NULL,
	[Estado] [varchar](20) NOT NULL,
	[IdMarca] [int] NOT NULL,
	[ImagenUrl] [varchar](250) NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAuto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Placa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Dni] [varchar](20) NOT NULL,
	[Nombres] [varchar](120) NOT NULL,
	[Apellidos] [varchar](120) NOT NULL,
	[Email] [varchar](120) NULL,
	[Telefono] [varchar](20) NULL,
	[LicenciaConducir] [varchar](30) NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marcas]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcas](
	[IdMarca] [int] IDENTITY(1,1) NOT NULL,
	[NombreMarca] [varchar](80) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[NombreMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[NombreRol] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[NombreRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]   *****/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Clave] [varchar](100) NOT NULL,
	[NombreCompleto] [varchar](120) NOT NULL,
	[IdRol] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Alquileres] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[Autos] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Clientes] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Alquileres]  WITH CHECK ADD FOREIGN KEY([IdAuto])
REFERENCES [dbo].[Autos] ([IdAuto])
GO
ALTER TABLE [dbo].[Alquileres]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[Alquileres]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Autos]  WITH CHECK ADD FOREIGN KEY([IdMarca])
REFERENCES [dbo].[Marcas] ([IdMarca])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([IdRol])
REFERENCES [dbo].[Roles] ([IdRol])
GO
/****** Object:  StoredProcedure [dbo].[usp_alquiler_registrar]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_alquiler_registrar]
    @IdCliente INT,
    @IdAuto INT,
    @FechaInicio DATE,
    @FechaFin DATE,
    @Garantia DECIMAL(10,2),
    @IdUsuario INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRAN;

    DECLARE @PrecioDia DECIMAL(10,2);
    DECLARE @Dias INT;
    DECLARE @Total DECIMAL(10,2);
    DECLARE @EstadoAuto VARCHAR(20);

    SELECT
        @PrecioDia = PrecioPorDia,
        @EstadoAuto = Estado
    FROM Autos
    WHERE IdAuto = @IdAuto
      AND Activo = 1;

    IF @PrecioDia IS NULL
    BEGIN
        RAISERROR('El auto no existe.', 16, 1);
        ROLLBACK TRAN;
        RETURN;
    END

    IF @EstadoAuto <> 'DISPONIBLE'
    BEGIN
        RAISERROR('El auto no está disponible.', 16, 1);
        ROLLBACK TRAN;
        RETURN;
    END

    SET @Dias = DATEDIFF(DAY, @FechaInicio, @FechaFin) + 1;

    IF @Dias <= 0
    BEGIN
        RAISERROR('Las fechas del alquiler no son válidas.', 16, 1);
        ROLLBACK TRAN;
        RETURN;
    END

    SET @Total = (@Dias * @PrecioDia) + @Garantia;

    INSERT INTO Alquileres(
        IdCliente, IdAuto, FechaInicio, FechaFin, Dias,
        PrecioDia, Garantia, Total, Estado, IdUsuario
    )
    VALUES(
        @IdCliente, @IdAuto, @FechaInicio, @FechaFin, @Dias,
        @PrecioDia, @Garantia, @Total, 'RESERVADO', @IdUsuario
    );

    UPDATE Autos
    SET Estado = 'ALQUILADO'
    WHERE IdAuto = @IdAuto;

    COMMIT TRAN;
END
GO
/****** Object:  StoredProcedure [dbo].[usp_auto_eliminar]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_auto_eliminar]
    @IdAuto INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Autos
    SET Activo = 0
    WHERE IdAuto = @IdAuto;
END
GO
/****** Object:  StoredProcedure [dbo].[usp_auto_guardar]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_auto_guardar]
    @IdAuto INT,
    @Placa VARCHAR(15),
    @Modelo VARCHAR(100),
    @Anio INT,
    @Color VARCHAR(50),
    @PrecioPorDia DECIMAL(10,2),
    @Estado VARCHAR(20),
    @IdMarca INT,
    @ImagenUrl VARCHAR(250)
AS
BEGIN
    SET NOCOUNT ON;

    IF @IdAuto = 0
    BEGIN
        INSERT INTO Autos(Placa, Modelo, Anio, Color, PrecioPorDia, Estado, IdMarca, ImagenUrl, Activo)
        VALUES(@Placa, @Modelo, @Anio, @Color, @PrecioPorDia, @Estado, @IdMarca, @ImagenUrl, 1);
    END
    ELSE
    BEGIN
        UPDATE Autos
        SET Placa = @Placa,
            Modelo = @Modelo,
            Anio = @Anio,
            Color = @Color,
            PrecioPorDia = @PrecioPorDia,
            Estado = @Estado,
            IdMarca = @IdMarca,
            ImagenUrl = @ImagenUrl
        WHERE IdAuto = @IdAuto;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_auto_obtener] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_auto_obtener]
    @IdAuto INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        IdAuto, Placa, Modelo, Anio, Color, PrecioPorDia, Estado, IdMarca, ImagenUrl, Activo
    FROM Autos
    WHERE IdAuto = @IdAuto;
END
GO
/****** Object:  StoredProcedure [dbo].[usp_autos_disponibles] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_autos_disponibles]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        a.IdAuto,
        CONCAT(m.NombreMarca, ' ', a.Modelo, ' - ', a.Placa) AS NombreAuto,
        a.PrecioPorDia
    FROM Autos a
    INNER JOIN Marcas m ON m.IdMarca = a.IdMarca
    WHERE a.Activo = 1
      AND a.Estado = 'DISPONIBLE'
    ORDER BY m.NombreMarca, a.Modelo;
END
GO
/****** Object:  StoredProcedure [dbo].[usp_autos_listar]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_autos_listar]
    @Texto VARCHAR(100) = '',
    @Estado VARCHAR(20) = '',
    @Pagina INT = 1,
    @TamPagina INT = 8
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH DATA AS
    (
        SELECT
            a.IdAuto,
            a.Placa,
            a.Modelo,
            a.Anio,
            a.Color,
            a.PrecioPorDia,
            a.Estado,
            a.IdMarca,
            m.NombreMarca,
            a.ImagenUrl,
            a.Activo,
            ROW_NUMBER() OVER (ORDER BY a.IdAuto DESC) AS RowNum,
            COUNT(*) OVER() AS TotalRegistros
        FROM Autos a
        INNER JOIN Marcas m ON m.IdMarca = a.IdMarca
        WHERE a.Activo = 1
          AND (a.Placa LIKE '%' + @Texto + '%' OR a.Modelo LIKE '%' + @Texto + '%' OR m.NombreMarca LIKE '%' + @Texto + '%')
          AND (@Estado = '' OR a.Estado = @Estado)
    )
    SELECT *
    FROM DATA
    WHERE RowNum BETWEEN ((@Pagina - 1) * @TamPagina) + 1 AND (@Pagina * @TamPagina);
END
GO
/****** Object:  StoredProcedure [dbo].[usp_cliente_eliminar] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_cliente_eliminar]
    @IdCliente INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Clientes
    SET Activo = 0
    WHERE IdCliente = @IdCliente;
END
GO
/****** Object:  StoredProcedure [dbo].[usp_cliente_guardar] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_cliente_guardar]
    @IdCliente INT,
    @Dni VARCHAR(20),
    @Nombres VARCHAR(120),
    @Apellidos VARCHAR(120),
    @Email VARCHAR(120),
    @Telefono VARCHAR(20),
    @LicenciaConducir VARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;

    IF @IdCliente = 0
    BEGIN
        INSERT INTO Clientes(Dni, Nombres, Apellidos, Email, Telefono, LicenciaConducir, Activo)
        VALUES(@Dni, @Nombres, @Apellidos, @Email, @Telefono, @LicenciaConducir, 1);
    END
    ELSE
    BEGIN
        UPDATE Clientes
        SET Dni = @Dni,
            Nombres = @Nombres,
            Apellidos = @Apellidos,
            Email = @Email,
            Telefono = @Telefono,
            LicenciaConducir = @LicenciaConducir
        WHERE IdCliente = @IdCliente;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_cliente_obtener]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_cliente_obtener]
    @IdCliente INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        IdCliente, Dni, Nombres, Apellidos, Email, Telefono, LicenciaConducir, Activo
    FROM Clientes
    WHERE IdCliente = @IdCliente;
END
GO
/****** Object:  StoredProcedure [dbo].[usp_clientes_combo] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_clientes_combo]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        IdCliente,
        CONCAT(Nombres, ' ', Apellidos, ' - DNI: ', Dni) AS NombreCliente
    FROM Clientes
    WHERE Activo = 1
    ORDER BY Nombres, Apellidos;
END
GO
/****** Object:  StoredProcedure [dbo].[usp_clientes_listar]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_clientes_listar]
    @Texto VARCHAR(100) = ''
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        IdCliente,
        Dni,
        Nombres,
        Apellidos,
        Email,
        Telefono,
        LicenciaConducir,
        Activo
    FROM Clientes
    WHERE Activo = 1
      AND (Dni LIKE '%' + @Texto + '%'
        OR Nombres LIKE '%' + @Texto + '%'
        OR Apellidos LIKE '%' + @Texto + '%')
    ORDER BY IdCliente DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[usp_marcas_listar]  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_marcas_listar]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT IdMarca, NombreMarca
    FROM Marcas
    ORDER BY NombreMarca;
END
GO
/****** Object:  StoredProcedure [dbo].[usp_reporte_alquileres]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_reporte_alquileres]
    @FechaInicio DATE = NULL,
    @FechaFin DATE = NULL,
    @Texto VARCHAR(100) = ''
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        al.IdAlquiler,
        CONCAT(c.Nombres, ' ', c.Apellidos) AS Cliente,
        c.Dni,
        CONCAT(m.NombreMarca, ' ', a.Modelo, ' - ', a.Placa) AS Auto,
        al.FechaInicio,
        al.FechaFin,
        al.Dias,
        al.PrecioDia,
        al.Garantia,
        al.Total,
        al.Estado,
        al.FechaRegistro,
        u.NombreCompleto AS UsuarioRegistro
    FROM Alquileres al
    INNER JOIN Clientes c ON c.IdCliente = al.IdCliente
    INNER JOIN Autos a ON a.IdAuto = al.IdAuto
    INNER JOIN Marcas m ON m.IdMarca = a.IdMarca
    INNER JOIN Usuarios u ON u.IdUsuario = al.IdUsuario
    WHERE (@FechaInicio IS NULL OR al.FechaInicio >= @FechaInicio)
      AND (@FechaFin IS NULL OR al.FechaFin <= @FechaFin)
      AND (
            @Texto = '' OR
            c.Nombres LIKE '%' + @Texto + '%' OR
            c.Apellidos LIKE '%' + @Texto + '%' OR
            c.Dni LIKE '%' + @Texto + '%' OR
            a.Placa LIKE '%' + @Texto + '%' OR
            a.Modelo LIKE '%' + @Texto + '%'
          )
    ORDER BY al.IdAlquiler DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[usp_usuario_login] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[usp_usuario_login]
    @Usuario VARCHAR(50),
    @Clave VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        u.IdUsuario,
        u.Usuario,
        u.NombreCompleto,
        r.NombreRol
    FROM Usuarios u
    INNER JOIN Roles r ON r.IdRol = u.IdRol
    WHERE u.Usuario = @Usuario
      AND u.Clave = @Clave
      AND u.Activo = 1;
END
GO

INSERT INTO Roles (NombreRol) VALUES ('ADMIN');
go
INSERT INTO Roles (NombreRol) VALUES ('RECEPCIONISTA');
go

-- ADMIN
INSERT INTO Usuarios (Usuario, Clave, NombreCompleto, IdRol, Activo)
VALUES ('admin', '123456', 'Administrador General', 1, 1);

-- RECEPCIONISTA
INSERT INTO Usuarios (Usuario, Clave, NombreCompleto, IdRol, Activo)
VALUES ('recep', '123456', 'Recepcionista 1', 2, 1);

INSERT INTO Marcas(NombreMarca) VALUES
('Toyota'),
('Kia'),
('Hyundai'),
('Nissan'),
('Chevrolet');
GO

INSERT INTO Autos(Placa, Modelo, Anio, Color, PrecioPorDia, Estado, IdMarca, ImagenUrl, Activo)
VALUES
('ABC-123', 'Yaris', 2023, 'Blanco', 120.00, 'DISPONIBLE', 1, 'https://images.unsplash.com/photo-1549317661-bd32c8ce0db2?q=80&w=1200&auto=format&fit=crop', 1),
('BCD-234', 'Rio', 2022, 'Gris', 110.00, 'DISPONIBLE', 2, 'https://images.unsplash.com/photo-1492144534655-ae79c964c9d7?q=80&w=1200&auto=format&fit=crop', 1),
('CDE-345', 'Accent', 2024, 'Negro', 130.00, 'DISPONIBLE', 3, 'https://images.unsplash.com/photo-1503376780353-7e6692767b70?q=80&w=1200&auto=format&fit=crop', 1);
GO