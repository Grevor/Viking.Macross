using System;
using System.Threading.Tasks;

namespace Viking.Macross.Interface
{
    public enum InvocationStatus
    {
        WaitingForInvocation,
        Running,
        Success,
        Error,
    }

    public interface IInvocationToken<TResult> : IDisposable
    {
        InvocationStatus Status { get; }

        InvocationStatus WaitForCompletion();
        Task<InvocationStatus> WaitForCompletionAsync();

        TResult Result { get; }
        InvocationError Error { get; }
    }
}
