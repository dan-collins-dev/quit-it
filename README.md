# Quit It

## Overview

Quit It is a web app that I built as a proof of concept for a smoking cessation app. This version currently uses a .NET 10 web API and related JSON files to persist data entered from the front-end built with Svelte and SvelteKit.

## Capstone Related Questions

This section will be updated as needed until the deadline of April 10th at 12pm EST 

#### What did I learn from this project?

Will fill this out before deadline

#### What did I learn from this course?

Will fill this out before deadline

#### What would I have done differently

Will fill this out before deadline

## How To Run

### Required Tools to Run

| Tools                       |
| --------------------------- |
| .NET 10 SDK                 |
| VS Code                     |
| C# Dev Kit VSCode Extension |
| NodeJS                      |

### Verify that you have the tools needed

In GitBash, run the following commands to ensure that you have both the [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download) and [NodeJS](https://nodejs.org/en/download). If these commands do not output a version number, please install the respective tool.

#### .NET 10 SDK

```bash
dotnet --version
```

#### NodeJS

```bash
node -v
npm -v
```


### Running the Web API

Once you have verified that the .NET SDK is installed as well as NodeJS, open GitBash and `cd` into the directory of your choice to clone the project.

```bash
git clone https://github.com/dan-collins-dev/quit-it.git
```

`cd` into the `quit-it` directory and run the following:

```bash
dotnet clean
dotnet build
```

In your current terminal, run the following to start the web API:

```bash
dotnet run --project QuitIt.API/QuitIt.API.csproj
```

### Running the Svelte App

After starting the server, open a new terminal and navigate back to the root of the project and run the following commands to start the Svelte app.

```bash
cd QuitIt.Web
npm install
npm run dev
```