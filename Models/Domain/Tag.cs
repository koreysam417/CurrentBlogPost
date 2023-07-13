namespace Blog.Web.Models.Domain
{
    public class Tag
    {

        public Guid ID { get; set; }

        public string Name { get; set; }

        public Guid BlogPostID { get; set; }    
    }
}
