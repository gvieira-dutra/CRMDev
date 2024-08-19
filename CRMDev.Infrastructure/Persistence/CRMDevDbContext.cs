using CRMDev.Core.Entities;
using CRMDev.Core.Enums;

namespace CRMDev.Infrastructure.Persistence
{
    public class CRMDevDbContext
    {
        public CRMDevDbContext()
        {

            FieldOrIndustries = new List<FieldOrIndustry>
            {
                new FieldOrIndustry(fieldName: "sales"),
                new FieldOrIndustry(fieldName: "marketing"),
                new FieldOrIndustry(fieldName: "information technology"),
                new FieldOrIndustry(fieldName: "healthcare"),
                new FieldOrIndustry(fieldName: "finance"),
                new FieldOrIndustry(fieldName: "education"),
                new FieldOrIndustry(fieldName: "manufacturing"),
                new FieldOrIndustry(fieldName: "construction"),
                new FieldOrIndustry(fieldName: "retail"),
                new FieldOrIndustry(fieldName: "hospitality"),
                new FieldOrIndustry(fieldName: "legal"),
                new FieldOrIndustry(fieldName: "human resources")
            };

            var emptyFieldOrIndustry = new FieldOrIndustry("");

            // Initialize contacts
            Contacts = new List<Contact>
            {
                

                new Contact(
                    name: "John Doe",
                    email: "john.doe@example.com",
                    phone: "555-1234",
                    cellPhone: "555-6789",
                    fieldOrIndustry: FieldOrIndustries.FirstOrDefault(f => f.FieldName == "sales") ?? emptyFieldOrIndustry,
                    position: "Manager",
                    address: "123 Elm Street, Springfield, IL"
                ),
                new Contact(
                    name: "Jane Smith",
                    email: "jane.smith@example.com",
                    phone: "555-5678",
                    cellPhone: "555-9876",
                    fieldOrIndustry: FieldOrIndustries.FirstOrDefault(f => f.FieldName == "marketing") ?? emptyFieldOrIndustry,
                    position: "Coordinator",
                    address: "456 Oak Avenue, Springfield, IL"
                ),
                new Contact(
                    name: "Alice Johnson",
                    email: "alice.johnson@example.com",
                    phone: "555-3456",
                    cellPhone: "555-6543",
                    fieldOrIndustry: FieldOrIndustries.FirstOrDefault(f => f.FieldName == "hospitality") ?? emptyFieldOrIndustry,
                    position: "Director",
                    address: "789 Pine Road, Springfield, IL"
                ),
                new Contact(
                    name: "Bob Brown",
                    email: "bob.brown@example.com",
                    phone: "555-8765",
                    cellPhone: "555-4321",
                    fieldOrIndustry: FieldOrIndustries.FirstOrDefault(f => f.FieldName == "finance") ?? emptyFieldOrIndustry,
                    position: "Tech Lead",
                    address: "101 Maple Lane, Springfield, IL"
                ),
                new Contact(
                    name: "Carol White",
                    email: "carol.white@example.com",
                    phone: "555-2468",
                    cellPhone: "555-8642",
                    fieldOrIndustry: FieldOrIndustries.FirstOrDefault(f => f.FieldName == "education") ?? emptyFieldOrIndustry,
                    position: "Account Manager",
                    address: "202 Birch Blvd, Springfield, IL"
                    )
            }; 

            Opportunities = new List<Opportunity>
        {
            new Opportunity(
                title: "CRM System Implementation",
                description: "Implementation of a new CRM system for better sales tracking.",
                deliveryEstimate: new DateTime(2024, 12, 15),
                estimative: 15000.00m,
                scope: "Full system implementation including training and support.",
                supportIncluded: true,
                stage: Stage.Connected,
                contactId: 1,
                contact: Contacts.ElementAt(0) // John Doe
            ),
            new Opportunity(
                title: "Website Redesign",
                description: "Redesign of the company's website to improve user experience.",
                deliveryEstimate: new DateTime(2024, 11, 30),
                estimative: 8000.00m,
                scope: "Redesign homepage and key landing pages.",
                supportIncluded: false,
                stage: Stage.SentProposition,
                contactId: 2,
                contact: Contacts.ElementAt(1) // Jane Smith
            ),
            new Opportunity(
                title: "Marketing Automation Tools",
                description: "Implementation of marketing automation tools to streamline campaigns.",
                deliveryEstimate: new DateTime(2025, 02, 20),
                estimative: 20000.00m,
                scope: "Tool integration, setup, and campaign training.",
                supportIncluded: true,
                stage: Stage.WaitingSignature,
                contactId: 1,
                contact: Contacts.ElementAt(0) // John Doe
            ),
            new Opportunity(
                title: "Employee Training Program",
                description: "Development and delivery of a comprehensive employee training program.",
                deliveryEstimate: new DateTime(2024, 10, 10),
                estimative: 5000.00m,
                scope: "Training for sales and support teams.",
                supportIncluded: true,
                stage: Stage.MeetingScheduled,
                contactId: 3,
                contact: Contacts.ElementAt(2) // Alice Johnson
            ),
            new Opportunity(
                title: "Customer Feedback System",
                description: "Design and implementation of a new customer feedback system.",
                deliveryEstimate: new DateTime(2024, 09, 15),
                estimative: 12000.00m,
                scope: "System design, development, and deployment.",
                supportIncluded: false,
                stage: Stage.PreQualified,
                contactId: 4,
                contact: Contacts.ElementAt(3) // Bob Brown
            )
        };
        }

        public ICollection<Contact> Contacts { get; set; }
        public ICollection<Opportunity> Opportunities { get; set; }

        public ICollection<FieldOrIndustry> FieldOrIndustries { get; set; }
    }
}
