using System.Windows;
using OpenTK.Windowing.Common;
using OpenTK.Wpf;

namespace FailingIntelDriverTest;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private ExampleScene _exampleScene;

    public MainWindow()
    {
        InitializeComponent();

        GLWpfControlSettings settings = new()
        {
            Profile = ContextProfile.Core,
            Samples = 0,
            MajorVersion = 3,
            MinorVersion = 3,
            RenderContinuously = true,
            ContextFlags = ContextFlags.Debug | ContextFlags.Offscreen,
        };

        OpenTKControl.Start(settings);

        _exampleScene = new ExampleScene();

        _exampleScene.Initialize();
    }

    private void OpenTKControl_OnRender(TimeSpan obj)
    {
        _exampleScene.Render();
    }
}