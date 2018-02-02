using System;
using System.Collections;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Grid;
using DS.OrangeAdmin.Client.UI.DataSources;

namespace DS.OrangeAdmin.Client.UI.UserControls
{
    /// <summary>
    /// Interaction logic for DSGridControl.xaml
    /// </summary>
    public partial class DSGridControl : UserControl
    {
        enum DataEvent { INIT, SCROLL }

        private int _viewSize;
        private int _pageSize;
        private int _page;
        private IList _data;

        public DSGridControl()
        {
            this._viewSize = 29;
            this._pageSize = 101;

            InitializeComponent();
            this.Columns = this.datagrid.Columns;
            //this.scroll.Scroll += Scroll_Scroll;
            this.scroll.ValueChanged += Scroll_ValueChanged;
            this.scroll.Scroll += Scroll_Scroll;
            this.datagrid.PreviewMouseWheel += Datagrid_PreviewMouseWheel;
        }

        private void Datagrid_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            e.Handled = true;
        }

        private void Scroll_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            if(e.ScrollEventType== System.Windows.Controls.Primitives.ScrollEventType.EndScroll)
            {
                int intValue = Convert.ToInt32(e.NewValue);
                int page;
                int reminder;
                page = Math.DivRem(intValue, (this._pageSize - 1) / 2, out reminder);
                this._page = page;

                getData(DataEvent.SCROLL, reminder);
            }
        }

        private void Scroll_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        /*private void Scroll_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            this.datagrid.View.FocusedRowHandle = Convert.ToInt32(e.NewValue);
        }*/

        public static readonly DependencyPropertyKey ColumnsProperty = DependencyProperty.RegisterReadOnly(
                                            nameof(Columns),  // Prior to C# 6.0, replace nameof(Children) with "Children"
                                            typeof(GridColumnCollection),
                                            typeof(DSGridControl),
                                            new PropertyMetadata());

        public static readonly DependencyProperty DataSourceProperty = DependencyProperty.Register(
                                    nameof(DataSource),  // Prior to C# 6.0, replace nameof(Children) with "Children"
                                    typeof(IDataSource),
                                    typeof(DSGridControl),
                                    new PropertyMetadata(null, OnBoundDataSourceChanged));

        public GridColumnCollection Columns
        {
            get { return (GridColumnCollection)GetValue(ColumnsProperty.DependencyProperty); }
            set { SetValue(ColumnsProperty, value); }
        }

        public object ItemsSource
        {
            get { return this.datagrid.ItemsSource; }
            set { this.datagrid.ItemsSource = value; }
        }

        public object SelectedItem
        {
            get { return this.datagrid.SelectedItem; }
            set { this.datagrid.SelectedItem = value; }
        }

        public IDataSource DataSource
        {
            get { return (IDataSource)GetValue(DataSourceProperty); }
            set
            {
                SetValue(DataSourceProperty, value);
                getData(DataEvent.INIT);
            }
        }

        private async Task getData(DataEvent @event, int offset = 0)
        {
            if (this.DataSource != null)
            {
                int skip;
                skip = (this._page - 1) * (this._pageSize - 1) / 2;

                int take;
                if (skip < 0)
                {
                    take = this._pageSize + skip;
                    skip = 0;
                }
                else
                {
                    take = this._pageSize;
                }

                this._data = await this.DataSource.GetData(take, skip);
                this.datagrid.ItemsSource = this._data;

                switch (@event)
                {
                    case DataEvent.INIT:
                        this.scroll.Maximum = await this.DataSource.Count() - 1;
                        break;
                    case DataEvent.SCROLL:
                        if (this._page == 0)
                        {
                            if (offset > this._viewSize)
                            {
                                this.datagrid.View.TopRowIndex = Math.Min(offset, this.datagrid.VisibleRowCount);
                            }
                            else
                            {
                                this.datagrid.View.TopRowIndex = 0;
                            }
                            this.datagrid.SelectedItem = this._data[Math.Min(offset, this.datagrid.VisibleRowCount)];
                        }
                        else
                        {
                            int newOffset = (this._pageSize - 1) / 2 + offset;
                            this.datagrid.View.TopRowIndex = Math.Min(newOffset, this.datagrid.VisibleRowCount);
                            this.datagrid.SelectedItem = this._data[Math.Min(newOffset, this.datagrid.VisibleRowCount)];
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                this.datagrid.ItemsSource = null;
            }
        }

        private static async void OnBoundDataSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DSGridControl datagrid = d as DSGridControl;
            await datagrid.getData(DataEvent.INIT);
        }
    }
}
