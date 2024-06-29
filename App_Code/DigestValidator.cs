using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for DigestValidator
/// </summary>

public class DigestValidator
{
    /// <summary>
    ///     ''' Helps to create a digest of the querystring, and provides function to verify the querystring hasn't been tampered with
    ///     ''' </summary>
    ///     ''' <remarks></remarks>
    // Dim SecretSalt As String = "AB@34_B69ctyJ2980^eR21"
    private string SecretSalt = WebConfigurationManager.AppSettings.Get("saltkey");
    private bool authenticatedParam = false;
    public string GetDigest(string tamperProofParams)
    {
        string Digest = string.Empty;
        string input = string.Concat(SecretSalt, tamperProofParams, SecretSalt);

        // The array of bytes that will contain the encrypted value of input
        byte[] hashedDataBytes;

        // The encoder class used to convert strPlainText to an array of bytes
        System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();

        // Create an instance of the MD5CryptoServiceProvider class
        System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();

        // Call ComputeHash, passing in the plain-text string as an array of bytes
        // The return value is the encrypted value, as an array of bytes
        hashedDataBytes = md5Hasher.ComputeHash(encoder.GetBytes(input));

        // Base-64 Encode the results and strip off ending '==', if it exists
        Digest = Convert.ToBase64String(hashedDataBytes).TrimEnd("=".ToCharArray());

        return Digest;
    }

    // Public Function CreateTamperProofURL(ByVal url As String, ByVal nonTamperProofParams As String, _
    // ByVal tamperProofParams As String) As String
    // Dim tpURL As String = url
    // If nonTamperProofParams.Length > 0 OrElse tamperProofParams.Length > 0 Then
    // url &= "?"
    // End If

    // 'Add on the tamper & non-tamper proof parameters, if any
    // If nonTamperProofParams.Length > 0 Then
    // url &= nonTamperProofParams

    // If tamperProofParams.Length > 0 Then url &= "&"
    // End If

    // If tamperProofParams.Length > 0 Then url &= tamperProofParams

    // 'Add on the tamper-proof digest, if needed
    // If tamperProofParams.Length > 0 Then
    // url &= String.Concat("&Digest=", GetDigest(tamperProofParams))
    // End If

    // Return url
    // End Function

    public string CreateTamperProofURL(string tamperProofParams)
    {
        string url;
        url = "";


        // Add on the tamper-proof digest, if needed
        if (tamperProofParams.Length > 0)
            url = string.Concat("&Digest=", GetDigest(tamperProofParams));
        //url = string.Concat(tamperProofParams, url);
        return url;
    }
    /// <summary>
    ///     ''' This function helps ensure that the querystring of the current request has not been tampered with.
    ///     ''' </summary>
    ///     ''' <param name="tamperProofParams">All the parameters as name value pairs passed in the querystring.A name and value must be separated using equals to(=) and each name value pair must be separated by an ampersand</param>
    ///     ''' <returns>True if the querystring has not been tampered with and False otherwise</returns>
    ///     ''' <remarks>This function can only be used if 'CreateTamperProofUrl' was used to create the link. The function creates a new digest based on the 'tamperProofParams' and compares it with the Digest present in the querystring</remarks>
    public bool EnsureURLNotTampered(string tamperProofParams)
    {
        // Determine what the digest SHOULD be
        string expectedDigest = GetDigest(tamperProofParams);

        // Any + in the digest passed through the querystring would be
        // convereted into spaces, so 'uncovert' them
        string receivedDigest = System.Web.HttpContext.Current.Request.QueryString["Digest"];
        if (receivedDigest == null)
            // Oh my, we didn't get a Digest!
            authenticatedParam = false;
        else
        {
            receivedDigest = receivedDigest.Replace(" ", "+");
            // Now, see if the received and expected digests match up
            if (string.Compare(expectedDigest, receivedDigest) != 0)
                authenticatedParam = false;
            else
                authenticatedParam = true;
        }
        return authenticatedParam;
    }
    public string GetHexHash(string key, string dynSalt = null)
    {
        string Digest = string.Empty;
        string Salt_P = "AC_@94_B69ctXu5980^F";
        if (dynSalt != null)
            Salt_P += dynSalt;
        string input = string.Concat(Salt_P, key, Salt_P);

        // The array of bytes that will contain the encrypted value of input
        byte[] hashedDataBytes;

        // The encoder class used to convert strPlainText to an array of bytes
        System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();

        // Create an instance of the MD5CryptoServiceProvider class
        System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();

        // Call ComputeHash, passing in the plain-text string as an array of bytes
        // The return value is the encrypted value, as an array of bytes
        hashedDataBytes = md5Hasher.ComputeHash(encoder.GetBytes(input));
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //byte outputByte1;
        foreach (byte outputByte1 in hashedDataBytes)

            // convert each byte to a Hexadecimal upper case string
            sb.Append(outputByte1.ToString("x2").ToUpper());
        return sb.ToString().ToLower();
    }
    public static string ency_pwd(string PWD)
    {
        string Digest = string.Empty;
        string input = PWD;
        byte[] hashedDataBytes;
        System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
        System.Security.Cryptography.SHA256CryptoServiceProvider sha256 = new System.Security.Cryptography.SHA256CryptoServiceProvider();
        hashedDataBytes = sha256.ComputeHash(encoder.GetBytes(input));
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        foreach (byte outputByte in hashedDataBytes)
            sb.Append(outputByte.ToString("x2").ToUpper());
        return sb.ToString().ToLower();
    }

    public string Encode(string str)
    {
        // Dim EncodedString As String = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(EncodedString))
        string EncodedString = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(str));
        return EncodedString;
    }
    public string Decode(string str)
    {
        // Dim DecodedString As String = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(str))
        string DecodedString = System.Text.Encoding.ASCII.GetString(Convert.FromBase64String(str));
        return DecodedString;
    }
}


