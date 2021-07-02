using System;
using Entities.Models.Concerts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contracts
{
public class ConcertConfiguration : IEntityTypeConfiguration<Concert>
    {
        public void Configure(EntityTypeBuilder<Concert> builder)
        {
            builder.HasData
            (
                //The Beatles Concerts
                new Concert
                {
                    Id = new Guid("9637b59a-65e6-4049-8ace-5dfc70a79593"),
                    ConcertName = "The Beatles at Apple Corps Rooftop",
                    ArtistId = new Guid("cea51056-4180-45e6-9007-b92b2c4e806a"),
                    Date = DateTime.Now.AddMonths(-5)
                },
                new Concert
                {
                    Id = new Guid("9f0b0daf-70aa-4a9e-bd89-70adf5351655"),
                    ConcertName = "The Beatles at Twickenham Studios",
                    ArtistId = new Guid("cea51056-4180-45e6-9007-b92b2c4e806a"),
                    Date = DateTime.Now.AddMonths(-4)
                },
                new Concert
                {
                    Id = new Guid("ccc3968c-5418-4df6-a8cb-eedb803f9ab3"),
                    ConcertName = "The Beatles at EMI Recording Studios",
                    ArtistId = new Guid("cea51056-4180-45e6-9007-b92b2c4e806a"),
                    Date = DateTime.Now.AddMonths(-3)
                },
                new Concert
                {
                    Id = new Guid("c9fdbce2-b8f4-4d9e-a319-c805590beebc"),
                    ConcertName = "The Beatles at Candlestick Park",
                    ArtistId = new Guid("cea51056-4180-45e6-9007-b92b2c4e806a"),
                    Date = DateTime.Now.AddMonths(-1)
                },
                new Concert
                {
                    Id = new Guid("b2415bc2-1137-4a79-80ac-ad1be8721e42"),
                    ConcertName = "The Beatles at Seattle Center Coliseum",
                    ArtistId = new Guid("cea51056-4180-45e6-9007-b92b2c4e806a"),
                    Date = DateTime.Now.AddMonths(1)
                },
                new Concert
                {
                    Id = new Guid("6a972a13-c1dc-4322-894e-e6103bbdc620"),
                    ConcertName = "The Beatles at Shea Stadium",
                    ArtistId = new Guid("cea51056-4180-45e6-9007-b92b2c4e806a"),
                    Date = DateTime.Now.AddMonths(2)
                },
                //The Queen Concerts
                new Concert
                {
                    Id = new Guid("ec19f4c0-5682-4941-8eb4-71475744610c"),
                    ConcertName = "Early shows",
                    ArtistId = new Guid("f32cba10-8b39-430b-904e-1013ce10bd7e"),
                    Date = DateTime.Now.AddMonths(-3)
                },
                new Concert
                {
                    Id = new Guid("73ae9a23-7f86-4088-b37c-1b6f569edce2"),
                    ConcertName = "Queen I",
                    ArtistId = new Guid("f32cba10-8b39-430b-904e-1013ce10bd7e"),
                    Date = DateTime.Now.AddMonths(-2)
                },
                new Concert
                {
                    Id = new Guid("3e55eb93-e228-4d90-87ad-3341b15760c9"),
                    ConcertName = "Queen II",
                    ArtistId = new Guid("f32cba10-8b39-430b-904e-1013ce10bd7e"),
                    Date = DateTime.Now.AddMonths(-1)
                },
                new Concert
                {
                    Id = new Guid("d8ef04df-052b-417e-8812-3f45986c9c14"),
                    ConcertName = "Sheer Heart Attack",
                    ArtistId = new Guid("f32cba10-8b39-430b-904e-1013ce10bd7e"),
                    Date = DateTime.Now.AddMonths(0)
                },
                new Concert
                {
                    Id = new Guid("9abedbd5-7407-46fd-a09e-070353a576a3"),
                    ConcertName = "A Night At The Opera",
                    ArtistId = new Guid("f32cba10-8b39-430b-904e-1013ce10bd7e"),
                    Date = DateTime.Now.AddMonths(1)
                },
                new Concert
                {
                    Id = new Guid("ba4345df-2828-4f1e-b040-380ee65bdc54"),
                    ConcertName = "Day At The Races",
                    ArtistId = new Guid("f32cba10-8b39-430b-904e-1013ce10bd7e"),
                    Date = DateTime.Now.AddMonths(2)
                },
                new Concert
                {
                    Id = new Guid("ed232607-0b60-42e5-b7fc-a4ceb2502a16"),
                    ConcertName = "News Of The World",
                    ArtistId = new Guid("f32cba10-8b39-430b-904e-1013ce10bd7e"),
                    Date = DateTime.Now.AddMonths(3)
                }
            );
        }
    }
}