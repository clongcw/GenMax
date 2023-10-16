﻿using GenMax.Database.DbContext;
using GenMax.Database.EntityModel;
using GenMax.Database.Interface;
using System;
using System.Collections.Generic;

namespace GenMax.Database.Service
{
    public class UserService : IUserService
    {
        private readonly UserDbContext _context;

        public UserService(UserDbContext dbContext)
        {
            _context = dbContext;
        }

        public bool AddUser(User user)
        {
            var ur = _context.UserDb.Context.Queryable<User>()
                .Where(s => s.Name == user.Name)
                .First();

            if (ur == null)
            {
                _context.UserDb.Insert(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckPassword(string name)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            return _context.Db.Queryable<User>()
                            .Where(p => p.Id == id)
                            .Includes(t => t.Role, s => s.Privileges)
                            .First();
        }

        public User GetUserByName(string name)
        {
            return _context.Db.Queryable<User>()
                            .Where(p => p.Name == name)
                            .Includes(t => t.Role, s => s.Privileges)
                            .First();

        }

        public List<User> GetUsers()
        {
            return _context.UserDb.Context.Queryable<User>()
                .Includes(t => t.Role, t => t.Privileges)
                .OrderBy(t => t.Id)
                .ToList();
        }

        public bool RemoverUser(User user)
        {
            return _context.UserDb.Context.Deleteable(user)
                .ExecuteCommand() > 0;
        }

        public bool UpdatePassword(User user, string strPassword, bool isReset)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user)
        {

            return _context.UserDb.Context.UpdateNav(user)
                .Include(s => s.Role)
                .ThenInclude(s => s.Privileges)
                .ExecuteCommand();
        }

        public bool UpdateUser()
        {
            throw new NotImplementedException();
        }
    }
}
