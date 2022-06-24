using API.DTO;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using API.Migrations;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class LikesRepository : ILikesRepository
{
    private readonly DataContext _context;

    public LikesRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<AppUserLike> GetUserLike(int sourceUserId, int likedUserId)
    {
        return await _context.UserLikes.FindAsync(sourceUserId, likedUserId);
    }

    public async Task<AppUser> GetUserWithLikes(int userId)
    {
        return await _context.Users
            .Include(x => x.Likes)
            .FirstOrDefaultAsync(x => x.Id == userId);
    }

    public async Task<IEnumerable<LikeDto>> GetUserLikes(string predicate, int userId)
    {
        var users = _context.Users.OrderBy(u => u.UserName).AsQueryable();
        var likes = _context.UserLikes.AsQueryable();

        if (predicate == "liked")
        {
            likes = likes.Where(l => l.SourceUserId == userId);
            users = likes.Select(l => l.LikedUser);
        }

        if (predicate == "likedBy")
        {
            likes = likes.Where(l => l.LikedUserId == userId);
            users = likes.Select(l => l.SourceUser);
        }

        return await users.Select(u => new LikeDto
        {
            Username = u.UserName,
            KnownAs = u.KnownAs,
            Age = u.DateOfBirth.CalculateAge(),
            PhotoUrl = u.Photos.FirstOrDefault(p => p.IsMain).Url,
            City =  u.City,
            Id = u.Id,
        }).ToListAsync();
    }
}