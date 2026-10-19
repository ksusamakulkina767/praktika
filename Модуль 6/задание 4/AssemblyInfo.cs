using System.Windows;

// Настройка WPF: где искать стили оформления
[assembly: ThemeInfo(
    // Стили под темы Windows (светлая/тёмная) — не искать
    ResourceDictionaryLocation.None,

    // Общие стили — искать в этом приложении
    ResourceDictionaryLocation.SourceAssembly
)]