using SQLThing.indexing.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLThing.indexing.api
{
    public interface IInvertedIndexStorage
    {
        void StoreIndex(DocumentIndex index);
        Token[] ResolveTokens(string[] words);
        string[] SearchWords(string incompleteInput);
        //Store by opening the index and searching
        List<DocumentIndex> MatchTokens(Token[] tokens);
        long GetPostingListSize(Token token);
        //I need the total term count of index - can do
        //I need the total document count of token - can do
        Dictionary<int, long> GetPostingListSizes(int[] tokenIds);
        long GetTotalCorpusSize();
    }

}
