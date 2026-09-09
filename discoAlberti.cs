using System;

public class AlbertiDisc 
{
    private string externalDisk;
    private string internalDisk;

    public AlbertiDisc(string externalAlphabet, string internalAlphabet)
    {
        if (externalAlphabet.Length != internalAlphabet.Length)
            throw new ArgumentException("Ambos discos deben tener la misma longitud.");

        externalDisk = externalAlphabet.ToUpper();
        internalDisk = internalAlphabet.ToLower();
    }

    public string Encrypted(string message, int displacement)
    {

        string mobileDisk = internalDisk.Substring(displacement) + 
                            internalDisk.Substring(0, displacement);
        
        string result = "";

        foreach (char letter in message.ToUpper())
        {
            int letterDisk = externalDisk.IndexOf(letter);
            
            if (letterDisk != -1)
            {

                result += mobileDisk[letterDisk];
            }
            else
            {

                result += letter;
            }
        }

        return result;
    }

    public string Decrypted(string encryptedMessage, int displacement)
    {

        string mobileDisk = internalDisk.Substring(displacement) + 
                            internalDisk.Substring(0, displacement);
        
        string result = "";

        foreach (char letter in encryptedMessage.ToLower())
        {

            int letterDisk = mobileDisk.IndexOf(letter);
            
            if (letterDisk != -1)
            {

                result += externalDisk[letterDisk];
            }
            else
            {

                result += letter;
            }
        }

        return result;
    }
}

public class Program
{
    public static void Main()
    {
        string externalAlphabet = "ABCDEFGHIKLMNOPQRSTVXYZ";
        string internalAlphabet = "qwertyuiopasdfghjklzxcv";
        
        // Instanciamos el objeto inyectando los alfabetos
        AlbertiDisc  alberti = new AlbertiDisc(externalAlphabet, internalAlphabet);

        Console.Write("\n");
        Console.Write("Message: ");
        string message = Console.ReadLine();

        Console.Write("Number of displacement: ");
        int displacement = int.Parse(Console.ReadLine());

        string encryptedMessage = alberti.Encrypted(message, displacement);
        string decryptedMessage = alberti.Decrypted(encryptedMessage, displacement);
        
        Console.Write("\n--------------------------------------------\n");
        Console.WriteLine($"Message:         {message}");
        Console.WriteLine($"Displacements:   {displacement}");
        Console.WriteLine($"Encrypted:       {encryptedMessage}");
        Console.WriteLine($"Decrypted:       {decryptedMessage}");
        Console.Write("----------------------------------------------\n");
    }
}