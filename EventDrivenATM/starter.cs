namespace EventDrivenATM;

public class starter
{
    public event EventHandler KeyPressOne; 
    public event EventHandler KeyPressTwo; 
    public void getStarter()
    {
        
            Console.WriteLine("For English, Press \"1\" \nMaka I horo asusu Igbo, Pia \"2\" \n ");
            string? option = Console.ReadLine();

            if (int.TryParse(option, out int language))
            {
                switch (language)
                {
                    case 1:
                    OnKeyPressOne(EventArgs.Empty);
                    break;
                    case 2:
                    OnKeyPressTwo(EventArgs.Empty);
                    break;
                    default:
                    Console.WriteLine("Please, Press \"1\" or \"2\"\nBiko, Pia \"1\" maobu \"2\"\n");
                    getStarter();
                    break;
                }
            }
            else
            {
                Console.WriteLine("Your input is not a numerical value! Press \"1\" or \"2\"\nAkara I pinyere abughi nomba! Pia \"1\" maobu \"2\"\n");
                getStarter();
            }

    }
    

    protected virtual void OnKeyPressOne(EventArgs e)
    {
        KeyPressOne?.Invoke(this, e);
    }

    protected virtual void OnKeyPressTwo(EventArgs e)
    {
        KeyPressTwo?.Invoke(this, e);
    }

}
