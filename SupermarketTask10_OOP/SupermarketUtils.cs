public class SupermarketUtils
{
}

public static class GoodsRenderer
{
    public static List<Goods> RenderGoods(Dictionary<Func<Goods>, int> creationRules)
    {
        var goodsList = new List<Goods>();
        foreach (var rule in creationRules)
        {
            for (int i = 0; i < rule.Value; i++)
            {
                goodsList.Add(rule.Key());
            }
        }

        return goodsList;
    }
}

public static class CustomerService
{
    private static readonly Random _random = new Random();

    public static Queue<Consumer> CreateConsumerQueue(int customerCount)
    {
        var queue = new Queue<Consumer>();
        for (int i = 0; i < customerCount; i++)
        {
            int rubles = _random.Next(0, 131); // 0..130
            var consumer = new Consumer(rubles);
            queue.Enqueue(consumer);
        }

        return queue;
    }
}
