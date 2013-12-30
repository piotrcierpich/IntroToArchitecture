namespace DomainLogic.BusinessLogic.TransactionScript
{
  internal class Money
  {
    private readonly decimal _amount;
    private readonly Currency _currency;

    private Money(decimal amount, Currency currency)
    {
      _amount = amount;
      _currency = currency;
    }

    public static Money Dollars(decimal amount)
    {
      return new Money(amount, Currency.Dollars);
    }


  }

  enum Currency { Dollars, Euro, Pound}
}