var builder = WebApplication.CreateBuilder(args);
//add services to the container
builder.Services.AddCarter(new DependencyContextAssemblyCatalog([typeof(Program).Assembly]));
//builder.Services.AddCarter(null, config =>
//{
//    config.DependencyContextAssemblyCatalog(typeof(Program).Assembly);
//});
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();
//configure http request pipeline
app.MapCarter();//maps routes defined in ICarter implementation

app.Run();
/*1. register carter library (handle minimal api endpoints)
 * add carter classes into dependancy injection using builder object
 * configure http request pipeline with carter (to expose http get and post methods)
 */

/*2. register the mediatR library which will manage command and query handles
 * add carter classes into dependancy injection using builder object, **configure
 * ?? register assembly
 * 
 */