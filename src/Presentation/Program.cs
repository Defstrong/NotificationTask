using BusinessLogic;
using DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

using var db = new NotifyContext();

var backgroundWorker = new NotificationWorker(new MessageRepository(), new NotificationEventRepository(db));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

Thread thread = new(async () => await backgroundWorker.StartAsync(CancellationToken.None));
thread.IsBackground = true;
thread.Start();

app.Run();

