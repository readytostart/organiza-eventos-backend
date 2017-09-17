using System.Collections.Generic;
using System.Linq;
using OrganizaEventosApi.Models;

namespace OrganizaEventosApi.Repositories {
    public class LeadRepository : IDataAccess<BlogLead, int> {
        private readonly ApplicationContext _context;

        public LeadRepository(ApplicationContext context) {
            _context = context;
        }

        public int Add(BlogLead lead) {
            var resultado = 0;
            if (!VerifiqueSeExiste(lead.Id)) {
                _context.Leads.Add(lead);
                resultado = _context.SaveChanges();                
            }
            return resultado;
        }

        public BlogLead GetItem(int id) {
            var lead = _context.Leads.FirstOrDefault(l => l.Id == id);
            return lead;
        }

        public IEnumerable<BlogLead> GetItens() {
            var books = _context.Leads.ToList();
            return books;
        }

        private bool VerifiqueSeExiste(int id) {
            var lead = GetItem(id);
            return lead != null;
        }
    }
}