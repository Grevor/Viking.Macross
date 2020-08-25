using System.Collections.Generic;

namespace Viking.Macross.Interface
{
    public interface IProgrammingInterface
    {
        bool TryGetInvocator<TParameter, TResult>(Identifier identifier, out IFunctionInvocator<TParameter, TResult> invocator);
        bool TryGetValueStream<TValue>(Identifier identifier, out IValueStream<TValue> invocator);
    }

    public static class ProgrammingInterfaceExtensions
    {
        public static bool TryGetInvocator<TParameter, TResult>(
            this IProgrammingInterface api, 
            FunctionIdentifier<TParameter, TResult> identifier, 
            out IFunctionInvocator<TParameter, TResult> invocator)
        {
            return api.TryGetInvocator(identifier.Identifier, out invocator);
        }

        public static bool TryGetValueStream<TValue>(
            this IProgrammingInterface api,
            ValueStreamIdentitfier<TValue> identifier,
            out IValueStream<TValue> invocator)
        {
            return api.TryGetValueStream(identifier.Identifier, out invocator);
        }
    }
}
