﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PBL6.Dto;
using PBL6.Repositories.IRepository;
using PBL6.Repositories.Repository;
using PBL6.Services.IService;
using PBL6_QLBH.Models;
using System.Drawing;

namespace PBL6.Services.Service
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _userRepository.GetUserByUsernameAsync(username);
        }

        public async Task<ReviewDto> createReview(Review review)
        {
            var createdReview = await _userRepository.createReview(review);
            return _mapper.Map<ReviewDto>(createdReview);
        }
        public async Task<User1Dto> GetUser(string username)
        {
            var user = await _userRepository.GetUserByUsername(username);
            return _mapper.Map<User1Dto>(user);

        }
        public async Task<bool> UpdateUserInfoByUsernameAsync(string username, UpdateUserDto updatedInfo)
        {
            // Tìm User dựa trên Username
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null) return false;

            // Tìm UserInfo dựa trên UserId
            var userInfo = await _userRepository.GetUserInfoByUserIdAsync(user.UserId);
            if (userInfo == null) return false;

            // Cập nhật thông tin
            userInfo.Address = updatedInfo.Address ?? userInfo.Address;
            userInfo.PhoneNumber = updatedInfo.PhoneNumber ?? userInfo.PhoneNumber;
            userInfo.FirstName = updatedInfo.FirstName ?? userInfo.FirstName;
            userInfo.LastName = updatedInfo.LastName ?? userInfo.LastName;
            userInfo.Gender = updatedInfo.Gender;

            // Lưu thay đổi
            await _userRepository.UpdateUserInfoAsync(userInfo);
            return true;
        }
        public async Task<bool> UpdateUserAsync(string username, string password, string email)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null)
            {
                return false; // Không tìm thấy user
            }

            // Cập nhật thông tin
            user.PasswordHash = password;
            user.Email = email;

            // Lưu thay đổi
            await _userRepository.UpdateUserAsync(user);
            return true;
        }

    }
}
