using System.Collections.Generic;
using BusinessRulesEngine.Enums;

namespace BusinessRulesEngine.Results
{
	public class ExecutionResult
	{
		public ResultCode ResultCode { get; set; }
		public List<string> Errors { get; set; }
		public string Comments { get; set; }
	}
}