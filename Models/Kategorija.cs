using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RestoranJelaRPA.Models
{
    public class Kategorija
    {
        [Display(Name = "#")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        public string Naziv { get; set; }

        public List<Proizvod> Products { get; set; } = new List<Proizvod>();
    }

}

