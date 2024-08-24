using System.Text.Json.Serialization;

namespace CRMDev.Core.Entities
{
    public class Task : BaseClass
    {
        public Task() {}
        public Task(string name, string description)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description;
            IsCompleted = false;
            TaskNotes = new List<TaskNote>();
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsCompleted { get; private set; }
        public List<TaskNote> TaskNotes { get; private set; }
        [JsonIgnore]
        public Stage Stage { get; private set; }
        public int StageId { get; private set; }

        public void AddTaskNote(TaskNote note)
        {
            TaskNotes.Add(note);
        }

        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }
    }
}
