using System.Windows;

// Настройка WPF: где искать стили (цвета, шрифты, оформление)
[assembly: ThemeInfo(
    ResourceDictionaryLocation.None,           // стили для тем Windows — не искать(не подключать отдельные стили под темы Windows)
    ResourceDictionaryLocation.SourceAssembly  // общие стили — искать в этом приложении
)]