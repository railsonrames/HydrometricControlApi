using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HydrometricControl.Data.Entities
{

    [Table("LeituraGeral")]
    public partial class TbLeituraGeral
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public int MetrosCubicos { get; set; }
        [Required]
        [Column(TypeName = "decimal(7,2)")]
        public decimal Valor { get; set; }
        [Required]
        public DateTime DataRealizacao { get; set; }
        [Required]
        public DateTime DataRegistro { get; set; }
        public bool ExclusaoLogica { get; set; }

        //FK's para as tabelas abaixo
        [ForeignKey("TbCondominio")]
        public Guid IdCondominio { get; set; }
        public TbCondominio TbCondominio { get; set; }

    }

}
