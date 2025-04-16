namespace Domain.Common.Contracts.Response;

public sealed record SolicitudResponse(int Id, string Solicitante, DateTime FechaSolicitud, string Estado);
