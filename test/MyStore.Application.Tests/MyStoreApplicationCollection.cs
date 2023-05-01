using MyStore.MongoDB;
using Xunit;

namespace MyStore;

[CollectionDefinition(MyStoreTestConsts.CollectionDefinitionName)]
public class MyStoreApplicationCollection : MyStoreMongoDbCollectionFixtureBase
{

}
