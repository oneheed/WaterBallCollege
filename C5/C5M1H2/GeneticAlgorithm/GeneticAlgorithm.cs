using System.Collections;

class Product
{
    public int Id { get; set; }

    public decimal Price { get; set; }

    public int Weight { get; set; }

    public string Category { get; set; }
}

static class Example1Utility
{
    private static List<Product> products = new()
    {
        new Product { Id = 1, Price = 100, Weight = 2, Category = "A" },
        new Product { Id = 2, Price = 200, Weight = 3, Category = "A" },
        new Product { Id = 3, Price = 150, Weight = 5, Category = "B" },
        new Product { Id = 4, Price = 300, Weight = 4, Category = "B" },
        new Product { Id = 5, Price = 180, Weight = 6, Category = "C" },
        new Product { Id = 6, Price = 250, Weight = 7, Category = "C" },
    };

    private static Dictionary<string, decimal> preferences = new()
    {
        { "A", 0.8m },
        { "B", 0.6m },
        { "C", 0.2m },
    };

    private static decimal budget = 700;

    private static int capacity = 15;

    public static Example1 GenerateInstance()
    {
        var shoppingList = new List<Product>();

        var remainBudget = budget;
        var remainCapacity = capacity;

        while (remainBudget > 0 && remainCapacity > 0)
        {
            var index = new Random().Next(products.Count);
            var product = products[index];

            remainBudget -= product.Price;
            remainCapacity -= product.Weight;

            shoppingList.Add(products[index]);
        }

        var result = new Example1(shoppingList.Select(s => s.Id).ToList(), products, preferences, budget, capacity);
        if (result.Fitness == -1)
        {
            result = new Example1(shoppingList.Select(s => s.Id).Take(shoppingList.Count - 1).ToList(), products, preferences, budget, capacity);
        }

        return result;
    }

    public static Example1 GenerateInstance(List<int> ids)
    {
        return new Example1(ids, products, preferences, budget, capacity);
    }
}

class Example1 : Individual
{
    private readonly List<Product> products;

    private readonly Dictionary<string, decimal> preferences;

    public decimal budget;

    public int capacity;

    public List<Product> ShoppingList
    {
        get
        {
            var ids = this.Gens.Select(g =>
            {
                var array = new int[1];
                g.CopyTo(array, 0);
                return array[0];
            }).ToList();

            return ids.Select(id => products.Find(p => p.Id == id)).Where(p => p != null).ToList();
        }
    }

    public decimal TotalPrice => ShoppingList.Sum(p => p.Price);

    public int TotalWeight => ShoppingList.Sum(p => p.Weight);

    public Example1(List<int> shoppingList, List<Product> products, Dictionary<string, decimal> preferences, decimal budget, int capacity)
    {
        this.products = products;
        this.preferences = preferences;
        this.budget = budget;
        this.capacity = capacity;

        this.Gens = shoppingList.Select(id => new BitArray(new int[] { id })).ToArray();
    }

    public override decimal Fitness
    {
        get
        {
            if (TotalPrice > budget || TotalWeight > capacity)
            {
                return -1;
            }
            else
            {
                var test = ShoppingList.Sum(s => budget / s.Price + capacity / s.Weight + preferences[s.Category]);
                var sumPrice = (budget - TotalPrice == 0 ? 1 : 1m / (budget - TotalPrice));
                var sumWeight = (capacity - TotalWeight == 0 ? 1 : 1m / (capacity - TotalWeight));
                //var sumPreference = ShoppingList.Sum(p => preferences[p.Category]) / this.ShoppingList.Count;

                return test * ShoppingList.Count;
            }

        }
    }

    public override void Mutation(int type)
    {
        var random = new Random();
        // Random Replacement
        var mutationIndex = random.Next(this.Gens.Count());

        if (type <= 50)
        {
            this.Gens[mutationIndex] = new BitArray(new int[] { random.Next(1, products.Count + 1) });
        }
        else
        {
            // Inversion Mutation
            this.Gens = this.Gens.Append(new BitArray(new int[] { random.Next(1, products.Count + 1) })).ToArray();
        }
    }

    public override Example1 Clone()
    {
        return new Example1(this.ShoppingList.Select(p => p.Id).ToList(), products, preferences, budget, capacity);
    }
}

class Individual
{
    public virtual void Mutation(int type)
    {

    }

    public virtual Individual Clone()
    {
        var clone = new Individual
        {
            Gens = this.Gens.ToArray()
        };

        return clone;
    }

    public virtual decimal Fitness { get; }

    public virtual BitArray[] Gens { get; set; }
}

class Population
{
    public List<Individual> Individuals { get; set; } = new();

