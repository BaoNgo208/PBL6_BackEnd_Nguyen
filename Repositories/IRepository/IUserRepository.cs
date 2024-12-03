using PBL6.Dto;
using PBL6_QLBH.Models;

namespace PBL6.Repositories.IRepository
{
    public interface IUserRepository
    {
        public Task<Review> createReview(Review newReview);
        Task<User1Dto> GetUserByUsername(string username);
        Task<User> GetUserByUsernameAsync(string username);
        Task<UserInfo> GetUserInfoByUserIdAsync(Guid userId);
        Task UpdateUserInfoAsync(UserInfo userInfo);
        Task UpdateUserAsync(User user);
    }
}
