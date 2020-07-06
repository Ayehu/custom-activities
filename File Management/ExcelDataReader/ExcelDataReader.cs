using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using ExcelDataReader.Core;

namespace ExcelDataReader
{
    /// <summary>
    /// A generic implementation of the IExcelDataReader interface using IWorkbook/IWorksheet to enumerate data.
    /// </summary>
    /// <typeparam name="TWorkbook">A type implementing IWorkbook</typeparam>
    /// <typeparam name="TWorksheet">A type implementing IWorksheet</typeparam>
    internal abstract class ExcelDataReader<TWorkbook, TWorksheet> : IExcelDataReader
        where TWorkbook : IWorkbook<TWorksheet>
        where TWorksheet : IWorksheet
    {
        private IEnumerator<TWorksheet> _worksheetIterator;
        private IEnumerator<Row> _rowIterator;
        private IEnumerator<TWorksheet> _cachedWorksheetIterator;
        private List<TWorksheet> _cachedWorksheets;

        ~ExcelDataReader()
        {
            Dispose(false);
        }

        public string Name => _worksheetIterator?.Current?.Name;

        public string CodeName => _worksheetIterator?.Current?.CodeName;

        public string VisibleState => _worksheetIterator?.Current?.VisibleState;

        public HeaderFooter HeaderFooter => _worksheetIterator?.Current?.HeaderFooter;

        // We shouldn't expose the internal array here. 
        public CellRange[] MergeCells => _worksheetIterator?.Current?.MergeCells;

        public int Depth { get; private set; }

        public int ResultsCount => Workbook?.ResultsCount ?? -1;

        public bool IsClosed { get; private set; }

        public int FieldCount => _rowIterator?.Current?.Cells.Count ?? 0;

        public int RowCount => _worksheetIterator?.Current?.RowCount ?? 0;

        public int RecordsAffected => throw new NotSupportedException();

        public double RowHeight => _rowIterator?.Current.Height ?? 0;

        protected TWorkbook Workbook { get; set; }

        protected Cell[] RowCells { get; set; }

        public object this[int i] => GetValue(i);

        public object this[string name] => throw new NotSupportedException();


        #region Range
        private int GetColumn(string columnAddress)
        {
            return columnAddress.ToUpper().
                Aggregate(0, (column, letter) => 26 * column + letter - 'A' + 1);
        }

        private int GetRow(string address)
        {
            return int.Parse(address.Substring(GetStartIndex(address)));
        }

        private int GetStartIndex(string address)
        {
            return address.IndexOfAny("123456789".ToCharArray());
        }

        public void GetRange(string range)
        {
            if (!string.IsNullOrEmpty(range))
            {
                string[] ranges = range.Trim().Split(',');
                // one-cell or multi-cell range with rows and columns in format of A1:A2, ... or just A1
                string pattern = @"(\$?[a-z]{1,3}\$?[0-9]{1,7}(\:\$?[a-z]{1,3}\$?[0-9]{1,7})|[a-z_\\][a-z0-9_\.]{0,254})";
                if (Regex.IsMatch(range, pattern, RegexOptions.IgnoreCase))
                {
                    // Get single cell
                    if (ranges.Length == 1 && ranges[0].Split(':').Length == 1)
                    {
                        int rowIndex = 0;
                        int colIndex = GetColumn(ranges[0].First().ToString());
                        if (ranges[0].Length > 1)
                            rowIndex = GetRow(ranges[0]);

                        GetSingleColumn(rowIndex, colIndex);
                    }
                    else
                    {
                        List<Row> rowsRange = new List<Row>();
                        foreach (string r in ranges)
                        {
                            string[] r_c = r.Split(':');

                            int rowIndex = 0;
                            var cells = new List<Cell>();
                            foreach (var rc in r_c) 
                            {
                                int colIndex = GetColumn(Regex.Replace(rc.ToString(), "[0-9]", ""));
                                if (rc.Length > 1)
                                    rowIndex = GetRow(rc.ToString());

                                cells.Add(new Cell(colIndex, null, null));
                                rowsRange.Add(new Row(rowIndex, 0, cells));
                            }
                        }

                        GetRange(rowsRange[0].RowIndex, rowsRange[1].RowIndex, rowsRange[0].Cells[0].ColumnIndex, rowsRange[0].Cells[1].ColumnIndex);
                    }
                }
                else
                {
                    int[] rowsCols = new int[4];
                    for (int i = 0; i < ranges.Length; i++)
                    {
                        if (int.TryParse(ranges[i], out _))
                        {
                            rowsCols[i] = int.Parse(ranges[i]);
                        }
                    }

                    GetRange(rowsCols[0], rowsCols[1], rowsCols[2], rowsCols[3]);
                }
            }
        }

        private void GetRange(int startRow, int endRow, int startColumn, int endColumn)
        {
            if (endRow < startRow)
            {
                int swap = startRow;
                startRow = endRow;
                endRow = swap;
            }

            if (endColumn < startColumn)
            {
                int swap = startColumn;
                startColumn = endColumn;
                endColumn = swap;
            }

            if (startRow > 0 && endRow > 0)
                GetRangeByRow(startRow, endRow);

            if (startColumn > 0 && endColumn > 0)
                GetRangeByColumn(startColumn, endColumn);
        }

        private void GetRangeByRow(int startRow, int endRow)
        {
            List<Row> rows = new List<Row>();
            while (_rowIterator.MoveNext())
            {
                int rowIndex = _rowIterator.Current.RowIndex + 1;
                if (rowIndex >= startRow && rowIndex <= endRow)
                {
                    rows.Add(_rowIterator.Current);
                }
                else if (rowIndex > endRow)
                    break;
                else
                    continue;
            }

            _rowIterator = rows.GetEnumerator();
        }

        private void GetRangeByColumn(int startColumn, int endColumn)
        {
            List<Row> rows = new List<Row>();
            while (_rowIterator.MoveNext())
            {
                var cells = _rowIterator.Current.Cells
                    .Where(c => c.ColumnIndex + 1 >= startColumn && c.ColumnIndex < endColumn).ToList();
                _rowIterator.Current.Cells.Clear();
                cells.ForEach(c => _rowIterator.Current.Cells.Add(c));
                rows.Add(_rowIterator.Current);
            }

            _rowIterator = rows.GetEnumerator();
        }

        private void GetSingleColumn(int rowIndex, int colIndex)
        {
            List<Row> rows = new List<Row>();
            List<Cell> cells = new List<Cell>();
            
            while (_rowIterator.MoveNext())
            {
                var row = _rowIterator.Current;//(Row)ExcelDataReaderExtensions.CloneObject(_rowIterator.Current);
                if (row.RowIndex == rowIndex - 1 || rowIndex == 0)
                {
                    cells.AddRange(row.Cells.Where(c => c.ColumnIndex == colIndex - 1).ToList());
                    _rowIterator.Current.Cells.Clear();
                    cells.ForEach(c => _rowIterator.Current.Cells.Add(c));
                    rows.Add(_rowIterator.Current);
                }

                cells.Clear();
            }

            _rowIterator = rows.GetEnumerator();
        }
        #endregion


        public bool GetBoolean(int i) => (bool)GetValue(i);

        public byte GetByte(int i) => (byte)GetValue(i);

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
            => throw new NotSupportedException();

        public char GetChar(int i) => (char)GetValue(i);

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
             => throw new NotSupportedException();

        public IDataReader GetData(int i) => throw new NotSupportedException();

        public string GetDataTypeName(int i) => throw new NotSupportedException();

        public DateTime GetDateTime(int i) => (DateTime)GetValue(i);

        public decimal GetDecimal(int i) => (decimal)GetValue(i);

        public double GetDouble(int i) => (double)GetValue(i);

        public Type GetFieldType(int i) => GetValue(i)?.GetType();

        public float GetFloat(int i) => (float)GetValue(i);

        public Guid GetGuid(int i) => (Guid)GetValue(i);

        public short GetInt16(int i) => (short)GetValue(i);

        public int GetInt32(int i) => (int)GetValue(i);

        public long GetInt64(int i) => (long)GetValue(i);

        public string GetName(int i) => throw new NotSupportedException();

        public int GetOrdinal(string name) => throw new NotSupportedException();

        /// <inheritdoc />
        public DataTable GetSchemaTable() => throw new NotSupportedException();

        public string GetString(int i) => (string)GetValue(i);

        public object GetValue(int i)
        {
            if (RowCells == null)
                throw new InvalidOperationException("No data exists for the row/column.");

            return RowCells[i]?.Value;
        }

        public int GetValues(object[] values) => throw new NotSupportedException();

        public bool IsDBNull(int i) => GetValue(i) == null;

        public string GetNumberFormatString(int i)
        {
            if (RowCells == null)
                throw new InvalidOperationException("No data exists for the row/column.");
            if (RowCells[i] == null)
                return null;
            if (RowCells[i].EffectiveStyle == null)
                return null;
            return Workbook.GetNumberFormatString(RowCells[i].EffectiveStyle.NumberFormatIndex)?.FormatString;
        }

        public int GetNumberFormatIndex(int i)
        {
            if (RowCells == null)
                throw new InvalidOperationException("No data exists for the row/column.");
            if (RowCells[i] == null)
                return -1;
            if (RowCells[i].EffectiveStyle == null)
                return -1;
            return RowCells[i].EffectiveStyle.NumberFormatIndex;
        }

        public double GetColumnWidth(int i)
        {
            if (i >= FieldCount)
            {
                throw new ArgumentException($"Column at index {i} does not exist.", nameof(i));
            }

            var columnWidths = _worksheetIterator?.Current?.ColumnWidths ?? null;
            double? retWidth = null;
            if (columnWidths != null)
            {
                foreach (var columnWidth in columnWidths)
                {
                    if (i >= columnWidth.Minimum && i <= columnWidth.Maximum)
                    {
                        retWidth = columnWidth.Hidden ? 0 : columnWidth.Width;
                        break;
                    }
                }
            }

            const double DefaultColumnWidth = 8.43D;

            return retWidth ?? DefaultColumnWidth;
        }

        public CellStyle GetCellStyle(int i)
        {
            if (RowCells == null)
                throw new InvalidOperationException("No data exists for the row/column.");

            var result = new CellStyle();
            if (RowCells[i] == null)
            {
                return result;
            }

            var effectiveStyle = RowCells[i].EffectiveStyle;
            if (effectiveStyle == null)
            {
                return result;
            }

            result.FontIndex = effectiveStyle.FontIndex;
            result.NumberFormatIndex = effectiveStyle.NumberFormatIndex;
            result.IndentLevel = effectiveStyle.IndentLevel;
            result.HorizontalAlignment = effectiveStyle.HorizontalAlignment;
            result.Hidden = effectiveStyle.Hidden;
            result.Locked = effectiveStyle.Locked;
            return result;
        }

        /// <inheritdoc />
        public void Reset()
        {
            _worksheetIterator?.Dispose();
            _rowIterator?.Dispose();

            _worksheetIterator = null;
            _rowIterator = null;

            ResetSheetData();

            if (Workbook != null)
            {
                _worksheetIterator = ReadWorksheetsWithCache().GetEnumerator(); // Workbook.ReadWorksheets().GetEnumerator();
                if (!_worksheetIterator.MoveNext())
                {
                    _worksheetIterator.Dispose();
                    _worksheetIterator = null;
                    return;
                }

                _rowIterator = _worksheetIterator.Current.ReadRows().GetEnumerator();
            }
        }

        public virtual void Close()
        {
            if (IsClosed)
                return;

            _worksheetIterator?.Dispose();
            _rowIterator?.Dispose();

            _worksheetIterator = null;
            _rowIterator = null;
            RowCells = null;
            IsClosed = true;
        }

        public bool NextResult()
        {
            if (_worksheetIterator == null)
            {
                return false;
            }

            ResetSheetData();

            _rowIterator?.Dispose();
            _rowIterator = null;

            if (!_worksheetIterator.MoveNext())
            {
                _worksheetIterator.Dispose();
                _worksheetIterator = null;
                return false;
            }

            _rowIterator = _worksheetIterator.Current.ReadRows().GetEnumerator();
            return true;
        }

        public bool Read()
        {
            if (_worksheetIterator == null || _rowIterator == null)
            {
                return false;
            }

            if (!_rowIterator.MoveNext())
            {
                _rowIterator.Dispose();
                _rowIterator = null;
                return false;
            }

            ReadCurrentRow();

            Depth++;
            return true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
                Close();
        }

        private IEnumerable<TWorksheet> ReadWorksheetsWithCache()
        {
            // Iterate TWorkbook.ReadWorksheets() only once and cache the 
            // worksheet instances, which are expensive to create. 
            if (_cachedWorksheets != null)
            {
                foreach (var worksheet in _cachedWorksheets)
                {
                    yield return worksheet;
                }

                if (_cachedWorksheetIterator == null)
                {
                    yield break;
                }
            }
            else
            {
                _cachedWorksheets = new List<TWorksheet>();
            }

            if (_cachedWorksheetIterator == null)
            {
                _cachedWorksheetIterator = Workbook.ReadWorksheets().GetEnumerator();
            }

            while (_cachedWorksheetIterator.MoveNext())
            {
                _cachedWorksheets.Add(_cachedWorksheetIterator.Current);
                yield return _cachedWorksheetIterator.Current;
            }

            _cachedWorksheetIterator.Dispose();
            _cachedWorksheetIterator = null;
        }

        private void ResetSheetData()
        {
            Depth = -1;
            RowCells = null;
        }

        private void ReadCurrentRow()
        {
            if (RowCells == null)
            {
                RowCells = new Cell[FieldCount];
            }

            Array.Clear(RowCells, 0, RowCells.Length);

            foreach (var cell in _rowIterator.Current.Cells)
            {
                if (cell.ColumnIndex < RowCells.Length)
                {
                    RowCells[cell.ColumnIndex] = cell;
                }
            }
        }
    }
}

