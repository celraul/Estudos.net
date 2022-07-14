using Cel.Estudos.CoreDomain.Notification;
using MediatR;
using FluentValidation;
using FluentValidation.Results;

namespace Cel.Estudos.CoreDomain.BehaviorMediatR
{
    public class ValidationRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : MediatR.IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator> _validators;
        private readonly INotificationContext _notificationContext;
        private readonly bool _throwOnFailure = false;

        public ValidationRequestBehavior(IEnumerable<IValidator<TRequest>> validators,
            INotificationContext notificationContext)
        {
            _validators = validators;
            _notificationContext = notificationContext;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var contextFluentValidator = new ValidationContext<object>(request);

            var failures = _validators
               .Select(v => v.Validate(contextFluentValidator))
               .SelectMany(x => x.Errors)
               .Where(f => f != null)
               .ToList();

            foreach (var failure in failures)
                _notificationContext.Add(new GenericNotification(failure.ErrorMessage));

            return _throwOnFailure ? Notify(failures) : next();
        }

        private Task<TResponse> Notify(IEnumerable<ValidationFailure> failures)
        {
            return Task.FromResult(default(TResponse));
        }
    }
}
