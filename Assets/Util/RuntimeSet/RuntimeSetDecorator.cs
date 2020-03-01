public abstract class RuntimeSetDecorator<T> 
{
    protected RuntimeSet<T> runtimeSet;

    public RuntimeSetDecorator(RuntimeSet<T> runtimeSet)
    {
        this.runtimeSet = runtimeSet;
    }
}
