﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GenMax.Database.EntityModel;
using GenMax.Database.Interface;
using GenMax.GlobalConst;
using GenMax.Log;
using GenMax.Util;
using GenMax.View;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Panuon.WPF.UI;
using System;
using System.IO;
using System.Windows;

namespace GenMax.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {
        #region Property
        [ObservableProperty]
        private string _username;
        [ObservableProperty]
        private string _password;
        [ObservableProperty]
        private bool _enabled;
        [ObservableProperty]
        private User _currentUser;
        #endregion

        private readonly ILog _log;

        private readonly IUserService _userService;

        public LoginViewModel(ILog log, IUserService userService)
        {
            _log = log;
            _userService = userService;

            string jsonPath = Environment.CurrentDirectory + @"\Configuration";
            string jsonName = @"user.json";
            string wholeName = Path.Combine(jsonPath, jsonName);

            #region json文件不存在就创建
            if (!Directory.Exists(jsonPath))
            {
                // 创建文件夹并设置文件夹的访问权限为可读可写
                Directory.CreateDirectory(jsonPath).Attributes = FileAttributes.Normal;
            }

            if (!File.Exists(wholeName))
            {
                // 创建文件
                User user = _userService.GetUserByName("Admin");
                JsonUtil.WriteJsonFile(wholeName, JsonConvert.SerializeObject(user));
            }
            #endregion


            string userstring = JsonUtil.ReadJsonFile(wholeName);

            CurrentUser = JsonConvert.DeserializeObject<User>(userstring);

            if (CurrentUser.Enabled)
            {
                Username = CurrentUser.Name;
                Password = CurrentUser.Password;
                Enabled = CurrentUser.Enabled;
            }
        }

        #region 登录
        [RelayCommand]
        public void SignIn()
        {

            User user = _userService.GetUserByName(Username);

            if (user != null && user.Password == Password)
            {
                #region 记住登录信息
                //将当前的配置序列化为json字符串
                CurrentUser.Enabled = Enabled;
                CurrentUser.Role = user.Role;
                CurrentUser.Name = Username;
                CurrentUser.Password = Password;
                var content = JsonConvert.SerializeObject(CurrentUser);
                JsonUtil.WriteJsonFile(Environment.CurrentDirectory + @"\Configuration\user.json", content);
                Const.User = CurrentUser;
                #endregion

                // 获取主屏幕的分辨率
                double screenWidth = SystemParameters.PrimaryScreenWidth;
                double screenHeight = SystemParameters.PrimaryScreenHeight;
                MainView mainView = App.Current._host.Services.GetRequiredService<MainView>();
                mainView.Width = screenWidth * 0.678;
                mainView.Height = screenHeight * 0.678;
                mainView.DataContext = App.Current._host.Services.GetRequiredService<MainViewModel>();


                /*mainView.Loaded += ((s, e) =>
                {
                    try
                    {
                        double screenscale = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / SystemParameters.PrimaryScreenWidth;

                        // 获取窗体中的所有控件
                        IEnumerable<FrameworkElement> controls = WPFUtil.GetChildControls(mainView);

                        foreach (FrameworkElement control in controls)
                        {
                            *//*// 排除不需要缩放的控件类型，例如 Label 等
                            if (!(control is Button) && !(control is TextBox) && !(control is ComboBox))
                            {
                                continue;
                            }*//*

                            // 将控件的宽度和高度缩放
                            control.Width /= screenscale;
                            control.Height /= screenscale;

                            // 如果是字体大小可以缩放的控件，也可以进行缩放             
                            if (control is Control controlWithFont)
                            {
                                controlWithFont.FontSize /= screenscale;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // 错误处理：在控制台输出错误信息
                        Console.WriteLine($"Error while scaling controls: {ex.Message}");
                    }
                });*/

                mainView!.Show();

                App.Current._host.Services.GetRequiredService<LoginView>().Close();

                _log.Debug($"此次登录的用户名：{Username}，密码：{Password}，登录时间：{DateTime.Now}");
            }
            else
            {
                MessageBoxX.Show(Application.Current.MainWindow, "用户名或密码错误！", "提示", MessageBoxButton.OK, MessageBoxIcon.Error, DefaultButton.YesOK, 5);
            }



        }
        #endregion
    }
}
