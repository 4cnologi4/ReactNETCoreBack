using System;

namespace ReactCore.Models
{
    public class Users
    {
        public int _UserId { get; set; }
        public string _UserName { get; set; }
        public string _LastName { get; set; }
        public DateTime _DischargeDate { get; set; }
        public int _Age { get; set; }
        public int _RolId { get; set; }
        public string _RolName { get; set; }
        public int _Status { get; set; }
        public Users(int UserId, string UserName, string LastName, DateTime DischargeDate, int Age, int RolId, int Status)
        {
            _UserId = UserId;
            _UserName = UserName;
            _LastName = LastName;
            _DischargeDate = DischargeDate;
            _Age = Age;
            _RolId = RolId;
            _Status = Status;
        }
    }
}
