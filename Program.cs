using TrackingApp.Model;
using TrackingApp.Services.CarrierService;
using TrackingApp.Services.CategoryService;
using TrackingApp.Services.InventoryService;
using TrackingApp.Services.NotificationService;
using TrackingApp.Services.OrderItemService;
using TrackingApp.Services.OrderService;
using TrackingApp.Services.ProductService;
using TrackingApp.Services.ShipmentService;
using TrackingApp.Services.ShippingMethodService;
using TrackingApp.Services.UserService;
using TrackingApp.Services.WarehouseService;

namespace TrackingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Adding the made comp.
            //User
            builder.Services.Configure<DatabaseSettings>(
                builder.Configuration.GetSection("MyDb"));
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IOrderService, OrderService>();
            builder.Services.AddTransient<ICarrierService, CarrierService>();
            builder.Services.AddTransient<ICategoryService, CategoryService>();
            builder.Services.AddTransient<INotificationService, NotificationService>();
            builder.Services.AddTransient<IOrderItemService, OrderItemService>();
            builder.Services.AddTransient<IProductService, ProductService>();
            builder.Services.AddTransient<IShipmentService, ShipmentService>();
            builder.Services.AddTransient<IShipmentMethodService, ShipmentMethodService>();
            builder.Services.AddTransient<IWarehouseService, WarehouseService>();
            builder.Services.AddTransient<IInventoryService, InventoryService>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(opt => opt.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}