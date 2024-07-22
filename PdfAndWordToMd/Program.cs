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
        public static IEnumerable<string> GetRtfFiles()
        {
            return Directory.GetFiles(Path.Combine("..", "..", "..", "Data", "RTFs"), "*.rtf", SearchOption.AllDirectories);
        }
        public static IEnumerable<string> GetEpubFiles()
        {
            return Directory.GetFiles(Path.Combine("..", "..", "..", "Data", "EPUBs"), "*.epub", SearchOption.AllDirectories);
        }
        public static IEnumerable<string> GetTxtFiles()
        {
            return Directory.GetFiles(Path.Combine("..", "..", "..", "Data", "TXTs"), "*.txt", SearchOption.AllDirectories);
        }

        public static IEnumerable<string> GetUrls()
        {
            var urls = new List<string>() { "https://ru-brightdata.com/blog/how-tos-ru/web-scraping-with-c-sharp" };
            return urls;
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

            foreach (var epubFileName in GetEpubFiles())
            {
                Console.Out.WriteLine(epubFileName);
                var text = EpubExtractor.GetText(epubFileName);
                MdCreator.CreateMd(text, epubFileName.Replace(".epub", ".md"));

            }

            foreach (var rtfFileName in GetRtfFiles())
            {
                Console.Out.WriteLine(rtfFileName);
                var text = RtfExtractor.GetText(rtfFileName);
                MdCreator.CreateMd(text, rtfFileName.Replace(".rtf", ".md"));

            }

            foreach(var txtFileName in GetTxtFiles())
            {
                Console.Out.WriteLine(txtFileName);
                var text = TxtExtractor.GetText(txtFileName);
                MdCreator.CreateMd(text, txtFileName.Replace(".txt", ".md"));

            }

            foreach (var url in GetUrls())
            {
                Console.Out.WriteLine(url);
                var text = UrlExtractor.GetText(url);
                MdCreator.CreateMd(text, Path.Combine("..", "..", "..", "Data", "UrlsMd","url.md"));

            }

        }

    }
}

