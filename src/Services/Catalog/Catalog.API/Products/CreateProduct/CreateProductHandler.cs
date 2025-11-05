namespace Catalog.API.Products.CreateProduct
{
    //with parameters which are members from Product document entity, represents the data needed to create a new product
    public record CreateProductCommand(string Name, List<string> Catagory, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;
    //as a result need aditional record type, represents the response return object
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //1. create product document entity and **3. save to the database
            

            var product = new Product
            {
                Name = command.Name,
                Catagory = command.Catagory,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,

            };

            //3.
            session.Store(product);

            await session.SaveChangesAsync(cancellationToken);

            //2. return result CreateProductTResult result
            //return new CreateProductResult(Guid.NewGuid());
            return new CreateProductResult(product.Id);
            //throw new NotImplementedException();
        }
    }
}
//separated application logic

//creating command and result object (CreateProductCommand and CreateProductRsesult)

//command handler class contains the business logic to create a product, expects a command, triggered by the command or query class with IRequest<Result> interface from mediatR library object