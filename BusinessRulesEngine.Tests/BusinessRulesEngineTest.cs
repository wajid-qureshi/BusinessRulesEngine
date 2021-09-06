using BusinessRulesEngine.Entities;
using BusinessRulesEngine.Enums;
using NUnit.Framework;

namespace BusinessRulesEngine.Tests
{
	[TestFixture]
	public class BusinessRulesEngineTest
	{
		private BusinessRulesEngine _businessRulesEngine;

		[SetUp]
		public void Setup()
		{
			_businessRulesEngine = new BusinessRulesEngine();
		}

		[Test]
		public void PhysicalProductBoughtTest()
		{
			RunTest(new Product { Type = ProductType.Physical });
		}

		[Test]
		public void BookBoughtTest()
		{
			RunTest(new Product { Type = ProductType.Book });
		}

		[Test]
		public void MembershipBoughtTest()
		{
			RunTest(new Product { Type = ProductType.Membership });
		}

		[Test]
		public void MembershipUpgradeBoughtTest()
		{
			RunTest(new Product { Type = ProductType.MembershipUpgrade });
		}

		[Test]
		public void VideoBoughtTest()
		{
			Product product = new() { Name = "Abc", Type = ProductType.Video };
			var result = _businessRulesEngine.ExecuteBusinessRules(product);
			Assert.IsEmpty(result);

			product = new() { Name = "Learning to Ski", Type = ProductType.Video };
			result = _businessRulesEngine.ExecuteBusinessRules(product);
			Assert.NotNull(result);
			Assert.IsTrue(result.Count == 1, "One rule should be executed!");
			Assert.AreEqual("Video rule", result[0].RuleName);
		}

		private void RunTest(Product product)
		{
			var result = _businessRulesEngine.ExecuteBusinessRules(product);
			Assert.IsNotEmpty(result);
			Assert.IsTrue(result.Count == 2, "Two rules should be executed!");
		}
	}
}