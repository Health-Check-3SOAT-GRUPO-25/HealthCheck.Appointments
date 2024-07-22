﻿using HealthCheck.Appointments.Domain.DatabaseConfiguration;
using Microsoft.Extensions.Configuration;

namespace HealthCheck.Appointments.Infrastructure.Database.Config;

public class MongoDBSettings(IConfiguration configuration) : IDatabaseConfiguration
{
    public string CollectionName()
    {
        IConfigurationSection mongoDBSection = GetMongoDBSection();
        return mongoDBSection.GetSection("CollectionName").Value!;
    }

    private IConfigurationSection GetMongoDBSection()
    {
        return configuration.GetSection("MongoDB");
    }

    public string ConnectionURI()
    {
        IConfigurationSection mongoDBSection = GetMongoDBSection();
        return mongoDBSection.GetSection("ConnectionURI").Value!;
    }

    public string DatabaseName()
    {
        IConfigurationSection mongoDBSection = GetMongoDBSection();
        return mongoDBSection.GetSection("DatabaseName").Value!;
    }
}