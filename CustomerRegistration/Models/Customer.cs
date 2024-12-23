using System.ComponentModel.DataAnnotations;

namespace CustomerRegistration.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "O tamanho máximo é 150 caracteres")]
        public string Name { get; set; }
        [Required]
        [EmailAddress()]
        public string Email { get; set; }
        public byte[] Logo { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
