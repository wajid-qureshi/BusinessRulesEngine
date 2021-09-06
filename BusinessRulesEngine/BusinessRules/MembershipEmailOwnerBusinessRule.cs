using System;
using System.Collections.Generic;
using BusinessRulesEngine.Contracts;
using BusinessRulesEngine.Entities;
using BusinessRulesEngine.Enums;
using BusinessRulesEngine.Results;

namespace BusinessRulesEngine.BusinessRules
{
	public class MembershipEmailOwnerBusinessRule : IBusinessRule
	{
		public string Name => "Membership email owner rule";

		public ExecutionResult ExecuteRule(Product product)
		{
			if (product.Type == ProductType.Membership || product.Type == ProductType.MembershipUpgrade)
			{
				try
				{
					// M-mail the owner and inform them of the activation/upgrade.
					return new ExecutionResult { ResultCode = ResultCode.Ok, Comments = "Email sent successfully" };
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