using AdvertApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAdvert.SearchWorker
{
    public static class MappingHelper
    {
        public static AdvertType Map(AdvertModel message)
        {
            var doc = new AdvertType()
            {
                Id = "1",
                Title = message.Title,
                CreationDateTime = DateTime.UtcNow 
            };
            return doc;
        }
    }
}
