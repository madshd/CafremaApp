using Microsoft.Extensions.DependencyInjection;
using Supabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafremaApp.Infrastructure
{
    public class SupabaseClientWrapper
    {
        public Client Client { get; }

        public SupabaseClientWrapper(string url, string key)
        {
            Client = new Client(url, key);
            // Note: InitializeAsync will be called by DI after startup if needed
        }
    }
}
