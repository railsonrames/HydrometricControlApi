using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HydrometricControl.Data.Entities
{

    [Table("Condominio")]
    public partial class TbCondominio
    {

        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(70)]
        public string Nome { get; set; }
        [Required]
        [StringLength(140)]
        public string Endereco { get; set; }
        [Required]
        [StringLength(10)]
        public string Cep { get; set; }
        [Required]
        [StringLength(100)]
        public string Responsavel { get; set; }
        [StringLength(11)]
        public string Telefone { get; set; }
        [Required]
        [StringLength(14)]
        public string Cnpj { get; set; }
        public bool Ativo { get; set; }
        [Required]
        public DateTime DataRegistro { get; set; }
        [Required]
        public bool ExclusaoLogica { get; set; }

        // Tabelas que tem FK's da entidade TbCondominio
        public IEnumerable<TbUnidade> TbUnidade { get; set; }
        public IEnumerable<TbConsumo> TbConsumo { get; set; }
        public IEnumerable<TbLeituraGeral> TbLeituraGeral { get; set; }

    }

}
