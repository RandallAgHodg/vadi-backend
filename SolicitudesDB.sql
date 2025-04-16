-- Eliminar procedimientos almacenados si existen
IF OBJECT_ID('dbo.sp_Solicitudes_ObtenerTodas', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_Solicitudes_ObtenerTodas;
GO

IF OBJECT_ID('dbo.sp_Solicitudes_ObtenerPorSolicitante', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_Solicitudes_ObtenerPorSolicitante;
GO

IF OBJECT_ID('dbo.sp_Solicitudes_Crear', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_Solicitudes_Crear;
GO

IF OBJECT_ID('dbo.sp_Solicitudes_Actualizar', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_Solicitudes_Actualizar;
GO

IF OBJECT_ID('dbo.sp_Estado_ObtenerTodos', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_Estado_ObtenerTodos;
GO

-- Crear procedimientos almacenados
CREATE PROCEDURE sp_Solicitudes_ObtenerTodas
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        s.Id AS id,
        s.Solicitante AS solicitante,
        s.FechaSolicitud AS fechaSolicitud,
        e.Estado AS estado
    FROM dbo.Solicitudes s
    INNER JOIN dbo.Estados e ON s.IdEstado = e.IdEstado;
END;
GO

CREATE PROCEDURE sp_Solicitudes_ObtenerPorSolicitante
    @Solicitante NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        s.Id AS id,
        s.Solicitante AS solicitante,
        s.FechaSolicitud AS fechaSolicitud,
        e.Estado AS estado
    FROM dbo.Solicitudes s
    INNER JOIN dbo.Estados e ON s.IdEstado = e.IdEstado
    WHERE s.Solicitante LIKE '%' + @Solicitante + '%';
END;
GO

CREATE PROCEDURE sp_Solicitudes_Crear
    @Solicitante NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @NextId INT;
    SELECT @NextId = ISNULL(MAX(Id), 0) + 1 FROM dbo.Solicitudes;

    INSERT INTO dbo.Solicitudes
        (Id, Solicitante, FechaSolicitud, IdEstado)
    VALUES
        (@NextId, @Solicitante, GETDATE(), 1);

    SELECT @NextId AS Id;
END;
GO

CREATE PROCEDURE dbo.sp_Solicitudes_Actualizar
    @Id INT,
    @Solicitante NVARCHAR(100),
    @IdEstado INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Solicitudes
    SET 
        Solicitante = @Solicitante,
        FechaSolicitud = GETDATE(), 
        IdEstado = @IdEstado
    WHERE Id = @Id;

    SELECT @Id AS UpdatedId;
END;
GO

CREATE PROCEDURE sp_Estado_ObtenerTodos
AS
BEGIN
    SET NOCOUNT ON;

    SELECT e.IdEstado, e.Estado FROM dbo.Estados e;
END;
GO
