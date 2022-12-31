using Microsoft.AspNetCore.Identity;

namespace LMS.Models
{

    public class UserBook
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Books Books { get; set; }

        public int UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
