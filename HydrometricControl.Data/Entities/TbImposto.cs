using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HydrometricControl.Data.Entities
{

    [Table("Imposto")]
    public partial class TbImposto
    {

        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(40)]
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        [Required]
        public DateTime DataRegistro { get; set; }
        [Required]
        public bool ExclusaoLogica { get; set; }

        // Tabelas que tem FK's da entidade TbImposto
        public ICollection<TbFaixa> TbFaixa { get; set; }
        public ICollection<TbConsumo> TbConsumo { get; set; }
        public ICollection<TbLeitura> TbLeitura { get; set; }

    }

}
