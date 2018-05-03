using DinamicallyControllers.Controllers.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinamicallyControllers.Models
{
    [GeneratedController("api/albums")]
    public class Album
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
    }
}
