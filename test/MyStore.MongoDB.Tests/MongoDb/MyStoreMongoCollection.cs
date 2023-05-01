using Xunit;

namespace MyStore.MongoDB;

[CollectionDefinition(MyStoreTestConsts.CollectionDefinitionName)]
public class MyStoreMongoCollection : MyStoreMongoDbCollectionFixtureBase
{

}
