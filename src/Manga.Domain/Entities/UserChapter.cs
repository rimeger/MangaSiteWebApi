using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga.Domain.Entities
{
    public class UserChapter
    {
        public Guid ChapterId { get; set; }
        public Guid UserId { get; set; }
        public MangaChapter MangaChapter { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
