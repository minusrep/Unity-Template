namespace Root.Services.SDK
{
    public interface IStrategy
    {
        IDataHandler DataHandler { get; }

        IAdvertisement Advertisement { get; }
    }
}
