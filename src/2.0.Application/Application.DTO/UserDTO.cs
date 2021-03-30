namespace Application.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        
        public string TaxNumber { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public byte EnumRole { get; set; }

        public string Role { get; set; }

        public int ClinicalUnitId { get; set; }
    }
}