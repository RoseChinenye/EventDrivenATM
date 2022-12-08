
namespace EventDrivenATM;

    public delegate string Mydelegate(string message); 
    public partial class atmApp
    {

    private static List<Operations> ExistingAccounts = new List<Operations>();
    
    public static void getEnglish()
    {
        atmApp.getAccounts();

        Operations user = new Operations("test");
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

        void Transaction(Operations user)
        {

            Console.WriteLine("Enter 1 to withdraw\nEnter 2 to Check balance\nEnter 3 to Transfer\nEnter 4 to Quit");
            
            var selection = Console.ReadLine();


            if (int.TryParse(selection, out int userInput))
            {
            switch (userInput)
            {
                case 1:
                    Console.WriteLine("Enter amount: ");
                    var amount = Console.ReadLine();

                    if (double.TryParse(amount, out double amountInput))
                    {
                        user.Withdraw(amountInput);
                        user.Checkbalance();
                        Transaction(user);
                    }
                    else
                    {
                        Console.WriteLine("Transaction failed!");
                        Transaction(user);
                    }
                    break;

                case 2:
                    user.Checkbalance(); Transaction(user);
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
                            user.Transfer(transferAmountInput, recieverAccount);
                            Transaction(user);
                        }
                        else
                        {
                            Transaction(user);
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
                        Transaction(user);
                        _login = false;
                        break;

                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Your input appears to be invalid, please try a numeric value");
                Transaction(user);
            }
        }
        Transaction(user);

    }
    

    public static void getAccounts()
    {
        Operations First = new Operations("Chinenye");
        Operations Second = new Operations("Rose");
        Operations Third = new Operations("Akin");

        ExistingAccounts.Add(First);
        ExistingAccounts.Add(Second);
        ExistingAccounts.Add(Third);

        
    }

    public static string getMessage(string message)
    {
        return message;
    }

    
    }




