namespace Logistics.Models
{
    public class PizzaStatistics
    {
        private List<string> UniqueDepartments { get; set; }   
        public List<Department> Departments { get; set; } = new List<Department>();
        public string ToppingToCount { get; set; } = string.Empty;
        public string DepartmentToFeed { get; set; } = string.Empty;

        public PizzaStatistics(List<Employee> employees)
        {
            UniqueDepartments = employees.Select(a => a.Department).Distinct().ToList();

            foreach (string name in UniqueDepartments)
            {
                Departments.Add(new Department(name, employees.Where(e => e.Department.Equals(name)).ToList()));
            }
        }

        public List<string> DepartmentsWithMostVotes(string topping)
        {
            var departmentNames = new List<string>();
            int? topCount = 0;

            foreach(var department in Departments)
            {
                var departmentVotes = department.ToppingCombinations?.Where(e => e.Toppings.Contains(topping))?.Count();

                departmentNames = departmentVotes > topCount ? new List<string>() : departmentNames;
                
                if (departmentVotes >= topCount)
                {
                    departmentNames.Add(department.Name);
                }

                topCount = departmentVotes > topCount ? departmentVotes : topCount;
            }

            return departmentNames;
        }

        public Department? GetDepartment(string name)
        {
            return Departments.Where(a => a.Name.ToLower().Equals(name.ToLower())).Single();
        }
    }
}
