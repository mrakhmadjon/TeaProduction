namespace TeaProduction.Infrastructure.Entities
{
    public class Admin : User
    {
        public string Department { get; set; }
        public bool CanManageUsers { get; set; } = false;

    }
}
