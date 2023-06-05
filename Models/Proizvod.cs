using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RestoranJelaRPA.Models
{
    public class Proizvod
    {
        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        [Display(Name = "#")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }


        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        public string Naziv { get; set; }



        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        [DataType(DataType.Currency)]
        public decimal Cijena { get; set; }


        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        [Display(Name = "Poster")]
        public string SlikaUrl { get; set; }



        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        [Display(Name = "Sastojci")]
        public string Sastojci { get; set; }



        [Display(Name = "Kategorija")]
        public int KategorijaId { get; set; }


        public Kategorija Kategorija { get; set; }

    }
}
