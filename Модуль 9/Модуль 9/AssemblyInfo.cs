using System.Windows;

// Указывает настройки расположения словарей ресурсов темы для WPF-приложения
[assembly: ThemeInfo(
    ResourceDictionaryLocation.None,            // Где искать специфичные для темы словари ресурсов (None, так как используются общие)
    ResourceDictionaryLocation.SourceAssembly   // Где искать общие словари ресурсов (в текущей сборке приложения, например, в App.xaml)
)]