    public Population Init(int populationSize)
    {
        var individuals = Enumerable.Range(0, populationSize).Select(i => Example1Utility.GenerateInstance()).ToList();

        this.Individuals.AddRange(individuals);

        return this;
    }

    public Individual GetIndividualByIndex(int index)
    {
        return this.Individuals[index];
    }

    public void RemoveIndividualByIndex(int index)
    {
        this.Individuals.RemoveAt(index);
    }

    public void AddIndividual(Individual individual)
    {
        this.Individuals.Add(individual);
    }

    public void AddIndividuals(List<Individual> individuals)
    {
        this.Individuals.AddRange(individuals);
    }
}


class GeneticAlgorithm
{
    public Individual GenerateRecommendations()
    {
        var result = default(Individual);

        try
        {
            // 初始化種群
            var population = new Population();
            population.Init(10);

            // 進行多個世代的演化
            for (var generation = 0; generation < 30; generation++)
            {
                // 選擇交配池
                var matingPool = SelectMatingPool(population);

                // 交配
                var offspring = Crossover(matingPool);

                // 突變
                offspring = Mutation(offspring);

                // 生成新的種群
                population.AddIndividuals(offspring.Individuals);

                var count = (int)(population.Individuals.Count * 0.1);
                population.Individuals.RemoveRange(population.Individuals.Count - count, count);

                //population.Individuals.RemoveAll(i => i.Fitness == -1);

                population.Individuals = population.Individuals.OrderByDescending(i => i.Fitness).ToList();
                //if (result == default || result.Fitness < population.Individuals.First().Fitness)
                //{
                //    result = Example1Utility.GenerateInstance();
                //    result.Gens = population.Individuals.First().Gens.ToArray();
                //}

                Console.WriteLine($"Fitness:{population.Individuals.First().Fitness}");
                Console.WriteLine($"{string.Join(",", ((Example1)population.Individuals.First()).ShoppingList.Select(x => x.Id))}");
            }

            return population.Individuals.First();
        }
        catch (Exception ex)
        {
            throw;
        }

        return result;
    }

    private Population SelectMatingPool(Population population)
    {
        var matingPool = new Population();
        var random = new Random();

        if (random.Next(1) == 0)
        {
            // Tournament Selection
            var count = population.Individuals.Count / 2;
            var randomIndividuals = population.Individuals.OrderBy(i => Guid.NewGuid()).ToList();

            for (int i = 0; i < count; i++)
            {
                var candidate = randomIndividuals.Skip(i * 2).Take(2).ToList();

                var winner = candidate[0].Fitness > candidate[1].Fitness ? candidate[0] : candidate[1];

                matingPool.AddIndividual(winner);
            }
        }
        else
        {
            // Rank Selection
            matingPool.AddIndividuals(population.Individuals.OrderBy(i => i.Fitness).Take(2).ToList());
        }

        return matingPool;
    }

    private Population Crossover(Population matingPool)
    {
        var offspring = new Population();
        var random = new Random();
        var index = random.Next(3);

        var count = matingPool.Individuals.Count / 2;
        for (var i = 0; i < count; i++)
        {
            var parent = matingPool.Individuals.Skip(i * 2).Take(2).ToList();

            var minCount = Math.Min(parent[0].Gens.Count(), parent[1].Gens.Count());
            var maxCount = Math.Max(parent[0].Gens.Count(), parent[1].Gens.Count());

            if (index == 0)
            {
                // Single-Point Crossover
                var crossoverIndex = random.Next(minCount);
                var chidden1 = parent[0].Clone();
                var chidden2 = parent[1].Clone();
                chidden1.Gens[crossoverIndex] = parent[1].Gens[crossoverIndex];
                chidden2.Gens[crossoverIndex] = parent[0].Gens[crossoverIndex];

                offspring.AddIndividual(chidden1);
                offspring.AddIndividual(chidden2);
            }
            else if (index == 1)
            {
                // Two-Point Crossover
                var crossoverIndex1 = random.Next(minCount);
                var chidden1 = parent[0].Clone();
                var chidden2 = parent[1].Clone();
                var tempGens1 = parent[0].Gens[0..crossoverIndex1].Concat(parent[1].Gens[crossoverIndex1..^0]);
                var tempGens2 = parent[1].Gens[0..crossoverIndex1].Concat(parent[0].Gens[crossoverIndex1..^0]);
                chidden1.Gens = tempGens1.ToArray();
                chidden2.Gens = tempGens2.ToArray();

                offspring.AddIndividual(chidden1);
                offspring.AddIndividual(chidden2);
            }
            else
            {
                // Uniform Crossover
                var chidden1 = parent[0].Clone();
                var chidden2 = parent[1].Clone();

                for (var crossoverIndex = 0; crossoverIndex < minCount; crossoverIndex++)
                {
                    var probability = random.Next(2);

                    if (probability == 1)
                    {
                        var temp = chidden1.Gens[crossoverIndex];
                        chidden1.Gens[crossoverIndex] = parent[1].Gens[crossoverIndex];
                        chidden2.Gens[crossoverIndex] = temp;
                    }
                }

                offspring.AddIndividual(chidden1);
                offspring.AddIndividual(chidden2);
            }
        }

        return offspring;
    }

