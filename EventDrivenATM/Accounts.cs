
namespace EventDrivenATM;
    internal class Accounts
    {
        private static int _cardNumber = 1020304050;
        private static int _pin = 1234;
        private List<TransactionsDetails> transactions = new List<TransactionsDetails>();

        public string Number { get; }
        public string Pin { get; }
        public string AccountName { get; }

        private double Balance
        {
            get
            {
                double AccountBalance = 5000.00;
                foreach (var item in transactions)
                {
                    AccountBalance += item.Amount;
                }
                return AccountBalance;
            }
        }

        public Accounts(string accountName)
        {
            AccountName = accountName;
            Number = _cardNumber.ToString();
            Pin = _pin.ToString();

        }

        public void Transfer(double amount, string recieverDetails)
        {
           
            if (amount <= 0)
            {
                Console.WriteLine("Cannot make a zero amount withdrawal");
            }
            else if (Balance - amount < 0)
            {
                Console.WriteLine("Insufficient balance...");
            }
            else
            {
                TransactionsDetails transfer = new TransactionsDetails(-amount);
                transactions.Add(transfer);
                Console.WriteLine($"Successful: {amount} has been transfered to {recieverDetails}");

            }

        }
        public void igboTransfer(double amount, string recieverDetails)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Iweghi ike inwere ego erughi otu naira. ");
            }
            else if (Balance - amount < 0)
            {
                Console.WriteLine("Ego inwere ezughi!");
            }
            else
            {
                TransactionsDetails transfer = new TransactionsDetails(-amount);
                transactions.Add(transfer);
                Console.WriteLine($"O gara nkeoma!: Ikwunyere {amount} na akantu nomba {recieverDetails}");

            }

        }


        public void Checkbalance()
        {

            Console.WriteLine($"Available Balance: {Balance}");
        }

        public void igboCheckbalance()
        {

            Console.WriteLine($"Ego inwere di: {Balance}");
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid amount.");
            }
            else if (Balance - amount < 0)
            {
                Console.WriteLine("Insufficient balance...");
            }
            else
            {
                TransactionsDetails withdrawal = new TransactionsDetails(-amount);
                transactions.Add(withdrawal);
                Console.WriteLine($"Transaction Successful!");
            }

        }
        public void igboWithdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Ego ole itinyere adabaghi!");
            }
            else if (Balance - amount < 0)
            {
                Console.WriteLine("Ego inwere ezughi!...");
            }
            else
            {
                TransactionsDetails withdrawal = new TransactionsDetails(-amount);
                transactions.Add(withdrawal);
                Console.WriteLine($"O gara nkeoma!");
            }

        }
    }



