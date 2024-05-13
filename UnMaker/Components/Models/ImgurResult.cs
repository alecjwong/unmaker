namespace UnMaker.Components.Models
{
    public class ImgurResult
    {
        public string title;
        public string link;
        public string id;
        public string error;

        public ImgurResult()
        {
            title = "";
            link = "";
            id = "";
            error = "";
        }
    }

    public class Imgur
    {
        public static string IdToImage(string? id)
        {
            if (id == null) return "";
            return "https://i.imgur.com/" + id + ".png";
        }

        public static string IdToJpegImage(string? id)
        {
            if (id == null) return "";
            return "https://i.imgur.com/" + id + ".jpg";
        }

        public static string IdToThumbnail(string? id)
        {
            if (id == null) return "";
            return "https://i.imgur.com/" + id + "m.png";
        }
    }
}
