using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoAppAPI.Entities;

namespace ToDoAppAPI.DataBase.EntityConfigurations
{
    public class ListEntityConfiguration : IEntityTypeConfiguration<ListEntity>
    {
        public void Configure(EntityTypeBuilder<ListEntity> builder)
        {
            builder.HasData(new ListEntity[]
                {
                    new ListEntity{Id=1, Name="shopping A"},
                    new ListEntity{Id=2, Name="To Do A"},

                    new ListEntity{Id=3, Name="shopping B"},
                    new ListEntity{Id=4, Name="To Do B"},

                    new ListEntity{Id=5, Name="Shardo"},
                });
        }
    }
}
