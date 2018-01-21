using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyInkCanvas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // InkCanvasでペン以外も入力ＯＫ
            this.InkCanvas.InkPresenter.InputDeviceTypes =
                CoreInputDeviceTypes.Pen | CoreInputDeviceTypes.Mouse | CoreInputDeviceTypes.Touch;

            // ペンの色や太さを変更
            var attr = new InkDrawingAttributes
            {
                Color = Colors.Red,
                Size = new Size(10, 10),
            };
            this.InkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(attr);
        }

        /// <summary>
        /// Clearボタン押したときのイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppBarClearButton_Click(object sender, RoutedEventArgs e)
        {
            // Canvas上の線をすべて消す
            this.InkCanvas.InkPresenter.StrokeContainer.Clear();
        }

        /// <summary>
        /// Eraserボタン押したときのイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppBarEraserButton_Click(object sender, RoutedEventArgs e)
        {
            // モード切替
            if(this.InkCanvas.InkPresenter.InputProcessingConfiguration.Mode == InkInputProcessingMode.Inking)
            {
                this.InkCanvas.InkPresenter.InputProcessingConfiguration.Mode = InkInputProcessingMode.Erasing;
            } else
            {
                this.InkCanvas.InkPresenter.InputProcessingConfiguration.Mode = InkInputProcessingMode.Inking;
            }
        }
    }
}
