namespace PdfAndWordToMd
{
    class Program
    {
        public static IEnumerable<string> GetPdfFiles()
        {
            return Directory.GetFiles(Path.Combine("..", "..", "..", "Data", "PDFs"), "*.pdf", SearchOption.AllDirectories);
        }
        public static IEnumerable<string> GetWordFiles()
        {
            return Directory.GetFiles(Path.Combine("..", "..", "..", "Data", "WORDs"), "*.docx", SearchOption.AllDirectories);
        }

        static void Main(string[] args)
        {

            foreach (var pdfFileName in GetPdfFiles())
            {
                Console.Out.WriteLine(pdfFileName);
                var text = PdfExtractor.GetText(pdfFileName);
                MdCreator.CreateMd(text, pdfFileName.Replace(".pdf", ".md"));

            }
            foreach (var wordFileName in GetWordFiles())
            {
                Console.Out.WriteLine(wordFileName);
                var text = WordExtractor.GetText(wordFileName);
                MdCreator.CreateMd(text, wordFileName.Replace(".docx", ".md"));

            }

        }

    }
}

