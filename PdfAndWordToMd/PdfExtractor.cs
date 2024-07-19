using System.Text;
using UglyToad.PdfPig;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;

namespace PdfAndWordToMd
{
    public static class PdfExtractor
    {
        public static string GetText(string filePath)
        {
            StringBuilder text = new StringBuilder();
            using (var pdf = PdfDocument.Open(filePath))
            {
                foreach (var page in pdf.GetPages())
                {
                    text.Append(ContentOrderTextExtractor.GetText(page));
                }

            }

            return text.ToString();

        }

    }
}
