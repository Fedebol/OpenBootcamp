namespace DotNetApiRestfulEjer9.DTO
{
    public class Rating
    {
        public double rate { get; set; }
        public int count { get; set; }
    }
    public class Producto1
    {
        public int? id { get; set; }
        public string? title { get; set; }
        public double? price { get; set; }
        public string? description { get; set; }
        public string? category { get; set; }
        public string? image { get; set; }
        public Rating? rating { get; set; }
    }


    public class Producto2
    {
        public Guid? guid = Guid.NewGuid();
        public int? id { get; set; }
        public string? title { get; set; }
        public float? price { get; set; }
        public string? description { get; set; }
        public string? category { get; set; }
        public string? image { get; set; }
        
    }



}
