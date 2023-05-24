namespace Codewars.Domain
{
    internal class AgedBrie : MyItem
    {
        internal AgedBrie(string name, int sellIn, int quality) :
            base(name, sellIn, quality)
        {
            if (this.Quality != null)
            {
                this.Quality.Degradation *= -1;
            }
        }

        protected override void EvaluateRule()
        {
            if (this.Quality == null)
            {
                throw new NullReferenceException();
            }

            if (this.Quality.Degradation > 0)
            {
                this.Quality.Degradation *= -1;
            }
        }
    }
}
