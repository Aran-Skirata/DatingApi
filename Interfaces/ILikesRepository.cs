using API.DTO;
using API.Entities;

namespace API.Interfaces;

public interface ILikesRepository
{
    Task<AppUserLike> GetUserLike(int sourceUserId, int likedUserId);

    Task<AppUser> GetUserWithLikes(int userId);

    Task<IEnumerable<LikeDto>> GetUserLikes(string predicate, int userId);
}