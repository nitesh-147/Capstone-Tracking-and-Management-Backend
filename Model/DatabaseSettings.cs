namespace TrackingApp.Model
{
    public class DatabaseSettings
    {
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        public string? UsersCollectionName { get; set; }
        public string? OrdersCollectionName { get; set; }
        public string? OrderItemsCollectionName { get; set; }
        public string? ProductsCollectionName { get; set; }
        public string? CategoriesCollectionName { get; set; }
        public string? WarehousesCollectionName { get; set; }
        public string? CarriersCollectionName { get; set; }
        public string? ShippingMethodsCollectionName { get; set; }
        public string? ShipmentsCollectionName { get; set; }
        public string? NotificationsCollectionName { get; set; }
        public string? InventoriesCollectionName { get; set; }
    }
}
