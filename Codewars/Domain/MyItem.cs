namespace Codewars.Domain;

public class MyItem
{
    protected int sellIn;

    protected Quality? quality;

    public string Name { get; protected set; }

    public virtual int SellIn { get => this.sellIn; protected set => this.sellIn = value; }

    public virtual Quality? Quality { get => this.quality; protected set => this.quality = value; }

    internal MyItem(string name, int sellIn, int quality)
    {
        this.Name = name;
        this.SellIn = sellIn;
        this.Quality = new Quality(quality, 0, 50);
    }

    public void Update()
    {
        if (this.Quality == null)
        {
            throw new NullReferenceException();
        }

        this.SellIn--;
        this.EvaluateRule();
        this.Quality.Value -= this.Quality.Degradation;
    }

    protected virtual void EvaluateRule()
    {
        if (this.SellIn < 0 && this.Quality != null)
        {
            this.Quality.Degradation = 2;
        }
    }

    public static MyItem Of(string name, int sellIn, int quality)
    {
        if (name.Contains("Aged Brie"))
        {
            return new AgedBrie(name, sellIn, quality);
        }

        if (name.Contains("Conjured"))
        {
            return new Conjured(name, sellIn, quality);
        }

        if (name.Contains("Backstage passes"))
        {
            return new BackstagePasses(name, sellIn, quality);
        }

        if (name.Contains("Sulfuras"))
        {
            return new Sulfuras(name, sellIn, quality);
        }

        return new MyItem(name, sellIn, quality);
    }

    public override bool Equals(object? obj)
    {
        var item = obj as MyItem;
        if (item == null)
        {
            return false;
        }

        return this.Equals(item);
    }

    public bool Equals(MyItem obj)
    {
        return this.Name.Equals(obj.Name) &&
               this.SellIn == obj.SellIn &&
               this.Quality.Equals(obj.Quality);
    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode() * 17 +
            this.SellIn.GetHashCode() * 17 +
            this.Quality.GetHashCode();
    }
}