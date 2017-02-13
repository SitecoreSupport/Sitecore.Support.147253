using System.Data.SqlClient;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.ListManagement.ContentSearch.Pipelines;

namespace Sitecore.Support.ListManagement.ContentSearch.Pipelines.ImportMediaContacts
{
    public class RemoveMediaItem : ListProcessor
    {
        public virtual void Process(ImportContactsBaseArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            Assert.IsNotNullOrEmpty(args.ImportFileId, "args.ImportFileId");
            Item item = base.Database.GetItem(args.ImportFileId);
            if (item != null)
            {
                try
                {
                    item.Delete();
                }
                catch
                {
                    Log.Warn("Sitecore.Support.147253 The Sitecore.Support.ListManagement.ContentSearch.Pipelines.ImportMediaContacts processor was interrupted ", this);
                }
            }
        }
    }
}
