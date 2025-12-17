# 🪢 Blazonia

[![Nuget](https://img.shields.io/nuget/v/Blazonia)](https://www.nuget.org/packages/Blazonia/)

## 🤔 What is this?

Blazonia enables developers to use the **<a href="https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor">Blazor</a> syntax** to build **<a href="https://avaloniaui.net/">Avalonia</a> applications**. Compared to Avalonia’s original XAML syntax, Blazonia’s Blazor-based approach is more concise and straightforward, allowing you to develop pages using a **single file**. It is particularly suitable for **small to medium-sized** client applications.

✨ **Note**

- 🚫 After using Blazonia, there will be **no HTML code or WebView components** involved.
- 🤩 **Fully utilizes** native Avalonia controls

Thanks to Avalonia's cross-platform capabilities, Blazonia enables developers to rapidly build **beautiful**, **pixel-perfect** applications for 💻 **desktop**, 📱 **mobile**, and 🌐 **web** platforms.

## 🌰 A Simple Example

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

![Counter](/images/Blazonia.png "Counter")

## 🛫 Start

1. Install Blazonia
```powershell
dotnet add package Blazonia
```

2. Create a new Razor component
```razor
<!-- src/RazorPages/Hello.razor -->
<StackPanel>
    <TextBlock FontSize="30">Hello World</TextBlock>
</StackPanel>
```

3. Use Blazonia controls in axaml
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

## 📃 Razor Page Navigation?
1. Replace `BlazoniaControl` with `BlazoniaNavigationControl` control

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
2. Inject the INavigation object for page navigation
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
3. Use the @page attribute to mark the url
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

## ✂ NativeAot and Trimming
Blazonia supports NativeAot and trimming features, but you need to add the `TrimmerRootDescriptor` property to your project to let the trimmer preserve all metadata of the Razor components

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

## ⚠️ Notes
Please use Rider or VS Code to develop the project, as the code hints for razor files in Visual Studio 2022 may fail.

## 🗨 Communication

1. **Discord Server:** https://discord.gg/qtDKFgRAcg
2. **QQ Group:** 1063998889

![QQ Group](/images/QQGroup.png "QQ Group")
