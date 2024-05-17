using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneToManyDemo.Models
{
    public class Boek
    {
        [Key]
        public int BoekId { get; set; }
        public string Titel { get; set; }

        [ForeignKey("Auteur")]
        public int AuteurId { get; set; }
        public Auteur Auteur { get; set; }
    }
}
