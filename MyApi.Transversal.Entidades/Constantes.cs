namespace MyApi.Transversal.Entidades
{

    public enum TipoObservacion
    {
        Solicitud = 1,
        Documento = 2,
        Preexistencia = 3,
        Procedimiento = 4,
    }

    public enum TipoParentesco
    {
        Titular = 1,
        Conyuge = 2,
        Hijo = 3,
        Padre = 4
    }

    public enum TipoAfiliado
    {
        Contratante = 1,
        Titular = 2,
        Beneficiario = 3,
    }

    public enum TipoDeclaracion
    {
        Preexistencia = 1,
        Procedimiento = 2,
    }

    public enum EstadoPlan
    {
        Vigente = 1,
    }

    public enum TipoAporte
    {
        Copago = 1,
        PorEdad = 2,
        GrupoFamiliar = 3,
    }

    public enum TipoSolicitud
    {
        NuevaAfiliacion = 1,
        InclusionDependientes = 2,
        CambioPlan = 3,
        Desafiliacion = 4,
    }

    public enum EstadoSolicitud
    {
        Pendiente = 1,
        EnTramite = 2,
        Aceptado = 3,
        Observado = 4,
        Aprobado = 5,
        Rechazado = 6,
    }

    public enum Genero
    {
        Masculino = 1,
        Femenino = 2
    }

    public enum CanalCaptacion
    {
        Back = 1,
        Front = 2
    }

    public enum TipoMedioInformacion
    {
        Web = 1,
        Llamada = 2,
        Otros = 3
    }
}
