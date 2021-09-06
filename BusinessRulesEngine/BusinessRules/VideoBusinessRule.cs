using System;
using System.Collections.Generic;
using BusinessRulesEngine.Contracts;
using BusinessRulesEngine.Entities;
using BusinessRulesEngine.Enums;
using BusinessRulesEngine.Results;

namespace BusinessRulesEngine.BusinessRules
{
	public class VideoBusinessRule : IBusinessRule
	{
		public string Name => "Video rule";
		private const string VideoTitle = "Learning to Ski";

		public ExecutionResult ExecuteRule(Product product)
		{
			if (product.Type == ProductType.Video && product.Name == VideoTitle)
			{
				try
				{
					// Add a free first aid video to the packing slip
					return new ExecutionResult { ResultCode = ResultCode.Ok, Comments = "Free first aid video to the packing slip added successfully" };
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