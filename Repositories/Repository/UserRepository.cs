using Microsoft.EntityFrameworkCore;
using PBL6.Repositories.IRepository;
using PBL6_QLBH.Data;
using PBL6_QLBH.Models;
using Microsoft.AspNetCore.Mvc;
using PBL6.Dto;

namespace PBL6.Repositories.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Review> createReview(Review newReview)
        {
            newReview.ReviewId = new Guid();
            newReview.UserId = Guid.Parse("d4e56743-ff2c-41d3-957d-576e9f574c5d");
            newReview.ReviewDate = DateTime.Now;

            var result = await _context.Reviews.AddAsync(newReview);
            await _context.SaveChangesAsync();

            return await _context.Reviews
            .Include(r => r.Product)
            .Include(r => r.User)
            .FirstOrDefaultAsync(r => r.ReviewId == result.Entity.ReviewId);
        }

        public async Task<User1Dto> GetUserByUsername(string username)
        {
            var user = await _context.Users
                .Where(u => u.Username == username)
                .Select(u => new User1Dto
                {
                    UserName = u.Username,
                    Email = u.Email,
                    FirstName = u.UserInfo.FirstName,
                    LastName = u.UserInfo.LastName,
                    Address = u.UserInfo.Address,
                    PhoneNumber = u.UserInfo.PhoneNumber,
                    Gender = u.UserInfo.Gender,
                    PasswordHash = u.PasswordHash
                })
                .FirstOrDefaultAsync();

            return user;
        }
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<UserInfo> GetUserInfoByUserIdAsync(Guid userId)
        {
            return await _context.UserInfos.FirstOrDefaultAsync(ui => ui.UserId == userId);
        }

        public async Task UpdateUserInfoAsync(UserInfo userInfo)
        {
            _context.UserInfos.Update(userInfo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }


    }
}
