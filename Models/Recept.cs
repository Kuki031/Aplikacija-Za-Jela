using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RestoranJelaRPA.Models
{
    public class Recept
    {

        [Display(Name = "#")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje {0} je obvezno.")]

        public string NazivJela { get; set; }
        public string Opis { get; set; }

        public List<Proizvod> Products { get; set; } = new List<Proizvod>();

    }
}
