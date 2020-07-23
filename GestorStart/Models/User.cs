namespace GestorStart.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class User
    {
        [JsonProperty("error")]
        public bool Error { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("UsuarioId")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long UsuarioId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }
}
