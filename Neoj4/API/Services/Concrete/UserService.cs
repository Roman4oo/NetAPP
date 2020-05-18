using AutoMapper;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Neoj4.API.Data.Abstract;
using Neoj4.API.Data.Models;
using Neoj4.API.Neoj4;
using Neoj4.API.Neoj4.Abstract;
using Neoj4.API.Services.Abstract;
using Neoj4.API.Services.DTO_s;
using Neoj4.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neoj4.API.Services
{
    public class UserService : IUserService
    {
        private readonly IFriendsRepository _friendsRepository;
        private readonly IDBContext _context;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMongoQueryable<User> _users;
        private readonly IMapper _mapper;


        public UserService(IDBContext context, IMapper mapper, IPasswordHasher passwordHasher, IFriendsRepository friendsRepository)
        {
            _friendsRepository = _friendsRepository;
            _context = context;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _users = _context.Users.AsQueryable();
        }

        public async Task<UserDTO> AuthUser(LoginViewModel loginViewModel)
        {
            return _mapper.Map<UserDTO>(
                await _users.FirstOrDefaultAsync(u => u.UserName == loginViewModel.UserName && _passwordHasher.CheckMatch(u.HashedPassword,loginViewModel.Password)));
        }
        
        // TODO
        public async Task AddFriend(string friendLogin)
        {
            var setter = Builders<User>.Update.Push(el => el.Friends, friendLogin);

            await _context.Users.UpdateOneAsync(el => el.Id == User.Id, setter);

            User.Friends.Add(friendLogin);

            await _connectionsRepository.AddFollower(
                _mapper.Map<UserNode>(User),
                _mapper.Map<UserNode>(await AuthUser(friendLogin)));
        }

        public async Task DeleteFriend(string friendLogin)
        {
            var setter = Builders<User>.Update.Pull(el => el.Friends, friendLogin);

            await _context.Users.UpdateOneAsync(el => el.Id == User.Id, setter);

            User.Friends.Remove(friendLogin);

            await _connectionsRepository.RemoveFollower(
                _mapper.Map<UserNode>(User),
                _mapper.Map<UserNode>(await GetUserByLogin(friendLogin)));
        }
        public async Task<ConnectionType> FindConnectionTo(UserDTO user)
        {
            var path = await _friendsRepository.GetConnectingPath(
                _mapper.Map<UserNode>(User),
                _mapper.Map<UserNode>(user),
                length: 3);

            if (path == null)
            {
                return ConnectionType.Other;
            }

            return (ConnectionType)(path.Count() - 1);

        }
}
