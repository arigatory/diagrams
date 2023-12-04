using CarvedRock.DataAccess.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq.Expressions;
using System.Text;
var _dbContext = new CarvedRockContext();

#region Module 3
/* SHADOW PROPERTIES */
//var customer = _dbContext
//    .Customers
//    .AsTracking()
//    .First();

//var checksum = (byte[])_dbContext.Entry(customer).Property("Checksum").CurrentValue;

//var checksum2 = _dbContext
//    .Customers
//    .AsNoTracking()
//    .Select(c => EF.Property<byte[]>(c, "Checksum"))
//    .First();

//var hexString = BitConverter.ToString(checksum);

// This will not work for a computed column, but would work for any ordinary column 
//var newChecksum = Encoding.ASCII.GetBytes("ThisWillNotBeSaved");
//_dbContext.Entry(customer).Property("Checksum").CurrentValue = newChecksum;
//_dbContext.SaveChanges();

/* INDEXER PROPERTIES */
//var customer = _dbContext
//    .Customers
//    .AsNoTracking()
//    .First();

//var lastUpdatedDate = (DateTime)customer["LastUpdated"];
//var consumerType = (string)customer["ConsumerType"];

//_dbContext.Attach(customer);

//customer["LastUpdated"] = new DateTime(2022, 1, 1);
//customer["ConsumerType"] = "Big spender";
//customer["NotDefined"] = "This will not be saved on the database";

//_dbContext.SaveChanges();

//var updatedCustomer = _dbContext
//    .Customers
//    .AsNoTracking()
//    .Select(c => new
//    {
//        c.Id,
//        LastUpdated = EF.Property<DateTime>(c, "LastUpdated"),
//        ConsumerType = EF.Property<string>(c, "ConsumerType")
//    })
//    .First();

//customer["LastUpdated"] = new DateTime(2022, 12, 31);
//_dbContext.SaveChanges();

//customer = _dbContext
//    .Customers
//    .AsNoTracking()
//    .First();

/* PROPERTY BAGS */
//var newTag = new Dictionary<string, object>
//{
//    { "CustomerId", 4 },
//    { "Nickname", "SomethingFunny" },
//    { "DiscountRate", 10 },
//    { "NotDefined", "Will not be saved" }
//};

//_dbContext.Tags.Add(newTag);
//_dbContext.SaveChanges();

//var tag = _dbContext.Tags.FirstOrDefault();

//newTag["Nickname"] = "SomethingFunnier";
//_dbContext.SaveChanges();

/* OWNED ENTITY TYPES */
//var customer = _dbContext
//    .Customers
//    .First();

//customer.BillToAddress = new Address { Street = "Glendale Boulevard", City = "Los Angeles", Country = "United States" };
//customer.ShipToAddress = new Address { Street = "Hollywood Boulevard", City = "Los Angeles", Country = "United States" };

//_dbContext.SaveChanges();

//customer = _dbContext
//    .Customers
//    .First();

/* VALUE CONVERSIONS */
//var customer = _dbContext
//    .Customers
//    .First();

//customer.CustomerStatus = Status.Active;
//_dbContext.SaveChanges();

#endregion
#region Module 4
/* STORED PROCEDURES */
//var orders = _dbContext
//    .Orders
//    .FromSqlInterpolated($"GetOrders")
//    .ToList();

//var paramCustomerOrderCount = new SqlParameter
//{
//    ParameterName = "CustomerOrderCount",
//    SqlDbType = System.Data.SqlDbType.Int,
//    Direction = System.Data.ParameterDirection.Output,
//};

//var ordersByCustomerId = _dbContext
//    .Orders
//    .FromSqlInterpolated(@$"GetOrdersByCustomerId @customerId = {_dbContext.Customers.First().Id}, 
//                                                  @customerOrderCount = {paramCustomerOrderCount} OUTPUT")
//    .ToList();

//var customerOrderCount = paramCustomerOrderCount.Value;

/* VIEWS */
//var customerOrders = _dbContext
//    .CustomerOrders
//    .ToList();

//var invoiceAmountByOrder = _dbContext
//    .CustomerOrders
//    .GroupBy(co => co.OrderId,
//            (orderId,
//             group) => new
//             {
//                 OrderId = orderId,
//                 TotalInvoiceAmountAfterVat = group.Sum(co => co.UnitPriceAfterVAT)
//             })
//    .ToList();

/* INLINE TABLE-VALUED FUNCTIONS */
//var customerOrdersByCustomerId = _dbContext
//    .GetCustomerOrdersByCustomerId(4)
//    .ToList();

//var customerOrdersByCustomerIdJoined = _dbContext
//    .GetCustomerOrdersByCustomerId(4)
//    .Join(_dbContext.Orders,
//          co => co.OrderId,
//          o => o.Id,
//          (co, o) => new { CustomerOrder = co, Order = o })
//    .ToList();

