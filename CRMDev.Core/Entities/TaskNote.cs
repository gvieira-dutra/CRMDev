using System.Text.Json.Serialization;

namespace CRMDev.Core.Entities
{
    public class TaskNote : BaseNote
    {
        public TaskNote() {}
        public TaskNote(Task task, string content) : base(content)
        {
            TaskId = task.Id;
            Task = task;
        }
        public int TaskId { get; private set; }
        [JsonIgnore]
        public Task Task { get; private set; }
    }
}
