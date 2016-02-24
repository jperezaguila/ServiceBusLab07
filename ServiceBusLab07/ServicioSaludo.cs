using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceBusLab07
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioSaludo" in both code and config file together.
    public class ServicioSaludo : IServicioSaludo
    {

        private Dictionary<String, String> Saludos = new Dictionary<string, string>()
        {
            {"Español", "Buenos días"},
            {"Ingles", "Good morning"},
            {"Frances", "Bon jour"},
            {"Aleman", "Guten morgen"}
        };

      
        public string GetSaludo(string idioma)
        {
            if (Saludos.ContainsKey(idioma))
                return Saludos[idioma];
            return "idioma no disponible";

        }

        public void Dispose()
        {
            
        }
    }
}
