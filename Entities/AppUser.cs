using Microsoft.AspNetCore.Identity;

namespace API.Entities {
    public class AppUser : IdentityUser<int> {
        public DateTime DateOfBirth { get; set; }
        
        public DateTime CreationDate { get; set; } = DateTime.Now;
        
        public DateTime LastActive { get; set; } = DateTime.Now;
        
        public string? Gender { get; set; }
        
        public string? KnownAs { get; set; }
        
        public string? Introduction { get; set; }
        
        public string? LookingFor { get; set; }
        
        public string? Interests { get; set; }
        
        public string? City { get; set; }
        
        public string? Country { get; set; }
        
        public ICollection<Photo> Photos { get; set; }
        
        public ICollection<AppUserLike> LikedBy { get; set; }
        public ICollection<AppUserLike> Likes { get; set; }
        
        public ICollection<Message> MessagesSent { get; set; }
        public ICollection<Message> MessagesRecived { get; set; }
        
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}