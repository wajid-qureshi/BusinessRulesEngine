using System;
using System.Collections.Generic;
using BusinessRulesEngine.Contracts;
using BusinessRulesEngine.Entities;
using BusinessRulesEngine.Enums;
using BusinessRulesEngine.Results;

namespace BusinessRulesEngine.BusinessRules
{
	public class CommissionPaymentBusinessRule : IBusinessRule
	{
		public string Name => "Commission payment rule";

		public ExecutionResult ExecuteRule(Product product)
		{
			if (product.Type == ProductType.Book || product.Type == ProductType.Physical)
			{
				try
				{
					// Create commission payment to the agent
					return new ExecutionResult { ResultCode = ResultCode.Ok, Comments = "Commission payment to the agent created successfully" };
				}
				catch (Exception e)
				{
					return new ExecutionResult { ResultCode = ResultCode.Error, Errors = new List<string> { e.Message } };
				}
			}
			return null;
		}
	}
}