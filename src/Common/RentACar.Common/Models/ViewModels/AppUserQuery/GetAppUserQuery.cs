using MediatR;
using RentACar.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Common.Models.ViewModels.AppUserQuery
{
    public class GetAppUserQuery:IRequest<Guid>  // Kullanıcı sorgu modeli (ViewModel)
    {
        public Guid RentOfficeId { get; set; }  // Kullanıcının ofis ID'si
        public Status Status { get; set; }  // Kullanıcı durumu
        public string Name { get; set; }  // Kullanıcı adı
        public string Surname { get; set; }  // Kullanıcı soyadı
    }
}
