# WinForms Theme Manager

A comprehensive theme manager component for WinForms applications that allows you to easily manage and apply themes across your entire application.

## Features

- **Main Color**: Primary color used for buttons, links, and accents
- **Background Color**: Background color for forms and panels
- **5 Accent Colors**: Additional color options for different UI elements
- **Font Management**: Consistent font application across all controls
- **Automatic Control Styling**: Automatically applies appropriate styles to different control types
- **Singleton Pattern**: Easy access to the theme manager from anywhere in your application
- **Real-time Theme Switching**: Change themes on-the-fly without restarting the application

## Components

### ThemeColor Class
Represents a complete theme with the following properties:
- `Primary`: Main theme color
- `Background`: Background color
- `Accent1-5`: 5 accent colors for different UI elements
- `Font`: Default font for all controls

### ThemeManager Class
Singleton class that manages themes across your application:
- `Instance`: Singleton access to the theme manager
- `CurrentTheme`: Get or set the current theme
- `RegisterControl()`: Register a control to be managed by the theme manager
- `ApplyThemeToControl()`: Apply the current theme to a specific control
- `UnregisterControl()`: Remove a control from theme management

## Usage

### 1. Register Controls
First, register your forms and controls with the theme manager:

```csharp
ThemeManager.Instance.RegisterControl(this); // For forms
ThemeManager.Instance.RegisterControl(someControl); // For other controls
```

### 2. Apply a Custom Theme
Create and apply a custom theme:

```csharp
var customTheme = new ThemeColor
{
    Primary = Color.FromArgb(255, 100, 100), // Red
    Background = Color.FromArgb(40, 40, 40), // Dark gray
    Accent1 = Color.FromArgb(100, 255, 100), // Green
    Accent2 = Color.FromArgb(100, 100, 255), // Blue
    Accent3 = Color.FromArgb(255, 255, 100), // Yellow
    Accent4 = Color.FromArgb(255, 100, 255), // Magenta
    Accent5 = Color.FromArgb(100, 255, 255), // Cyan
    Font = new Font("Arial", 10F)
};

ThemeManager.Instance.CurrentTheme = customTheme;
```

### 3. Supported Controls
The theme manager automatically handles styling for:
- Forms
- Buttons
- TextBoxes
- Labels
- Panels
- ComboBoxes
- ListBoxes
- DataGridViews

## Example

The included `SampleForm.cs` demonstrates how to use the theme manager with various control types and includes buttons to switch between different themes at runtime.

## Installation

1. Add the `ThemeManager.cs` file to your project
2. Use `using ThemeManager;` in files where you want to use the theme manager
3. Register your forms and controls with the theme manager
4. Customize and apply themes as needed

## Extending

The theme manager is designed to be easily extensible. You can add support for additional control types by modifying the `ApplyThemeToControl` method in the `ThemeManager` class to include switch cases for new control types.