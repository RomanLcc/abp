﻿using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Uow;

namespace Volo.Abp.PermissionManagement.MongoDB
{
    [DependsOn(
        typeof(AbpPermissionManagementMongoDbModule),
        typeof(AbpPermissionManagementTestBaseModule))]
    public class AbpPermissionManagementMongoDbTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var connectionString = MongoDbFixture.ConnectionString.EnsureEndsWith('/')  +
                                   "Db_" +
                                   Guid.NewGuid().ToString("N");

            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = connectionString;
            });

            Configure<AbpUnitOfWorkDefaultOptions>(options =>
            {
                options.TransactionBehavior = UnitOfWorkTransactionBehavior.Disabled;
            });
        }
    }
}
