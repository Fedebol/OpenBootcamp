namespace DotNetApiRestfulEjer9.DTO
{
    public class Producto1
    {
        public string? id { get; set; }
        public string? title { get; set; }
        public string? price { get; set; }
        public string? description { get; set; }
        public string? category { get; set; }
        public string? image { get; set; }
        public string? rating { get; set; }
    }

    public class Rating
    {
        public float rate { get; set; }
        public int count { get; set; }
    }

    public class Producto2
    {
        public Guid guid = Guid.NewGuid();
        public int id { get; set; }
        public string title { get; set; }
        public float price { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string image { get; set; }
        
    }



}
