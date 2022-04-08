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
		public JishoQuickDefinition(JishoResult<JishoDefinition[]> result)
		{
			if (result.Data.Length != 0 && result.Success && result.Meta.Status == 200)
			{
				this.EnglishSense = result.Data[0].Senses[0];
				this.JapaneseReading = result.Data[0].Japanese[0];
			}
		}

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