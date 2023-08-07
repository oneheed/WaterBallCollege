class Product
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public int Weight { get; set; }
    public string Category { get; set; }
}

Individual

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