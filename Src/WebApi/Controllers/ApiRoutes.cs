namespace WebApi.Controllers;

public static class ApiRoutes
{
    public const string Root = "api";

    public static class Solicitudes
    {
        public const string Index = $"{Root}/solicitud";

        public const string GetAll = Index;

        public const string Search = $"{Index}/busqueda";

        public const string Create = $"{Index}/crear-solicitud";

        public const string Update = $"{Index}/actualizar-solicitud";
    }

    public static class Estados
    {
        public const string Index = $"{Root}/estado";

        public const string GetAll = Index;
    }
}
