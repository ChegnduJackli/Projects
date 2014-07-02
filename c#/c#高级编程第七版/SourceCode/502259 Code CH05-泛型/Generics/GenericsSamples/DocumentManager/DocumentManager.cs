using System;
using System.Collections.Generic;

namespace Wrox.ProCSharp.Generics
{
    //泛型类添加约束
    //实现这个接口，where子句指定了实现IDocument接口的要求
    //表示TDocument类型必须实现IDocument接口，此例中就是Document 类
    public class DocumentManager<TDocument>
        where TDocument : IDocument
    {
        private readonly Queue<TDocument> documentQueue = new Queue<TDocument>();   

        public void AddDocument(TDocument doc)
        {
            lock (this)
            {
                documentQueue.Enqueue(doc);
            }
        }

        public bool IsDocumentAvailable
        {
            get { return documentQueue.Count > 0; }
        }

        public void DisplayAllDocuments()
        {
            foreach (TDocument doc in documentQueue)
            {
                Console.WriteLine(doc.Title);
            }
        }


        public TDocument GetDocument()
        {
            TDocument doc = default(TDocument);
            lock (this)
            {
                doc = documentQueue.Dequeue();
            }
            return doc;
        }

    }

}
