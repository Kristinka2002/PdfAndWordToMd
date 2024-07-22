using System.Data.SqlTypes;
using System.Net;
using VerifyTests;

namespace PdfAndWordToMd
{
    public static class UrlExtractor
    {
        public static string GetText(string url)
        {
            string s;
            string result = "";
       
            using (WebClient client = new WebClient())
            {
                s = client.DownloadString(url);
            }

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();

            htmlDoc.OptionFixNestedTags = true;

            htmlDoc.LoadHtml(s);

            // ParseErrors is an ArrayList containing any errors from the Load statement
            if (htmlDoc.ParseErrors != null && htmlDoc.ParseErrors.Count() > 0)
            {
                // Handle any parse errors as required

            }
            else
            {

                if (htmlDoc.DocumentNode != null)
                {
                    HtmlAgilityPack.HtmlNode bodyNode = htmlDoc.DocumentNode.SelectSingleNode("//body");

                    if (bodyNode != null)
                    {
                        result = bodyNode.InnerText;
                    }
                }
            }


            return result;
        }

    }
}
