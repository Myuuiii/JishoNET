using System.Collections.Generic;
using System.Diagnostics;
using JishoNET.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JishoNET.Tests
{
	[TestClass]
	public class Tests
	{
		[TestMethod("Get Normal Definition")]
		public void GetNormalDefinition()
		{
			JishoClient client = new JishoClient();
			JishoResult result = client.GetDefinition("川口");

			Assert.IsTrue(result.Success, "The request was not successful");
			Assert.IsNull(result.Exception, "An exception occurred whilst executing the request");
			Assert.IsTrue(result.Data.Length > 0, "The result did not contain any data");
		}

		[TestMethod("Get Quick Definition")]
		public void GetQuickDefinition()
		{
			JishoClient client = new JishoClient();
			JishoQuickDefinition qDef = client.GetQuickDefinition("川口");

			Assert.IsTrue(qDef.Success, "The request was not successful");
			Assert.IsNull(qDef.Exception, "An exception occurred whilst executing the request");
			Assert.IsNotNull(qDef.JapaneseReading, "The Japanese Reading was null");
			Assert.IsNotNull(qDef.EnglishSense, "The English Definition was null");
		}
	}
}