    private Population Mutation(Population offspring)
    {
        var random = new Random();
        var mutationCount = random.Next(offspring.Individuals.Count);
        var randomIndividuals = offspring.Individuals.OrderBy(i => Guid.NewGuid()).ToList();

        foreach (var individual in randomIndividuals.Take(mutationCount))
        {
            individual.Mutation(random.Next(100));
        }

        return offspring;
    }
}

class Sample1 : Population<Product>
{
    private static readonly List<Product> products = new()
    {
        new Product { Id = 1, Price = 100, Weight = 2, Category = "A" },
        new Product { Id = 2, Price = 200, Weight = 3, Category = "A" },
        new Product { Id = 3, Price = 150, Weight = 5, Category = "B" },
        new Product { Id = 4, Price = 300, Weight = 4, Category = "B" },
        new Product { Id = 5, Price = 180, Weight = 6, Category = "C" },
        new Product { Id = 6, Price = 250, Weight = 7, Category = "C" }
    };

    private static Dictionary<string, decimal> preferences = new()
    {
        { "A", 0.8m },
        { "B", 0.6m },
        { "C", 0.2m }
    };

    private const decimal budget = 700;
    private const int capacity = 15;

    private int genesCount = 0;

    public Sample1()
    {
        var budgetCount = products.Select(p => (int)(budget / p.Price)).Max();
        var capacityCount = products.Select(p => capacity / p.Weight).Max();

        this.genesCount = Math.Max(budgetCount, capacityCount);
    }

    public override Individual<Product> GenerateInstance()
    {
        var result = new Individual<Product>();
        var remainBudget = budget;
        var remainCapacity = capacity;

        while (remainBudget > 0 && remainCapacity > 0)
        {
            var index = new Random().Next(products.Count);
            var product = products[index];

            remainBudget -= product.Price;
            remainCapacity -= product.Weight;

            result.Values.Add(products[index]);
        }

        result.Fitness = CalFitness(result);

        return result;
    }

    public override Product GenerateInstance1()
    {
        var index = new Random().Next(products.Count);

        return products[index];
    }

    public override decimal CalFitness(Individual<Product> individual)
    {
        if (individual.Values.Sum(i => i.Price) > budget || individual.Values.Sum(i => i.Weight) > capacity)
        {
            return -1;
        }
        else
        {
            return individual.Values.Sum(p => preferences[p.Category] * (budget / p.Price + capacity / p.Weight) / 2);
        }
    }
}

class Individual<T> where T : new()
{
    public List<T> Values { get; set; } = new List<T>();

    public decimal Fitness;
}

class Population<T> where T : new()
{
    public List<Individual<T>> Individuals { get; set; } = new();

    public Population<T> Init(int populationSize)
    {
        var individuals = Enumerable.Range(0, populationSize).Select(i => GenerateInstance()).ToList();

        this.Individuals.AddRange(individuals);

        return this;
    }

    public Individual<T> GetIndividualByIndex(int index)
    {
        var result = this.Individuals[index];

        this.Individuals.RemoveAt(index);

        return result;
    }

    public void AddIndividual(Individual<T> individual)
    {
        individual.Fitness = CalFitness(individual);

        this.Individuals.Add(individual);

        this.Individuals = this.Individuals.OrderByDescending(i => i.Fitness).ToList();
    }

    public void AddIndividuals(List<Individual<T>> individuals)
    {
        individuals.ForEach(i => i.Fitness = CalFitness(i));

        this.Individuals.AddRange(individuals);

        this.Individuals = this.Individuals.OrderByDescending(i => i.Fitness).ToList();
    }

    public virtual Individual<T> GenerateInstance()
    {
        return default;
    }

    public virtual T GenerateInstance1()
    {
        return default;
    }

    public virtual decimal CalFitness(Individual<T> individual)
    {
        return 1;
    }
}


