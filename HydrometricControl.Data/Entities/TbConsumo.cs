using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HydrometricControl.Data.Entities
{

    [Table("Consumo")]
    public partial class TbConsumo
    {

        [Key]
        public Guid Id { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public double ValorExcedente { get; set; }
        public int VolumeExcedente { get; set; }
        [Required]
        public DateTime DataRegistro { get; set; }
        [Required]
        public bool ExclusaoLogica { get; set; }

        // FK's para as tabelas abaixo
        [ForeignKey("TbImposto")]
        public Guid IdImposto { get; set; }
        public TbImposto TbImposto { get; set; }
        [ForeignKey("TbCondominio")]
        public Guid IdCondominio { get; set; }
        public TbCondominio TbCondominio { get; set; }

    }
}
