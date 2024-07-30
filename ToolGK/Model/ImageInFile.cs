namespace ToolGK.Model
{
    internal class ImageInfile
    {
        public string ImageName { get; }
        public string FullPathImage { get; }
        public string PathFileName { get; }
        public int Line { get; }
        public string SourceCodeByLine { get; }

        public ImageInfile(string imageName, string fullPathImage, string fileName, int line, string sourceCodeByLine)
        {
            ImageName = imageName;
            FullPathImage = fullPathImage;
            PathFileName = fileName;
            Line = line;
            SourceCodeByLine = sourceCodeByLine;
        }
    }
}
