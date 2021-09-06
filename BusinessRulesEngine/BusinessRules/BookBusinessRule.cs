using System;
using System.Collections.Generic;
using BusinessRulesEngine.Contracts;
using BusinessRulesEngine.Entities;
using BusinessRulesEngine.Enums;
using BusinessRulesEngine.Results;

namespace BusinessRulesEngine.BusinessRules
{
	public class BookBusinessRule : IBusinessRule
	{
		public string Name => "Book rule";

		public ExecutionResult ExecuteRule(Product product)
		{
			if (product.Type != ProductType.Book) return null;
			try
			{
				// Create duplicate packing slip for the royalty department
				return new ExecutionResult { ResultCode = ResultCode.Ok, Comments = "Duplicate packing slip for the royalty department created successfully"};
			}
			catch (Exception e)
			{
				return new ExecutionResult { ResultCode = ResultCode.Error, Errors = new List<string> { e.Message } };
			}
		}
	}
}