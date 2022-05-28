using System;

namespace Jimmys20.ProblemDetails
{
    public class ProblemDetailsException : Exception
    {
        public ProblemDetailsException(ProblemDetails problem)
        {
            Problem = problem;
        }

        public ProblemDetails Problem { get; }
    }
}
