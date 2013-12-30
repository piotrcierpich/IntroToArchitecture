using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DomainLogic.BusinessLogic.TransactionScript
{
  internal class RecognitionGateway
  {
    private const string RecognitionsQuery = @"SELECT amount FROM REVENUE_RECOGNITIONS WHERE contract = @contract AND recognizedOn <= @recognizedOn";
    private static readonly string m_connString;

    static RecognitionGateway()
    {
      m_connString = ConfigurationManager.ConnectionStrings["archConnString"].ConnectionString;
    }

    public IDataReader FindRecognitionFor(long contractNumber, DateTime asOf)
    {
      SqlConnection connString = new SqlConnection(m_connString);
      SqlCommand sqlCommand = new SqlCommand(RecognitionsQuery, connString);
      sqlCommand.Parameters.AddWithValue("contract", contractNumber);
      sqlCommand.Parameters.AddWithValue("recognizedOn", asOf);
      connString.Open();
      return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
    }
  }
}