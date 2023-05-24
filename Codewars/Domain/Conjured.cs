namespace Codewars.Domain
{
    internal class Conjured : MyItem
    {
        internal Conjured(string name, int sellIn, int quality) :
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

            this.Quality.Degradation *= 2;
        }
    }
}
