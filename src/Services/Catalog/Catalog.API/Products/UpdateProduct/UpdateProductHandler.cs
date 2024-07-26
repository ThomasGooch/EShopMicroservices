namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name, List<string> Categories, string Description, string ImageFile, decimal Price) : ICommand<UpdateProductResult>;
    public record UpdateProductResult(bool IsSuccess);
    public class UpdateProductCommandHandler(IDocumentSession session) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            // business logic to update an existing product

            // find a Product entity from command
            var productForUpdate = await session.LoadAsync<Product>(command.Id, cancellationToken) ?? throw new ProductNotFoundException(command.Id);

            productForUpdate.Name = command.Name;
            productForUpdate.Category = command.Categories;
            productForUpdate.Description = command.Description;
            productForUpdate.ImageFile = command.ImageFile;
            productForUpdate.Price = command.Price;


            // save changes to the database
            session.Update(productForUpdate);
            await session.SaveChangesAsync(cancellationToken);
            // return CreateProductResult result
            return new UpdateProductResult(true);
        }
    }

}
