using NerdStore.Core.DomainObjects.Dto;
using NerdStore.Pagamentos.Business.Entities;

namespace NerdStore.Pagamentos.Business.Interfaces
{
    public interface IPagamentoService
    {
        Task<Transacao> RealizarPagamentoPedido(PagamentoPedido pagamentoPedido);
    }
}
