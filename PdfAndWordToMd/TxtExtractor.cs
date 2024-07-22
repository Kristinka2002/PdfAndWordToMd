using System.Text;

namespace PdfAndWordToMd
{
    public static class TxtExtractor
    {
        public static string GetText(string filePath)
        {
            using StreamReader reader = new(filePath);
            string text = reader.ReadToEnd();
            return text.ToString();

        }

    }
}