/* MULTI-STATEMENT TABLE-VALUED FUNCTIONS */
//var statusOverview = _dbContext
//    .GetStatusOverview()
//    .ToList();

/* SCALAR FUNCTIONS */
//var totalInvoiceAmount = _dbContext
//    .Orders
//    .Select(o => new { OrderId = o.Id, totalInvoiceAmount = _dbContext.GetTotalInvoiceAmountByOrderId(o.Id) })
//    .ToList();
#endregion
#region Module 5
/* DIRECT MANY-TO-MANY - FETCHING THE PROPERTY BAGS */
//var itemsInOrder = _dbContext
//    .Orders
//    .Include(o => o.Items)
//    .First(o => o.Id == 1)
//    .Items
//    .ToList();

//var skipNavigations = _dbContext
//    .Orders
//    .EntityType
//    .GetSkipNavigations();

//var itemsSkipNavigation = skipNavigations
//    .First(nav => nav.Name == "Items"); // Items is the name of the skip navigation for orders, for items it would orders

//var itemOrders = _dbContext
//    .Set<Dictionary<string, object>>(itemsSkipNavigation.JoinEntityType.Name)
//    .ToList();

/* DIRECT MANY-TO-MANY WITH PAYLOAD */
//var itemsInOrder = _dbContext
//    .Orders
//    .Include(o => o.Items)
//    .First(o => o.Id == 1)
//    .Items
//    .ToList();

//var skipNavigations = _dbContext
//    .Orders
//    .EntityType
//    .GetSkipNavigations();

//var itemsSkipNavigation = skipNavigations
//    .First();

//var itemOrders = _dbContext
//    .Set<ItemOrder>(itemsSkipNavigation.JoinEntityType.Name)
//    .ToList();

//var firstItem = itemOrders.First();

//var orderDate = firstItem.OrderDate;
//var quantity = firstItem.Quantity;

//firstItem.OrderDate = new DateTime(2020, 1, 1);
//firstItem.Quantity = 10;

//_dbContext.SaveChanges();

/* INDIRECT MANY-TO-MANY */
//var skipNavigations = _dbContext
//    .Orders
//    .EntityType
//    .GetSkipNavigations();

//var itemRelationsInOrder = _dbContext
//    .Orders
//    .Include(o => o.ItemOrders)
//    .First(o => o.Id == 1)
//    .ItemOrders
//    .ToList();

//var itemsInOrder = _dbContext
//    .Orders
//    .Include(o => o.ItemOrders)
//        .ThenInclude(io => io.Item)
//    .First(o => o.Id == 1)
//    .ItemOrders
//    .Select(x => new { x.Item.Id, x.Item.Description, x.Item.Price, x.Quantity, x.OrderDate })
//    .ToList();

//var itemOrders = _dbContext
//    .ItemOrders
//    .Include(io => io.Item)
//    .Include(io => io.Order)
//    .ToList();
#endregion

#region Module 5
#endregion

#region Module 6

/* MAPPING INHERITANCE */
_dbContext
    .Items
    .AddRange(
    new CannedFoodItem
    {
        Description = "Energy Drink",
        Price = 12,
        Weight = 5,
        CanningMaterial = CanningMaterial.Tin,
        ExpiryDate = DateTime.Now.AddYears(1),
        ProductionDate = DateTime.Now.AddYears(-1),
    },
    new CannedFoodItem
    {
        Description = "Canned Tomato Soup",
        Price = 10,
        Weight = 5,
        CanningMaterial = CanningMaterial.Steel,
        ExpiryDate = DateTime.Now.AddYears(3),
        ProductionDate = DateTime.Now.AddYears(-1),
    },
    new DriedFoodItem
    {
        Description = "Dried Tomato Soup",
        Price = 7,
        Weight = 3,
        ExpiryDate = DateTime.Now.AddYears(10),
        ProductionDate = DateTime.Now.AddYears(-1),
    },
    new ClothesItem
    {
        Description = "Hiking Shoes",
        Price = 40,
        Weight = 15,
        Fabric = ClothesFabric.Leather
    },
    new MagazineItem
    {
        Description = "Climber's Quarterly",
        Price = 15,
        Weight = 2,
        PublicationFrequency = PublicationFrequency.Quarterly
    },
    new Item
    {
        Description = "Knotting Rope",
        Price = 3,
        Weight = 2
    });

_dbContext.SaveChanges();

_dbContext.ChangeTracker.Clear();

var allItems = _dbContext
    .Items
    .ToList();

var magazineItems = _dbContext
    .Items
    .OfType<MagazineItem>()
    .ToList();

magazineItems = _dbContext
    .MagazineItems
    .ToList();

var cannedFoodItems = _dbContext
    .CannedFoodItems
    .ToList();

var driedFoodItems = _dbContext
    .DriedFoodItems
    .ToList();

var clothesItems = _dbContext
    .ClothesItems
    .ToList();


































#endregion














Console.WriteLine("Press any key to exit");
Console.Read();