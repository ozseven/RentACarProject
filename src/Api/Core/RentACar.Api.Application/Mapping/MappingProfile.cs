using AutoMapper;
using RentACar.Api.Domain.Models;
using RentACar.Common.Models.CommandModels.AppUserCommand;
using RentACar.Common.Models.CommandModels.CustomerCommand;
using RentACar.Common.Models.CommandModels.CustomerCommand.RentACar.Common.Models.CommandModels.AppUserCommand;
using RentACar.Common.Models.CommandModels.PaymentCommand;
using RentACar.Common.Models.CommandModels.ProductCommand;
using RentACar.Common.Models.CommandModels.RentCommand;
using RentACar.Common.Models.CommandModels.RentOfficeCommand;
using RentACar.Common.Models.ViewModels.AppUserQuery;
using RentACar.Common.Models.ViewModels.CustomerQuery;
using RentACar.Common.Models.ViewModels.PaymentQuery;
using RentACar.Common.Models.ViewModels.ProductQuery;
using RentACar.Common.Models.ViewModels.RentOfficeQuery;
using RentACar.Common.Models.ViewModels.RentQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Api.Application.Mapping
{
    /// <summary>
    /// AutoMapper yapılandırma profili.
    /// Komut modelleri ile domain modelleri arasındaki dönüşüm kurallarını tanımlar.
    /// </summary>
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            //AppUser
            CreateMap<CreateAppUserCommand, AppUser>();
            CreateMap<UpdateAppUserCommand, AppUser>();

            CreateMap<AppUser, GetAppUserQuery>();
            CreateMap<AppUser, GetAppUserQuery?>();

            //Customer
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<UpdateCustomerCommand, Customer>();

            CreateMap<Customer, GetCustomerQuery>();
            //Payment
            CreateMap<CreatePaymentCommand, Payment>();
            CreateMap<Payment, GetPaymentQuery>();
            //Product
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();

            CreateMap<Product, GetProductQuery>();
            //Rent
            CreateMap<CreateRentCommand, Rent>();
            CreateMap<UpdateRentCommand, Rent>();

            CreateMap<Rent, GetRentQuery>();
            //RentOffice
            CreateMap<CreateRentOfficeCommand, RentOffice>();
            CreateMap<UpdateRentOfficeCommand, RentOffice>();
            CreateMap<RentOffice, GetRentOfficeQuery>();
        }
    }
}
