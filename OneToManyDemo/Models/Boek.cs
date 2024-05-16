using System.ComponentModel.DataAnnotations.Schema;

namespace OneToManyDemo.Models
{
    public class Boek
    {
        public int BoekId { get; set; }
        public string Titel { get; set; }

        [ForeignKey("Auteur")]
        public int AuteurId { get; set; }
        public Auteur Auteur { get; set; }
    }
}
