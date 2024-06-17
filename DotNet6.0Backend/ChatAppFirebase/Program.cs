using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Hosting;
using Services.fbInterface;
using Services.fbServices;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

//FireBase
var credential = GoogleCredential.FromFile("D:\\github\\webapichatapp-firebase-adminsdk-8soov-34b03737a7.json");
var _firebaseApp = FirebaseApp.Create(new AppOptions
{
    Credential = credential
});

//FirebaseApp.Create(new AppOptions()
//{
//    Credential = GoogleCredential.FromJson("{\r\n    \"apiKey\": \"AIzaSyDePMb8WlMmU-V2Cd-leiTk5qe767zqSNo\",\r\n    \"authDomain\": \"webapichatapp.firebaseapp.com\",\r\n    \"projectId\": \"webapichatapp\",\r\n    \"storageBucket\": \"webapichatapp.appspot.com\",\r\n    \"messagingSenderId\": \"827153009802\",\r\n    \"appId\": \"1:827153009802:web:0ea67856c63a3830847173\",\r\n    \"measurementId\": \"G-3D6CBERMWC\"\r\n  }")
//});
// Add services to the container.

builder.Services.AddControllers();
//Services
builder.Services.AddScoped<IfbUserServices, fbUserServices>();
//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.

//Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
