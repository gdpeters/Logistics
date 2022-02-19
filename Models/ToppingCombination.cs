namespace Logistics.Models
{
    public class ToppingCombination
    {
        public List<string> Toppings { get; set; } = new List<string>();
        public string ToppingString => string.Join(", ", Toppings);


        public ToppingCombination(List<string> toppings)
        {
            Toppings = toppings.Select(t => t.ToLower()).OrderBy(t => t).ToList();    
        }
    }
}
