using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BRGS.Util
{
	#region Data Grid Column Comparer

	public class DataGridComparer : System.Collections.IComparer
	{
		DataGridView _grid;
		List<SortColDefn> _sortedColumns;
		int _maxSortColumns;

		private struct SortColDefn
		{
			internal int colNum;
		    internal int colOriginal;
			internal bool ascending;

			internal SortColDefn(int columnNum, int columnOriginal, SortOrder sortOrder)
			{
				colNum = columnNum;
                colOriginal = columnOriginal;
				ascending = (sortOrder != SortOrder.Descending);
			}
		}

		public DataGridComparer(DataGridView datagrid)
		{
			_grid = datagrid;

			// No limit by default to the number of columns sorted.
			_maxSortColumns = 0;

			_sortedColumns = new List<SortColDefn>(_maxSortColumns);
		}

		public int MaxSortColumns
		{
			get { return _sortedColumns.Capacity; }
			set
			{
				if (_sortedColumns.Count > value)
					_sortedColumns.RemoveRange(value - 1, _sortedColumns.Count);

				_sortedColumns.Capacity = value;
			}
		}

		public SortOrder SetSortColumn(int columnIndex, Keys ModifierKeys)
		{
			bool keepSamePriority = ((ModifierKeys & Keys.Control) == Keys.Control);
			SortColDefn colDefn = new SortColDefn();

            colDefn = MapearOrdenacaoColuna(columnIndex);

            if (_sortedColumns.Count > 0 && !keepSamePriority)
			{
				// Erase the current sort glyph.			
                _grid.Columns[_sortedColumns[0].colOriginal].HeaderCell.SortGlyphDirection = SortOrder.None;
			}            

			int sortPriority = _sortedColumns.FindIndex(
                delegate(SortColDefn cd) { return cd.colNum == colDefn.colNum; });

			if (sortPriority != -1)
                return ReverseSort(colDefn, keepSamePriority, sortPriority);		
			
            if (keepSamePriority)
			{
				_sortedColumns.Add(colDefn);
				if (_sortedColumns.Count > 1)
					return SortOrder.Ascending; // Do not set the glyph.
			}
			else
				_sortedColumns.Insert(0, colDefn);
            
		    colDefn.colNum = short.Parse(columnIndex.ToString());
          
			_grid.Columns[colDefn.colOriginal].HeaderCell.SortGlyphDirection = SortOrder.Ascending;

			return SortOrder.Ascending;
		}

        private SortColDefn MapearOrdenacaoColuna(int colunaSelecionada)
        {
            int colunaRedirecionada = colunaSelecionada;

            if (_grid.Name == "gvOrdensPagamentos" && colunaSelecionada == 1)
                colunaRedirecionada = 0;
            else if (_grid.Name == "gvAbastecimentos" && colunaSelecionada == 1)
                colunaRedirecionada = 0;
            else if (_grid.Name == "gvAbastecimentos" && colunaSelecionada == 9)
                colunaRedirecionada = 8;
            else if (_grid.Name == "gvFretes" && colunaSelecionada == 1)
                colunaRedirecionada = 0;
            else if (_grid.Name == "gvManutencoes" && colunaSelecionada == 1)
                colunaRedirecionada = 0;
            else if (_grid.Name == "gvManutencoes" && colunaSelecionada == 7)
                colunaRedirecionada = 6;

            return new SortColDefn(colunaRedirecionada, colunaSelecionada, _grid.Columns[colunaSelecionada].HeaderCell.SortGlyphDirection);
        }

		private SortOrder ReverseSort(SortColDefn colDefn, bool keepSamePriority, int sortPriority)
		{
            // The column is already being sorted.
			SortOrder sortOrder;
			if (sortPriority == 0 || keepSamePriority)
			{
				// There is no need to change where it is in the list.
				colDefn.ascending = !colDefn.ascending;
				_sortedColumns[sortPriority] = colDefn;

				sortOrder = colDefn.ascending ? SortOrder.Ascending : SortOrder.Descending;
				if (sortPriority != 0)
					return sortOrder; // Reverse only, do not set the glyph.
			}
			else
			{
				// Promote this column to be the first.
				for (int loop = sortPriority; loop > 0; --loop)
				{
					_sortedColumns[loop] = _sortedColumns[loop - 1];
				}
				// Promoted columns are always sorted ascending.
				colDefn.ascending = true;
				_sortedColumns[0] = colDefn;
				sortOrder = SortOrder.Ascending;
			}
			_grid.Columns[colDefn.colOriginal].HeaderCell.SortGlyphDirection = sortOrder;

			return sortOrder;
		}

		public string SortOrderDescription
		{
			get
			{
				StringBuilder sb = new StringBuilder("Sorted by ");

				foreach (SortColDefn colDefn in _sortedColumns)
				{					
					sb.Append(_grid.Columns[colDefn.colNum].HeaderText);
					sb.Append(colDefn.ascending ? " ASC, " : " DESC, ");
				}

				sb.Length -= 2;

				return sb.ToString();
			}
		}

		public int Compare(DataGridViewCellCollection lhs, DataGridViewCellCollection rhs)
		{
			foreach (SortColDefn colDefn in _sortedColumns)
			{
				int retval = Comparer<object>.Default.Compare(
					lhs[colDefn.colNum].Value,
					rhs[colDefn.colNum].Value);

				if (retval != 0)
					return (colDefn.ascending ? retval : -retval);
			}

			// These two rows are indistinguishable.
			return 0;
		}

		#region IComparer Members

		public int Compare(object x, object y)
		{
			DataGridViewRow lhs = x as DataGridViewRow;
			DataGridViewRow rhs = y as DataGridViewRow;

			return Compare(lhs.Cells, rhs.Cells);
		}

		#endregion
	}

	#endregion
}
