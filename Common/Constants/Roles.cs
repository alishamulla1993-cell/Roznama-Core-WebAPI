namespace Roznama.Common.Constants
{
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string Support = "Support";
        public const string User = "User";
        public const string Manager = "Manager";
        public const string Reviewer = "Reviewer";
        // Combined Roles
        public const string All =
            Admin + "," +
            Support + "," +
            User + "," +
            Manager + "," +
            Reviewer;
    }
}