var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/frete", (double valor) =>
{
    if (valor < 0)
    {
        return Results.BadRequest(new { erro = "O valor do pedido não pode ser negativo." });
    }

    double frete = valor >= 100 ? 0 : 15;
    return Results.Ok(new
    {
        valorPedido = valor,
        valorFrete = frete,
        freteGratis = frete == 0
    });
});

app.Run();