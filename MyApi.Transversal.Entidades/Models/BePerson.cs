namespace MyApi.Transversal.Entidades
{
    public class BePerson
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public int? State { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Token { get; set; }
    }
}
