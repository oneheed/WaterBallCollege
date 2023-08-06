class Product
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public int Weight { get; set; }
    public string Category { get; set; }
}

public class Individual
{
    public double Fitness;
}

class Population
{
    public List<Individual> Individuals { get; set; } = new();

    public Population Init(int populationSize)
    {
        var individuals = Enumerable.Range(0, populationSize).Select(i => new Individual());

        this.Individuals.AddRange(individuals); // Todo:

        return this;
    }

    public Individual GetIndividualByIndex(int index)
    {
        var result = this.Individuals[index];

        this.Individuals.RemoveAt(index);

        return result;
    }

    public void AddIndividual(Individual individual)
    {
        this.Individuals.Add(individual);
    }

    internal void AddIndividuals(List<Individual> individuals)
    {
        this.Individuals.AddRange(individuals);
    }
}


class GeneticAlgorithm
{
    private List<Product> products;
    private decimal budget;
    private int capacity;
    private Dictionary<string, decimal> preferences;

    public GeneticAlgorithm(List<Product> products, decimal budget, int capacity, Dictionary<string, decimal> preferences)
    {
        this.products = products;
        this.budget = budget;
        this.capacity = capacity;
        this.preferences = preferences;
    }

    public List<Product> GenerateRecommendations()
    {
        // 初始化種群
        var population = new Population().Init(10);

        // 進行多個世代的演化
        for (var generation = 0; generation < 10; generation++)
        {
            // 選擇交配池
            var matingPool = SelectMatingPool(population);

            // 交配和突變
            var offspring = Crossover(matingPool);

            // 生成新的種群
            population.AddIndividuals(offspring.Individuals);
        }

        // 選擇最優解
        var maxFitness = decimal.MinValue;
        var maxIndex = -1;

        for (int i = 0; i < population.Count; i++)
        {
            var fitness = CalculateFitnessValue(population[i]);

            if (fitness > maxFitness)
            {
                maxFitness = fitness;
                maxIndex = i;
            }
        }

        return population[maxIndex];
    }

    private Population SelectMatingPool(Population population)
    {
        var matingPool = new Population();
        var random = new Random();

        if (random.Next(1) == 0)
        {
            // Tournament Selection
            var count = population.Individuals.Count / 2;

            for (int i = 0; i < count; i++)
            {
                var candidate1 = population.GetIndividualByIndex(random.Next(0, population.Individuals.Count - 1));
                var candidate2 = population.GetIndividualByIndex(random.Next(0, population.Individuals.Count - 1));

                var winner = candidate1.Fitness > candidate2.Fitness ? candidate1 : candidate2;

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
        var population = new Population();
        var random = new Random();
        var index = random.Next(2);

        if (index == 0)
        {
            // Single-Point Crossover
        }
        else if (index == 1)
        {
            // Two-Point Crossover
        }
        else
        {
            // Uniform Crossover
        }
    }


    private int RouletteWheelSelection(List<decimal> fitnessValues)
    {
        var totalFitness = 0m;

        foreach (var fitness in fitnessValues)
        {
            totalFitness += fitness;
        }

        var randomValue = (decimal)(new Random().NextDouble()) * totalFitness;
        var partialSum = 0m;

        for (var i = 0; i < fitnessValues.Count; i++)
        {
            partialSum += fitnessValues[i];

            if (partialSum >= randomValue)
            {
                return i;
            }
        }

        return fitnessValues.Count - 1;
    }

    private List<List<Product>> Breed(List<List<Product>> matingPool)
    {
        List<List<Product>> offspring = new List<List<Product>>();

        try
        {
            for (int i = 0; i < matingPool.Count - 1; i += 2)
            {
                List<Product> parent1 = matingPool[i];
                List<Product> parent2 = matingPool[i + 1];

                // 使用交叉操作產生子代
                List<Product> child = Crossover(parent1, parent2);

                // 使用突變操作引入變異
                Mutate(child);

                offspring.Add(child);
            }
        }
        catch (Exception)
        {
            throw;
        }

        return offspring;
    }

    private List<Product> Crossover(List<Product> parent1, List<Product> parent2)
    {
        int crossoverPoint = new Random().Next(1, Math.Min(parent1.Count, parent2.Count));
        List<Product> child = new List<Product>();

        for (int i = 0; i < crossoverPoint; i++)
        {
            child.Add(parent1[i]);
        }

        for (int i = crossoverPoint; i < parent2.Count; i++)
        {
            if (!child.Contains(parent2[i]) && IsInBudget(child, parent2[i]) && IsWithinCapacity(child, parent2[i]))
            {
                child.Add(parent2[i]);
            }
        }

        return child;
    }

    private void Mutate(List<Product> individual)
    {
        double mutationRate = 0.1;

        for (int i = 0; i < individual.Count; i++)
        {
            double randomValue = new Random().NextDouble();

            if (randomValue < mutationRate)
            {
                Product mutatedProduct = products[new Random().Next(products.Count)];

                if (!individual.Contains(mutatedProduct) && IsInBudget(individual, mutatedProduct) && IsWithinCapacity(individual, mutatedProduct))
                {
                    individual[i] = mutatedProduct;
                }
            }
        }
    }

    private List<List<Product>> CreateNewPopulation(List<List<Product>> population, List<List<Product>> offspring)
    {
        List<List<Product>> newPopulation = new List<List<Product>>();

        newPopulation.AddRange(population);
        newPopulation.AddRange(offspring);

        return newPopulation;
    }

    private bool IsInBudget(List<Product> individual, Product product)
    {
        decimal totalCost = 0;

        foreach (Product p in individual)
        {
            totalCost += p.Price;
        }

        return totalCost + product.Price <= budget;
    }

    private bool IsWithinCapacity(List<Product> individual, Product product)
    {
        int totalWeight = 0;

        foreach (Product p in individual)
        {
            totalWeight += p.Weight;
        }

        return totalWeight + product.Weight <= capacity;
    }

    private decimal GetPreference(Product product)
    {
        if (preferences.ContainsKey(product.Category))
        {
            return preferences[product.Category];
        }

        return 0;
    }
}