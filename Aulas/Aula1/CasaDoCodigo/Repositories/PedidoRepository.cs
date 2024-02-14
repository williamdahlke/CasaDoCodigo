using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Http;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace CasaDoCodigo.Repositories
{
    public interface IPedidoRepository
    {
        Pedido getPedido();
    }
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor contextAcessor;

        public PedidoRepository(ApplicationContext context,
                                IHttpContextAccessor contextAccessor) : base(context)
        {
            this.contextAcessor = contextAccessor;
        }

        public Pedido getPedido()
        {
            var pedidoId = GetPedidoId();
            var pedido = dbset.Where(p => p.Id == pedidoId).SingleOrDefault();

            if (pedido == null)
            {
                pedido = new Pedido();
                dbset.Add(pedido);
                _context.SaveChanges();
            }

            return pedido;
        }

        private int? GetPedidoId()
        {
            return contextAcessor.HttpContext.Session.GetInt32("pedidoId");
        }

        private void SetPedidoId(int pedidoId)
        {
            contextAcessor.HttpContext.Session.SetInt32("pedidoId", pedidoId);
        }
    }
}
