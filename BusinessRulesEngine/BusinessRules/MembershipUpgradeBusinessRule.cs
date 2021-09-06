using System;
using System.Collections.Generic;
using BusinessRulesEngine.Contracts;
using BusinessRulesEngine.Entities;
using BusinessRulesEngine.Enums;
using BusinessRulesEngine.Results;

namespace BusinessRulesEngine.BusinessRules
{
	public class BookUpgradeBusinessRule : IBusinessRule
	{
		public string Name => "Membership upgrade rule";

		public ExecutionResult ExecuteRule(Product product)
		{
			if (product.Type != ProductType.MembershipUpgrade) return null;
			try
			{
				// Upgrade membership
				return new ExecutionResult { ResultCode = ResultCode.Ok, Comments = "Membership upgraded successfully"};
			}
			catch (Exception e)
			{
				return new ExecutionResult { ResultCode = ResultCode.Error, Errors = new List<string> { e.Message } };
			}
		}
	}
}