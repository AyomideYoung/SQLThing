using SQLThing.indexing.api;
using SQLThing.indexing.models;
using SQLThing.ranking.api;
using SQLThing.ranking.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLThing.ranking.impl
{
    public class TFIDFRankingAlgorithm:IRanking
    {
        private readonly IInvertedIndexStorage _invertedIndexStorage;
        private long _totalCorpusSize;

        public TFIDFRankingAlgorithm(IInvertedIndexStorage invertedIndexStorage)
        {
            _invertedIndexStorage = invertedIndexStorage;
            _totalCorpusSize = _invertedIndexStorage.GetTotalCorpusSize();
        }

        public List<ScoredDocumentIndex> Rank(List<DocumentIndex> indexes, int[] tokenIds)
        {
            // 1. Get posting list sizes for the relevant tokens
            Dictionary<int, long> postingListSizes = _invertedIndexStorage.GetPostingListSizes(tokenIds);
            _totalCorpusSize = _invertedIndexStorage.GetTotalCorpusSize();

            // 2. Calculate scores for each document
            var scoredDocuments = new List<ScoredDocumentIndex>();

            foreach (var docIndex in indexes)
            {
                double documentScore = 0;

                foreach (var token in tokenIds)
                {
                    // Retrieve the string representation of the token (assuming a mapping exists)
                    // This part depends on how your tokens are stored.
                    // For simplicity, we'll assume we can get it from an existing dictionary
                    // or just use the token ID to access the frequency.

                    // Check if the document contains the token and get its frequency
                    if (docIndex.FrequencyDict.TryGetValue(token.ToString(), out long termFrequency))
                    {
                        // Calculate TF: (term count in doc) / (total terms in doc)
                        double tf = (double)termFrequency / docIndex.totalTermCount;

                        // Calculate IDF: log(total docs / docs with term)
                        double idf = 0;
                        if (postingListSizes.ContainsKey(token) && postingListSizes[token] > 0)
                        {
                            idf = Math.Log((double)_totalCorpusSize / postingListSizes[token]);
                        }

                        // Calculate TF-IDF score for the term in the document
                        documentScore += tf * idf;
                    }
                }

                // Add the document and its final score to the list
                scoredDocuments.Add(new ScoredDocumentIndex(docIndex, documentScore));
            }

            // 3. Rank documents by score in descending order
            return scoredDocuments.OrderByDescending(d => d.Score).ToList();
        }
    }
    
}
