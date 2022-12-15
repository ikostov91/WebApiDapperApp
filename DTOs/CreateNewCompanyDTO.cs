namespace WebApiDapperApp.DTOs
{
    public class CreateNewCompanyDTO
    {
        public string Name { get; set; } = default!;

        public string Address { get; set; } = default!;

        public string Country { get; set; } = default!;
    }
}
