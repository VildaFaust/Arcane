using System;

namespace Server.ServerCore.Models.User
{
    [Flags]
    public enum UserType
    {
        Guest = 1,
        Parent = 2,
        Student = 4,
        Schoolboy = 8,
        Teacher = 16,
        Moderator = 32,
        Admin = 64,
        ContentMaker = 128,
        Redactor = 256
    }
}