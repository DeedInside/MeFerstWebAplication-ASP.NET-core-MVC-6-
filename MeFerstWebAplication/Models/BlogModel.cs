namespace MeFerstWebAplication.Models
{
    public class BlogModel
    {
        public BlogModel()
        {        }
        public BlogModel(string? categori, string? text_Content, string? url_image, string? time)
        {
            Categori = categori;
            Text_Content = text_Content;
            Url_image = url_image;
            Time = time;
        }

        public BlogModel(int id, string? categori, string? text_Content, string? url_image, string? time)
        {
            Id = id;
            Categori = categori;
            Text_Content = text_Content;
            Url_image = url_image;
            Time = time;
        }

        public int Id { get; set; }
        public string? Categori { get; set; }
        public string? Text_Content { get; set; }
        public string? Url_image { get; set; }
        public string? Time { get; set; }

        

    }
}
