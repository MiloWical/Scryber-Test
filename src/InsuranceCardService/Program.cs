using InsuranceCardWriter.Components;
using Scryber.Components;

//Load your template from a 
var path = System.Environment.CurrentDirectory;
path = System.IO.Path.Combine(path, "../../templates/InsuranceCardTemplate.html");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.MapPost("/write-card", (InsuranceCardModel model) =>
{
  using (var doc = Document.ParseDocument(path))
  {
    doc.Params["model"] = model;

    //And save it to a file or a stream
    using (var stream = new System.IO.FileStream("InsuranceCard.pdf", System.IO.FileMode.Create))
    {
      doc.SaveAsPDF(stream);
    }
  }

  return Results.Json($"{System.Environment.CurrentDirectory}/InsuranceCard.pdf");
});

app.Run();
