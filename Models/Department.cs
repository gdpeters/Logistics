namespace Logistics.Models
{
    public class Department
    {
        public string Name { get; set; }
        public List<string>? PreferredToppings { get; set; } = new List<string>();
        public List<ToppingCombination>? ToppingCombinations { get; set; }
        public int? PreferredToppingCount { get; set; }
        private List<Employee> Employees { get; set; } = new List<Employee>();


        public Department(string name, List<Employee> employees)
        {
            Name = name;
            Employees = employees;
            ToppingCombinations = employees.Select(e => e.Toppings).Select(t => new ToppingCombination(t))?.ToList();

            SetPreferredToppingStats();
        }

        public int PizzaQty()
        {
            return (int) Math.Ceiling(Employees.Count() / 4.0);
        }

        public int Size()
        {
            return Employees.Count;
        }

        private void SetPreferredToppingStats()
        {
            var uniqueToppingCombinations = ToppingCombinations?.GroupBy(tc => tc.ToppingString)
                                                                .Select(g => new { g.Key, Votes = g.Count() } ).ToList();

            PreferredToppingCount = uniqueToppingCombinations?.MaxBy(c => c.Votes)?.Votes;
            PreferredToppings = uniqueToppingCombinations?.Where(a => a.Votes == PreferredToppingCount)
                                                          .Select(a => a.Key).ToList();
        }
    }
}
