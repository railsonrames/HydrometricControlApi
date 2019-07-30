using System;

namespace HydrometricControl.Data.Models
{

    public class FiltroLeituraData
    {

        public Guid? IdCondominio { get; set; }
        public Guid? IdUnidade { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

    }

}
