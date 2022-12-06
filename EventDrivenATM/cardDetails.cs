
namespace EventDrivenATM;

public partial class operations
{
    private static int _cardNumber = 1020304050;
    private static int _pin = 1234;
    private static double amount;
    private static string recieverDetails;

    const int balanceLimit = 0;


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

    public operations(string accountName)
    {
        AccountName = accountName;
        Number = _cardNumber.ToString();
        Pin = _pin.ToString();

    }

}
