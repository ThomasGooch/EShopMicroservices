﻿namespace Catalog.API.Products.GetProductsByCategory
{
    //public record GetProductsByCategoryQueryRequest(string Category);
    public record GetProductsByCategoryResponse(IEnumerable<Product> Products);
    public class GetProductsByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (ISender sender, string category) =>
            {
                var result = await sender.Send(new GetProductsByCategoryQuery(category));
                var response = result.Adapt<GetProductsByCategoryResponse>();
                return Results.Ok(response);
            }).WithName("GetProductsByCatgory")
        .Produces<GetProductsByCategoryResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products By Category")
        .WithDescription("Get Products By Category");
        }
    }
}
