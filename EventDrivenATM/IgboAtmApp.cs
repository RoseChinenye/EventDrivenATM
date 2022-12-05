namespace EventDrivenATM;

public partial class atmApp
{
    public static void getIgbo()
    {
        atmApp.getAccounts();

        Accounts user = new Accounts("test");
        bool _login = false;


        void Entry()
        {
            Console.Clear();

            Mydelegate mydelegate = new Mydelegate(getMessage);
            mydelegate += getMessage;

            string output = mydelegate.Invoke("...............THBank ATM na asi gi nnoo!................ \n.....Tinye akara Card gi na pin gi......\n");
            Console.WriteLine(output);

            Console.Write("Akara Card(1020304050): ");
            var CardNumber = Console.ReadLine();

            Console.Write("Pin(1234): ");
            var Pin = Console.ReadLine();

            foreach (var input in ExistingAccounts)
            {
                if (input.Number == CardNumber && input.Pin == Pin)
                {
                    user = input;
                    _login = true;
                    Transaction(user);
                }
            }
            if (!_login)
            {
                Console.WriteLine("Akantu a adighi na THBank!");
                Entry();
            }
        }
        if (!_login)
        {
            Entry();
        }

        void Transaction(Accounts owner)
        {

            DateTime date = DateTime.Now;

            Console.WriteLine("Tinye 1 maka iwere ego\nTinye 2 maka imata ego ole inwere\nTinye 3 maka itinye ego na akantu ozo\nTinye 4 maka ipu");
            

            var selection = Console.ReadLine();


            if (int.TryParse(selection, out int userInput))
            {
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("Tinye ego ole ichoro iwere: ");
                        var amount = Console.ReadLine();

                        if (double.TryParse(amount, out double amountInput))
                        {
                            owner.igboWithdraw(amountInput);
                            owner.igboCheckbalance();
                            Transaction(owner);
                        }
                        else
                        {
                            Console.WriteLine("Transaction gi agaghi nke oma!");
                            Transaction(owner);
                        }
                        break;

                    case 2:
                        owner.igboCheckbalance();
                        Transaction(owner);
                        break;

                    case 3:
                        Console.WriteLine("Tinye ego ole ichoro ikwunye: ");
                        var transferAmount = Console.ReadLine();

                        Console.WriteLine("Tinye akantu nomba: ");
                        var recieverAccount = Console.ReadLine();
                        if (recieverAccount.Length == 10)
                        {

                            if (double.TryParse(transferAmount, out double transferAmountInput))
                            {
                                owner.igboTransfer(transferAmountInput, recieverAccount);
                                Transaction(owner);
                            }
                            else
                            {
                                Transaction(owner);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Akantu nomba itinyere ezughi oke!");
                        }
                        break;

                    case 4:
                        Console.Clear();
                        Entry();
                        Transaction(owner);
                        _login = false;
                        break;

                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Akara itinyere adighi mma, pinye 1, 2, 3 maobu 4!");
                Transaction(owner);
            }
        }
        Transaction(user);

    }

}
