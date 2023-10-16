﻿using GenMax.Database.EntityModel;
using System.Collections.Generic;

namespace GenMax.Database.Interface
{
    public interface IRoleService
    {
        List<Role> GetRoles();
        bool AddRole(Role role);
        bool RemoverRole(Role role);
        bool UpdateRole(Role role);
        Role GetRoleById(int id);
        Role GetRoleByRoleName(string rolename);
    }
}
