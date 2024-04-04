using Microsoft.AspNetCore.Identity;

namespace ACRM.src.Domain.Entity
{
    public class Employer : IdentityUser<Guid>
    {
        public List<Lead> Leads { get; set; } = [];
        public List<Form> Forms { get; set; } = [];
        public List<Resource> Resources { get; set; } = [];
        public bool InWork { get; set; }

    }
}
