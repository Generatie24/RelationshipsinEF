using System.ComponentModel.DataAnnotations;

namespace OneToManyDemo.Models.ViewModels
{
    public class BoekAuteurViewModel
    {
        [Key]
        public int BoekId { get; set; }
        [Display(Name = "Boek Titel")]
        public string Titel { get; set; }
        [Display(Name = "Auteur Naam")]
        public string AuteurNaam { get; set; }
    }
}
