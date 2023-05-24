namespace Codewars.Domain
{
    internal class BackstagePasses : AgedBrie
    {
        internal BackstagePasses(string name, int sellIn, int quality) :
            base(name, sellIn, quality)
        {
        }

        protected override void EvaluateRule()
        {
            base.EvaluateRule();

            if (this.Quality == null)
            {
                throw new NullReferenceException();
            }

            if (this.SellIn == 0)
            {
                this.Quality.Value = 0;
                this.Quality.Degradation = 0;
            }
            else if (this.SellIn <= 5)
            {
                this.Quality.Degradation *= 3;
            }
            else if (this.SellIn <= 10)
            {
                this.Quality.Degradation *= 2;
            }
        }
    }
}
