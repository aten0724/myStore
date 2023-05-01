using MyStore.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace MyStore.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MyStoreMongoDbModule),
    typeof(MyStoreApplicationContractsModule)
    )]
public class MyStoreDbMigratorModule : AbpModule
{

}
