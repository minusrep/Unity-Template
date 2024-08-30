namespace Root._Core._Locator
{
    public interface ILocator<T> 
    {
        U Get<U>() where U : T;
    }
}
