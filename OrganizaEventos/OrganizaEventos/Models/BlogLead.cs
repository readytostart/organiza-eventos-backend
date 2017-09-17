using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganizaEventosApi.Models {
    [Table("BlogLead")]
    public class BlogLead {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome completo deve ser informado")]
        [StringLength(150, MinimumLength = 2)]
        [Column("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "o e-mail deve ser informado")]
        [StringLength(150, MinimumLength = 2)]
        [Column("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A data deve ser informada")]
        [Column("Data")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O IPv4 deve ser informado")]
        [StringLength(15, MinimumLength = 3)]
        [Column("IpV4")]
        public string IpV4 { get; set; }
    }
}