using CarvedRock.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

var _dbContext = new CarvedRockContext();

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
var customer = _dbContext
    .Customers
    .First();

customer.BillToAddress = new Address { Street = "Glendale Boulevard", City = "Los Angeles", Country = "United States" };
customer.ShipToAddress = new Address { Street = "Hollywood Boulevard", City = "Los Angeles", Country = "United States" };

_dbContext.SaveChanges();

customer = _dbContext
    .Customers
    .First();



















/* VALUE CONVERSIONS */
//var customer = _dbContext
//    .Customers
//    .First();

//customer.CustomerStatus = Status.Active;
//_dbContext.SaveChanges();





























Console.WriteLine("Press any key to exit");
Console.Read();