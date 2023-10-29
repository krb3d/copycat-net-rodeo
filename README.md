# Copycat .net Rodeo

The Textual Exchange Extravaganza

## Apps

- App1: Local Win App1, with input and output fields,
- App2: Web App2, localy hosted, with input and output fields,

## Workflow

- Text is entered in App1 input it is shown in App2 output
- Text is entered in App2 input it is shown in App1 output
- Optional: multiple instances of App1 -> single instance of App2

## Development environment

dotnet 7
Visual Studio + Visual Studio Code

## How to build

```cmd
dotnet publish ./src/WpfDesktopApp1 --output ./release/Desktop --configuration Release --self-contained 
dotnet publish ./src/BlazorWebApplication2/Server --output ./release/WebApp --configuration Release --self-contained
```

## How to run

Check `appsettings.json`` in both apps for settings
Default port 443: [https://localhost:443/](https://localhost:443/)
