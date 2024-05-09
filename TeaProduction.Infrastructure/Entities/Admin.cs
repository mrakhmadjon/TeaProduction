namespace TeaProduction.Infrastructure.Entities
{
    internal class Admin : User
    {
        public string Department { get; set; }
        public bool CanManageUsers { get; set; } = false;

    }
}
