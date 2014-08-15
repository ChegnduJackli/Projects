using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class WordsEntity
    {
        public int ID { get; set; }
        public string Word { get; set; }
        public string Description { get; set; }
        public DateTime AddTime { get; set; }
    }

    public class Article
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string FilePath { get; set; }
        public DateTime AddTime { get; set; }
    }
}
