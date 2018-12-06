namespace DemoApp.Contracts
{
    public interface IValidator
    {
        bool Validate<TType>(TType input);
    }
}
