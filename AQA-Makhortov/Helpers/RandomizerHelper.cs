namespace AQA_Makhortov.Helpers;

public static class RandomizerHelper
{
    public static T GetRandomItem<T>(IList<T> items)
    {
        if (items == null || items.Count == 0)
            throw new ArgumentException("Список пустой или null");
        var rnd = new Random();
        var index = rnd.Next(items.Count);
        return items[index];
    }
}