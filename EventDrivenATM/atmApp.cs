
namespace EventDrivenATM;
    internal class atmApp
    {
        private static List<Accounts> ExistingAccounts = new List<Accounts>();


        public static void getEnglish()
        {
            Accounts First = new Accounts("Chinenye");
            Accounts Second = new Accounts("Rose");
            Accounts Third = new Accounts("Akin");

            ExistingAccounts.Add(First);
            ExistingAccounts.Add(Second);
            ExistingAccounts.Add(Third);

            Accounts user = new Accounts("test");
            bool _login = false;


            void Entry()
            {
                Console.Clear();
                Console.WriteLine("...............Welcome to THBank ATM!................ ");
                Console.WriteLine(".....Kindly Enter your Card Number and Pin to run a transaction......");
                Console.WriteLine();

                Console.Write("Card Number: ");
                var CardNumber = Console.ReadLine();

                Console.Write("Pin: ");
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

                Console.WriteLine("Enter 1 to withdraw");
                Console.WriteLine("Enter 2 to Check balance");
                Console.WriteLine("Enter 3 to Transfer");
                Console.WriteLine("Enter 4 to Quit");

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


                            if (double.TryParse(transferAmount, out double transferAmountInput))
                            {
                                owner.Transfer(transferAmountInput, recieverAccount);
                                Transaction(owner);
                            }
                            else
                            {
                                Transaction(owner);
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

        public static void getIgbo()
        {
            Accounts First = new Accounts("Chinenye");
            Accounts Second = new Accounts("Rose");
            Accounts Third = new Accounts("Akin");

            ExistingAccounts.Add(First);
            ExistingAccounts.Add(Second);
            ExistingAccounts.Add(Third);

            Accounts user = new Accounts("test");
            bool _login = false;


            void Entry()
            {
                Console.Clear();
                Console.WriteLine("...............THBank ATM na asi gi nnoo!................ ");
                Console.WriteLine(".....Tinye akara Card gi na pin gi......");
                Console.WriteLine();

                Console.Write("Akara Card: ");
                var CardNumber = Console.ReadLine();

                Console.Write("Pin: ");
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

                Console.WriteLine("Tinye 1 maka iwere ego");
                Console.WriteLine("Tinye 2 maka imata ego ole inwere");
                Console.WriteLine("Tinye 3 maka itinye ego na akantu ozo");
                Console.WriteLine("Tinye 4 maka ipu");

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




