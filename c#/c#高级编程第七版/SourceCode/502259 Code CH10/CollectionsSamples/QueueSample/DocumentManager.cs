using System.Collections.Generic;

//队列是先进先出的方式来处理集合
namespace Wrox.ProCSharp.Collections
{
    public class DocumentManager
    {
        private readonly Queue<Document> documentQueue = new Queue<Document>();

        //实际应用中，文档可以写入文件，数据库，或通过网络发送
        public void AddDocument(Document doc)
        {
            lock (this)
            {
                documentQueue.Enqueue(doc);
            }
        }

        public Document GetDocument()
        {
            Document doc = null;
            lock (this)
            {
                //从队列的头部获取元素，读取元素，将同时从队列中删除元素。
                doc = documentQueue.Dequeue();
            }
            return doc;
        }

        public bool IsDocumentAvailable
        {
            get
            {
                return documentQueue.Count > 0;
            }
        }
    }

}
