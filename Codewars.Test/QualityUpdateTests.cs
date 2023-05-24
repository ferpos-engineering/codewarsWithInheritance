using System.Collections;
using Codewars.Domain;
using Codewars.UseCases;

namespace Codewars.Test;

public class QualityUpdateTests
{
    public class TestItemGenerator: IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { MyItem.Of("Banana", 10, 5), MyItem.Of("Banana", 9, 4) };
            yield return new object[] { MyItem.Of("Banana", 0, 5), MyItem.Of("Banana", -1, 3) };
            yield return new object[] { MyItem.Of("Banana", 10, 0), MyItem.Of("Banana", 9, 0) };
            yield return new object[] { MyItem.Of("Banana. Conjured", 10, 6), MyItem.Of("Banana. Conjured", 9, 4) };
            yield return new object[] { MyItem.Of("Banana. Conjured", 0, 6), MyItem.Of("Banana. Conjured", -1, 2) };
            yield return new object[] { MyItem.Of("Aged Brie", 10, 5), MyItem.Of("Aged Brie", 9, 6) };
            yield return new object[] { MyItem.Of("Aged Brie", 10, 5), MyItem.Of("Aged Brie", 9, 6) };
            yield return new object[] { MyItem.Of("Sulfuras", 10, 5), MyItem.Of("Sulfuras", 10, 5) };
            yield return new object[] { MyItem.Of("Backstage passes", 12, 15), MyItem.Of("Backstage passes", 11, 16) };
            yield return new object[] { MyItem.Of("Backstage passes", 11, 15), MyItem.Of("Backstage passes", 10, 17) };
            yield return new object[] { MyItem.Of("Backstage passes", 6, 15), MyItem.Of("Backstage passes", 5, 18) };
            yield return new object[] { MyItem.Of("Backstage passes", 1, 15), MyItem.Of("Backstage passes", 0, 0) };
        }

        IEnumerator IEnumerable.GetEnumerator() 
            => GetEnumerator();
    }

    public class TestItemGeneratorVero : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { MyItem.Of("Banana", 10, 5), "Banana", 9, 4 };
            yield return new object[] { MyItem.Of("Banana", 0, 5), "Banana", -1, 3 };
            yield return new object[] { MyItem.Of("Banana", 10, 0), "Banana", 9, 0 };
            yield return new object[] { MyItem.Of("Banana. Conjured", 10, 6), "Banana. Conjured", 9, 4 };
            yield return new object[] { MyItem.Of("Banana. Conjured", 0, 6), "Banana. Conjured", -1, 2 };
            yield return new object[] { MyItem.Of("Aged Brie", 10, 5), "Aged Brie", 9, 6 };
            yield return new object[] { MyItem.Of("Aged Brie", 10, 5), "Aged Brie", 9, 6 };
            yield return new object[] { MyItem.Of("Sulfuras", 10, 5), "Sulfuras", 10, 5 };
            yield return new object[] { MyItem.Of("Backstage passes", 12, 15), "Backstage passes", 11, 16 };
            yield return new object[] { MyItem.Of("Backstage passes", 11, 15), "Backstage passes", 10, 17 };
            yield return new object[] { MyItem.Of("Backstage passes", 6, 15),  "Backstage passes", 5, 18 };
            yield return new object[] { MyItem.Of("Backstage passes", 1, 15), "Backstage passes", 0, 0 };
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }

    [Theory]
    [ClassData(typeof(TestItemGenerator))]
    public void QualityOfAnItem_ShouldBeUpdated_AsDaysPasses(MyItem item, MyItem expectedItem)
    {
        ItemUpdater itemUpdater = new ItemUpdater();
        itemUpdater.Update(item);
        Assert.Equal(expectedItem, item);
    }

    [Theory]
    [ClassData(typeof(TestItemGeneratorVero))]
    public void QualityOfAnItem_ShouldBeUpdated_AsDaysPasses_Vero(
        MyItem item, string name, int sellIn, int quality)
    {
        ItemUpdater itemUpdater = new ItemUpdater();
        itemUpdater.Update(item);

        Assert.Equal(name, item.Name);
        Assert.NotNull(item.Quality);
        Assert.Equal(quality, item.Quality.Value);
        Assert.Equal(item.SellIn, sellIn);
    }
}