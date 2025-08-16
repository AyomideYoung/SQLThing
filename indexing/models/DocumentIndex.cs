using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLThing.indexing.models
{
    public class DocumentIndex
    {
        public string Id { get; set; }
        public string DocumentLink { get; set; }
        public string DocumentType { get; set; }
        public IDictionary<string, long> FrequencyDict = new Dictionary<string, long>();
        public long totalTermCount {get; set; }
    }
}
