using System.Windows;
using System.Windows.Controls;
using WindowsDimmer.ViewModels;

namespace WindowsDimmer.TemplateSelectors
{
    internal class MainWindowTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            switch (item)
            {
                case DrimmerViewModel _: return App.Current.FindResource("DrimmerTemplate") as DataTemplate;
                case ConfigViewModel _: return App.Current.FindResource("ConfigTemplate") as DataTemplate;
                default: return new DataTemplate();
            }
        }
    }
}
