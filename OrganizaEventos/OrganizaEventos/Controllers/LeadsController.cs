using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using OrganizaEventosApi.Extensions;
using OrganizaEventosApi.Models;
using OrganizaEventosApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace OrganizaEventosApi.Controllers{
    [Route("api/[controller]/[action]")]
    public class LeadsController : Controller {
        private readonly IDataAccess<MobLeeLead, string> _repositorio;

        public LeadsController(IDataAccess<MobLeeLead, string> repositorio) {
            _repositorio = repositorio;
        }

        [HttpGet("{email}", Name = "getleads")]
        public IEnumerable<MobLeeLead> Get(string email) {
            return email != "organizaeventofloripa@gmail.com" ? new List<MobLeeLead>() : _repositorio.GetItens();
        }

        [HttpPost]        
        public IActionResult Post(string nome, string email) {
            try {
                if (!ValideNome(nome)) {
                    return RetorneResultadoDaOperacao(3);
                }

                if (!ValideEmail(email)) {
                    return RetorneResultadoDaOperacao(4);
                }

                var resultado = SaveLead(nome, email);
                return RetorneResultadoDaOperacao(resultado);
            }
            catch {
                return RetorneResultadoDaOperacao(0); ;
            }

        }

        [HttpPost]
        public IActionResult PostFromBody([FromBody] MobLeeLead lead) {
            var email = lead.Email;
            var nome = lead.Nome;
            try {
                if (!ValideEmail(email)) {
                    return new JsonResult(new {Sucesso = false, Mensagem = "E-mail inválido."});
                }

                if (!ValideNome(nome)) {
                    return new JsonResult(new {Sucesso = false, Mensagem = "Nome inválido."});
                }

                SaveLead(nome, email);
                return new JsonResult(new {Sucesso = true, Mensagem = "Operação realizada."});
            }
            catch {
                return new JsonResult(new {Sucesso = false, Mensagem = "Não foi possível realizar o cadastro."});
            }
        }

        private int SaveLead(string nome, string email) {
            var ipv4 = GetRequestIp();
            var lead = new MobLeeLead {
                Nome = nome,
                Email = email,
                IpV4 = ipv4,
                Data = DateTime.Now
            };
            var resultado = _repositorio.Add(lead);
            return resultado;
        }

        public string GetRequestIp() {
            try {
                string ip = HttpContext.Connection.RemoteIpAddress.ToString();

                if (String.IsNullOrEmpty(ip)) {
                    ip = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress?.ToString();
                }

                if (String.IsNullOrEmpty(ip)) {
                    ip = GetHeaderValueAs<string>("REMOTE_ADDR");
                }

                if (String.IsNullOrEmpty(ip)) {
                    ip = GetHeaderValueAs<string>("X-Forwarded-For").SplitCsv().FirstOrDefault();
                }

                return ip;
            }
            catch {
                return ":::";
            }
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

        private static bool ValideNome(string nome) {
            if (String.IsNullOrEmpty(nome)) {
                return false;
            }
            var partes = nome.Split(' ');
            if (partes.Length < 2) {
                return false;
            }
            if (partes[0].Length < 2) {
                return false;
            }
            if (partes[1].Length < 2) {
                return false;
            }
            return true;
        }

        private static bool ValideEmail(string email) {
            Regex regExpEmail = new Regex("^[A-Za-z0-9](([_.-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([.-]?[a-zA-Z0-9]+)*)([.][A-Za-z]{2,4})$");
            Match match = regExpEmail.Match(email);
            return match.Success;
        }

        private static RedirectResult RetorneResultadoDaOperacao(int resultado) {
            switch (resultado) {
                case 0://Erro não tratado
                    return new RedirectResult(
                        @"https://www.organizaevento.blog.br/landing-page/?error=Tivemos%20um%20problema.%20Realize%20o%20cadastro%20novamente.");
                case 1://Sucesso no cadastro do lead
                    return new RedirectResult(
                        @"https://www.organizaevento.blog.br/landing-page-success/");
                case 2://Email duplicado
                    return new RedirectResult(
                        @"https://www.organizaevento.blog.br/landing-page/?error=Email%20j%C3%A1%20cadastrado.");
                case 3://Nome incompleto
                    return new RedirectResult(
                        @"https://www.organizaevento.blog.br/landing-page/?error=Nome%20est%C3%A1%20incompleto.%20Informe%20nome%20e%20sobrenome.");
                case 4://E-mail inválido
                    return new RedirectResult(
                        @"https://www.organizaevento.blog.br/landing-page/?error=E-mail%20inv%C3%A1lido%20Informe%20um%20e-mail%20no%20formato:%20xxx@xxx.xxx.");
                default:
                    return new RedirectResult(
                        @"https://www.organizaevento.blog.br/landing-page/?error=Ops.%20Tivemos%20um%20problema.%20Realize%20o%20cadastro%20novamente.");
            }
        }
    }
}