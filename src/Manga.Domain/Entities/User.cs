﻿using Manga.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public ICollection<UserChapter> UserChapters { get; set; } = new List<UserChapter>();
        public ICollection<UserTitle> UserTitles { get; set; } = new List<UserTitle>();
    }
}
