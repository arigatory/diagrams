using GloboTicket.TicketManagement.Api;

using Serilog;



var builder = WebApplication.CreateBuilder(args);


var app = builder
       .ConfigureServices()
       .ConfigurePipeline();


await app.ResetDatabaseAsync();

app.Run();

public partial class Program { }
