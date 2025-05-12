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
            CreateMap<CreateAppUserCommand, AppUser>();  // Kullanıcı oluşturma dönüşümü
            CreateMap<UpdateAppUserCommand, AppUser>();  // Kullanıcı güncelleme dönüşümü

            CreateMap<AppUser, GetAppUserQuery>();  // Kullanıcıdan ViewModel'e dönüşüm
            CreateMap<AppUser, GetAppUserQuery?>();

            //Customer
            CreateMap<CreateCustomerCommand, Customer>();  // Müşteri oluşturma dönüşümü
            CreateMap<UpdateCustomerCommand, Customer>();  // Müşteri güncelleme dönüşümü

            CreateMap<Customer, GetCustomerQuery>();  // Müşteriden ViewModel'e dönüşüm
            //Payment
            CreateMap<CreatePaymentCommand, Payment>();  // Ödeme oluşturma dönüşümü
            CreateMap<Payment, GetPaymentQuery>();  // Ödemeden ViewModel'e dönüşüm
            //Product
            CreateMap<CreateProductCommand, Product>();  // Ürün oluşturma dönüşümü
            CreateMap<UpdateProductCommand, Product>();  // Ürün güncelleme dönüşümü

            CreateMap<Product, GetProductQuery>();  // Üründen ViewModel'e dönüşüm
            //Rent
            CreateMap<CreateRentCommand, Rent>();  // Kiralama oluşturma dönüşümü
            CreateMap<UpdateRentCommand, Rent>();  // Kiralama güncelleme dönüşümü

            CreateMap<Rent, GetRentQuery>();  // Kiralamadan ViewModel'e dönüşüm
            //RentOffice
            CreateMap<CreateRentOfficeCommand, RentOffice>();  // Ofis oluşturma dönüşümü
            CreateMap<UpdateRentOfficeCommand, RentOffice>();  // Ofis güncelleme dönüşümü
            CreateMap<RentOffice, GetRentOfficeQuery>();  // Ofisten ViewModel'e dönüşüm
        }
    }
}
