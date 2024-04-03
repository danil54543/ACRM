using Microsoft.AspNetCore.Identity;

namespace ACRM.src.Domain.Entity
{
    public class Employer : IdentityUser
    {
        public List<Lead> Leads { get; set; }
        public List<Form> Forms { get; set; }
    }
}
