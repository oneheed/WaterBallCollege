// See https://aka.ms/new-console-template for more information
//List<Product> products = new List<Product>()
//{
//    new Product { Id = 1, Price = 100, Weight = 2, Category = "A" },
//    new Product { Id = 2, Price = 200, Weight = 3, Category = "A" },
//    new Product { Id = 3, Price = 150, Weight = 5, Category = "B" },
//    new Product { Id = 4, Price = 300, Weight = 4, Category = "B" },
//    new Product { Id = 5, Price = 180, Weight = 6, Category = "C" },
//    new Product { Id = 6, Price = 250, Weight = 7, Category = "C" }
//};

//decimal budget = 700;
//int capacity = 15;
//Dictionary<string, decimal> preferences = new Dictionary<string, decimal>()
//{
//    { "A", 0.8m },
//    { "B", 0.6m },
//    { "C", 0.2m }
//};

//GeneticAlgorithm geneticAlgorithm = new GeneticAlgorithm(products, budget, capacity, preferences);
//List<Product> recommendations = geneticAlgorithm.GenerateRecommendations();

//Console.WriteLine("購買推薦清單：");
//foreach (Product product in recommendations)
//{
//    Console.WriteLine("產品 " + product.Id);
//}

//var geneticAlgorithm = new GeneticAlgorithm<Sample1, Product>();

//var result = geneticAlgorithm.GenerateRecommendations();

//Console.WriteLine($"購買推薦清單：{result.Values.Sum(r => r.Price)}, {result.Values.Sum(r => r.Weight)}, {result.Fitness}");
//foreach (var product in result.Values)
//{
//    Console.WriteLine("產品 " + product.Id);
//}

//Console.ReadLine();
