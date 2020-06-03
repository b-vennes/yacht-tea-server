namespace YachtTea.Actions
{
    using System;
    using Paramore.Brighter;

    public class ActionHandlerFactoryAsync : IAmAHandlerFactoryAsync
    {
        private readonly IServiceProvider _serviceProvider;
        public ActionHandlerFactoryAsync(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IHandleRequestsAsync Create(Type handlerType)
        {
            return (IHandleRequestsAsync)_serviceProvider.GetService(handlerType);
        }

        public void Release(IHandleRequestsAsync handler)
        {
        }
    }
}