using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection_13
{
    class ResourceHolderBase : IDisposable
    {
        public string ResourceName { get; private set; }
        public StreamReader str = new StreamReader("streamreader.txt");
        protected bool _disposed;

        public ResourceHolderBase()
        {
            this.ResourceName = "Simple name";
        }

        ~ResourceHolderBase()
        {
            Console.WriteLine("type:{0}, Finilizer was used",this.GetType());
            Dispose(false);
        }

        public void MakeAction()
        {
            Console.WriteLine("This method is simply demonstrate that action");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (str != null)
                    {
                        str.Dispose();
                    }
                }
                _disposed = true;
            }
        }
    }
}

