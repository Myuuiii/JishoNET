using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using JishoNET.Models;

namespace JishoNET
{
    public static class JishoNETKanji
    {
        public static async Task<JishoResult<JishoKanjiDefinition>> GetKanjiDefinitionAsync(this JishoClient client, string keyword)
        {
            string kanjiUrlBase = "https://jisho.org/search/";
            string request = $"{kanjiUrlBase}{keyword} %23kanji";

            try
            {
                string htmlData = await new HttpClient().GetAsync(request).Result.Content.ReadAsStringAsync();
                HtmlDocument htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(htmlData);

                JishoKanjiDefinition result = new JishoKanjiDefinition();

                // Save the user input as the kanji
                result.Kanji = keyword;

                // Get the meaning of the kanji from the node with class kanji-details__main-meanings
                HtmlNode meaningNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='kanji-details__main-meanings']");
                result.Meanings = meaningNode.InnerText.Split(',').Select(x => x.Trim()).ToArray();

                // Get the Kunyomi and Onyomi readings from the node with class kanji-details__main-readings
                HtmlNode readingsNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='kanji-details__main-readings']");

                // In the readings node there are 2 nodes that need to be processed. 
                HtmlNode KunyomiNode = readingsNode.SelectSingleNode("//*[@class='dictionary_entry kun_yomi']");
                HtmlNode OnyomiNode = readingsNode.SelectNodes("//*[@class='dictionary_entry on_yomi']").Last();

                List<string> kunyomiReadings = new List<string>();
                List<string> onyomiReadings = new List<string>();

                // For each node, extract all the anchor tags and save their inner text, trimmed to a list
                if (KunyomiNode != null)
                    foreach (HtmlNode node in KunyomiNode.Descendants().Where(x => x.Name == "a"))
                        kunyomiReadings.Add(node.InnerText.Trim());
                if (OnyomiNode != null)
                    foreach (HtmlNode node in OnyomiNode.Descendants().Where(x => x.Name == "a"))
                        onyomiReadings.Add(node.InnerText.Trim());

                // Save the lists as arrays to the result
                result.KunyomiReadings = kunyomiReadings.ToArray();
                result.OnyomiReadings = onyomiReadings.ToArray();

                // Get kanji stroke count (class kanji-details__stroke_count)
                HtmlNode strokeCountNode = htmlDocument.DocumentNode.SelectSingleNode("//*[@class='kanji-details__stroke_count']");
                result.Strokes = int.Parse(strokeCountNode.InnerText.Replace("\n", "").Replace("strokes", "").Trim());

                // Get the JLPT level, if exists, from the node with class jlpt
                HtmlNode jlptNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='jlpt']/strong");
                var jlptText = jlptNode?.InnerText;
                // if the string fits the form, "N#" where '#' is an integer, 1-9
                if (jlptText != null && jlptText.Length > 1 && jlptText[0] == 'N' && jlptText[1] > '0' && jlptText[1] <= '9')
                    result.Jlpt = jlptText[1] - 0x30;

                return new JishoResult<JishoKanjiDefinition>
                {
                    Data = result,
                    Success = true
                };
            }
            catch (System.Exception e)
            {
                return new JishoResult<JishoKanjiDefinition>
                {
                    Exception = e.Message,
                    Success = false
                };
            }
        }

        public static JishoResult<JishoKanjiDefinition> GetKanjiDefinition(this JishoClient client, string keyword)
        {
            return GetKanjiDefinitionAsync(client, keyword).Result;
        }
    }
}
