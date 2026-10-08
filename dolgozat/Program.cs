namespace dolgozat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Auto> autos = new List<Auto>()
{
                new Auto("Toyota", "Corolla",140,"Nagy Peter"){Rating = 8.7},
                new Auto("BMW", "330i", 245, "Kiss Adam"){Rating = 9.1},
                new Auto("Tesla", "Model 3", 410, "Zsár Dániel"){Rating = 4.3},
                new Auto("Honda", "Civic", 220, "Zsár Dániel") { Rating = 7.3 },
                new Auto("Toyota", "Camry", 218, "Kiss Adam") { Rating = 8.8 },
                new Auto("BMW", "520i", 208, "Szabo David") { Rating = 8.9 },
                new Auto("Ford", "Mustang", 450, "Szabo David") { Rating = 9.2 }
            };

            autos[0].SetAverageConsumption(5.8);
            autos[1].SetAverageConsumption(7.2);
            autos[2].SetAverageConsumption(0.4);
            autos[3].SetAverageConsumption(10.2);
            autos[4].SetAverageConsumption(6.4);
            autos[5].SetAverageConsumption(6.8);
            autos[6].SetAverageConsumption(10.5);

            autos[0].SetPrice(9500000);
            autos[1].SetPrice(18500000);
            autos[2].SetPrice(9000000);
            autos[3].SetPrice(2000000);
            autos[4].SetPrice(14500000);
            autos[5].SetPrice(22500000);
            autos[6].SetPrice(24000000);

            //1
            Console.WriteLine(autos.Where(x => x.Brand == "Toyota").Count());
            Console.WriteLine("-------------------------------------------------------------------------");
            //2
            Console.WriteLine(autos.Sum(x => x.GetPrice()));
            Console.WriteLine("-------------------------------------------------------------------------");

            //3
            Console.WriteLine(autos.Where(x => x.Brand == "BMW").Average(x => x.Hp));
            Console.WriteLine("-------------------------------------------------------------------------");

            //4
            Console.WriteLine(autos.OrderBy(x => x.GetPrice()).Select(x => x.Type).First());
            Console.WriteLine("-------------------------------------------------------------------------");

            //5
            autos.Select(x => x.Brand).Distinct().ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine("-------------------------------------------------------------------------");

            //6
            autos.GroupBy(x => x.Brand).ToDictionary(x => x.Key, x => x.Count()).ToList().ForEach(x => Console.WriteLine(x.Key + " " +  x.Value));
            Console.WriteLine("-------------------------------------------------------------------------");

            //7
            autos.GroupBy(x => x.Owner).ToDictionary(x => x.Key, x => x.Sum(x => x.GetPrice())).ToList().ForEach(x => Console.WriteLine(x.Key + " " + x.Value));
            Console.WriteLine("-------------------------------------------------------------------------");

            //8
            autos.GroupBy(x => x.Brand).ToDictionary(x => x.Key, x => x.Average(x => x.Rating)).ToList().ForEach(x => Console.WriteLine(x.Key + " " + x.Value));
            Console.WriteLine("-------------------------------------------------------------------------");

            //9
            autos.GroupBy(x => x.Brand).ToDictionary(x => x.Key, x => x.OrderByDescending(x => x.Rating).Select(x => x.Type).First()).ToList().ForEach(x => Console.WriteLine(x.Key + " " + x.Value));
            Console.WriteLine("-------------------------------------------------------------------------");

            //10
            autos.GroupBy(x => x.Owner).ToDictionary(x => x.Key, x => x.OrderByDescending(x => x.GetPrice()).Select(x => x.Type).First()).ToList().ForEach(x => Console.WriteLine(x.Key + " " + x.Value));
            Console.WriteLine("-------------------------------------------------------------------------");

            //11
            autos.Where(x => x.Rating >= 8.8).GroupBy(x => x.Brand).ToDictionary(x => x.Key, x => x.Average(x =>x.GetPrice())).ToList().ForEach(x => Console.WriteLine(x.Key + " " + x.Value));
            Console.WriteLine("-------------------------------------------------------------------------");

            //12
            Console.WriteLine(autos.GroupBy(x => x.Owner).OrderByDescending(x => x.Average(y => y.GetPrice())).ToDictionary(x => x.Key, x => x.Average(y => y.GetPrice())).First().Key);

        }
    }
}
