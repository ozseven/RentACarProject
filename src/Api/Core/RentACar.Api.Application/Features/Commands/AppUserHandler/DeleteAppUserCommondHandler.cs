using MediatR;
using RentACar.Api.Application.Interfaces.Repositories;
using RentACar.Common.Models.CommandModels.AppUserCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Features.Commands.AppUserHandler
{
    /// <summary>
    /// Uygulama kullanıcısını silen komut işleyici sınıfı.
    /// </summary>
    public class DeleteAppUserCommandHandler : IRequestHandler<DeleteAppUserCommand, Guid>
    {
        /// <summary>
        /// Uygulama kullanıcısı veritabanı işlemleri için repository.
        /// </summary>
        private readonly IAppUserRepository _repository;

        public DeleteAppUserCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Uygulama kullanıcısını siler.
        /// </summary>
        /// <param name="request">Kullanıcından alınan parametreler.</param>
        /// <param name="cancellationToken">İptal Tokeni</param>
        /// <returns>Silinen Kullanıcı Id'si.</returns>
        public async Task<Guid> Handle(DeleteAppUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveAsync(request.Id);
            await _repository.SaveChangesAsync();
            return request.Id;
        }
    }
}
