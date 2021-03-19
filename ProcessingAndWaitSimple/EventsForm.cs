using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcessingAndWait.Classes.Containers;

namespace ProcessingAndWait
{
    public partial class EventsForm : Form
    {
        private readonly List<AppEventItem> _appEventList;

        public EventsForm(List<AppEventItem> itemList)
        {
            InitializeComponent();
            
            _appEventList = itemList;
            
            Shown += OnShown;
        }

        public EventsForm()
        {
            InitializeComponent();
        }

        private void OnShown(object? sender, EventArgs e)
        {
            EventsListView.FullRowSelect = true;
            EventsListView.MultiSelect = false;
            
            EventsListView.BeginUpdate();

            try
            {
                foreach (var appEventItem in _appEventList)
                {
                    EventsListView.Items.Add(new ListViewItem(appEventItem.ItemArray()));
                }

                EventsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                EventsListView.Items[0].Selected = true;
                EventsListView.EnsureVisible(0);
            }
            finally
            {
                EventsListView.EndUpdate();
            }

            ActiveControl = EventsListView;

        }
    }
}
