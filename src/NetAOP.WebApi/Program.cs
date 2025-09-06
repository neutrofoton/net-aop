
using Castle.DynamicProxy;
using NetAOP.WebApi.Interceptors;
using NetAOP.WebApi.Services;
using NetAOP.WebApi.Services.Impl;
using NetAOP.WebApi.Aop;
using NetAOP.WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Castle Core
builder.Services.AddSingleton(new ProxyGenerator());
builder.Services.AddScoped<IInterceptor, LoggingInterceptor>();

//Register services
builder.Services.AddProxiedScoped<IHelloService, HelloService>();
builder.Services.AddProxiedScoped(typeof(IGenericService<,>), typeof(GenericService<,>));

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
