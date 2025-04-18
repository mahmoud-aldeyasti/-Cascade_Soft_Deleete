using Microsoft.EntityFrameworkCore.Diagnostics;
using Save_Changes_interceptors.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 
namespace Save_Changes_interceptors.Data.Interceptors
{
    public class OverridingSaveChangeInterceptors : SaveChangesInterceptor
    {

        public override InterceptionResult<int> SavingChanges (DbContextEventData eventData, 
            InterceptionResult<int> result)
        {

            if( eventData.Context == null)
            {
                return result;
            }

            var context = eventData.Context; 
            
            foreach( var entry in context.ChangeTracker.Entries() )
            {
                if( entry .Entity is not ISoftDelete entity || entry.State != EntityState.Deleted)
                {
                    continue; 
                }

                entry.State = EntityState.Modified;
                
                entity.Delete();

            }

            return result; 

        }
    }
}
