namespace ReactCore.Models
{
    public class Roles
    {
        public int _RolId { get; set; }
        public string _RolName { get; set; }
        public int _RolStatus { get; set; }

        public Roles(int RolId, string RolName, int RolStatus)
        {
            _RolId = RolId;
            _RolName = RolName;
            _RolStatus = RolStatus;
        }
    }
}
