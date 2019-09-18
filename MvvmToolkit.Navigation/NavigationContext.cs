using System;
using System.Collections.Generic;

namespace MvvmToolkit.Navigation
{
    public class NavigationContext
    {
        public NavigationContext(Uri navigationUri, IReadOnlyDictionary<string, object> parameters)
        {
            NavigationUri = navigationUri;
            Parameters = parameters;
        }

        public Uri NavigationUri { get; }
        public IReadOnlyDictionary<string, object> Parameters { get; }
    }
}
