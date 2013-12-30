using System;
using DomainLogic.BusinessLogic.TransactionScript;

namespace DomainLogic
{
  class Program
  {
    static void Main(string[] args)
    {
      RecognitionGateway recognitionGateway = new RecognitionGateway();
      RecognitionService recognitionService = new RecognitionService(recognitionGateway);

      decimal totalRecognized = recognitionService.RecognizedRevenue(1, DateTime.Now);
      Console.WriteLine("Total recognized is: " + totalRecognized);
    }
  }
}
