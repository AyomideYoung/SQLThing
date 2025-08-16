using SQLThing.indexing.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLThing.ranking.models
{
    public class ScoredDocumentIndex: DocumentIndex
    {
        public ScoredDocumentIndex(DocumentIndex documentIndex, double score)
        {
            Id = documentIndex.Id;
            DocumentLink = documentIndex.DocumentLink;
            DocumentType = documentIndex.DocumentType;
            Score = score;
            FrequencyDict = documentIndex.FrequencyDict;
            totalTermCount = documentIndex.totalTermCount;
        }

        public double Score { get; set; }

        public override string ToString()
        {
            return $"ScoredDocumentIndex(Id: {Id}, DocumentLink: {DocumentLink}, DocumentType: {DocumentType}, Score: {Score}, FrequencyDict: [{string.Join(", ", FrequencyDict.Select(kv => $"{kv.Key}: {kv.Value}"))}])";
        }
    }
}
