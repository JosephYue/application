namespace Application.Extension.Infrastructure.InfluxDb.Interface
{
    public interface IInfluxDbClientFactory
    {
        InfluxDbClientDecorator CreateClient();
    }
}
