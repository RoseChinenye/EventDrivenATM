
namespace EventDrivenATM;

public class starter
{
    public void getStarter()
    {
        Console.WriteLine(" 1. English\n 2. Igbo\n ");
        string? option = Console.ReadLine();

        if (int.TryParse(option, out int language))
        {
            switch (language)
            {
                case 1:
                    atmApp.getEnglish();
                    break;
                case 2:
                    atmApp.getIgbo();
                    break;
                default:
                    Console.WriteLine("Please Enter 1 or 2");
                    getStarter();
                    break;
            }
        }
        else
        {
            Console.WriteLine("Your input is not a numerical value! Enter 1 or 2");
            getStarter();
        }

    }
}
