namespace CRMDev.Core.Entities
{
    public class Task : BaseClass
    {
        public Task(string name, string description)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description;
            IsCompleted = false;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsCompleted { get; private set; }

        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }
    }
}
