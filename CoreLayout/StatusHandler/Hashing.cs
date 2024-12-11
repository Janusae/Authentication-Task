using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


public class PasswordHasher
{
    // Method to hash the password
    public static string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            // Convert the password string to a byte array
            byte[] byteData = Encoding.UTF8.GetBytes(password);

            // Compute the hash
            byte[] hashedData = sha256.ComputeHash(byteData);

            // Convert the hash to a hexadecimal string and return
            StringBuilder hexString = new StringBuilder();
            foreach (byte b in hashedData)
            {
                hexString.Append(b.ToString("x2"));
            }

            return hexString.ToString();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        string password = "your_password"; // Example password
        string hashedPassword = PasswordHasher.HashPassword(password);
        Console.WriteLine("Hashed Password: " + hashedPassword);
    }
}
