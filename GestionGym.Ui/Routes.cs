namespace GestionGym.Ui
{
    public static class Routes
    {
        public const string ClienteListado = "/clientes";
        public const string ClienteRegistrar = "/clientes/registro/";

        public const string SuscripcionRegistrar = "/suscripcion/registro";

        public const string Suscripciones = "/suscripciones";

        public const string DetalleSuscripcion = "/suscripciones/detalle/{idSuscripcion:int}";
        public const string DetalleSuscripcionNav = "/suscripciones/detalle";

        public const string ClienteEditarNav = "/clientes/editar/{idCliente:int}";
        public const string ClienteEditar = "/clientes/editar";

        public const string EjerciciosListado = "/Ejercicios";
        public const string EjerciciosRegistrar = "/Ejercicio/registro";
    }

}
