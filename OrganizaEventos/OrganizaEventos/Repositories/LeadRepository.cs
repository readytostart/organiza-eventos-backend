using System.Collections.Generic;
using System.Linq;
using OrganizaEventosApi.Models;

namespace OrganizaEventosApi.Repositories {
    public class LeadRepository : IDataAccess<MobLeeLead, string> {
        private readonly ApplicationContext _context;

        public LeadRepository(ApplicationContext context) {
            _context = context;
        }

        public int Add(MobLeeLead lead) {
            var resultado = 0;
            if (!VerifiqueSeExiste(lead.Email)) {
                try {
                    _context.Leads.Add(lead);
                    resultado = _context.SaveChanges();
                }
                catch {
                    resultado = 0;
                }
            }
            return resultado;
        }

        public MobLeeLead GetItem(string id) {
            var lead = _context.Leads.FirstOrDefault(l => l.Email == id);
            return lead;
        }

        public IEnumerable<MobLeeLead> GetItens() {
            var books = _context.Leads.ToList();
            return books;
        }

        private bool VerifiqueSeExiste(string id) {
            var lead = GetItem(id);
            return lead != null;
        }
    }
}