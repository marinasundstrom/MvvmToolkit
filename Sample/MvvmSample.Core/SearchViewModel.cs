﻿using System.Collections.ObjectModel;
using System.Windows.Input;

using MvvmToolkit;

namespace MvvmSample
{
    public class SearchViewModel : BindableObject
    {
        public SearchViewModel(ISearchClient searchClient)
        {
            this.searchClient = searchClient;

            SearchResults = new ObservableCollection<SearchResults>();
            IsEnabled = true;
        }

        private string searchText;
        private Command searchCommand;
        private bool isEnabled;

        private readonly ISearchClient searchClient;

        public string SearchText
        {
            get => searchText;
            set
            {
                SetProperty(ref searchText, value);
                (SearchCommand as Command).RaiseCanExecuteChanged();
            }
        }

        public bool IsEnabled
        {
            get => isEnabled;
            set => SetProperty(ref isEnabled, value);
        }

        public ObservableCollection<SearchResults> SearchResults { get; }

        public ICommand SearchCommand => searchCommand ?? (searchCommand = new Command(async () =>
        {
            IsEnabled = false;

            SearchResults.Clear();

            await foreach (SearchResults result in searchClient.SearchAsync(SearchText))
            {
                SearchResults.Add(result);
            }

            IsEnabled = true;
        },
        () => !string.IsNullOrEmpty(searchText)));
    }
}