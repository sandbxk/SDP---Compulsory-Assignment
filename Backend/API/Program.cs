using Application.Interfaces;
using FluentValidation;
using Infrastructure;
using Infrastructure.Interfaces;


var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("initializing");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(); //Cors is needed for the frontend to work
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddScoped<IDapperr, Dapperr>();
builder.Services.AddScoped<IBoxRepository, BoxRepository>();



/*
 *
var mapper = new MapperConfiguration(configuration =>
{
    configuration.CreateMap<PostProductDTO, Product>();
}).CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddDbContext<ProductDbContext>(options => options.UseSqlite(
    "Data source=db.db"
    ));

 */





Application.DependencyResolver
    .DependencyResolverService
    .RegisterApplicationLayer(builder.Services);

Infrastructure.DependencyResolver
    .DependencyResolverService
    .RegisterInfrastructure(builder.Services);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(builder => builder //Configure cors
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();