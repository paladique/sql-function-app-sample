namespace WikiSQL
{
    public class Article
    {
        public int? id { get; set; }
        public string url { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
    }


    public class ArticleEmbeddings
    {
        public int? Id { get; set; }
        
        public float vector_value { get; set; }

        public int article_id { get; set; }
    }
}