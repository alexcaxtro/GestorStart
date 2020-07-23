using System;
using System.Collections.Generic;
using System.Text;

namespace GestorStart.Models
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Response
    {
        public string status { get; set; }
        public int userid { get; set; }
        public string message { get; set; }

    }

    public class Root
    {
        public Response response { get; set; }

    }


}
