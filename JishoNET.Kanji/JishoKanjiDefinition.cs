using System;

namespace JishoNET.Models
{
	public class JishoKanjiDefinition
	{
		/// <summary>
		/// The kanji character.
		/// </summary>
		public string Kanji;

		/// <summary>
		/// The meanings of the kanji.
		/// </summary>
		public string[] Meanings { get; set; }

		/// <summary>
		/// The Kunyomi readings of the kanji.
		/// </summary>
		public string[] KunyomiReadings { get; set; }

		/// <summary>
		/// The Onyomi readings of the kanji.
		/// </summary>
		public string[] OnyomiReadings { get; set; }

		/// <summary>
		/// The number of strokes of the kanji.
		/// </summary>
		/// <value></value>
		public int Strokes { get; set; }

        /// <summary>
        /// The JLPT level at which this kanji will start appearing
        /// </summary>
        /// <value></value>
        public int? Jlpt { get; set; }
    }
}