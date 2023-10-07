namespace MyApi.Transversal.Entidades
{
    public class CustomSettings
    {
        public string RutaArchivosServer { get; set; }
        public string SuSaludConnection { get; set; }
        public bool EnviarCorreos { get; set; }
        public string JwtIssuer { get; set; }
        public string JwtAudience { get; set; }
        public string JwtKey { get; set; }
    }
}
