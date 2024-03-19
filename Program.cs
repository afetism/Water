// See https://aka.ms/new-console-template for more information


using System.Net.Mail;
using System.Net;
using WaterRemainder.Helper;
using System.Security.Cryptography.X509Certificates;
using WaterRemainder.Models;

void menuRegister()
{
    userName:
    Console.WriteLine("Enter UserName:");
    string? userName = Console.ReadLine();
    email:
    Console.WriteLine("Enter Email:");
    string? email = Console.ReadLine();
    Console.WriteLine("Enter Password:");
    password:
    string? password = Console.ReadLine();
    weightInput:
    Console.WriteLine("Enter Weight:");
    string? weightInput = Console.ReadLine();
    float weight;

    try
    {
        weight =CheckAndCasting.GetDoubleFromString(weightInput);
    }
    catch (InvalidCastException ex)  
    {
        Console.WriteLine(ex.Message);
        goto weightInput;

    }
    catch(NullReferenceException ex)
    {
        Console.WriteLine(ex.Message);
        goto weightInput;
    }

    User user = new User(userName!, email!, password!, weight);



}


















