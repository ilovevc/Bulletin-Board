﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bulletin_Board.Models
{
    public class MessageModel
    {
        public int Id { set; get; }
        public string cls { get; set; }
        public string msg { get; set; }
        public string zhiban1 { get; set; }
        public string zhiban2 { get; set; }
    }
    public class Zhibanyuan
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}