using Data.Models;

namespace Data.Models.ViewModels
{
    public class UserView
    {
        public Guid Id { get; set; }

        public string Username { get; set; }


        public string Password { get; set; }

        public int Status { get; set; }
        public Guid IdRole { get; set; }
        public string RoleName { get; set; }

        public virtual Role Role { get; set; }


        public virtual Cart Cart { get; set; }



        public virtual ICollection<Bill> Bills { get; set; }

    }
}
