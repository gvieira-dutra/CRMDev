using System.Text.Json.Serialization;

namespace CRMDev.Core.Entities
{
    public class Stage : BaseClass
    {
        public Stage(string name, List<Task> defaultTasks) : base()
        {
            Name = name;
            Tasks = defaultTasks;
        }
        public Stage() : base() {}
        public string Name { get; private set; }
        public List<Task> Tasks { get; private set; }

        [JsonIgnore]
        public Opportunity Opportunity { get; private set; }
        public int OpportunityId { get; private set; }

        public string StageSummary { get; private set; }

        public void CreateStageSummary()
        {
            //TasksSummary = 
        }
    }   
}
