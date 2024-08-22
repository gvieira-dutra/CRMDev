namespace CRMDev.Core.Entities
{
    public class Stage(string name, List<Task> defaultTasks) : BaseClass
    {
        public string Name { get; private set; } = name;
        public List<Task> Tasks { get; private set; } = defaultTasks;

        public string StageSummary { get; private set; }

        public void CreateStageSummary()
        {
            //TasksSummary = 
        }
    }   
}
