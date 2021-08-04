using System;
using System.Text.Json.Serialization;

namespace JishoNET.Models
{
	public class QuickDefinition
	{
		public QuickDefinition() { }

		/// <summary>
		/// Create a new <see cref="QuickDefinition" /> from a <see cref="JishoResult" />
		/// </summary>
		public QuickDefinition(JishoResult result)
		{

			this.Meta = result.Meta;
			this.Success = result.Success;
			this.Exception = result.Exception;
			if (result.Data.Count != 0 && result.Success && result.Meta.Status == 200)
			{
				this.EnglishSense = result.Data[0].Senses[0];
				this.JapaneseReading = result.Data[0].Japanese[0];
			}
		}

		/// <summary>
		/// Meta data that is returned by the API
		/// </summary>
		public Meta Meta { get; set; }

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
		public Sense EnglishSense { get; set; }

		/// <summary>
		/// Top result Japanese Reading 
		/// </summary>
		public Japanese JapaneseReading { get; set; }
	}
}