using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HydrometricControl.Data.Entities
{

    [Table("Faixa")]
    public partial class TbFaixa
    {

        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(70)]
        public string Nome { get; set; }
        [Required]
        public int Minimo { get; set; }
        [Required]
        public int Maximo { get; set; }
        [Required]
        public int Ordem { get; set; }
        [Required]
        public double Aliquota { get; set; }
        [Required]
        public DateTime DataRegistro { get; set; }
        [Required]
        public bool Ativo { get; set; }
        public bool ExclusaoLogica { get; set; }

        // FK's para as tabelas abaixo
        [ForeignKey("TbImposto")]
        public Guid IdImposto { get; set; }
        public TbImposto TbImposto { get; set; }

    }

}
