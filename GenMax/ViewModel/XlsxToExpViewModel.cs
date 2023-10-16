using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Options;
using NPOI.SS.UserModel;
using Panuon.WPF.UI;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Shell;
using System.Windows;
using System;
using NPOI.XSSF.UserModel;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Linq;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;

namespace GenMax.ViewModel
{
public partial class XlsxToExpViewModel : ObservableObject
{
    [ObservableProperty] private string _excelPath = @"C:\Users\63214\Desktop\20220809_160644C15256.xlsx";
    [ObservableProperty] private string _expPath = @"C:\ProgramData\Virtue\Experiment\20220809_160644C.exp";
    [ObservableProperty] private string _newExpPath = @"C:\Users\63214\Desktop\newExp.exp";
    [ObservableProperty] private double _schedule = 0;

    public XlsxToExpViewModel()
    {

    }

    #region Excel
    [RelayCommand]
    public void OpenExcel()
    {
        Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
        if (openFileDialog.ShowDialog() == true)
        {
            ExcelPath = openFileDialog.FileName;
        }
    }

    [RelayCommand]
    public void OpenExp()
    {
        Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
        if (openFileDialog.ShowDialog() == true)
        {
            ExpPath = openFileDialog.FileName;
        }
    }

    [RelayCommand]
    public void Export()
    {
        //配置文件目录
        string dict = null;
        //IOUtil.Exists(dict);
        Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog()
        {
            Title = "请选择导出配置文件...",            //对话框标题
            Filter = "Exp Files(*.exp)|*.exp",    //文件格式过滤器
            FilterIndex = 1,                          //默认选中的过滤器
            FileName = "newfile",                      //默认文件名
            DefaultExt = "exp",                      //默认扩展名
            InitialDirectory = dict,                  //指定初始的目录
            OverwritePrompt = true,                   //文件已存在警告
            AddExtension = true,                      //若用户省略扩展名将自动添加扩展名
        };
        if (sfd.ShowDialog() == true)
        {
            NewExpPath = sfd.FileName;
        }
    }

    [RelayCommand]
    public void GenerateNewExpFile()
    {
        if (File.Exists(NewExpPath))
        {
            File.Delete(NewExpPath);
            Console.WriteLine("文件已删除。");
        }

        // 指定要读取的工作表名称
        List<string> listSheet = new List<string>() { "Raw Data", "Calibrated Data", "Amplification Data" };
        string json = File.ReadAllText(ExpPath);
        foreach (string sheetName in listSheet)
        {
            try
            {
                // 使用FileStream打开Excel文件
                using (FileStream fs = new FileStream(ExcelPath, FileMode.Open, FileAccess.ReadWrite))
                {
                    // 使用XSSFWorkbook打开.xlsx文件（如果是.xls文件，使用HSSFWorkbook）
                    IWorkbook workbook = new XSSFWorkbook(fs);

                    // 获取指定工作表
                    ISheet sheet = workbook.GetSheet(sheetName);

                    if (sheet != null)
                    {
                        List<string> newDataList = new List<string>();

                        // 获取指定sheet的内容并添加到list集合
                        // 遍历列
                        for (int columnIndex = 1; columnIndex < sheet.GetRow(0).LastCellNum; columnIndex++)
                        {
                            string data = "-1," + sheet.GetRow(0).GetCell(columnIndex) + ",";
                            //string data = "-1,";
                            // 遍历行
                            for (int row = 1; row <= sheet.LastRowNum; row++)
                            {
                                IRow currentRow = sheet.GetRow(row);

                                if (currentRow != null)
                                {
                                    ICell cell = currentRow.GetCell(columnIndex);

                                    if (cell != null)
                                    {
                                        // 获取单元格的值（假设它是文本）
                                        string cellValue = Convert.ToDouble(cell.ToString()).ToString("F3") + " ";
                                        data += cellValue;
                                    }
                                }
                            }
                            newDataList.Add(data);
                        }
                        // 使用正则表达式查找目标 JSON 结构
                        string pattern = $@"\{{[^{{}}]*""Name"":\s*""{sheetName}""[^{{}}]*\}}";
                        System.Text.RegularExpressions.Match match = Regex.Match(json, pattern, RegexOptions.Singleline);
                        if (match.Success)
                        {
                            // 获取匹配的 JSON 结构
                            string jsonStructure = match.Value;

                            // 解析 JSON 数据
                            JObject jObject = JObject.Parse(jsonStructure);

                            // 查找 "DataList" 数组并替换内容
                            JArray dataList = (JArray)jObject["DataList"];

                            // 替换 "DataList" 的内容
                            dataList.ReplaceAll(newDataList.Select(item => new JValue(item)));

                            // 更新 JSON 结构
                            string updatedJsonStructure = jObject.ToString(Formatting.Indented);

                            // 替换原始文本中的 JSON 结构
                            json = Regex.Replace(json, pattern, updatedJsonStructure);
                        }
                        else
                        {
                            Console.WriteLine("未找到目标结构.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("工作表 " + sheetName + " 不存在.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("发生错误: " + ex.Message);
            }
        }
        // 保存更新后的文本回文件
        File.WriteAllText(NewExpPath, json);
        MessageBoxX.Show(Application.Current.MainWindow, "新文件已生成！", "提示", MessageBoxButton.OK, MessageBoxIcon.Success, DefaultButton.YesOK, 5);
    }
    #endregion
}
}
