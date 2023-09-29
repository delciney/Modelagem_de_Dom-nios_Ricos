using MediatR;
using NerdStore.Catalogo.Application.Services;
using NerdStore.Catalogo.Data.Repository;
using NerdStore.Catalogo.Data;
using NerdStore.Catalogo.Domain.Events;
using NerdStore.Catalogo.Domain.Repositories;
using NerdStore.Catalogo.Domain.Services;
using NerdStore.Vendas.Application.Commands;
using NerdStore.Vendas.Application.Handlers;
using NerdStore.Vendas.Domain.Repositories;
using NerdStore.Vendas.Data.Repository;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using NerdStore.Core.Messages.CommonMessages.IntegrationEvents;
using NerdStore.Vendas.Application.Events;
using NerdStore.Vendas.Data;
using NerdStore.Vendas.Application.Queries;
using Microsoft.IdentityModel.Protocols;
using NerdStore.Pagamentos.Business.Interfaces;
using NerdStore.Pagamentos.Data.Repository;
using NerdStore.Pagamentos.Business.Services;
using NerdStore.Pagamentos.AntiCorruption;
using NerdStore.Pagamentos.Data;
using NerdStore.Pagamentos.Business.Handlers;
using NerdStore.Pagamentos.Business.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace NerdStore.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region Core
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<INotificationHandler<DomainNotification>,
                DomainNotificationHandler>();
            #endregion

            #region Catalogo
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<CatalogoContext>();

            services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, 
                ProdutoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoIniciadoEvent>, 
                ProdutoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoProcessamentoCanceladoEvent>, 
                ProdutoEventHandler>();
            #endregion

            #region Vendas
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPedidoQueries, PedidoQueries>();
            services.AddScoped<VendasContext>();

            services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, 
                PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarItemPedidoCommand, bool>, 
                PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverItemPedidoCommand, bool>, 
                PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<AplicarVoucherPedidoCommand, bool>, 
                PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<IniciarPedidoCommand, bool>, 
                PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<FinalizarPedidoCommand, bool>, 
                PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<CancelarProcessamentoPedidoCommand, bool>, 
                PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<CancelarProcessamentoPedidoEstornarEstoqueCommand, bool>, 
                PedidoCommandHandler>();
            
            services.AddScoped<INotificationHandler<PedidoRascunhoIniciadoEvent>, 
                PedidoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoAtualizadoEvent>, 
                PedidoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoItemAdicionadoEvent>, 
                PedidoEventHandler>();
            services.AddScoped<INotificationHandler<PedidoEstoqueRejeitadoEvent>, 
                PedidoEventHandler>();
            services.AddScoped<INotificationHandler<PagamentoRealizadoEvent>, 
                PedidoEventHandler>();
            services.AddScoped<INotificationHandler<PagamentoRecusadoEvent>, 
                PedidoEventHandler>();
            #endregion

            #region Pagamento
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<IPagamentoService, PagamentoService>();
            services.AddScoped<IPagamentoCartaoCreditoFacade, PagamentoCartaoCreditoFacade>();
            services.AddScoped<IPayPalGateway, PayPalGateway>();
            services.AddScoped<IConfigurationManager, InternalConfigurationManager>();
            services.AddScoped<PagamentoContext>();

            services.AddScoped<INotificationHandler<PedidoEstoqueConfirmadoEvent>, PagamentoEventHandler>();
            #endregion
        }
    }
}
