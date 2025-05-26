using System.Text;

namespace OurApi.Models;

public class JWTSettings
{
    public string SecretKey { get; set; }
    public byte[] key { get; set; }

    public string Issuer { get; set; }
    public string Audience { get; set; }

    public JWTSettings(){
        SecretKey = "i-love-you_We_are_i_&_Tovi_Kuperman";
        key = Encoding.UTF8.GetBytes(SecretKey); // המפתח הסודי שלך
        System.Console.WriteLine("sfdxgh!!!!!"+key[0]);
        string result = System.Text.Encoding.UTF8.GetString(key);
        Console.WriteLine(result); // מדפיס את התווים A, B, C, D
         foreach (byte b in key)
        {
            Console.Write(b); // מדפיס כל בייט
        }
        Issuer = "https://Web-Api-Project.com";
        Audience = "https://Web-Api-Project.com";
    }
}