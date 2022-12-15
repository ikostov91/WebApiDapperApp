namespace WebApiDapperApp.Entities
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string Address { get; set; } = default!; 

        public string Country { get; set; } = default!;

        public List<Employee> Employees { get; set; } = new();
    }
}
