
using System.IO;
using System.Text;

namespace PdfAndWordToMd
{
    public static class RtfExtractor
    {
        public static string GetText(string filePath)
        {
           
            System.Windows.Forms.RichTextBox rtBox = new System.Windows.Forms.RichTextBox();

            string rtfText = System.IO.File.ReadAllText(filePath);
            
            rtBox.Rtf = rtfText;
            string plainText = rtBox.Text;
            return plainText;

        }

    }
}
