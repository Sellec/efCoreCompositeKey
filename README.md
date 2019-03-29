# efCoreCompositeKey
Solution for using data annotation composite keys with EntityFramework Core.

EntityFramework Core does not allow to use System.ComponentModel.DataAnnotations.KeyAttribute with multiple columns to define composite key. I dont know the reason of this variant of feature implementation, but i have some projects using EntityFramework6 and there are some entities with composite keys defined as property attributes. Since some of the projects are multi-platformed (.Net 4.5 and .Net Standard 2.0) and they are using common class library with entities definitions (this library is dont know about EF versions) i cannot use Fluent API in data contexts.

This solution solves my problem completely and now i can use old data annotation definitions with EF Core.
Maybe i lose some of the important moments, but the fixes and issues are welcome.

