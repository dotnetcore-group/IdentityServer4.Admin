using AutoMapper;
using IdentityServer4.Admin.Domain.Entities;
using IdentityServer4.Admin.Domain.Events.User;
using IdentityServer4.Admin.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Domain.EventHandlers
{
    public class UserEventHandler
        : INotificationHandler<UserRegisteredEvent>,
        INotificationHandler<NewLoginAddedEvent>,
        INotificationHandler<UserLoggedInEvent>
    {
        private readonly ILoginLogRepository _loginLogRepository;
        private readonly IMapper _mapper;
        public UserEventHandler(ILoginLogRepository loginLogRepository,
            IMapper mapper)
        {
            _loginLogRepository = loginLogRepository;
            _mapper = mapper;
        }

        public async Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
        {

        }

        public async Task Handle(NewLoginAddedEvent notification, CancellationToken cancellationToken)
        {
        }

        public async Task Handle(UserLoggedInEvent notification, CancellationToken cancellationToken)
        {
            var log = _mapper.Map<UserLoginLog>(notification);
            await _loginLogRepository.AddAsync(log);
            await _loginLogRepository.SaveChangesAsync();
        }
    }
}
