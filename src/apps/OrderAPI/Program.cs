
using Microsoft.EntityFrameworkCore;
using Order.Application.Features.Commands.OrderRequests;
using Order.Domain.Aggregates.OrderAggregate.Entities;
using Order.Domain.Aggregates.OrderAggregate.Repositories;
using Order.Domain.Aggregates.OrderQuoteAggregate.Repositories;
using Order.Domain.Aggregates.OrderQuoteAggregate.Services;
using Order.Domain.Aggregates.OrderRequestAggregate.Entities;
using Order.Domain.Aggregates.OrderRequestAggregate.Repositories;
using Order.Domain.SeedWork;
using OrderAPI.Data;
using OrderAPI.Data.Repositories;

namespace OrderAPI
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      // Add services to the container.

      builder.Services.AddControllers();
      // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();

      builder.Services.AddDbContext<OrderContext>(opt =>
      {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("OrderDbWindowsConn"));
      });

      builder.Services.AddMediatR(opt =>
      {
        opt.RegisterServicesFromAssemblyContaining<OrderRequestCreateCommand>();
        opt.RegisterServicesFromAssemblyContaining<PurchaseOrderItem>();
      });

      builder.Services.AddScoped<IOrderRepository, EFOrderRepository>();
      builder.Services.AddScoped<IOrderRequestRepository, EFOrderRequestRepository>();
      builder.Services.AddScoped<IOrderQuoteRepository, EFOrderQouteRepository>();
      builder.Services.AddScoped<IUnitOfWork, OrderUnitOfWork>();
      builder.Services.AddScoped<RequestQuoteApprovalService>();

      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      app.UseHttpsRedirection();

      app.UseAuthorization();


      app.MapControllers();

      app.Run();
    }
  }
}
