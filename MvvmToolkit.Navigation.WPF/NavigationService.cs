using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Controls;

namespace MvvmToolkit.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly Frame frame;
        private readonly IServiceProvider serviceProvider;

        public NavigationService(Frame frame, IServiceProvider serviceProvider)
        {
            this.frame = frame;
            this.serviceProvider = serviceProvider;
        }

        public Task GoBack()
        {
            frame.GoBack();

            return Task.CompletedTask;
        }

        public void ClearAllBackEntries()
        {
            System.Windows.Navigation.NavigationService navigationService = frame.NavigationService;
            while (navigationService.CanGoBack)
            {
                navigationService.RemoveBackEntry();
            }
        }

        public Task Navigate(string navigationUri)
        {
            return Navigate(new Uri(navigationUri, UriKind.RelativeOrAbsolute));
        }

        public Task Navigate(Uri navigationUri)
        {
            var taskCompletionSource = new TaskCompletionSource<object>();

            try
            {
                navigationUri = new Uri(new Uri($"package://{Assembly.GetExecutingAssembly().GetName().Name}/"), navigationUri);

                Type pageType = ResolvePageType(navigationUri);

                serviceProvider.GetService<IThreadDispatcher>().RunOnMainThread(async () =>
                {
                    IReadOnlyDictionary<string, object> parameters = ParseQueryParameters(navigationUri.Query);

                    var navigationContext = new NavigationContext(
                        new Uri(navigationUri.LocalPath, UriKind.Relative),
                        parameters);

                    object page = serviceProvider.GetService(pageType);

                    if (frame.NavigationService.Content is IPage page1)
                    {
                        await page1.OnNavigatedFrom(navigationContext).ConfigureAwait(false);
                    }

                    frame.Navigate(page);

                    if (page is IPage page2)
                    {
                        await page2.OnNavigatedTo(navigationContext).ConfigureAwait(false);
                    }

                    taskCompletionSource.SetResult(null);
                });
            }
            catch (Exception e)
            {
                taskCompletionSource.SetException(e);
            }

            return taskCompletionSource.Task;
        }

        private static IReadOnlyDictionary<string, object> ParseQueryParameters(string query)
        {
            var parameters = new Dictionary<string, object>();
            System.Collections.Specialized.NameValueCollection queryCollection = HttpUtility.ParseQueryString(query);
            foreach (string key in queryCollection.Keys)
            {
                parameters.Add(key, queryCollection[key]);
            }
            return parameters;
        }

        protected virtual Type ResolvePageType(Uri navigationUri)
        {
            var assembly = Assembly.GetEntryAssembly();
            string assemblyName = assembly.GetName().Name;
            string originalString = navigationUri.LocalPath;
            int index = -1;
            string resolvedPageTypeName;
            if ((index = originalString.IndexOf("?")) > -1)
            {
                resolvedPageTypeName = $"{assemblyName}{originalString.Substring(0, index).Replace('/', '.')}";
            }
            else
            {
                resolvedPageTypeName = $"{assemblyName}{originalString.Replace('/', '.')}";
            }

            return assembly.GetType(resolvedPageTypeName);
        }
    }
}
