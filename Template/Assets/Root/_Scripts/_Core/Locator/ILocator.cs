namespace Root.Core
{
    public interface ILocator<T> 
    {
        U Get<U>() where U : T;
    }
}
