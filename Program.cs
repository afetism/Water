// See https://aka.ms/new-console-template for more information


using System.Net.Mail;
using System.Net;
using WaterRemainder.Helper;
using System.Security.Cryptography.X509Certificates;
using WaterRemainder.Models;


void menuItem (DataBase db)
{
    Console.WriteLine($"User: {db.User.Name } CurrentWater: {db.User.CurrentWater} AvarageWater: {db.User.AvarageDailyWater()} Today:{(!db.User.HistoriesDaily.Any() ? DateTime.Now : db.User.HistoriesDaily.LastOrDefault().Date)} "); 
    Console.WriteLine("1.Su Icdim");
    Console.WriteLine("2.Tarixce");
    Console.WriteLine("3.Gunu bitir");
}



User  menuRegister()
{
    userName:
    Console.Write("Enter UserName:");
    string? userName = Console.ReadLine();
    email:
    Console.Write("Enter Email:");
    string? email = Console.ReadLine();
    password:
    Console.Write("Enter Password:");
    string? password = Console.ReadLine();
    weightInput:
    Console.Write("Enter Weight:");
    string? weightInput = Console.ReadLine();
    float weight;

    try
    {
        weight =CheckAndCasting.GetFloatFromString(weightInput);
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


    return user;
}

void mainMenu()
{
    DataBase db = new("register.json");
    if(db.User is null)
    {
        User user = menuRegister();
        db.User = user;
        db.SavaData();
        manageItem(db);
    }
    else
    {
        Register:
        Console.Write("Enter Email:");
        string? email = Console.ReadLine();
        Console.Write("Enter Password:");
        string? password = Console.ReadLine();
        if (email == db.User.Email &&  password == db.User.Password)
        {
            manageItem(db);
        }
        else goto Register;

    }
}





void manageItem(DataBase db)
{
    float water=0;
    while (true)
    {
        Console.Clear();
        menuItem(db);
        inputChoose:
        Console.Write("Choose: ");

        string inputChoose = Console.ReadLine();
        int choose;
        try
        {
            choose =CheckAndCasting.GetIntFromString(inputChoose);
        }
        catch (InvalidCastException ex)
        {
            Console.WriteLine(ex.Message);
            goto inputChoose;

        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine(ex.Message);
            goto inputChoose;
        }



        if(choose ==1)
        {
            water:
            Console.Write("Ne qeder su icdiz?: ");
            string inputWater = Console.ReadLine();
          
            try
            {
                water =CheckAndCasting.GetFloatFromString(inputWater);
                db.User.CurrentWater+=water;
                if(db.User.CurrentWater >= db.User.AvarageDailyWater()) { Console.WriteLine("Siz gunluk ortalama suyunuzu icdiniz!"); }

            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
                goto water;

            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                goto water;
            }
            db.SavaData();
        }
        else if(choose == 2)
        {
            Console.WriteLine("Tarixce: ");
            foreach(var i in db.User.HistoriesDaily)
            {
                Console.WriteLine(i);
            }
        }
        else if(choose == 3)
        {
            if(!db.User.HistoriesDaily.Any())
            {
                db.User.HistoriesDaily.Add(new History(DateTime.Now, db.User.CurrentWater));
            }
            else
            {
                DateTime time = db.User.HistoriesDaily.LastOrDefault().Date;
               time= time.AddDays(1);
                db.User.HistoriesDaily.Add(new History(time, db.User.CurrentWater));
            }
            db.User.CurrentWater=0;
            db.SavaData();
        }





    }
}





mainMenu();