class GeneticAlgorithm<T, T1>
    where T : Population<T1>, new()
    where T1 : new()
{
    public Individual<T1> GenerateRecommendations()
    {
        var result = default(Individual<T1>);

        try
        {
            // 初始化種群
            var population = new T();
            population.Init(10);

            // 進行多個世代的演化
            for (var generation = 0; generation < 100; generation++)
            {
                // 選擇交配池
                var matingPool = SelectMatingPool(population);

                // 交配
                var offspring = Crossover(matingPool);

                // 突變
                offspring = Mutation(offspring);

                // 生成新的種群
                population.AddIndividuals(offspring.Individuals);

                //var count = (int)(population.Individuals.Count * 0.2);
                //population.Individuals.RemoveRange(population.Individuals.Count - count, count);

                population.Individuals.RemoveAll(i => i.Fitness == -1);

                if (result == default || result.Fitness < population.Individuals.First().Fitness)
                {
                    var best = population.Individuals.First();
                    result = new Individual<T1>
                    {
                        Values = new List<T1>(best.Values),
                        Fitness = best.Fitness,
                    };
                }

                Console.WriteLine($"Fitness:{result.Fitness}");
            }

            return result;
        }
        catch (Exception ex)
        {
            throw;
        }

        return result;
    }

    private T SelectMatingPool(T population)
    {
        var clonePopulation = new T();
        clonePopulation.AddIndividuals(population.Individuals);

        var matingPool = new T();
        var random = new Random();

        if (random.Next(1) == 0)
        {
            // Tournament Selection
            var count = clonePopulation.Individuals.Count / 2;

            for (int i = 0; i < count; i++)
            {
                var candidate1 = clonePopulation.GetIndividualByIndex(random.Next(clonePopulation.Individuals.Count));
                var candidate2 = clonePopulation.GetIndividualByIndex(random.Next(clonePopulation.Individuals.Count));

                var winner = candidate1.Fitness > candidate2.Fitness ? candidate1 : candidate2;

                matingPool.AddIndividual(winner);
            }
        }
        else
        {
            // Rank Selection
            matingPool.AddIndividuals(clonePopulation.Individuals.OrderBy(i => i.Fitness).Take(2).ToList());
        }

        return matingPool;
    }


    private T Crossover(T matingPool)
    {
        var offspring = new T();
        var random = new Random();
        var index = random.Next(3);

        var count = matingPool.Individuals.Count / 2;
        for (var i = 0; i < count; i++)
        {
            var parent1 = matingPool.GetIndividualByIndex(random.Next(matingPool.Individuals.Count));
            var parent2 = matingPool.GetIndividualByIndex(random.Next(matingPool.Individuals.Count));
            var minCount = Math.Min(parent1.Values.Count, parent2.Values.Count);
            var maxCount = Math.Max(parent1.Values.Count, parent2.Values.Count);

            if (index == 0)
            {
                // Single-Point Crossover
                var crossoverIndex = random.Next(minCount);
                var temp = parent1.Values[crossoverIndex];
                parent1.Values[crossoverIndex] = parent2.Values[crossoverIndex];
                parent2.Values[crossoverIndex] = temp;

                offspring.AddIndividual(parent1);
                offspring.AddIndividual(parent2);
            }
            else if (index == 1)
            {
                // Two-Point Crossover
                var crossoverIndex = random.Next(minCount);
                var temp = parent1.Values[crossoverIndex];
                parent1.Values[crossoverIndex] = parent2.Values[crossoverIndex];
                parent2.Values[crossoverIndex] = temp;

                var tempIndex = 0;
                do
                {
                    tempIndex = random.Next(minCount);
                }
                while (crossoverIndex == tempIndex);

                crossoverIndex = tempIndex;
                temp = parent1.Values[crossoverIndex];
                parent1.Values[crossoverIndex] = parent2.Values[crossoverIndex];
                parent2.Values[crossoverIndex] = temp;

                offspring.AddIndividual(parent1);
                offspring.AddIndividual(parent2);
            }
            else
            {
                // Uniform Crossover
                for (var crossoverIndex = 0; crossoverIndex < minCount; crossoverIndex++)
                {
                    var probability = random.Next(2);

                    if (probability == 1)
                    {
                        var temp = parent1.Values[crossoverIndex];
                        parent1.Values[crossoverIndex] = parent2.Values[crossoverIndex];
                        parent2.Values[crossoverIndex] = temp;
                    }
                }

                offspring.AddIndividual(parent1);
                offspring.AddIndividual(parent2);
            }
        }

        return offspring;
    }

    private T Mutation(T offspring)
    {
        var random = new Random();
        var index = random.Next(2);

        foreach (var individual in offspring.Individuals)
        {
            if (index == 0)
            {
                // Random Replacement
                var mutationIndex = random.Next(individual.Values.Count);

                individual.Values[mutationIndex] = offspring.GenerateInstance1();
            }
            else
            {
                // Inversion Mutation
                //individual.
            }
        }

        return offspring;
    }
}