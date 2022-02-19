 namespace Logistics.Models
{
    public class Employee
    {
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public List<string> Toppings { get; set; } = new List<string>();
    }
}
