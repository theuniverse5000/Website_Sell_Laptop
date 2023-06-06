
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class User
    {
        // /^[a-zA-Z0-9]+$/
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        [RegularExpression("^[0-9\\-\\+]{9,15}$")]
        public string PhoneNumber { get; set; }

        [MinLength(7, ErrorMessage = "User phải dài hơn 6 kí tự")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Chỉ được chứa kí tự chữ hoặc số")]
        public string Username { get; set; }

        [MinLength(7, ErrorMessage = "Password phải dài hơn 6 kí tự")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Chỉ được chứa kí tự chữ hoặc số")]
        public string Password { get; set; }

        public int Status { get; set; }
        public Guid IdRole { get; set; }
        public virtual Role Role { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }

    }
}
