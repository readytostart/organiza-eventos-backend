using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using OrganizaEventosApi.Models;

namespace OrganizaEventosApi.Repositories {
    public class LeadRepository : IDataAccess<MobLeeLead, string> {
        private readonly ApplicationContext _context;
        private readonly ILogger _logger;

        public LeadRepository(ApplicationContext context, ILoggerFactory loggerFactory) {
            _context = context;
            _logger = loggerFactory.CreateLogger("LoggerCategory");
        }

        public int Add(MobLeeLead lead) {
            int resultado;
            if (!VerifiqueSeExiste(lead.Email)) {
                try {
                    _logger.LogInformation($"Salvando lead - Nome: {lead.Nome}, Email: {lead.Email}, IpV4: {lead.IpV4}, Data: {lead.Data}");
                    _context.Leads.Add(lead);
                    resultado = _context.SaveChanges();
                }
                catch (Exception ex) {
                    _logger.LogError($"Erro ao salvar lead: {ex.Message}");
                    _logger.LogCritical($"Nome: {lead.Nome}, Email: {lead.Email}, IpV4: {lead.IpV4}, Data: {lead.Data}");
                    resultado = 0;
                }
            }
            else {
                _logger.LogWarning($"Lead já cadastrado - Nome: {lead.Nome}, Email: {lead.Email}, IpV4: {lead.IpV4}, Data: {lead.Data}");
                resultado = 2;
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