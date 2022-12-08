namespace EventDrivenATM;

    public class Program
    {
        static void Main(string[] args)
        {

        starter start = new starter();
        start.KeyPressOne += HandleKeyPressOne;
        start.KeyPressTwo += HandleKeyPressTwo;
        start.getStarter();

        }
    public static void HandleKeyPressOne(object sender, EventArgs e)
    {
            atmApp.getEnglish();
    }

    public static void HandleKeyPressTwo(object sender, EventArgs e)
    {
            atmApp.getIgbo();
    }

    
    }

