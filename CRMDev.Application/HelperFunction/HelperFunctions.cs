using CRMDev.Application.ViewModels;
using CRMDev.Core.Entities;
using CRMDev.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace CRMDev.Application.HelperFunction
{
    public class HelperFunctions : IHelperFunctions
    {
        private readonly HttpClient _httpClient;
        public HelperFunctions(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApiClient");
        }
        public async Task<OpportunityDetailVM> CreateOpportunityDetailVM(CRMDevDbContext _dbContext, int id)
        {
            var opportunity = await _dbContext.Opportunities
                .Include(s => s.Stages)
                    .ThenInclude(t => t.Tasks)
                    .ThenInclude(t => t.TaskNotes)
                .Include(c => c.Contact)
                .SingleOrDefaultAsync(o => o.Id == id);

            if (opportunity != null)
            {
                var opportunityVM = new OpportunityDetailVM(
                    opportunity.Title,
                    opportunity.Description,
                    opportunity.DeliveryEstimate,
                    opportunity.Estimative,
                    opportunity.Scope,
                    opportunity.SupportIncluded,
                    opportunity.Status,
                    opportunity.ReasonForLostDeal,
                    opportunity.Stages,
                    opportunity.ContactId,
                    opportunity.Stages[opportunity.CurrentStageTracker].Name.ToString() ?? "N/A",
                    opportunity.Stages[opportunity.CurrentStageTracker].Tasks[opportunity.CurrentTaskTracker].Name.ToString() ?? "N/A",
                    opportunity.Stages[opportunity.CurrentStageTracker].Tasks[opportunity.CurrentTaskTracker].Description.ToString() ?? "N/A"

                );

                return opportunityVM;
            }
            return null;

        }

        public async Task<ContactDetailVM> CreateContactDetailVM(CRMDevDbContext _dbContext, int id)
        {
            var contact = await _dbContext.Contacts
                .Include(c => c.FieldOrIndustry)
                .Include(c => c.Notes)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (contact != null)
            {

                var contactVM = new ContactDetailVM(
                    contact.Name,
                    contact.Email,
                    contact.Phone,
                    contact.CellPhone,
                    contact.FieldOrIndustry.FieldName ?? "N/A",
                    contact.Position,
                    contact.Address,
                    contact.IsActive.ToString(),
                    contact.ContactNotesSummary ?? "N/A",
                    contact.Notes
               );

                return contactVM;
            }

            return null;
        }

        public async Task<FieldOrIndustryVM> CreateFieldOrIndustryVM(CRMDevDbContext _dbContext, int id)
        {

            var field = await _dbContext.FieldOrIndustries
                .SingleOrDefaultAsync(f => f.Id == id);

            if (field != null)
            {
                var fieldVM = new FieldOrIndustryVM(
                    field.FieldName,
                    field.Description
                );

                return fieldVM;
            }

            return null;

        }

        public async Task<string> CreateContactNotesSummary(List<ContactNote> notes)
        {
            // Create the prompt with the notes
            var requestContent = 
                "Please, make one short sentence summary from the notes below. The summary must contain: " +
                "1 - Information about what the client wants " +
                "2 - The current stage of the project." +
                "Just give me back a summary, no headers or introductions, go straight to the point\n";

            foreach (var note in notes)
            {
                requestContent += note.Content + "\n";
            }

            // Create the request object (matching the format in the curl command)
            var requestData = new
            {
                model = "llama3.1",
                prompt = requestContent,
                stream = false
            };

            // Serialize the object to JSON
            var json = JsonSerializer.Serialize(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send the POST request
            var response = await _httpClient.PostAsync("", content);

            // Ensure the response is successful
            if (!response.IsSuccessStatusCode)
            {
                // Handle error (log, throw exception, etc.)
                throw new HttpRequestException($"Error: {response.StatusCode}");
            }

            // Read and return the response content as a string
            var responseValue = await response.Content.ReadAsStringAsync();
            var responseString = JsonDocument.Parse(responseValue).RootElement.GetProperty("response").GetString();

            return responseString; 
        }
    }
}
