using SQLThing.indexing.models;
using SQLThing.ranking.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLThing.ranking.api
{
    public interface IRanking
    {
        List<ScoredDocumentIndex> Rank(List<DocumentIndex> scoredIndex, int[] tokenIds);

    }
}
