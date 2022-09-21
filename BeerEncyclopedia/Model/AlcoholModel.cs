namespace BeerEncyclopedia.Model
{
    public class Amount
    {
        public double? Value { get; set; }
        public string? Unit { get; set; }
    }

    public class BoilVolume
    {
        public int? Value { get; set; }
        public string? Unit { get; set; }
    }

    public class Fermentation
    {
        public Temp? Temp { get; set; }
    }

    public class Hop
    {
        public string? Name { get; set; }
        public Amount? Amount { get; set; }
        public string? Add { get; set; }
        public string? Attribute { get; set; }
    }

    public class Ingredients
    {
        public List<Malt>? Malt { get; set; }
        public List<Hop>? Hops { get; set; }
        public string? Yeast { get; set; }
    }

    public class Malt
    {
        public string? Name { get; set; }
        public Amount? Amount { get; set; }
    }

    public class MashTemp
    {
        public Temp? Temp { get; set; }
        public int? Duration { get; set; }
    }

    public class Method
    {
        public List<MashTemp>? MashTemp { get; set; }
        public Fermentation? Fermentation { get; set; }
        public string? Twist { get; set; }
    }

    public class Beer
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Tagline { get; set; }
        public string? FirstBrewed { get; set; }
        public string? Description { get; set; }
        public string? Image_url { get; set; }
        public double? Abv { get; set; }
        public int? Ibu { get; set; }
        public int? Target_fg { get; set; }
        public double? Target_og { get; set; }
        public double? Ebc { get; set; }
        public double? Srm { get; set; }
        public double? Ph { get; set; }
        public double? Attenuation_level { get; set; }
        public Volume? Volume { get; set; }
        public BoilVolume? Boil_volume { get; set; }
        public Method? Method { get; set; }
        public Ingredients? Ingredients { get; set; }
        public List<string>? Food_pairing { get; set; }
        public string? Brewers_tips { get; set; }
        public string? Contributed_by { get; set; }
    }

    public class Temp
    {
        public int? Value { get; set; }
        public string? Unit { get; set; }
    }

    public class Volume
    {
        public int? Value { get; set; }
        public string? Vnit { get; set; }
    }

}
