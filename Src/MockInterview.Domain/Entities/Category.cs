namespace MockInterview.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Employee> Specialist { get; set; }
    }
}
