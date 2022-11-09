using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using JishoNET.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JishoNET.Tests
{
	[TestClass]
	public class Tests
	{
		[TestMethod("Get Normal Definition (ASYNC)")]
		public async Task GetNormalDefinitionAsync()
		{
			JishoClient client = new JishoClient();
			JishoResult<JishoDefinition[]> result = await client.GetDefinitionAsync("川口");

			Assert.IsTrue(result.Success, "The request was not successful");
			Assert.IsNull(result.Exception, "An exception occurred whilst executing the request");
			Assert.IsTrue(result.Data.Length > 0, "The result did not contain any data");
		}

		[TestMethod("Get Normal Definition (SYNC)")]
		public void GetNormalDefinition()
		{
			JishoClient client = new JishoClient();
			JishoResult<JishoDefinition[]> result = client.GetDefinition("川口");

			Assert.IsTrue(result.Success, "The request was not successful");
			Assert.IsNull(result.Exception, "An exception occurred whilst executing the request");
			Assert.IsTrue(result.Data.Length > 0, "The result did not contain any data");
		}

		[TestMethod("Get Quick Definition (ASYNC)")]
		public async Task GetQuickDefinitionAsync()
		{
			JishoClient client = new JishoClient();
			JishoResult<JishoQuickDefinition> qDef = await client.GetQuickDefinitionAsync("川口");

			Assert.IsTrue(qDef.Success, "The request was not successful");
			Assert.IsNull(qDef.Exception, "An exception occurred whilst executing the request");
			Assert.IsNotNull(qDef.Data.JapaneseReading, "The Japanese Reading was null");
			Assert.IsNotNull(qDef.Data.EnglishSense, "The English Definition was null");
		}

		[TestMethod("Get Quick Definition (SYNC)")]
		public void GetQuickDefinition()
		{
			JishoClient client = new JishoClient();
			JishoResult<JishoQuickDefinition> qDef = client.GetQuickDefinition("川口");

			Assert.IsTrue(qDef.Success, "The request was not successful");
			Assert.IsNull(qDef.Exception, "An exception occurred whilst executing the request");
			Assert.IsNotNull(qDef.Data.JapaneseReading, "The Japanese Reading was null");
			Assert.IsNotNull(qDef.Data.EnglishSense, "The English Definition was null");
		}

		[TestMethod("Get Kanji by extension package (ASYNC)")]
		public async Task GetKanjiDefinitionAsync()
		{
			JishoClient client = new JishoClient();
			JishoResult<JishoKanjiDefinition> result = await client.GetKanjiDefinitionAsync("鬱");

			Assert.IsTrue(result.Success, "The request was not successful");
			Assert.IsNull(result.Exception, "An exception occurred whilst executing the request");
			Assert.IsNotNull(result.Data, "The result did not contain any data");
			Assert.IsTrue(result.Data.Meanings.Any());
			Assert.IsTrue(result.Data.OnyomiReadings.Any());
			Assert.IsTrue(result.Data.KunyomiReadings.Any());
			Assert.IsNull(result.Data.Jlpt);
        }

        [TestMethod("Get Kanji by extension package (ASYNC)")]
        public async Task GetKanjiDefinitionWithJlptAsync()
        {
            JishoClient client = new JishoClient();
            JishoResult<JishoKanjiDefinition> result = await client.GetKanjiDefinitionAsync("川");

            Assert.IsTrue(result.Success, "The request was not successful");
            Assert.IsNull(result.Exception, "An exception occurred whilst executing the request");
            Assert.IsNotNull(result.Data, "The result did not contain any data");
            Assert.IsTrue(result.Data.Meanings.Any());
            Assert.IsTrue(result.Data.OnyomiReadings.Any());
            Assert.IsTrue(result.Data.KunyomiReadings.Any());
            Assert.IsNotNull(result.Data.Jlpt);
        }

        [TestMethod("Get Kanji by extension package (SYNC)")]
		public void GetKanjiDefinitionSync()
		{
			JishoClient client = new JishoClient();
			JishoResult<JishoKanjiDefinition> result = client.GetKanjiDefinition("鬱");

			Assert.IsTrue(result.Success, "The request was not successful");
			Assert.IsNull(result.Exception, "An exception occurred whilst executing the request");
			Assert.IsNotNull(result.Data, "The result did not contain any data");
			Assert.IsTrue(result.Data.Meanings.Any());
			Assert.IsTrue(result.Data.OnyomiReadings.Any());
			Assert.IsTrue(result.Data.KunyomiReadings.Any());
			Assert.IsNull(result.Data.Jlpt);
        }
    }
}
