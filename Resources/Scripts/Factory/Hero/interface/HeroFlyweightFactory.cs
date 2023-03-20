using System.Collections.Generic;

public static class HeroFlyweightFactory
{
    private static readonly Dictionary<string, Hero> flyweights = new Dictionary<string, Hero>();

    public static Hero GetFlyWeight(string heroString)
    {
        if (!flyweights.ContainsKey(heroString))
        {
            switch (heroString)
            {
                case "King":
                    flyweights[heroString] = new Hero
                    {
                        Health = 180f,
                        Damage = 20,
                        Defense = 15,
                        Speed = 1f,
                        DSpeed = 2f,
                        Range = 0.5f
                    };
                    break;

                case "Knight":
                    flyweights[heroString] = new Hero
                    {
                        Health = 150f,
                        Damage = 25,
                        Defense = 10,
                        Speed = 1.8f,
                        DSpeed = 1.5f,
                        Range = 0.6f
                    };
                    break;
            }
        }
        return flyweights[heroString];
    }
}