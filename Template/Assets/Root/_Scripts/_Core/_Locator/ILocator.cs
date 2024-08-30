namespace Root._Core._Locator
{
    public interface ILocator<T> 
    {
        T Get<U>() where U : T;
    }
}
