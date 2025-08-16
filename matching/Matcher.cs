using SQLThing.indexing.api;
using SQLThing.indexing.models;
using SQLThing.ranking.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLThing.matching
{
    public class Matcher:IMatcher
    {
        public Matcher(IInvertedIndexStorage invertedIndexStorage)
        {
            InvertedIndexStorage = invertedIndexStorage;
            RankingAlgorithm = new TFIDFRankingAlgorithm(InvertedIndexStorage);
        }

        public IInvertedIndexStorage InvertedIndexStorage { get; }
        public TFIDFRankingAlgorithm RankingAlgorithm { get; }

        public DocumentIndex[] MatchToken(Token[] token)
        {
            // This method should match the tokens against the inverted index storage
            // And then rank them using TFIDF.

            int[] tokenIds = token.Select(t => int.Parse(t.Id)).ToArray();
            List<DocumentIndex> matchedDocuments = InvertedIndexStorage.MatchTokens(token);
            if (matchedDocuments == null || matchedDocuments.Count == 0)
            {
                return Array.Empty<DocumentIndex>();
            }

            return RankingAlgorithm.Rank(matchedDocuments, tokenIds).ToArray();
        }
    }
}
