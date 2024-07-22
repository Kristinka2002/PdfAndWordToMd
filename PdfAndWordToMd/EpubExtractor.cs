
using System.Text;
using HtmlAgilityPack;
using VersOne.Epub;

namespace PdfAndWordToMd
{
    public static class EpubExtractor
    {
        public static string GetText(string filePath)
        {
            StringBuilder text = new StringBuilder();

            EpubBook book = EpubReader.ReadBook(filePath);
            foreach (EpubLocalTextContentFile textContentFile in book.ReadingOrder)
            {
                text.Append(PrintTextContentFile(textContentFile));
            }
            return text.ToString();

        }

        public static string PrintTextContentFile(EpubLocalTextContentFile textContentFile)
        {
            HtmlAgilityPack.HtmlDocument htmlDocument = new();
            htmlDocument.LoadHtml(textContentFile.Content);
            StringBuilder sb = new();
            foreach (HtmlAgilityPack.HtmlNode node in htmlDocument.DocumentNode.SelectNodes("//text()"))
            {
                sb.AppendLine(node.InnerText.Trim());
            }
            string contentText = sb.ToString();
            return contentText;
            //Console.WriteLine(contentText);
            //Console.WriteLine();
        }

    }
}
