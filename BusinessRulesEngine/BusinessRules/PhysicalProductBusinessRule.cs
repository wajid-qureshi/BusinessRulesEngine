using System;
using System.Collections.Generic;
using BusinessRulesEngine.Contracts;
using BusinessRulesEngine.Entities;
using BusinessRulesEngine.Enums;
using BusinessRulesEngine.Results;

namespace BusinessRulesEngine.BusinessRules
{
	public class PhysicalProductBusinessRule : IBusinessRule
	{
		public string Name => "Physical product rule";

		public ExecutionResult ExecuteRule(Product product)
		{
			if (product.Type != ProductType.Physical) return null;
			try
			{
				// Create packing slip
				return new ExecutionResult { ResultCode = ResultCode.Ok, Comments = "Packing slip created successfully"};
			}
			catch (Exception e)
			{
				return new ExecutionResult { ResultCode = ResultCode.Error, Errors = new List<string> { e.Message } };
			}
		}
	}
}