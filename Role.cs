using System;
using System.Collections.Generic;
using System.Text;

namespace PermissionsWithBitArray
{
    public class Role
    {
        private readonly string name;
        private readonly Permission permissions;
        
        internal Role(string name, Permission permissions)
        {
            this.name = name;
            this.permissions = permissions;
        }

        public string Name => name;

        public Permission Permissions => permissions;

        public bool HasPermission(Permission permission)
        {
            return permissions.Has(permission);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
