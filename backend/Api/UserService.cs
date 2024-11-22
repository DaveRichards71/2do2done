//using BCrypt.Net;

//public class UserService
//{
//    public void RegisterUser(string email, string password)
//    {
//        var hashedPassword = BCrypt.HashPassword(password);
//        // Store email and hashedPassword in the database
//    }

//    public bool ValidateUser(string email, string password)
//    {
//        // Retrieve the stored hashed password from the database
//        var storedHashedPassword = GetStoredHashedPassword(email);
//        return BCrypt.Verify(password, storedHashedPassword);
//    }

//    private string GetStoredHashedPassword(string email)
//    {
//        // Retrieve the hashed password from the database
//        // This is just a placeholder implementation
//        return "stored_hashed_password";
//    }
//}
