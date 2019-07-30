using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HydrometricControl.Data.Entities
{

    [Table("Leitura")]
    public partial class TbLeitura
    {

        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime RealizadaEm { get; set; }
        [Required]
        public int MetrosCubicos { get; set; }
        public int HidrometroAtual { get; set; }
        public int HidrometroAnterior { get; set; }
        [Required]
        [StringLength(140)]
        public string NomeDaImagem { get; set; }
        public string Observacao { get; set; }
        [Required]
        public DateTime DataRegistro { get; set; }
        [Required]
        public bool ExclusaoLogica { get; set; }

        // FK's para as tabelas abaixo
        [ForeignKey("TbUnidade")]
        public Guid IdUnidade { get; set; }
        public TbUnidade TbUnidade { get; set; }
        [ForeignKey("TbImposto")]
        public Guid IdImposto { get; set; }
        public TbImposto TbImposto { get; set; }

    }

}
