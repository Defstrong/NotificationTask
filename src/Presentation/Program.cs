using BusinessLogic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

NotificationWorker backgroundWorker = NotificationWorkerFactory.GetNotificationWorker();
Thread thread = new(async () => await backgroundWorker.StartAsync(CancellationToken.None));
thread.IsBackground = true;
thread.Start();

app.Run();

