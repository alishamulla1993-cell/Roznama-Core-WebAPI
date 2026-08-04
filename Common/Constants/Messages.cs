namespace Roznama.Common.Constants
{
    public static class Messages
    {
        // Auth
        public const string InvalidCredentials = "Invalid username or password.";
        public const string UnauthorizedAccess = "You are not authorized to access this resource.";
        public const string LoginSuccess = "Login successful.";

        // CRUD Generic
        public const string NotFound = "Record not found.";
        public const string Saved = "Record saved successfully.";
        public const string Updated = "Record updated successfully.";
        public const string Deleted = "Record deleted successfully.";
        public const string Failed = "Operation failed. Please try again later.";

        // Notice Module
        public const string NoticeNotFound = "Notice record not found.";
        public const string NoticeAdded = "Notice has been added successfully.";
        public const string NoticeUpdated = "Notice has been updated successfully.";

        // Litigation Module
        public const string LitigationNotFound = "Litigation record not found.";
        public const string LitigationAdded = "Litigation added successfully.";

        // Arbitration Module
        public const string ArbitrationNotFound = "Arbitration record not found.";

        // Filter/Dropdown
        public const string DropdownError = "Unable to load dropdown data.";

        // Validation
        public const string InvalidInput = "Invalid input provided.";
        public const string MissingRequiredFields = "Required field(s) missing.";

        // Server
        public const string ServerError = "Unexpected server error.";
    }
}