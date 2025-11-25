namespace MizeKar.Models
{
    public class FolderInfo
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Color { get; set; }

        public FolderInfo(string name, string path, string color = "#34495E")
        {
            Name = name;
            Path = path;
            Color = color;
        }
    }
}