using ExcelDataReader;
using System.Data;
using System.Text;
using UrbanLadder.Utilities;

namespace UrbanLadder.Utilities
{
    internal class ExcelUtilities
    {
        public static List<ExcelData> ReadExcelData(string excelFilePath, string sheetname)
        {
            List<ExcelData> productDatalist = new List<ExcelData>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))

                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });
                    var datatable = result.Tables[sheetname];
                    if (datatable != null)
                    {
                        foreach (DataRow row in datatable.Rows)
                        {
                            ExcelData productData = new ExcelData
                            {

                                ProductName = GetValueOrDefault(row, "productname")
                            };
                            productDatalist.Add(productData);

                        }
                    }
                    else
                    {
                        Console.WriteLine($"sheet'{sheetname}' not found in the excel file");
                    }
                }
            }

            return productDatalist;

        }



        public static List<ExcelDataDetailsPage> ReadExcelDataDetails(string excelFilePath, string sheetname)
        {
            List<ExcelDataDetailsPage> productDatalist = new List<ExcelDataDetailsPage>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))

                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });
                    var datatable = result.Tables[sheetname];
                    if (datatable != null)
                    {
                        foreach (DataRow row in datatable.Rows)
                        {
                            ExcelDataDetailsPage productData = new ExcelDataDetailsPage
                            {
                                Email = GetValueOrDefault(row, "email"),
                                Pincode = GetValueOrDefault(row, "pincode"),
                                Address = GetValueOrDefault(row, "address"),
                                Firstname = GetValueOrDefault(row, "firstname"),
                                Lastname = GetValueOrDefault(row, "lastname"),
                                Mobilenumber = GetValueOrDefault(row, "mobilenumber")

                            };
                            productDatalist.Add(productData);

                        }
                    }
                    else
                    {
                        Console.WriteLine($"sheet'{sheetname}' not found in the excel file");
                    }
                }
            }

            return productDatalist;
        }
        //static string GetValueOrDefault(DataRow row, string columnName)
        //{
        //    Console.WriteLine(row + "" + columnName);
        //    return row.Table.Columns.Contains(columnName) ?
        //        row[columnName]?.ToString() : null;
        //}

        public static List<ExcelDataJob> ReadExcelDataJob(string excelFilePath, string sheetname)
        {
            List<ExcelDataJob> productDatalist = new List<ExcelDataJob>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))

                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });
                    var datatable = result.Tables[sheetname];
                    if (datatable != null)
                    {
                        foreach (DataRow row in datatable.Rows)
                        {
                            ExcelDataJob productData = new ExcelDataJob

                            {
                                Firstname = GetValueOrDefault(row, "firstname"),
                                Lastname = GetValueOrDefault(row, "lastname"),
                                Email = GetValueOrDefault(row, "email"),
                                Mobilenumber = GetValueOrDefault(row, "mobilenumber"),
                                CurrentCTC = GetValueOrDefault(row, "currentctc"),
                                ExpectedCTC = GetValueOrDefault(row, "expectedctc"),
                                Joining = GetValueOrDefault(row, "joining")

                            };
                            productDatalist.Add(productData);

                        }
                    }
                    else
                    {
                        Console.WriteLine($"sheet'{sheetname}' not found in the excel file");
                    }
                }
            }

            return productDatalist;
        }

        internal static List<ExcelDataJob> ReadExcelDataJob(object excelFilePath, string sheetName1)
        {
            throw new NotImplementedException();
        }

        static string GetValueOrDefault(DataRow row, string columnName)
        {
            Console.WriteLine(row + "" + columnName);
            return row.Table.Columns.Contains(columnName) ?
                row[columnName]?.ToString() : null;
        }
    }
}
