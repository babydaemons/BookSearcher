using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BookSearcherApp
{
    public enum DataType { CSV, TSV, Excel };

    public abstract partial class DataSaver : DataIO
    {
        protected abstract bool IncludeAmazonHeader { get; }

        #region Headers

        private static Dictionary<string, string> headers_JP = new Dictionary<string, string>();

        public static void InitHeaders()
        {
            if (headers_JP.Count > 0)
            {
                return;
            }

            headers_JP.Add("sku", "商品管理番号");
            headers_JP.Add("product-id", "商品コード(JANコード等)");
            headers_JP.Add("product-id-type", "商品コードのタイプ");
            headers_JP.Add("optional-payment-type-exclusion", "使用しない支払い方法");
            headers_JP.Add("merchant_shipping_group_name", " 配送パターン");
            headers_JP.Add("price", "販売価格");
            headers_JP.Add("standard-price-points-percent", "ポイントパーセント");
            headers_JP.Add("minimum-seller-allowed-price", "販売価格の下限設定");
            headers_JP.Add("maximum-seller-allowed-price", "販売価格の上限設定");
            headers_JP.Add("item-condition", "商品のコンディション");
            headers_JP.Add("quantity", "在庫数");
            headers_JP.Add("add-delete", "登録/削除");
            headers_JP.Add("will-ship-internationally", "海外配送");
            headers_JP.Add("item-note", "商品メモ");
            headers_JP.Add("product-tax-code", "商品タックスコード");
            headers_JP.Add("fulfillment-center-id", "フルフィルメントセンターID");
            headers_JP.Add("handling-time", "出荷作業日数");
            headers_JP.Add("batteries_required", "電池の有無");
            headers_JP.Add("are_batteries_included", "電池付属");
            headers_JP.Add("battery_cell_composition", "バッテリーセルタイプ");
            headers_JP.Add("battery_type", "電池のタイプ");
            headers_JP.Add("number_of_batteries", "付属バッテリ個数");
            headers_JP.Add("battery_weight", "電池の重量(グラム)");
            headers_JP.Add("number_of_lithium_ion_cells", "リチウムイオン電池単数");
            headers_JP.Add("number_of_lithium_metal_cells", "リチウムメタル電池単数");
            headers_JP.Add("lithium_battery_packaging", "リチウム電池パッケージ");
            headers_JP.Add("lithium_battery_energy_content", "リチウム電池エネルギー量");
            headers_JP.Add("lithium_battery_weight", "リチウム電池重量");
            headers_JP.Add("supplier_declared_dg_hz_regulation1", "この商品は、危険物に該当しますか？詳細については危険物確認ガイド{X}をご覧ください。1");
            headers_JP.Add("supplier_declared_dg_hz_regulation2", "この商品は、危険物に該当しますか？詳細については危険物確認ガイド{X}をご覧ください。2");
            headers_JP.Add("supplier_declared_dg_hz_regulation3", "この商品は、危険物に該当しますか？詳細については危険物確認ガイド{X}をご覧ください。3");
            headers_JP.Add("supplier_declared_dg_hz_regulation4", "この商品は、危険物に該当しますか？詳細については危険物確認ガイド{X}をご覧ください。4");
            headers_JP.Add("supplier_declared_dg_hz_regulation5", "この商品は、危険物に該当しますか？詳細については危険物確認ガイド{X}をご覧ください。5");
            headers_JP.Add("hazmat_united_nations_regulatory_id", "国連(UN)番号");
            headers_JP.Add("safety_data_sheet_url", "安全データシート(SDS) URL");
            headers_JP.Add("item_weight", "商品の重量");
            headers_JP.Add("item_volume", "体積");
            headers_JP.Add("flash_point", "引火点(°C)");
            headers_JP.Add("ghs_classification_class1", "分類／危険物ラベル(適用されるものをすべて選択)1");
            headers_JP.Add("ghs_classification_class2", "分類／危険物ラベル(適用されるものをすべて選択)2");
            headers_JP.Add("ghs_classification_class3", "分類／危険物ラベル(適用されるものをすべて選択)3");
            headers_JP.Add("item_weight_unit_of_measure", "商品の重量の単位");
            headers_JP.Add("item_volume_unit_of_measure", "商品の容量の単位");
            headers_JP.Add("lithium_battery_energy_content_unit_of_measure", "リチウム電池のエネルギー量測定単位");
            headers_JP.Add("lithium_battery_weight_unit_of_measure", "リチウム電池の重量の測定単位");
            headers_JP.Add("battery_weight_unit_of_measure", "リチウム電池の重量の測定単位");
        }

        string[] GetAmazonHeader(int length)
        {
            string[] amazonHeader = new string[length];
            amazonHeader[0] = "TemplateType=InventoryLoader";
            amazonHeader[1] = "Version=2020.0805";
            amazonHeader[2] = "この行はAmazonが使用しますので変更や削除しないでください。";
            return amazonHeader;
        }

        #endregion

        #region DataSaver

        private FileStream file;
        private StreamWriter writer;
        protected string path;
        private readonly DataType dataType;

        public DataSaver(DataGridView view, string path)
        {
            this.path = path;

            CheckParameterEntered(view);
            foreach (var title in Titles)
            {
                dataTable.Columns.Add(title, typeof(string));
            }

            var extension = Path.GetExtension(path).ToLower();
            if (extension == ".csv")
            {
                dataType = DataType.CSV;
            }
            else if (extension == ".txt")
            {
                dataType = DataType.TSV;
            }
            else if (extension == ".xlsx")
            {
                dataType = DataType.Excel;
            }
            else
            {
                throw new MyException("出力ファイル種別エラー", $"不正なデータ種別です：{extension}");
            }
            Open();
        }

        protected bool IsOpened()
        {
            if (dataType == DataType.Excel)
            {
                return package != null && file != null && file.CanWrite;
            }
            if (file != null)
            {
                return writer != null && file != null && file.CanWrite;
            }
            else
            {
                return writer != null && writer.BaseStream != null && writer.BaseStream.CanWrite;
            }
        }

        protected void Open()
        {
            if (IsOpened())
            {
                return;
            }

            try
            {
                file = new FileStream(path, FileMode.Create, FileAccess.Write);
                writer = dataType != DataType.Excel ?　new StreamWriter(file, Encoding.GetEncoding(932), 8 * 4096) : null;
                package = dataType == DataType.Excel ? new ExcelPackage(file) : null;
            }
            catch (Exception ex)
            {
                Close();
                throw new MyException("出力ファイル保存エラー", path, ex);
            }
        }

        protected override void Close()
        {
            if (IsOpened())
            {
                if (dataType == DataType.Excel)
                {
                    if (package != null)
                    {
                        package.Dispose();
                        package = null;
                    }
                }
                if (writer != null)
                {
                    writer.Close();
                    writer.Dispose();
                }
                if (file != null)
                {
                    file.Close();
                    file.Dispose();
                }
            }
            writer = null;
            file = null;

            try
            {
                var file = new FileInfo(path);
                if (file.Exists && file.Length == 0)
                {
                    file.Delete();
                }
            }
            catch (IOException)
            {
            }
        }

        public void Write(DataTable table)
        {
            if (dataType == DataType.CSV)
            {
                WriteCSV(table, IncludeAmazonHeader);
            }
            else if (dataType == DataType.TSV)
            {
                WriteTSV(table, IncludeAmazonHeader);
            }
            else if (dataType == DataType.Excel)
            {
                WriteExcel(table, IncludeAmazonHeader);
            }
        }

        #endregion

        #region CalcCost

        public abstract string[] Titles { get; }
        public int ColumnIndexSKU => 0;
        public abstract int ColumnIndexPrice { get; }
        public abstract int ColumnIndexISBN { get; }
        public abstract int ColumnIndexAutoPriceStopperLower { get; }
        public abstract int ColumnIndexAutoPriceStopperUpper { get; }

        protected DataTable dataTable = new DataTable();
        public DataTable DataTable => dataTable;
        private readonly Dictionary<string, string> settings = new Dictionary<string, string>();

        private static readonly SortedDictionary<int, double> costTable = new SortedDictionary<int, double>();

        private void CheckParameterEntered(DataGridView view)
        {
            var settingName = (string)view.Tag;
            foreach (DataGridViewRow row in view.Rows)
            {
                DataGridViewCellCollection cells = row.Cells;

                var keyJP = (string)cells[0].Value;
                var keyEN = (string)cells[1].Value;
                var value = (string)cells[2].Value;
                if (string.IsNullOrEmpty(value))
                {
                    throw new MyException($"「{settingName}」入力エラー", $"「{keyJP}／{keyEN}」が入力されていません。");
                }

                settings.Add(keyEN, value);
            }
        }

        public void Save(BackgroundWorker backgroundWorker, DataIOProgressBar progressBar)
        {
            ConvertTable();
            StartIO(backgroundWorker, progressBar);
            Write(dataTable);
            StopIO();
        }

        public void ConvertTable() => ConvertTable(BookSearcher.ResultTables, BookSearcher.ColumnIndexISBN, BookSearcher.ColumnIndexCost);

        public void ConvertTable(List<DataTable> resultTables, int columnIndexISBN, int columnIndexCost)
        {
            foreach (var resultTable in resultTables)
            {
                foreach (var i in Enumerable.Range(0, resultTable.Rows.Count))
                {
                    var row = dataTable.NewRow();
                    foreach (var key in settings.Keys)
                    {
                        row[key] = settings[key];
                    }

                    if (ColumnIndexSKU >= 0)
                    {
                        row[ColumnIndexSKU] = (string)resultTable.Rows[i][columnIndexISBN] + settings["sku"];
                    }
                    if (ColumnIndexISBN >= 0)
                    {
                        row[ColumnIndexISBN] = (string)resultTable.Rows[i][columnIndexISBN];
                    }
                    if (ColumnIndexPrice >= 0)
                    {
                        row[ColumnIndexPrice] = CalcRatedPrice(resultTable.Rows[i][columnIndexCost], 1.0);
                    }
                    if (ColumnIndexAutoPriceStopperLower >= 0)
                    {
                        row[ColumnIndexPrice] = CalcRatedPrice(resultTable.Rows[i][columnIndexCost], 0.8);
                    }
                    if (ColumnIndexAutoPriceStopperUpper >= 0)
                    {
                        row[ColumnIndexPrice] = CalcRatedPrice(resultTable.Rows[i][columnIndexCost], 0.8);
                    }
                    dataTable.Rows.Add(row);
                }
            }
        }

        private string CalcRatedPrice(object costValue, double ratio)
        {
            var costString = (string)costValue;
            if (!int.TryParse(costString.Replace(",", "").Replace("円", ""), out int cost))
            {
                cost = 1; // throw new Exception($"原価のデータの書式が不正です：{i + 1}行{columnIndexCost + 1}列：「{costString}」");
            }
            var price = (int)Math.Ceiling(CalcSellingPrice(cost) * ratio);
            return price.ToString();
        }
        public static void InitCostTable(DataTable table)
        {
            costTable.Clear();
            foreach (DataRow row in table.Rows)
            {
                var costLower = int.Parse(row[0].ToString());
                var costRatio = double.Parse(row[1].ToString());
                costTable.Add(costLower, costRatio);
            }
        }

        public static int CalcSellingPrice(int cost)
        {
            var costRatio = 0.0;
            foreach (var costLimit in costTable.Reverse())
            {
                if (cost > costLimit.Key)
                {
                    costRatio = costLimit.Value;
                    break;
                }
            }

            // ＜出力CSVパターン２＞
            // ・販売価格の計算式の中で550円の部分を計算式から削除いただきたく。
            double sellingPrice = (cost + 88 + 110 + 330 + (cost * 0.15)) * costRatio;
            return (int)(sellingPrice + 0.5);
        }

        #endregion
    }
}
