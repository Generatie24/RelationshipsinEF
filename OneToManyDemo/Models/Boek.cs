namespace OneToManyDemo.Models
{
    public class Boek
    {
        public int BoekId { get; set; }
        public string Titel { get; set; }
        public int AuteurId { get; set; }
        public Auteur Auteur { get; set; }
    }
}
