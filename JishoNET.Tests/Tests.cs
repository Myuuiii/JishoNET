using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using JishoNET.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JishoNET.Tests
{
	[TestClass]
	public class Tests
	{
		[TestMethod("Get Normal Definition")]
		public async Task GetNormalDefinition()
		{
			JishoClient client = new JishoClient();
			JishoResult<JishoDefinition> result = await client.GetDefinitionAsync("川口");

			Assert.IsTrue(result.Success, "The request was not successful");
			Assert.IsNull(result.Exception, "An exception occurred whilst executing the request");
			Assert.IsTrue(result.Data.Length > 0, "The result did not contain any data");
		}

		[TestMethod("Get Quick Definition")]
		public async Task GetQuickDefinition()
		{
			JishoClient client = new JishoClient();
			JishoQuickDefinition qDef = await client.GetQuickDefinitionAsync("川口");

			Assert.IsTrue(qDef.Success, "The request was not successful");
			Assert.IsNull(qDef.Exception, "An exception occurred whilst executing the request");
			Assert.IsNotNull(qDef.JapaneseReading, "The Japanese Reading was null");
			Assert.IsNotNull(qDef.EnglishSense, "The English Definition was null");
		}
	}
}
