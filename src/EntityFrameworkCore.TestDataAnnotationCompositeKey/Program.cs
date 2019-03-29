using System;

namespace EntityFrameworkCore.TestDataAnnotationCompositeKey
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CustomDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var entity = new TestEntity()
                {
                    //Key1 = 1,
                    Key2 = 2,
                    DateCreate = DateTime.Now
                };

                context.TestEntities.Add(entity);
                context.SaveChanges();

            }

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
