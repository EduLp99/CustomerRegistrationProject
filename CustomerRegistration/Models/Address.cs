using System.ComponentModel.DataAnnotations;

namespace CustomerRegistration.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "O tamanho máximo é 150 caracteres")]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Cep { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
