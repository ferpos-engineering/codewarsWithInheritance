namespace Codewars.Domain
{
    internal class Sulfuras : MyItem
    {
        public override int SellIn
        {
            get => base.SellIn;

            protected set
            {
                // Ignore
            }
        }

        public override Quality? Quality
        { 
            get => base.Quality;
            protected set
            {
                // Ignore
            }
        }

        internal Sulfuras(string name, int sellIn, int quality) :
            base(name, sellIn, quality)
        {
            this.sellIn = sellIn;
            this.quality = new Quality(quality, 0, 80)
            {
                Degradation = 0,
            };
        }

        protected override void EvaluateDegradation()
        {
            // ignore.
        }
    }
}
