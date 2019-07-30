using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HydrometricControl.Data.Entities
{

    [Table("Unidade")]
    public partial class TbUnidade
    {

        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(12)]
        public string Numero { get; set; }
        [StringLength(6)]
        public string Hidrometro { get; set; }
        [Required]
        [StringLength(70)]
        public string Responsavel { get; set; }
        [Required]
        [StringLength(11)]
        public string Cpf { get; set; }
        [Required]
        [StringLength(11)]
        public string Telefone { get; set; }
        [StringLength(140)]
        public string Email { get; set; }
        public bool Ativo { get; set; }
        [Required]
        public DateTime DataRegistro { get; set; }
        [Required]
        public bool ExclusaoLogica { get; set; }

        // FK's para as tabelas abaixo
        [ForeignKey("TbCondominio")]
        public Guid IdCondominio { get; set; }
        public TbCondominio TbCondominio { get; set; }

        // Tabelas que tem FK's da entidade TbUnidade
        public ICollection<TbLeitura> TbLeitura { get; set; }

    }

}
