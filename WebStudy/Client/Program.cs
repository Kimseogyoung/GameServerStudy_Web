// See https://aka.ms/new-console-template for more information
using Client;

Console.WriteLine("Hello, World!");
var ctxSystem = new ContextSystem();
ctxSystem.Init();

await ctxSystem.RequestSignUpAsync("12345");

ctxSystem.Clear();