using System.Text;

namespace PdfAndWordToMd
{
    public static class MdCreator
    {
        public static void CreateMd(string text, string filePath)
        {
            try
            {
                using (FileStream fs = File.Create(filePath))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(text.ToString());
                    fs.Write(info, 0, info.Length);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
