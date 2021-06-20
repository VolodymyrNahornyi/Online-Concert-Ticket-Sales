using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace OnlineConcertTicketSales.Formatters
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext 
            context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();
            if (context.Object is IEnumerable<GenreDto>)
            {
                foreach (var genre in (IEnumerable<GenreDto>)context.Object)
                {
                    FormatCsv(buffer, genre);
                }
            }
            else
            {
                FormatCsv(buffer, (GenreDto)context.Object);
            }
            await response.WriteAsync(buffer.ToString());
        }
        private static void FormatCsv(StringBuilder buffer, GenreDto genre)
        { 
            buffer.AppendLine($"{genre.Id},\"{genre.GenreName}\"");
        }

        
        protected override bool CanWriteType(Type type)
        {
            if (typeof(GenreDto).IsAssignableFrom(type) ||
                typeof(IEnumerable<GenreDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }
    }
}