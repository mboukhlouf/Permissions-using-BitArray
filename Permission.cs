using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PermissionsWithBitArray
{
    public class Permission
    {
        private enum PermissionValue
        {
            ListSuppliers,
            GetSupplier,
            AddSupplier,
            UpdateSupplier,

            ListUsers,
            GetUser,
            AddUser,
            UpdateUser
        }

        private static int PermissionValuesCount { get; } = Enum.GetValues(typeof(PermissionValue)).Length;

        #region Suppliers

        public static Permission ListSuppliers { get; } = new Permission(PermissionValue.ListSuppliers);

        public static Permission GetSupplier { get; } = new Permission(PermissionValue.GetSupplier);

        public static Permission AddSupplier { get; } = new Permission(PermissionValue.AddSupplier);

        public static Permission UpdateSupplier { get; } = new Permission(PermissionValue.UpdateSupplier);

        public static Permission Supplier { get; } = ListSuppliers | GetSupplier | AddSupplier | UpdateSupplier;

        #endregion

        #region Users
        public static Permission ListUsers { get; } = new Permission(PermissionValue.ListUsers);

        public static Permission GetUser { get; } = new Permission(PermissionValue.GetUser);

        public static Permission AddUser { get; } = new Permission(PermissionValue.AddUser);

        public static Permission UpdateUser { get; } = new Permission(PermissionValue.UpdateUser);

        public static Permission User { get; } = ListUsers | GetUser | AddUser | UpdateUser;

        #endregion

        public static Permission All { get; } = Supplier | User;

        public static Permission operator |(Permission left, Permission right)
        {
            var permission = new Permission(left);
            permission.Or(right);
            return permission;
        }

        public static Permission operator &(Permission left, Permission right)
        {
            var permission = new Permission(left);
            permission.And(right);
            return permission;
        }

        private readonly BitArray bitArray;

        public Permission()
        {
            bitArray = new BitArray(PermissionValuesCount);
        }

        public Permission(Permission permission)
        {
            bitArray = new BitArray(permission.bitArray);
        }

        private Permission(PermissionValue permissionValue) : this()
        {
            bitArray.Set((int)permissionValue, true);
        }

        public Permission Or(Permission value)
        {
            bitArray.Or(value.bitArray);
            return this;
        }

        public Permission And(Permission value)
        {
            bitArray.And(value.bitArray);
            return this;
        }

        public bool Has(Permission value)
        {
            for (int i = 0; i < bitArray.Count; i++)
            {
                if (value.bitArray.Get(i) && bitArray.Get(i) != value.bitArray.Get(i))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
