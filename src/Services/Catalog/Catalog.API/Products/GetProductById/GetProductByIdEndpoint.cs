namespace Catalog.API.Products.GetProducts;

//public record GetProductByIdRequest(Guid Id);

public record GetProductByIdResponse(Product Product);



public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        // create endpoint
        app.MapGet("/products/{id}", async (ISender sender, Guid id) =>
        {
            //var query = new GetProductByIdQuery(id);

            var result = await sender.Send(new GetProductByIdQuery(id));

            var response = result.Adapt<GetProductByIdResponse>();



            return Results.Ok(response);
        })
        .WithName("GetProductById")
        .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product By Id")
        .WithDescription("Get Product By Id");
    }
}
