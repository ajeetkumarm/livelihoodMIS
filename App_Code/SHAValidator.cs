using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SHAValidator
/// </summary>
public class SHAValidator
{
    public static string SHAValid(string password)
    {
        string Digest = string.Empty;
        string input = password;
        byte[] hashedDataBytes = null;

        System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();

        System.Security.Cryptography.SHA256CryptoServiceProvider SHA256Hasher = new System.Security.Cryptography.SHA256CryptoServiceProvider();

        hashedDataBytes = SHA256Hasher.ComputeHash(encoder.GetBytes(input));
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        byte outputByte = 0;

        foreach (byte outputByte_loopVariable in hashedDataBytes)
        {
            outputByte = outputByte_loopVariable;
            sb.Append(outputByte.ToString("x2").ToUpper());

        }
        return sb.ToString().ToLower();
    }
}
