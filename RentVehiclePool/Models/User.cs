namespace RentVehiclePool.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string UserLogin { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        // roleID
        public int RoleId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }


        public Role Role { get; set; }
    }
}
