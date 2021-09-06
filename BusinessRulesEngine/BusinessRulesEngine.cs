using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BusinessRulesEngine.Contracts;
using BusinessRulesEngine.Entities;
using BusinessRulesEngine.Results;

namespace BusinessRulesEngine
{
	public class BusinessRulesEngine
	{
		private readonly List<IBusinessRule> _businessRules;

		public BusinessRulesEngine()
		{
			_businessRules = LoadBusinessRules();
		}

		public List<(string RuleName, ExecutionResult ExecutionResult)> ExecuteBusinessRules(Product product)
		{
			var executionResultList = new List<(string RuleName, ExecutionResult ExecutionResult)>();

			foreach (var businessRule in _businessRules)
			{
				ExecutionResult result = businessRule.ExecuteRule(product);

				if (result != null)
					executionResultList.Add(new(businessRule.Name, result));
			}

			return executionResultList;
		}

		private List<IBusinessRule> LoadBusinessRules()
		{
			var businessRules = new List<IBusinessRule>();

			Assembly executingAssembly = Assembly.GetAssembly(typeof(BusinessRulesEngine));

			if (executingAssembly is not null)
			{
				Type[] businessRuleTypes = executingAssembly
					.GetTypes()
					.Where(t => typeof(IBusinessRule).IsAssignableFrom(t) && t.IsClass)
					.ToArray();

				foreach (Type rule in businessRuleTypes)
				{
					IBusinessRule businessRule = Activator.CreateInstance(rule) as IBusinessRule;
					businessRules.Add(businessRule);
				}
			}
			return businessRules;
		}
	}
}