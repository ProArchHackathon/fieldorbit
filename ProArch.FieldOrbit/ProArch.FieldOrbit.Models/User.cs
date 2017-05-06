using ProArch.FieldOrbit.Models.Enums;

namespace ProArch.FieldOrbit.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public EmployeeType Type { get; set; }
        public int EmployeeId { get; set; }
    }
}
