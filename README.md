# Permissions-using-BitArray

I was using Enum and Flags for Permissions before, but then it got ugly
when there are many permissions, plus it's limited to 32 or 64 permissions.
Then I discovered that it's possible with BitArray, a bit per permission,
and also be able to have an unlimited number of permissions.

You can have use Bitwise Or | on permissions, for example the permission to be able
to display users and add a user: Permission.ListUsers | Permission.AddUser

Output of the example program:
```console
Admin has permission to List Users?: True.
Admin has permission to Update a Supplier?: True.
Users Manager has permission to Add a Supplier?: False.
Users Manager has permission to List Users?: True.
Users Manager has permission to List Users and Add a User?: True.
```