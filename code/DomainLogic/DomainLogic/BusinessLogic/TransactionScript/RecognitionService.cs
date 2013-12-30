using System;
using System.Data;

namespace DomainLogic.BusinessLogic.TransactionScript
{
  class RecognitionService
  {
    private readonly RecognitionGateway _dbGateway;

    public RecognitionService(RecognitionGateway dbGateway)
    {
      _dbGateway = dbGateway;
    }

    public decimal RecognizedRevenue(long contractNumber, DateTime asOf)
    {
      decimal result = decimal.Zero;
      using (IDataReader dr = _dbGateway.FindRecognitionFor(contractNumber, asOf))
      {
        while (dr.Read())
          result += dr.GetDecimal(0);

        return result;
      }
    }

    public void CalculateRevenueRecognitions(long contractNumber)
    {

    }
  }
}
