namespace dotnetEjercicio1.Models.DataModels
{
    public class JwtSettings
    {
        public bool ValidateIssuerSigningKey { get; set; }
        public string? IssuerSigningKey { get; set; }

        public bool ValidateIssuer { get; set; } = true;
        public string? ValidIssuer { get; set; }

        public bool ValidateAudience { get; set; } = true;
        public string? ValidAudice { get; set; }

        public bool RequireExpiretionTime { get; set; }
        public bool ValidateLifeTime { get; set; } = true;
    }
}
