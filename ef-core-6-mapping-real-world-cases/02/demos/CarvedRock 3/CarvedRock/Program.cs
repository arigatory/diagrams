using CarvedRock.DataAccess.Models;

var _dbContext = new CarvedRockContext();

Customer c = new Customer();

c.SetUsername("Test");
c.SetUsername("Test%#");

Console.WriteLine("Press any key to exit");
Console.Read();