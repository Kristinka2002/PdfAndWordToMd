using NPOI.XWPF.UserModel;
using System.Text;

namespace PdfAndWordToMd
{
    public static class WordExtractor
    {
        public static string GetText(string filePath)
        {
            var sb = new StringBuilder();
            try
            {
                Stream stream = File.OpenRead(filePath);
                XWPFDocument doc = new XWPFDocument(stream);
                foreach (var para in doc.Paragraphs)
                {
                    string text = para.ParagraphText; //Text
                    if (text.Trim() != "")
                        sb.AppendLine(text);
                }
            }
            catch (Exception e)
            {

            }
            var str = sb.ToString();
            return str;

        }

    }
}
