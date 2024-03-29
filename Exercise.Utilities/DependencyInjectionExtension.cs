﻿using Exercise.DataAccess;
using Exercise.DataAccess.Abstraction;
using Exercise.DataAccess.Repositories;
using Exercise.DataModels;
using Exercise.Services.Interfaces;
using Exercise.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Exercise.Utilities;
public static class DependencyInjectionExtension
{
    public static IServiceCollection RegisterModule(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ExerciseDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        // Repository registration
        services.AddTransient<IRepository<CompanyDto>, CompanyRepository>();
        services.AddTransient<IRepository<ContactDto>, ContactRepository>();
        services.AddTransient<IRepository<CountryDto>, CountryRepository>();

        // Service registration
        services.AddTransient<IContactService, ContactService>();
        services.AddTransient<ICompanyService, CompanyService>();
        services.AddTransient<ICountryService, CountryService>();

        return services;
    }
}

