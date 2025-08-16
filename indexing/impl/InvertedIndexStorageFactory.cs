using SQLThing.indexing.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLThing.indexing.impl
{
    public class InvertedIndexStorageFactory: IInvertedIndexStorageFactory
    {
        private static IInvertedIndexStorage _storage = new MySqlBasedInvertedTokenStorage();
        public  IInvertedIndexStorage Create()
        {
            return _storage;
        }
    }
}
