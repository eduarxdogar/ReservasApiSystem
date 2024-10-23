using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ReservationSystem.Data;
using ReservationSystem.Data.Repositories;
using ReservationSystem.Data.Repositories.Impl;
using ReservationSystem.Business.Services;
using ReservationSystem.Business.Services.Impl;
using System;
using ReservationSystem.Data.StoredProcedures;

namespace ReservationSystem.Root
{
    public class CompositionRoot
    {
        public CompositionRoot() { }

        public static void InjectDependencies(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ReservationSystemContext>(opts => opts.UseLazyLoadingProxies().UseSqlServer(
                configuration.GetConnectionString("ReservationSystemContext")));
            //DB Context
            services.AddScoped<ReservationSystemContext>();
            //Reservation
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IReservationService, ReservationService>();
            //Contact
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IContactService, ContactService>();
            //Contact Type
            services.AddScoped<IContactTypeRepository, ContactTypeRepository>();
            services.AddScoped<IContactTypeService, ContactTypeService>();
            //DB Creation and Seeding
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddScoped<IDbInitializeService, DbInitializeService>();
            //DB Stored Procedures
            services.AddScoped<IStoredProceduresManager, StoredProceduresManager>();
        }
        //public static void CreateDatabase(IServiceProvider services)
        //{
        //    var context = services.GetRequiredService<ReservationSystemContext>();
        //    context.Database.Migrate();
        //}
    }
}
