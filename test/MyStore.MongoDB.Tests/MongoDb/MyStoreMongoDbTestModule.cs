using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace MyStore.MongoDB;

[DependsOn(
    typeof(MyStoreTestBaseModule),
    typeof(MyStoreMongoDbModule)
    )]
public class MyStoreMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var stringArray = MyStoreMongoDbFixture.ConnectionString.Split('?');
        var connectionString = stringArray[0].EnsureEndsWith('/') +
                                   "Db_" +
                               Guid.NewGuid().ToString("N") + "/?" + stringArray[1];

        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = connectionString;
        });
    }
}
