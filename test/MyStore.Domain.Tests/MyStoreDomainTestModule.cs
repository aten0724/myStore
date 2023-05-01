using MyStore.MongoDB;
using Volo.Abp.Modularity;

namespace MyStore;

[DependsOn(
    typeof(MyStoreMongoDbTestModule)
    )]
public class MyStoreDomainTestModule : AbpModule
{

}
