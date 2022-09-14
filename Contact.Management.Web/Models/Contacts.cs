using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contact.Management.Web.Models
{

    public class Contacts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [Display(Name = "E-Mail address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid format E-mail")]
        public string EmailAddress { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Contact")]
        [StringLength(9, ErrorMessage = "The contact should be 9 digits.", MinimumLength = 9)]
        public string Contact { get; set; }


    }
}
