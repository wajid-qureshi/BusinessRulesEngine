using System;
using System.Collections.Generic;
using BusinessRulesEngine.Contracts;
using BusinessRulesEngine.Entities;
using BusinessRulesEngine.Enums;
using BusinessRulesEngine.Results;

namespace BusinessRulesEngine.BusinessRules
{
	public class MembershipBusinessRule : IBusinessRule
	{
		public string Name => "Membership rule";

		public ExecutionResult ExecuteRule(Product product)
		{
			if (product.Type != ProductType.Membership) return null;
			try
			{
				// Activate membership
				return new ExecutionResult { ResultCode = ResultCode.Ok, Comments = "Membership activated successfully"};
			}
			catch (Exception e)
			{
				return new ExecutionResult { ResultCode = ResultCode.Error, Errors = new List<string> { e.Message } };
			}
		}
	}
}