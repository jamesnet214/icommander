﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Commander.Windows.Mvvm;

namespace Commander.Windows.Controls
{
    public class NcoreWindow : Window
    {
        private UIElement TaskLayout;
        public NcoreWindow()
        {
            Loaded += RiotView_Loaded;
        }


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            TaskLayout = this.Template.FindName("PART_TaskBar", this) as UIElement;
            TaskLayout.MouseMove += TaskLayout_MouseMove;
        }

        private void TaskLayout_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void RiotView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is ObservableObject vm)
            {
                vm.ForceLoaded(this);
            }
        }
    }
}
