using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamentoWeb.Utils
{
    public class Sessao
    {
        private readonly IHttpContextAccessor _http;
        public Sessao(IHttpContextAccessor http) => _http = http;
        private const string PAGAMENTO_ID = "PAGAMENTO_ID";
        public string BuscarPagamentoId()
        {
            if(_http.HttpContext.Session.GetString("PAGAMENTO_ID") == null)
            {
                _http.HttpContext.Session.SetString("PAGAMENTO_ID", Guid.NewGuid().ToString());
            }
            return _http.HttpContext.Session.GetString("PAGAMENTO_ID");
        }
    }
}
