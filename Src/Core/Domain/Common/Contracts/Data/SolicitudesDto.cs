namespace Domain.Common.Contracts.Data;

public sealed record SolicitudDto(int Id, string Solicitante, DateTime FechaSolicitud, string Estado);