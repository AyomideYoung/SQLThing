using SQLThing.indexing.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLThing.matching
{
    interface IMatcher
    {
        DocumentIndex[] MatchToken(Token[] token);
    }
}
