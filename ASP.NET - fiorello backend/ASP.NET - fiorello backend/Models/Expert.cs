namespace ASP.NET___fiorello_backend.Models
{
    public class Expert : BaseEntity
    {
        public string Image { get; set; }
        public string FullName { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
