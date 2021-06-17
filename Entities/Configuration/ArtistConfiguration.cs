using System;
using Entities.Models.Concerts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasData
            (
                //Rock Artists
                new Artist
                {
                    Id = new Guid("cea51056-4180-45e6-9007-b92b2c4e806a"),
                    ArtistName = "The Beatles",
                    GenreId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                },
                new Artist
                {
                    Id = new Guid("7ecf51f4-d7a1-4446-a394-9685445c548d"),
                    ArtistName = "The Rolling Stones",
                    GenreId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                },
                new Artist
                {
                    Id = new Guid("f32cba10-8b39-430b-904e-1013ce10bd7e"),
                    ArtistName = "Queen",
                    GenreId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                },
                new Artist
                {
                    Id = new Guid("772a66e2-1758-429a-bf2a-fa879c0a814b"),
                    ArtistName = "AC/DC",
                    GenreId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                },
                new Artist
                {
                    Id = new Guid("fba81401-9ecb-4b88-bc76-f94a8cf2febf"),
                    ArtistName = "Pink Floyd",
                    GenreId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                },
                new Artist
                {
                    Id = new Guid("d50c5b99-49f3-49ff-89f3-3e4c6903209e"),
                    ArtistName = "Led Zeppelin",
                    GenreId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                },
                //Juzz Artists
                new Artist
                {
                    Id = new Guid("e8af3832-2e4f-489f-b282-94751285f4d4"),
                    ArtistName = "Miles Davis",
                    GenreId = new Guid("6d3dbb7d-6297-4839-aaa5-650760356875")
                },
                new Artist
                {
                    Id = new Guid("c1da350a-166a-490f-8430-d1fab16b24e7"),
                    ArtistName = "Louis Armstrong",
                    GenreId = new Guid("6d3dbb7d-6297-4839-aaa5-650760356875")
                },
                new Artist
                {
                    Id = new Guid("f545753e-b49f-45b9-91ee-de477d559365"),
                    ArtistName = "John Coltrane",
                    GenreId = new Guid("6d3dbb7d-6297-4839-aaa5-650760356875")
                },
                //Country Artists
                new Artist
                {
                    Id = new Guid("6a68cdd0-30c1-4b8c-9d3c-278c56bc7447"),
                    ArtistName = "Luke Combs",
                    GenreId = new Guid("4a4395c0-b3ce-4d32-916f-30200e9c7903")
                },
                new Artist
                {
                    Id = new Guid("1cf59f25-ea0f-46e1-9386-76d684e851ba"),
                    ArtistName = "Morgan Wallen",
                    GenreId = new Guid("4a4395c0-b3ce-4d32-916f-30200e9c7903")
                },
                new Artist
                {
                    Id = new Guid("bf0d8839-8205-4b38-ba5e-fe485409f423"),
                    ArtistName = "Kane Brown",
                    GenreId = new Guid("4a4395c0-b3ce-4d32-916f-30200e9c7903")
                }
            );
        }
    }
}