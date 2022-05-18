using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Models
{
    public class ModelAtendimento
    {
        public string codAtendimento { get; set; }
        public string DataAtendimento { get; set; }
        public string HoraAtendimento { get; set; }
        public string codAnimal { get; set; }
        public string codVet { get; set; }
        public string confAgendamento { get; set; }

    }
}