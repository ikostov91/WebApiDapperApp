namespace WebApiDapperApp.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public int Age { get; set; }

        public string Position { get; set; } = default!;

        public int CompanyId { get; set; }
    }
}
