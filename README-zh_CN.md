# 🪢 Blazonia
[![Nuget](https://img.shields.io/nuget/v/Blazonia)](https://www.nuget.org/packages/Blazonia/)


[English](./Readme.md) | 中文
## 🤔 这是啥子？

Blazonia可以让开发者使用 **<a href="https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor">Blazor</a>的语法**来开发 **<a href="https://avaloniaui.net/">Avalonia</a>程序**。相比原版Avalonia的axmal语法， Blazonia使用的Blazor语法更加的简洁和简单，只需要**单个文件**即可完成页面的开发。适用于**中小型规模**的客户端程序。

✨ **请注意**
- 🚫 使用Blazonia后**不会有**任何的HTML代码以及Webview组件
- 🤩 **完全使用**原生Avalonia控件

得益于Avalonia跨平台的特性，Blazonia可以让开发者快速的编写出**漂亮**的**像素完美级**的 💻 **电脑, 📱 手机 和 🌐 网页 应用程序**


## 🌰 这是一个小例子


```razor
<StackPanel>
    <Label FontSize="30">You pressed @_count times </Label>
    <CheckBox @bind-IsChecked="_showButton">Button visible</CheckBox>
    @if (_showButton == true)
    {
        <Button OnClick="OnButtonClick">+1</Button>
    }
</StackPanel>

@code {

    int _count;
    
    bool? _showButton = true;
    
    void OnButtonClick() => _count++;
}
```

![Counter](https://raw.githubusercontent.com/Blazonia/Blazonia/refs/heads/main/images/Blazonia.png "Counter")

## 🛫 开始
### 新项目
1. 安装项目模板
```powershell
dotnet new install BlazoniaTemplate
```

2. 使用模板创建新项目
```powershell
dotnet new blazonia -o BlazoniaApp
```

### 在已有的项目中使用

1. 安装Blazonia
```powershell
dotnet add package Blazonia
```

1. 新建Razor组件
```razor
<!-- src/RazorPages/Hello.razor -->
<StackPanel>
    <TextBlock FontSize="30">Hello World</TextBlock>
</StackPanel>
```

1. 在axaml中使用Blazonia控件
```xaml
<UserControl 
            ...
			 xmlns:local="clr-namespace:Blazonia.Controls;assembly=Blazonia"
			 xmlns:pages="clr-namespace:YourProject.RazorPages"
             ...
             >
	<local:BlazoniaControl x:TypeArguments="pages:Hello"/>
</UserControl>
``` 

## 📃Razor页面切换?
1. 将`BlazoniaControl`更换为`BlazoniaNavigationControl`控件

```xaml
<UserControl 
            ...
			 xmlns:local="clr-namespace:Blazonia.Controls;assembly=Blazonia"
			 xmlns:pages="clr-namespace:YourProject.RazorPages"
             ...
             >
	<local:BlazoniaNavigationControl x:TypeArguments="pages:Page1"/>
</UserControl>
``` 
2. 注入INavigation对象，用于跳转页面
```razor
<!-- src/RazorPages/Page1.razor -->
@inject INavigation Navigation

<StackPanel>
    <TextBlock FontSize="30">Page 1</TextBlock>
    <Button OnClick="@OnButtonClick">Go to Page2</Button>
</StackPanel>

@code {
    async Task OnButtonClick()
    {
        await Navigation.NavigateToAsync("/page2", null);
    }
}
```
3. 使用page特性(attribute)标记url
```razor
<!-- src/RazorPages/Page2.razor -->
@page "/page2"
@inject INavigation Navigation

<StackPanel>
    <TextBlock FontSize="30">Page 2</TextBlock>
    <Button OnClick="@OnButtonClick">Back</Button>
</StackPanel>

@code {
    async Task OnButtonClick()
    {
        await Navigation.PopAsync();
    }
}
```





## ✂ NativeAot和裁剪
Blazonia支持NativeAot和裁剪功能，但是你需要为你的项目添加`TrimmerRootDescriptor`属性，让裁剪器保留Razor组件的所有元数据

```xml
<!--root.xml-->
<linker>
	<assembly fullname="YourProject">
		<namespace fullname="Razor Component NameSpace" preserve="all" />
	</assembly>
</linker>
```

```xml
<!-- your project -->
<Project Sdk="Microsoft.NET.Sdk">
     ...
	<ItemGroup>
		<TrimmerRootDescriptor Include="..\root.xml" />
	</ItemGroup>
</Project>
```

## ⚠️ 注意事项
请使用Rider或VS Code开发项目，Visual Studio 2022的razor文件代码提示可能会失效

## 🗨 交流

1. **Discord Server:** https://discord.gg/qtDKFgRAcg
2. **QQ群:** 1063998889

![QQ群](https://raw.githubusercontent.com/Blazonia/Blazonia/refs/heads/main/images/QQGroup.png "QQ群")

> 本项目基于多个上游仓库。详情请参见 [NOTICE](NOTICE)。
