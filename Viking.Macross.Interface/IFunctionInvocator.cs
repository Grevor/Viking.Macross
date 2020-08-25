namespace Viking.Macross.Interface
{
    public interface IFunctionInvocator<TParameter, TResult>
    {
        FunctionIdentifier<TParameter, TResult> Identifier { get; }
        IInvocationToken<TResult> Invoke(TParameter parameter);

    }
}
