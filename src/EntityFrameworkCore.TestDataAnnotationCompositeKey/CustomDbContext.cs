using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace EntityFrameworkCore.TestDataAnnotationCompositeKey
{
    class CustomDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=TestDataAnnotationCompositeKey;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityTypeFirst in modelBuilder.Model.GetEntityTypes())
            {
                if (entityTypeFirst is EntityType entityType)
                {
                    if (entityType.BaseType == null)
                    {
                        var primaryKey = entityType.FindPrimaryKey();
                        if ((primaryKey != null ? (primaryKey.Properties.Count > 1 ? 1 : 0) : 0) != 0)
                        {
                            if (entityType.GetPrimaryKeyConfigurationSource() == ConfigurationSource.DataAnnotation)
                            {
                                var keyProperties = entityType.GetProperties().Where(x => x.IsKey() && x.GetConfigurationSource() != ConfigurationSource.Convention).ToList();
                                entityType.SetPrimaryKey(keyProperties, ConfigurationSource.Explicit);
                            }
                        }
                    }
                    else
                    {
                        foreach (Property declaredProperty in entityType.GetDeclaredProperties())
                        {
                            MemberInfo identifyingMemberInfo = declaredProperty.GetIdentifyingMemberInfo();
                            if (identifyingMemberInfo != (MemberInfo)null && Attribute.IsDefined(identifyingMemberInfo, typeof(KeyAttribute), true))
                            {
                                throw new NotImplementedException("EF Core hack with replacing data annotation primary keys - not implemented fully.");
                            }
                        }
                    }
                }
            }
        }

        public virtual DbSet<TestEntity> TestEntities { get; set; }
    }
}
