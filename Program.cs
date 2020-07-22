using System;

namespace PermissionsWithBitArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Role adminRole = new Role("Admin", Permission.All);
            Role usersManagerRole = new Role("Users Manager", Permission.ListUsers | Permission.AddUser);
            
            System.Console.WriteLine($"Admin has permission to List Users?: {adminRole.HasPermission(Permission.ListUsers)}.");
            System.Console.WriteLine($"Admin has permission to Update a Supplier?: {adminRole.HasPermission(Permission.UpdateSupplier)}.");

            System.Console.WriteLine($"Users Manager has permission to Add a Supplier?: {usersManagerRole.HasPermission(Permission.AddSupplier)}.");
            System.Console.WriteLine($"Users Manager has permission to List Users?: {usersManagerRole.HasPermission(Permission.ListUsers)}.");
            System.Console.WriteLine($"Users Manager has permission to List Users and Add a User?: {usersManagerRole.HasPermission(Permission.ListUsers | Permission.AddUser)}.");
        }
    }
}
