
namespace EventDrivenATM;
    public partial class atmApp
    {
    public delegate string Mydelegate(string message);

    private static List<Accounts> ExistingAccounts = new List<Accounts>();

    public static void getEnglish()
    {
        


        atmApp.getAccounts();

        Accounts user = new Accounts("test");
        bool _login = false;


        void Entry()
        {
            Console.Clear();

            Mydelegate mydelegate = new Mydelegate(getMessage);
            mydelegate += getMessage;

            string output = mydelegate.Invoke("...............Welcome to THBank ATM!................ \n.....Kindly Enter your Card Number and Pin to run a transaction......\n");
            Console.WriteLine(output);

            Console.Write("Card Number(1020304050): ");
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
                Console.WriteLine("This Account doesn't exist in THBank!");
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

            Console.WriteLine("Enter 1 to withdraw\nEnter 2 to Check balance\nEnter 3 to Transfer\nEnter 4 to Quit");
            
            var selection = Console.ReadLine();


            if (int.TryParse(selection, out int userInput))
            {
            switch (userInput)
            {
                case 1:
                    Console.WriteLine("Please enter amount: ");
                    var amount = Console.ReadLine();

                    if (double.TryParse(amount, out double amountInput))
                    {
                        owner.Withdraw(amountInput);
                        owner.Checkbalance();
                        Transaction(owner);
                    }
                    else
                    {
                        Console.WriteLine("Transaction failed!");
                        Transaction(owner);
                    }
                    break;

                case 2:
                    owner.Checkbalance(); Transaction(owner);
                    break;

                case 3:
                    Console.WriteLine("Please enter amount");
                    var transferAmount = Console.ReadLine();

                    Console.WriteLine("Please enter account number");
                    var recieverAccount = Console.ReadLine();
                    if (recieverAccount.Length == 10)
                    {
                        if (double.TryParse(transferAmount, out double transferAmountInput))
                        {
                            owner.Transfer(transferAmountInput, recieverAccount);
                            Transaction(owner);
                        }
                        else
                        {
                            Transaction(owner);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Account Number!");
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
                Console.WriteLine("Your input appears to be invalid, please try a numeric value");
                Transaction(owner);
            }
        }
        Transaction(user);

    }
    public static void getAccounts()
    {
        Accounts First = new Accounts("Chinenye");
        Accounts Second = new Accounts("Rose");
        Accounts Third = new Accounts("Akin");

        ExistingAccounts.Add(First);
        ExistingAccounts.Add(Second);
        ExistingAccounts.Add(Third);

        
    }

    public static string getMessage(string message)
    {
        return message;
    }

    
    }




