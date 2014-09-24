using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterkiller
{
    public class ListboxItem
    {
        private string path;
        private string title;

        public string Path { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
