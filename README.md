# Quit It

## Overview

Quit It is a web app that I built as a proof of concept for a smoking cessation app. This version currently uses a .NET 10 web API and related JSON files to persist data entered from the front-end built with Svelte and SvelteKit.

## Capstone Related Questions

#### What did I learn from this project?

I learned more about the C# language as well as Svelte and SvelteKit.

#### What did I learn from this course?

I think learned most about SOLID principles. DRY is a concept that I already understand and did my best to implement in this project.

#### What would I have done differently

There are plenty of items that could have been addressed differently. 

- My CRUD functionality for "triggers" is very simple. I would have liked to add more properties to this object such as a property for how intense the trigger is. 
- "Logs" are create and read only. The thought behind this was that it prevents the user from cheating. It may be wise to consider an accidental add that can be edited.
- There's still plenty of work for code clean-up that I'm not sure I'll have the time to accomplish before the deadline.
- I know that my limited knowledge of Svelte and SvelteKit prevents me from writing better code to handle requests. If I had time to explore it, I would have built a proxy api.

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

`cd` into the `Web-Api-Lab` directory and run the following:

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
cd quit-it-svelte
npm install
npm run dev
```


## Resources Used

All icons were sourced from [ionicons](https://ionic.io/ionicons) and [SVG Repo](https://www.svgrepo.com/). 

Special thanks to [LiminalElenyx](https://github.com/LiminalElenyx) for contributing to the [reasons-to-quit-smoking-api](https://github.com/dan-collins-dev/reasons-to-quit-smoking-api).