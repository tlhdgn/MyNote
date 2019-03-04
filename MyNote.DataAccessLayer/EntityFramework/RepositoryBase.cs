using MyNote.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccessLayer.EntityFramework
{
    public class RepositoryBase
    {
        protected static DatabaseContext context;
        protected static object _lockSync = new object();

        protected RepositoryBase()
        {
            CreateContext();
        }

        private static void CreateContext()
        {
            if(context == null)
            {
                //multi-thread uygulamalarda aynı anda iki parçacık çalışmaması için lock ile kitliyoruz
                lock(_lockSync)
                {
                    if(context == null)
                    {
                        context = new DatabaseContext();
                    }
                }
            }
        }
    }
}
