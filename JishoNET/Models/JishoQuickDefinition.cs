using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JishoNET.Models
{
	public class JishoQuickDefinition
	{
		public JishoQuickDefinition() { }

		/// <summary>
		/// Create a new <see cref="JishoQuickDefinition" /> from a <see cref="JishoResult" />
		/// </summary>
		public JishoQuickDefinition(JishoResult result)
		{

			this.Meta = result.Meta;
			this.Success = result.Success;
			this.Exception = result.Exception;
			if (result.Data.Length != 0 && result.Success && result.Meta.Status == 200)
			{
				this.EnglishSense = result.Data[0].Senses[0];
				this.JapaneseReading = result.Data[0].Japanese[0];
			}
		}

		/// <summary>
		/// Meta data that is returned by the API
		/// </summary>
		public JishoMeta Meta { get; set; }

		/// <summary>
		/// Indicates if the request was executed successfully 
		/// </summary>
		public Boolean Success { get; set; }

		/// <summary>
		/// Any exception information, this will only be provided if something goes wrong during the creation or processing of your request
		/// </summary>
		public String Exception { get; set; }

		/// <summary>
		/// Top result English Sense
		/// </summary>
		public JishoEnglishSense EnglishSense { get; set; }

		/// <summary>
		/// Top result Japanese Reading 
		/// </summary>
		public JishoJapaneseDefinition JapaneseReading { get; set; }
	}
}