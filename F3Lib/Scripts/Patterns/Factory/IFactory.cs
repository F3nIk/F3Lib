
namespace F3Lib.Patterns.Factory
{
    public interface IFactory<Product> where Product : class, new()
    {
        Product Create();
    }
}