using System;
using Entities.Models.Concerts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData
            (
                new Genre
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    GenreName = GenreName.Rock
                },
                new Genre
                {
                    Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    GenreName = GenreName.Electronic
                },
                new Genre
                {
                    Id = new Guid("4a4395c0-b3ce-4d32-916f-30200e9c7903"),
                    GenreName = GenreName.Country
                },
                new Genre
                {
                    Id = new Guid("2deefc3e-f1a9-4e70-9ebb-85fb2d3a9bef"),
                    GenreName = GenreName.Funk
                },
                new Genre
                {
                    Id = new Guid("6d3dbb7d-6297-4839-aaa5-650760356875"),
                    GenreName = GenreName.Jazz
                },
                new Genre
                {
                    Id = new Guid("286d0569-5f6e-44c9-939f-aa0165353694"),
                    GenreName = GenreName.Latin
                },
                new Genre
                {
                    Id = new Guid("e04ba65d-1c39-4895-9c9a-a5ddee3e014a"),
                    GenreName = GenreName.Polka
                }
            );
        }
    }
}