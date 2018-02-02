using System;
using DevExpress.Xpf.Docking;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Markup;
using DevExpress.Xpf.Bars;

namespace DS.OrangeAdmin.Client.UI.Views.Base
{
    [ContentProperty(nameof(Children))]
    public class DSDocumentPanel : DocumentPanel
    {
        Grid grid;
        Panel panel;
        public DSDocumentPanel()
        {
            this.grid = new Grid();
            this.Content = grid;

            grid.RowDefinitions.Add(new RowDefinition()
            {
                Height = new GridLength(0, GridUnitType.Auto)
            });
            grid.RowDefinitions.Add(new RowDefinition()
            {
                Height = new GridLength(100, GridUnitType.Star)
            });
            this.grid.VerticalAlignment = VerticalAlignment.Stretch;

            BarManager barManager = new BarManager();
            this.grid.Children.Add(barManager);
            Grid.SetRow(barManager, 0);
            //RibbonControl ribbon = new RibbonControl();
            //ribbon.RibbonStyle = RibbonStyle.OfficeSlim;
            //this.grid.Children.Add(ribbon);
            //Grid.SetRow(ribbon, 0);
            this.panel = new Grid();
            this.panel.VerticalAlignment = VerticalAlignment.Stretch;
            this.grid.Children.Add(this.panel);
            Grid.SetRow(this.panel, 1);

            this.Children = this.panel.Children;
            this.Bars = barManager.Bars;
        }

        public static readonly DependencyPropertyKey ChildrenProperty = DependencyProperty.RegisterReadOnly(
                                                    nameof(Children),  // Prior to C# 6.0, replace nameof(Children) with "Children"
                                                    typeof(UIElementCollection),
                                                    typeof(DSDocumentPanel),
                                                    new PropertyMetadata());

        public static readonly DependencyPropertyKey BarsProperty = DependencyProperty.RegisterReadOnly(
                                            nameof(Bars),  // Prior to C# 6.0, replace nameof(Children) with "Children"
                                            typeof(BarCollection),
                                            typeof(DSDocumentPanel),
                                            new PropertyMetadata());

        public UIElementCollection Children
        {
            get { return (UIElementCollection)GetValue(ChildrenProperty.DependencyProperty); }
            set { SetValue(ChildrenProperty, value); }
        }

        public BarCollection Bars
        {
            get { return (BarCollection)GetValue(BarsProperty.DependencyProperty); }
            set { SetValue(BarsProperty, value); }
        }
    }
}
