namespace MauiApi.Models;

public class Dog
{
    public List<Breed> Breeds { get; set; }
    public string Id { get; set; }
    public string Url { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public class Breed
    {
        public WeightUnit WeightUnit { get; set; }
        public HeightUnit HeightUnit { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string BredFor { get; set; }
        public string BreedGroup { get; set; }
        public string LifeSpan { get; set; }
        public string Temperament { get; set; }
        public string ReferenceImageId { get; set; }
        public string Origin { get; set; }
    }

    public class WeightUnit
    {
        public string Imperial { get; set; }
        public string Metric { get; set; }
    }

    public class HeightUnit
    {
        public string Imperial { get; set; }
        public string Metric { get; set; }
    }
}
