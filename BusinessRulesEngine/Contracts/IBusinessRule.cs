using BusinessRulesEngine.Entities;
using BusinessRulesEngine.Results;

namespace BusinessRulesEngine.Contracts
{
	// Interface to define a business rule
	public interface IBusinessRule
	{
		string Name { get; }

		ExecutionResult ExecuteRule(Product product);
	}
}