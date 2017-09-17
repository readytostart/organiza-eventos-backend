using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using OrganizaEventosApi.Extensions;
using OrganizaEventosApi.Models;
using OrganizaEventosApi.Repositories;

namespace OrganizaEventosApi.Controllers {
    [Route("api/[controller]")]
    public class LeadsController : Controller {
        private readonly IDataAccess<BlogLead, int> _repositorio;

        public LeadsController(IDataAccess<BlogLead, int> repositorio) {
            _repositorio = repositorio;
        }

        [HttpGet]
        public IEnumerable<BlogLead> Get() {
            return _repositorio.GetItens();
        }

        [HttpGet("{id}", Name = "GetLead")]
        public IActionResult Get(int id) {
            var item = _repositorio.GetItem(id);
            if (item == null) {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Post(string nome, string email) {
            var ipv4 = GetRequestIp();
            var lead = new BlogLead {
                Nome = nome,
                Email = email,
                IpV4 = ipv4,
                Data = DateTime.Now
            };
            var resultado = _repositorio.Add(lead);
            return RetorneResultadoDaOperacao(lead, resultado, "Não foi possível realizar o cadastro");
        }

        private static IActionResult RetorneResultadoDaOperacao(BlogLead lead, int resultado, string mensagem) {
            if (resultado == 1) {
                return new ObjectResult(lead);
            }
            return new JsonResult(new {
                status = false,
                mensagem
            });
        }

        public string GetRequestIp() {
            string ip = GetHeaderValueAs<string>("X-Forwarded-For").SplitCsv().FirstOrDefault();

            if (String.IsNullOrEmpty(ip)) {
                ip = GetHeaderValueAs<string>("REMOTE_ADDR");
            }

            if (String.IsNullOrEmpty(ip)) {
                ip = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress?.ToString();
            }

            if (String.IsNullOrEmpty(ip)) {
                ip = HttpContext.Connection.RemoteIpAddress.ToString();
            }

            return ip;
        }

        public T GetHeaderValueAs<T>(string header) {
            StringValues valores;

            if (HttpContext?.Request?.Headers?.TryGetValue(header, out valores) ?? false) {
                var valoresBrutos = valores.ToString();

                if (!String.IsNullOrEmpty(valoresBrutos)) {
                    return (T) Convert.ChangeType(valores.ToString(), typeof(T));
                }
            }
            return default(T);
        }
    }
}