using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Bulletin_Board.Models
{
    public class BulletinBoardDB:DbContext
    {
        public DbSet<MessageModel> Msgs { get; set; }
        public DbSet<Zhibanyuan> Zhibanyuans { get; set; }
    }
}