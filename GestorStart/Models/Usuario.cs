namespace GestorStart.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Usuario
    {
        [JsonProperty("UsuarioId")]
        public long UsuarioId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }
}
